using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Rocket_Elevator_CS_API.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocket_Elevator_CS_API.Controllers
{
    [Route("api/[controller]")]
    public class BatteriesController : Controller
    {
        private Rocket_Elevators_developmentContext dbContext = new Rocket_Elevators_developmentContext();
        [HttpGet]
        public JsonResult Get()
        {
            List<Batteries> BatteriesList = dbContext.Batteries.ToList();
            var newList = new List<Batteries>();
            foreach (var item in BatteriesList)
                newList.Add(item);
            
            return Json(newList);
        }
    }
}