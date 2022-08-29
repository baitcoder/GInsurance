using GInsurance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        GInsuranceContext db = new GInsuranceContext();

        [HttpGet]
        [Route("ClaimList")]
        public IActionResult DisplayClaimList()
        {
            var data = db.Claims.AsQueryable();
            return Ok(data);
        }

        [HttpGet]
        [Route("ClaimData/{id}")]
        public IActionResult GetClaimbyId([FromRoute] int id)
        {
            var data = db.Claims.Find(id);
            return Ok(data);
        }



        [HttpPut]
        [Route("approve/{id}")]
        public IActionResult Aprve([FromRoute] int id )
        {
            var data = db.Claims.Find(id);
            data.ApproveStatus = "true";
            db.SaveChanges();
            return Ok(data);
        }
    }
}
