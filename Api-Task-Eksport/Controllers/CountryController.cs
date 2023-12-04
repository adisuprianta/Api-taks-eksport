using Api_Task_Eksport.Entity;
using Api_Task_Eksport.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api_Task_Eksport.Controllers;

[Route("api/negara")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly CountryService countryService;

    public CountryController(CountryService countryService)
    {
        this.countryService = countryService;
    }
    
    [HttpGet("all")]
    public IActionResult Index() {
        return Ok(countryService.getall());
    }
        
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public ActionResult<Country> GetBarang([FromQuery] string negara) {
        if (negara == "" || negara == null ) {
            return BadRequest();
        }
        var response = countryService.getByName(negara);
        if (response == null) {
            return NotFound();
        }
        return Ok(response);
    }
}