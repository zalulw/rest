namespace Solution.DesktopApp.Views;

public partial class ModifyManufacturerView : ContentPage
{
    public ModifyManufacturerViewModel ViewModel => BindingContext as ModifyManufacturerViewModel;

    public static string Name => nameof(ModifyManufacturerView);

    public ModifyManufacturerView(ModifyManufacturerViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}