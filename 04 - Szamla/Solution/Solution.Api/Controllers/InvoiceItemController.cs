using Microsoft.AspNetCore.Mvc;
using Solution.Services;
using Solution.Services.InvoiceItem.Interfaces;
using Solution.Services.InvoiceItem.Model;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Solution.Api.Controllers;

public class InvoiceItemController(IInvoiceItemService invoiceItemService): BaseController
{
    [HttpGet]
    [Route("api/invoice/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await invoiceItemService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpGet]
    [Route("api/invoice/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await invoiceItemService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpDelete]
    [Route("api/invoice/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        var result = await invoiceItemService.DeleteAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("api/invoice/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] InvoiceItemModel model)
    {
        var result = await invoiceItemService.CreateAsync(model);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpPut]
    [Route("api/invoice/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] InvoiceItemModel model)
    {
        var result = await invoiceItemService.UpdateAsync(model);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors));
    }

    [HttpGet]
    [Route("api/invoice/page/{page}")]
    public async Task<IActionResult> GetPagedAsync([FromRoute] int page = 0)
    {
        var result = await invoiceItemService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
    
}
