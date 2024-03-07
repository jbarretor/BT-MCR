using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Business.Interfaces;
using MilesCarRental.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private readonly ICarRentalBusiness _carRentalBusiness;

        [HttpPost]
        public async Task<IActionResult> NewCarRental([FromBody] RqCreateCarRental input)
        {
            try
            {
                var client = new Client()
                {
                    FirstName = input.ClientFirstName, 
                    LastName = input.ClientLastName,
                    Identification = input.ClientIdentification,
                    Phone = input.ClientPhone
                };

                var carRental = new CarRental()
                {
                    StartDate = input.StartDate,
                    EndDate = input.EndDate,
                    CarId = input.VehicleId,
                    PickupLocationId = input.PickupLocationId,
                    ReturnLocationId = input.ReturnLocationId,
                    
                };

                var result = _carRentalBusiness.NewCarRental(client, carRental);
                
                switch (result)
                {
                    case -1:
                        return BadRequest(new { message = "este carro no existe" });
                    case -2:
                        return BadRequest(new { message = "La locación de recogida no existe" });
                    case -3:
                        return BadRequest(new { message = "La locación de regreso no existe" });
                    case 1:
                        return Ok(new { message = "La solicidud de renta ha sido exitosa" });
                    default:
                        return BadRequest(new { message = result });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Exception en la consulta {ex.Message}" });
            }
        }
    }
}
