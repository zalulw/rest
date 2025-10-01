namespace Solution.DesktopApp.Views;

public partial class CreateManufacturerView : ContentPage
{
    public CreateManufacturerViewModel ViewModel => this.BindingContext as CreateManufacturerViewModel;

    public static string Name => nameof(CreateManufacturerView);
    public CreateManufacturerView(CreateManufacturerViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();
    }
}