namespace Validators
{
    public class OpModelValidator: BaseValidator<OpModel>
    {
        public static string NameProperty => nameof(OpModel.name);

        public OpModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}
