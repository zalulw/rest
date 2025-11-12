using FluentValidation;
using Microsoft.AspNetCore.Http;
using Solution.Services.Account.Model;

namespace Solution.Services.Validators
{
    public class AccountValidator : BaseValidator<AccountModel>
    {
        public static string AccountNumberProperty => nameof(AccountModel.Accountnumber);
        public static string InvoiceDateProperty => nameof(AccountModel.Invoicedate);
        public AccountValidator(IHttpContextAccessor httpContextAccessor = null) : base(httpContextAccessor)
        {
            if(IsPut)
            {
                RuleFor(a => a.Accountnumber).NotEmpty()
                                          .WithMessage("Account number is required for update operations");
            }

            RuleFor(a => a.Invoicedate).NotEmpty()
                                      .WithMessage("Invoice date is required");
        }
    }
}
