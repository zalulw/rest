namespace Solution.DesktopApp.Views;

public partial class ModifyTypeView : ContentPage
{
    public ModifyTypeViewModel ViewModel => BindingContext as ModifyTypeViewModel;

    public static string Name => nameof(ModifyTypeView);

    public ModifyTypeView(ModifyManufacturerViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
} 