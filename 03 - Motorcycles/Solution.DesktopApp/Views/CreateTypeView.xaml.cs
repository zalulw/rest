namespace Solution.DesktopApp.Views;

public partial class CreateTypeView : ContentPage
{
	public CreateTypeViewModel ViewModel => this.BindingContext as CreateTypeViewModel;
	public static string Name => nameof(CreateTypeViewModel);
	public CreateTypeView(CreateTypeViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}