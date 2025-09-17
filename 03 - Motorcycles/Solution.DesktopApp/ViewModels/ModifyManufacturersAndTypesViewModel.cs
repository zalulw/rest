using Solution.Database.Entities;

namespace Solution.DesktopApp.ViewModels;

public partial class ModifyManufacturersAndTypesViewModel(AppDbContext dbcontext) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ManufacturerModel> manufacturers = new();

    [ObservableProperty]
    private ObservableCollection<TypeModel> types = new();

    [ObservableProperty]
    private ManufacturerModel selectedManufacturer;

    [ObservableProperty]
    private TypeModel selectedType;

    public IAsyncRelayCommand AddManufacturerCommand => new AsyncRelayCommand(OnAddManufacturerAsync);
    public IAsyncRelayCommand RemoveManufacturerCommand => new AsyncRelayCommand(OnRemoveManufacturerAsync);

    public IAsyncRelayCommand AddTypeCommand => new AsyncRelayCommand(OnAddTypeAsync);
    public IAsyncRelayCommand RemoveTypeCommand => new AsyncRelayCommand(OnRemoveTypeAsync);

    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);

    private async Task OnAppearingAsync()
    {
        await LoadManufacturersAsync();
        await LoadTypesAsync();
    }

    private async Task LoadManufacturersAsync()
    {
        var list = await dbcontext.Manufacturers.AsNoTracking()
            .OrderBy(m => m.Name)
            .Select(m => new ManufacturerModel(m))
            .ToListAsync();
        Manufacturers = new ObservableCollection<ManufacturerModel>(list);
    }

    private async Task LoadTypesAsync()
    {
        var list = await dbcontext.Types.AsNoTracking()
            .OrderBy(t => t.Name)
            .Select(t => new TypeModel(t))
            .ToListAsync();
        Types = new ObservableCollection<TypeModel>(list);
    }

    private async Task OnAddManufacturerAsync()
    {
        string name = await Application.Current.MainPage.DisplayPromptAsync("Add Manufacturer", "Enter Manufacturer Name:");

        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        var entity = new ManufacturerEntity { Name = name };
        dbcontext.Manufacturers.Add(entity);
        await dbcontext.SaveChangesAsync();

        Manufacturers.Add(new ManufacturerModel(entity));
    }

    private async Task OnRemoveManufacturerAsync()
    {
        if (selectedManufacturer is null)
        {
            return;
        }

        var confirm = await Application.Current.MainPage.DisplayAlert("Remove Manufacturer", $"Remove '{selectedManufacturer.Name}'?", "Yes", "No");
        if (!confirm)
        {
            return;
        }

        var entity = await dbcontext.Manufacturers.FindAsync(selectedManufacturer.Id);
        if (entity is null)
        {
            return;
        }

        dbcontext.Manufacturers.Remove(entity);
        await dbcontext.SaveChangesAsync();

        Manufacturers.Remove(selectedManufacturer);
        selectedManufacturer = null;
    }

    private async Task OnAddTypeAsync()
    {
        string name = await Application.Current.MainPage.DisplayPromptAsync("Add Type", "Enter Type Name:");
        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        var entity = new MotorcycleTypeEntity { Name = name };
        dbcontext.Types.Add(entity);
        await dbcontext.SaveChangesAsync();

        Types.Add(new TypeModel(entity));
    }

    private async Task OnRemoveTypeAsync()
    {
        if (SelectedType is null)
        {
            return;
        }

        var confirm = await Application.Current.MainPage.DisplayAlert("Remove Type", $"Remove '{SelectedType.Name}'?", "Yes", "No");
        if (!confirm)
        {
            return;
        }

        var entity = await dbcontext.Types.FindAsync(SelectedType.Id);
        if (entity is null)
        {
            return;
        }

        dbcontext.Types.Remove(entity);
        await dbcontext.SaveChangesAsync();
    }
}
