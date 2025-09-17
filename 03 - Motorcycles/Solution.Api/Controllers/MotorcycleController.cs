namespace Solution.Api.Controllers;

public class MotorcycleController(IMotorcycleService motorcycleService) : ControllerBase
{
    [HttpGet]
    [Route("api/motorcycle/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        if (motorcycleService is null)
        {
            return BadRequest("Motorcycle service is not available.");
        }

        return Ok(await motorcycleService.GetAllAsync());
    }
}