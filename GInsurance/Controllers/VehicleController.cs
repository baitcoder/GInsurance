using System;
using System.Linq;
using GInsurance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        GInsuranceContext db = new GInsuranceContext();

        /* [HttpPost]
         [Route("/{id}/BuyInsurance")]
         public IActionResult BuyIns(Detail vehicle, [FromRoute] int id)
         {
             try
             {

                 Detail vcle = new Detail();
                 //vcle.ManufacturerName = vehicle.ManufacturerName;
                 //vcle.ChassisNumber = vehicle.ChassisNumber;
                 //vcle.RegistrationNumber = vehicle.RegistrationNumber;
                 //vcle.
                 //db.Details.Add(vehicle);
                 //db.SaveChanges();

             }
             catch (Exception ex)
             {
                 return BadRequest(ex.InnerException.Message);
             }
             return Ok(vehicle);
         }*/


        [HttpPost]
        [Route("BuyInsurance")]
        public IActionResult BuyInsurance([FromBody] Detail detail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Details.Add(detail);

                    //db.Database.ExecuteSqlInterpolated($"AddToDept {dept.Id},{dept.Name},{dept.Location}");
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }

            }
            return Created("User Added Successfully", detail);
        }

        [HttpGet]
        [Route("GetVehicle")]
        public IActionResult GetVehicle()
        {
            var data = db.Details.AsQueryable();
            return Ok(data);
        }
    }
}
