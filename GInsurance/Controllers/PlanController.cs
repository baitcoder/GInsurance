using System;
using System.Linq;
using GInsurance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        GInsuranceContext db = new GInsuranceContext();

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var data = db.Plans.Where(e=>e.UserId==id).ToList();
            return Ok(data);
        }

        [HttpPost]
        [Route("AddPlan")]
        public IActionResult Post([FromBody] Plan plan)
        {
            try
            {
                db.Plans.Add(plan);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return Ok();
        }

    }
    
}
