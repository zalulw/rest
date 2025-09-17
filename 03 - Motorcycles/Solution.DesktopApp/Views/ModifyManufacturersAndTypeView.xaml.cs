namespace Solution.DesktopApp.Views;

public partial class ModifyManufacturersAndTypesView : ContentPage
{
    public ModifyManufacturersAndTypesViewModel ViewModel => BindingContext as ModifyManufacturersAndTypesViewModel;

    public static string Name => nameof(ModifyManufacturersAndTypesView);

    public ModifyManufacturersAndTypesView(ModifyManufacturersAndTypesViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}