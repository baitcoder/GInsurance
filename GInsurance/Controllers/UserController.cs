using System;
using GInsurance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GInsurance.Models.ViewModel;
using System.Collections.Generic;


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
        [Route("GetUserId/{email}")]
        public IActionResult GetUserId([FromRoute]string email)
        {
            var data = db.Users.Where(e => e.Email == email).FirstOrDefault();
            try
            {
                if (data != null)
                {
                    var id = data.UserId;
                    return Accepted($"UserID-{id}");
                }   
                
            }
            catch(Exception e)
            {
                //return NotFound($"Your UserID : {id}");
            }
            return Ok();
        }



        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetUsers()
        {
            var data = db.Users.AsQueryable();
          
            return Ok(data);
        }




        [HttpPost]
        [Route("Register")]
        public IActionResult AddUser([FromBody] User user)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    db.Users.Add(user);

                    //db.Database.ExecuteSqlInterpolated($"AddToDept {dept.Id},{dept.Name},{dept.Location}");
                    db.SaveChanges();
                    return Created("Your Id", user.UserId);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }

            }
            return Ok(user.UserId);
        }

              



        [HttpGet]
        [Route("Login/{id}/{password}")]
        public IActionResult UserLogin([FromRoute]int id,string password)
        {
            //var data = db.Users.Where(e => e.UserId == id).FirstOrDefault();
            //return Ok(data);
            try
            {
                var data = db.Users.Where(e => e.UserId==id).FirstOrDefault();
                if (data != null)
                {
                    if ((data.UserId == id) && (data.Password == password))
                    {
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return NotFound("UserID not Found");
        }


        
    }
}
