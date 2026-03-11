using Microsoft.AspNetCore.Mvc;
using Solution.Database.Entities;
using Solution.Services;

namespace Solution.Api.Controllers;

[ApiController]
[ProducesResponseType(statusCode: 400, type: typeof(BadRequestObjectResult))]
public class HeroController(IHeroService heroService) : ControllerBase
{
    [HttpGet]
    [Route("api/heroes")]
    public async Task<IActionResult> GetAll()
    {
        var result = await heroService.GetAllAsync();
        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    [Route("api/heroes/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await heroService.GetByIdAsync(id);
        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpPost]
    [Route("api/heroes")]
    public async Task<IActionResult> Create(HeroEntity entity)
    {
        var result = await heroService.CreateAsync(entity);
        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpPut]
    [Route("api/heroes")]
    public async Task<IActionResult> Update(HeroEntity entity)
    {
        var result = await heroService.UpdateAsync(entity);
        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }

        return Ok("Frissitve");
    }

    [HttpDelete]
    [Route("api/heroes/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await heroService.DeleteAsync(id);
        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }

        return Ok("Sikeres törlés");
    }
}
