using FluentValidation;

namespace Solution.Services.Validators;

public abstract class BaseValidator<T>(IHttpContextAccessor httpContextAccessor) : AbstractValidator<T> where T : class
{
    private string requestMethod = httpContextAccessor?.HttpContext?.Request?.Method;

    protected bool IsPut => requestMethod is not null && HttpMethods.IsPut(requestMethod);
}
