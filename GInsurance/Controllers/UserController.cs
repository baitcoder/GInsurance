using System;
using GInsurance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        GInsuranceContext db = new GInsuranceContext();
        [HttpGet]
        [Route("GetUser/{id}")]
        public IActionResult GetUserId([FromRoute]int id)
        {
            var data = db.Users.Find(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetUsers()
        {
            var data = db.Users.AsQueryable();
            return Ok(data);
        }


        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    db.Users.Add(user);

                    //db.Database.ExecuteSqlInterpolated($"AddToDept {dept.Id},{dept.Name},{dept.Location}");
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }

            }
            return Created("User Added Successfully", user);

        }


        
    }
}
