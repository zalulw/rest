using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Solution.Database;
using Solution.Services.InvoiceItem.Interfaces;
using Solution.Services.InvoiceItem.Model;
using Solution.Services.Validators;
using System.Windows.Input;

namespace Solution.DekstopApp.ViewModels
{
    public partial class AddBillViewModel(AppDbContext dbContext, IInvoiceItemService service) : InvoiceItemModel
    {
        public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);
        public ICommand ValidateCommand => new Command<string>(OnValidateAsync);

        private InvoiceItemValidator validator => new InvoiceItemValidator(null);
        [ObservableProperty]
        private ValidationResult validationResult = new ValidationResult();

        private delegate Task ButtonActionDelegate();
        private ButtonActionDelegate asyncButtonAction;

        [ObservableProperty]
        private string title;

        private async void OnValidateAsync(string propertyName)
        {
           /* var result = await validator.ValidateAsync(this, options => options.IncludeProperties(propertyName));

            ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == propertyName));
            ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == InvoiceItemValidator.GlobalProperty));

            ValidationResult.Errors.AddRange(result.Errors);

            OnPropertyChanged(nameof(propertyName));*/
        }

        private void ClearForm()
        {
            this.Title = null;
        }

        private async Task OnSubmitAsync() => await asyncButtonAction();

        private async Task OnUpdateAsync()
        {
            this.ValidationResult = await validator.ValidateAsync(this);

            if (!ValidationResult.IsValid)
            {
                return;
            }

            var result = await service.UpdateAsync(this);

            var message = result.IsError ? result.FirstError.Description : "Bill updated.";
            var title = result.IsError ? "Error" : "Information";

            await Application.Current.MainPage.DisplayAlert(title, message, "OK");
        }

        private async Task OnSaveAsync()
        {
            this.ValidationResult = await validator.ValidateAsync(this);

            if (!ValidationResult.IsValid)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Save failed", "Ok");
                return;
            }

            var result = await service.CreateAsync(this);
            var message = result.IsError ? result.FirstError.Description : "Type saved.";
            var title = result.IsError ? "Error" : "Information";

            if (!result.IsError)
            {
                ClearForm();
            }

            await Application.Current.MainPage.DisplayAlert(title, message, "OK");
        }


    }
}
