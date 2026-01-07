

namespace Bills_Solution.ViewModels;

public partial class CreateOrEditBillViewModel(
    AppDbContext dbContext,
    IBillService billService) : BillModel, IQueryAttributable
{
    #region Life Cycle
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    #region validation
    public ICommand ValidateCommand => new Command<string>(OnValidateAsync);
    #endregion

    #region event command
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);
    #endregion

    private BillValidation validator = new BillValidation();

    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();

    private delegate Task ButtonActionDelagate();
    private ButtonActionDelagate asyncButtonAction;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private IList<BillItemModel> items = [];

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        await Task.Run(LoadItemsAsync);

        bool hasValue = query.TryGetValue("Bill", out object result);
        
        if (!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            title = "Add new bill";
            return;
        }

        BillModel bill = result as BillModel;

        this.Id = bill.Id;
        this.AccountNumber = bill.AccountNumber;
        this.InvoiceDate = bill.InvoiceDate;
        this.items = new List<BillItemModel>();

        asyncButtonAction = OnUpdateAsync;
        title = "Update Bill";
    }

    private async Task OnAppearingAsync()
    {
    }

    private async Task OnDisappearingAsync()
    {
    }

    private async Task OnSubmitAsync() => await asyncButtonAction();

    private async Task OnSaveAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        var result = await billService.CreateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Bill saved";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            ClearForm();
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task OnUpdateAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        var result = await billService.UpdateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Bill updated";
        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task LoadItemsAsync()
    {
        Items = await dbContext.BillItems.AsNoTracking()
                                         .OrderBy(x => x.Id)
                                         .Select(x => new BillItemModel(x))
                                         .ToListAsync();
    }

    private void ClearForm()
    {
        this.items = null;
        this.AccountNumber = null;
        this.InvoiceDate = DateTime.Today;
        this.Items = null;
    }

    private async void OnValidateAsync(string propertyName)
    {
        var result = await validator.ValidateAsync(this, options => options.IncludeProperties(propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(e => e.PropertyName == propertyName));
        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == BillValidation.GlobalProperty));

        ValidationResult.Errors.AddRange(result.Errors);

        OnPropertyChanged(nameof(ValidationResult));
    }
}
