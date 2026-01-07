using Solution.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Solution.Api.Controllers;

public class BillItemController(IBillItemsService billItemService) : BaseController
{
    [HttpGet]
    [Route("api/items/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await billItemService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/items/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await billItemService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/items/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] BillItemModel item)
    {
        var result = await billItemService.CreateAsync(item);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/items/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] BillItemModel item)
    {
        var result = await billItemService.UpdateAsync(item);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/items/delete/${id}")]
    public async Task<IActionResult> DeleteAsync([FromBody][Required] int id)
    {
        var result = await billItemService.DeleteAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
