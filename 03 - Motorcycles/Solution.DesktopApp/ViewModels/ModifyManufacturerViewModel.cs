using Solution.Database.Entities;
using Solution.Database.Migrations;

namespace Solution.DesktopApp.ViewModels;

public partial class ModifyManufacturerViewModel(AppDbContext dbcontext) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ManufacturerModel> manufacturers = new();


    [ObservableProperty]
    private ManufacturerModel selectedManufacturer;


    public IAsyncRelayCommand AddManufacturerCommand => new AsyncRelayCommand(OnAddManufacturerAsync);
    public IAsyncRelayCommand RemoveManufacturerCommand => new AsyncRelayCommand(OnRemoveManufacturerAsync);

    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);

    private async Task OnAppearingAsync()
    {
        await LoadManufacturersAsync();
    }

    private async Task LoadManufacturersAsync()
    {
        var list = await dbcontext.Manufacturers.AsNoTracking()
            .OrderBy(m => m.Name)
            .Select(m => new ManufacturerModel(m))
            .ToListAsync();
        Manufacturers = new ObservableCollection<ManufacturerModel>(list);
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

}