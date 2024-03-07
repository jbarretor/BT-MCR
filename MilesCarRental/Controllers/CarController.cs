using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Business.Interfaces;
using MilesCarRental.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MilesCarRental.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarBusiness _carBusiness;

        public CarController(ICarBusiness carBusiness)
        {
            _carBusiness = carBusiness;
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetCarsByLocation(int locationId)
        {
            try
            {
                var result = _carBusiness.getCarsByLocation(locationId);
                if (!result.Any())
                {
                    return BadRequest(new { message = "No se encontraron carros en esta locación" });
                }
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Exception en la consulta {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewCar([FromBody] Car value)
        {
            try
            {
                var result = _carBusiness.addCar(value);
                if (result != 1)
                {
                    return BadRequest(new { message = "Error en la creacion" });
                }
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Exception en la consulta {ex.Message}" });
            }
        }
    }
}
