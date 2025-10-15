using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DekstopApp.ViewModels
{
    [ObservableObject]
    public partial class OpListViewModel(IOpService opService)
    {
        public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
        public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);

        public ICommand PreviousPageCommand { get; private set; }
        public ICommand NextPageCommand { get; private set; }

        public IAsyncRelayCommand DeleteCommand => new AsyncRelayCommand<string>((id) => OnDeleteAsync(id));

        [ObservableProperty]
        private ObservableCollection<OpModel> ops;

        private int page = 1;
        private bool isLoading = false;
        private bool hasNextPage = false;
        private int numberOfOpsInDb = 0;

        private async Task OnAppearingAsync()
        {
            PreviousPageCommand = new Command(async () => await OnPreviousPageAsync(), () => page > 1 && !isLoading);
            NextPageCommand = new Command(async () => await OnNextPageAsync(), () => !isLoading && hasNextPage);

            await LoadOpsAsync();
        }

        private async Task OnDisappearingAsync()
        { }

        private async Task OnPreviousPageAsync()
        {
            if (isLoading) return;

            page = page <= 1 ? 1 : --page;
            await LoadOpsAsync();
        }

        private async Task OnNextPageAsync()
        {
            if (isLoading) return;

            page++;
            await LoadOpsAsync();
        }

        private async Task LoadOpsAsync()
        {
            isLoading = true;

            var result = await opService.GetPagedAsync(page);

            if (result.IsError)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "ops not loaded!", "OK");
                return;
            }

            ops = new ObservableCollection<OpModel>(result.Value.Items);
            numberOfOpsInDb = result.Value.Count;

            hasNextPage = numberOfOpsInDb - (page * 10) > 0;
            isLoading = false;

            ((Command)PreviousPageCommand).ChangeCanExecute();
            ((Command)NextPageCommand).ChangeCanExecute();
        }

        private async Task OnDeleteAsync(string? id)
        {
            var result = await opService.DeleteAsync(id);

            var message = result.IsError ? result.FirstError.Description : "Motorcycle deleted.";
            var title = result.IsError ? "Error" : "Information";

            if (!result.IsError)
            {
                var op = ops.SingleOrDefault(x => x.Id == id);
                ops.Remove(op);

                if (ops.Count == 0)
                {
                    await LoadOpsAsync();
                }
            }

            await Application.Current.MainPage.DisplayAlert(title, message, "OK");
        }
    }
}
