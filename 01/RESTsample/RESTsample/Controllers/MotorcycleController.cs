namespace RESTsample.Controllers;

public class MotorcycleController: ControllerBase
{
    public List<string> motorcycles = new List<string>()
    {
        "Harley Davidson",
        "Ducati",
        "BMW",
        "Kawasaki",
        "Yamaha"
    };


    [HttpGet]
    [Route("motorcycle/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id) //fromRoute a urlben keresi az IDT
    {
        return Ok(motorcycles[id]);
    }
    
    [HttpGet]
    [Route("motorcycle")]
    public async Task<IActionResult> GetByQueryAsync([FromQuery][Required] int id)
    {
        return Ok(motorcycles[id]);
    }

    [HttpGet]
    [Route("motorcycle/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(motorcycles);
    }

    [HttpPost]
    [Route("motorcycle/create")]
    public async Task<IActionResult> PostAsync([FromBody][Required] string motorcycle)
    {
        motorcycles.Add(motorcycle);

        return Ok(motorcycles);
    }

    [HttpPut]
    [Route("motorcycle/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] MotorcycleUpdateModel request)
    {
        motorcycles[request.Id] = request.Name;

        return Ok(motorcycles);
    }

    [HttpDelete]
    [Route("motorcycle/delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute][Required] int id)
    {
        motorcycles.RemoveAt(id);

        return Ok(motorcycles);
    }
}
