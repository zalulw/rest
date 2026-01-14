using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Solution.Services.User;
using ErrorOr;

namespace Solution.WebAPI.Controllers;

[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [Route("api/users")]
    [Authorize]
    public async Task<IActionResult> GetUsersAsync()
    {
        var result = await userService.GetAllUsers();
        return result.Match(
            users => Ok(users),
            errors => errors.ToProblemResult()
        );
    }

}
