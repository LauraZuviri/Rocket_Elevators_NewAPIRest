using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Rocket_Elevator_CS_API.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocket_Elevator_CS_API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private Rocket_Elevators_developmentContext dbContext = new Rocket_Elevators_developmentContext();
        // GET: api/<controller>
        // Trying to get all columns
        [HttpGet]
        public JsonResult Get()
        {
            List<Users> UsersList = dbContext.Users.ToList();
            var newList = new List<Users>();
            foreach (var item in UsersList) 
                newList.Add(item);

            return Json(newList);
        }

        [HttpGet("{email}", Name = "GetEmail")]
        public ActionResult<Users> Get(string email)
        {
            var _result = dbContext.Users.Where(s => s.Email == email).FirstOrDefault();
            if (_result == null)
            {
                return NotFound();
            }
            return _result;
        }

    }
}