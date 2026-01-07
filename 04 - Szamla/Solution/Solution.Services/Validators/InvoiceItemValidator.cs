using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Solution.Services.Validators
{
    public class InvoiceItemValidator: BaseValidator<InvoiceItemModel>
    {
        public static string AccountNumberProperty => nameof(InvoiceItemModel.Accountnumber);
        public static string AppelationProperty => nameof(InvoiceItemModel.Appelation);
        public static string UnitPriceProperty => nameof(InvoiceItemModel.Unitprice);
        public static string UnitQuantityProperty => nameof(InvoiceItemModel.Unitquantity);
        public static string GlobalProperty => "Global";

        public InvoiceItemValidator(IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            if(IsPut)
            {
                RuleFor(i => i.Id).NotEmpty()
                                  .WithMessage("Id is required");
            }

            RuleFor(i => i.Accountnumber)
                    .NotEmpty()
                    .WithMessage("Account number is required")
                    .Length(16, 24) 
                    .WithMessage("Account number must be between 16 and 24 characters");

            RuleFor(i => i.Appelation).NotEmpty()
                                      .WithMessage("Appelation is required")
                                      .MaximumLength(150);

            RuleFor(i => i.Unitprice).GreaterThan(0)
                                     .WithMessage("Unit price must be greater than zero");

            RuleFor(i => i.Unitquantity).GreaterThan(0)
                                        .WithMessage("Unit quantity must be greater than zero");
        }
    }
}
