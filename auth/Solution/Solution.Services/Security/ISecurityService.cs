namespace Solution.Services.Security;

public interface ISecurityService
{
    Task<ErrorOr<TokenResponseModel>> LoginAsync(LoginRequestModel loginRequestModel);

    Task<ErrorOr<Success>> RegisterAsync(RegisterRequestModel registerRequestModel);
}
