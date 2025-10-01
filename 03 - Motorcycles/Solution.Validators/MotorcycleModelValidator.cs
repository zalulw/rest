using Microsoft.AspNetCore.Http;

namespace Solution.Validators;

public class MotorcycleModelValidator : BaseValidator<MotorcycleModel>
{
    public static string ModelProperty => nameof(MotorcycleModel.Model);

    public static string CubicProperty => nameof(MotorcycleModel.Cubic);

    public static string ManufacturerProperty => nameof(MotorcycleModel.Manufacturer);  

    public static string TypeProperty => nameof(MotorcycleModel.Type);

    public static string NumberOfCylindersProperty => nameof(MotorcycleModel.NumberOfCylinders);

    public static string ReleaseYearProperty => nameof(MotorcycleModel.ReleaseYear);

    public static string GlobalProperty => "Global";

    public MotorcycleModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            //validalni hogy az ID letezo
        }

        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required.");

        RuleFor(x => x.Cubic).NotNull().WithMessage("Cubic is required")
                             .GreaterThan(0).WithMessage("Cubic must be greater than 0.");

        RuleFor(x => x.Manufacturer).NotNull().WithMessage("Manufacturer is required.");
        RuleFor(x => x.Manufacturer.Id).GreaterThan(0).WithMessage("Manufacturer ID must be greater than 0.");
        //validalni hogy a gyarto id letezik az adatbazisban

        RuleFor(x => x.Type).NotNull().WithMessage("Type is required.");
        RuleFor(x => x.Type.Id).GreaterThan(0).WithMessage("Type ID must be greater than 0.");
        //validalni hogy a tpius ID letezik az adatbazisban

        RuleFor(x => x.NumberOfCylinders).NotNull().WithMessage("Number of cylinders is required.")
                                         .GreaterThan(0).WithMessage("Number of cylinders must be greater than 0.");

        RuleFor(x => x.ReleaseYear).NotNull().WithMessage("Release year is required.")
                                   .InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Release year must be between 1900 and {DateTime.Now.Year}.");
    }
}
