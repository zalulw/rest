using System.ComponentModel.DataAnnotations;

namespace homework.Controllers;

public class R6OpsController : ControllerBase
{
    public List<string> Operators = new List<string>()
    {
        "Denari",
        "Rauora",
        "Striker",
        "Deimos",
        "Ram",
        "Brava",
        "Grim",
        "Sens",
        "Osa",
        "Flores",
        "Zaro",
        "Ace",
        "Iana",
        "Kali",
        "Amaru",
        "Nokk",
        "Gridlock fatass",
        "Nomad",
        "Maverick",
        "Lion",
        "Finka",
        "Dokkaebi",
        "Zofia",
        "Ying",
        "Jackal",
        "Hibana",
        "Capitao",
        "Buck",
        "Sledge",
        "Thatcher",
        "Ash",
        "Thermite",
        "Montagne",
        "Twitch",
        "Blitz my king",
        "IQ",
        "Fuze",
        "Glaz"
    };

    [HttpGet]
    [Route("operators/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        return Ok(Operators[id]);
    }
    [HttpGet]
    [Route("operators/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(Operators);
    }

    [HttpPost]
    [Route("operators/create")]
    public async Task<IActionResult> PostAsync([FromBody][Required] string op)
    {
        Operators.Add(op);
        return Ok(Operators);
    }

    [HttpPut]
    [Route("operators/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] OpUpdateModel request)
    {
        Operators[request.Id] = request.Name;

        return Ok(Operators);
    }

    [HttpDelete]
    [Route("operators/delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute][Required] int id)
    {
        Operators.RemoveAt(id);

        return Ok(Operators);
    }

}
