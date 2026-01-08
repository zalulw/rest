using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Solution.Domain.Database.Entities;
using Solution.Domain.Models.Settings;

namespace Solution.Services.Security;

public class SecurityService(UserManager<UserEntity> userManager, IOptions<JWTSettingsModel> settings) : ISecurityService
{
public Task<ErrorOr<TokenResponseModel>> LoginAsync(LoginRequestModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Success>> RegisterAsync(RegisterRequestModel model)
    {
        var result = await userManager.CreateAsync(new UserEntity
        {
            Email = model.Email,
            EmailConfirmed = true,
            FullName = $"{model.FirstName} {model.LastName}",
            PhoneNumber = model.PhoneNumber,
            PhoneNumberConfirmed = true,
            UserName = $"{model.FirstName}.{model.LastName}"
        }, model.Password);
    }
}
