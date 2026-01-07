namespace Solution.Validations;

public class BillValidation : AbstractValidator<BillModel>
{
    public static string AccountNumberProperty => nameof(BillModel.AccountNumber);
    public static string InvoiceDateProperty => nameof(BillModel.InvoiceDate);
    public static string ItemDesignationProperty => nameof(BillItemModel.Designation);
    public static string ItemUnitPriceProperty => nameof(BillItemModel.UnitPrice);
    public static string ItemAmountProperty => nameof(BillItemModel.Amount);

    public static string GlobalProperty => "Global";    

    public BillValidation()
    {
        RuleFor(x => x.AccountNumber)
            .NotEmpty().WithMessage("Account Number is required.")
            .MaximumLength(20).WithMessage("Account Number must not exceed 20 characters.");
        RuleFor(x => x.InvoiceDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Invoice Date cannot be in the future.");
    }
}
