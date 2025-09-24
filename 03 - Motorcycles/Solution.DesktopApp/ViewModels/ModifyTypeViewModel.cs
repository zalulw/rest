using Solution.Database.Entities;
using Solution.Database.Migrations;

namespace Solution.DesktopApp.ViewModels;

public partial class ModifyTypeViewModel(AppDbContext dbcontext) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<TypeModel> types = new();

    [ObservableProperty]
    private TypeModel selectedType;

    public IAsyncRelayCommand AddTypeCommand => new AsyncRelayCommand(OnAddTypeAsync);
    public IAsyncRelayCommand RemoveTypeCommand => new AsyncRelayCommand(OnRemoveTypeAsync);

    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);

    private async Task OnAppearingAsync()
    {
        await LoadTypesAsync();
    }

    private async Task LoadTypesAsync()
    {
        var list = await dbcontext.Types.AsNoTracking()
            .OrderBy(t => t.Name)
            .Select(t => new TypeModel(t))
            .ToListAsync();
        Types = new ObservableCollection<TypeModel>(list);
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