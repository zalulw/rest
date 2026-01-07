using Solution.Services.InvoiceItem.Interfaces;
using Solution.Services.InvoiceItem.Model;
using System.ComponentModel.DataAnnotations;

namespace Solution.Api.Controllers;

public class BillItemController(IInvoiceItemService invoiceItemService) : BaseController
{
    [HttpGet]
    [Route("api/items/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await invoiceItemService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/items/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await invoiceItemService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/items/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] InvoiceItemModel item)
    {
        var result = await invoiceItemService.CreateAsync(item);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/items/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] InvoiceItemModel item)
    {
        var result = await invoiceItemService.UpdateAsync(item);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/items/delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromBody][Required] int id)
    {
        var result = await invoiceItemService.DeleteAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
