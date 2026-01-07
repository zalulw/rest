using ErrorOr;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Solution.Api.Controllers;
using Solution.Services;
using Solution.Services.Account.Interfaces;
using Solution.Services.Account.Model;
using System.ComponentModel.DataAnnotations;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Solution.Api.Controllers;

public class BillController(IAccountService accountService) :BaseController
{
    //ALL
    [HttpGet]
    [Route("api/bills")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await accountService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //BY ID
    [HttpGet]
    [Route("api/bills/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] string id)
    {
        var result = await accountService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //PAGED
    [HttpGet]
    [Route("api/bills/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute] int page = 0)
    {
        var result = await accountService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //CREATE
    [HttpPost]
    [Route("api/bills/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] AccountModel bill)
    {
        var result = await accountService.CreateAsync(bill);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //UPDATE
    [HttpPut]
    [Route("api/bills/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] AccountModel bill)
    {
        var result = await accountService.UpdateAsync(bill);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //DELETE
    [HttpDelete]
    [Route("api/bills/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute][Required] string id)
    {
        var result = await accountService.DeleteAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
