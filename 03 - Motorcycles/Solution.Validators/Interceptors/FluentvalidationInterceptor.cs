namespace Solution.Validators.Interceptors;

public class FluentvalidationInterceptor : IValidatorInterceptor
{
    public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
    {
        var validationErrors = new List<ValidationFailure>();

        if(!result.IsValid)
        {
            var errors = result.Errors.GroupBy(e => e.PropertyName).ToList();

            foreach(var error in errors)
            {
                var firstError = error.First();
                validationErrors.Add(new ValidationFailure(firstError.PropertyName, firstError.ErrorMessage));
            }
        }

        return new ValidationResult(validationErrors);
    }

    public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
    {
        return commonContext;
    }
}
