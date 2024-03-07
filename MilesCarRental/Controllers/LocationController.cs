using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Business.Interfaces;
using MilesCarRental.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MilesCarRental.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationBusiness _locationBusiness;

        public LocationController(ILocationBusiness locationBusiness)
        {
            _locationBusiness = locationBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocationsList()
        {
            try
            {
                var result = _locationBusiness.getLocation();
                if (!result.Any())
                {
                    return Ok(new { message = "No se encontraron locaciones" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Exception en la consulta {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewLocation([FromBody] Location value)
        {
            try
            {
                var location = _locationBusiness.getInfoByNameAndAddress(value.Name, value.Address);

                if (location != null)
                {
                    return BadRequest(new { message = "La locacion ya existe" });
                }

                var x = _locationBusiness.addLocation(value);
                
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Exception en la creación {ex.Message}" });
            }
        }
    }
}
