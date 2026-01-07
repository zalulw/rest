namespace Bills_Solution.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);
    public IAsyncRelayCommand AddNewBillCommand => new AsyncRelayCommand(OnAddNewBillAsync);
    public IAsyncRelayCommand ListAllBillsCommand => new AsyncRelayCommand(OnListAllBillsAsync);

    private async Task OnExitAsync() => Application.Current.Quit();

    private async Task OnAddNewBillAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditBillViewModel.Name);
    }

    private async Task OnListAllBillsAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(BillListViewModel.Name);
    }
}
