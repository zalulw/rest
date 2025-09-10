namespace Solution.Validators;

public class MotorcycleModelValidator : AbstractValidator<MotorcycleModel>
{
    public static string ModelProperty => nameof(MotorcycleModel.Model);
    public static string CubicProperty => nameof(MotorcycleModel.Cubic);
    public static string ManufacturerProperty => nameof(MotorcycleModel.Manufacturer);
    public static string TypeProperty => nameof(MotorcycleModel.Type);
    public static string NumberOfCylindersProperty => nameof(MotorcycleModel.NumberOfCylinders);
    public static string ReleaseYearProperty => nameof(MotorcycleModel.ReleaseYear);
    public static string GlobalProperty => "Global";




    public MotorcycleModelValidator()
    {
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required.");
        RuleFor(x => x.Cubic).GreaterThan(0).WithMessage("Cubic must be greater than 0.");
        RuleFor(x => x.Manufacturer).NotNull().WithMessage("Manufacturer is required.");
        RuleFor(x => x.Type).NotNull().WithMessage("Type is required.");
        RuleFor(x => x.NumberOfCylinders).GreaterThan(0).WithMessage("Number of cylinders must be greater than 0.");
        RuleFor(x => x.ReleaseYear).InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Release year must be between 1900 and {DateTime.Now.Year}.");
    }
}
