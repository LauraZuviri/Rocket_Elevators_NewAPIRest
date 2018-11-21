using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Rocket_Elevator_CS_API.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocket_Elevator_CS_API.Controllers
{
   [Route("api/[controller]")]
   public class ElevatorsController : Controller
   {
       private Rocket_Elevators_developmentContext dbContext = new Rocket_Elevators_developmentContext();
       // GET: api/<controller>
       // Trying to get all columns
       [HttpGet]
       public JsonResult Get()
       {
           List<Elevators> ElevatorsList = dbContext.Elevators.ToList();
           var newList = new List<Elevators>();
           foreach (var item in ElevatorsList)
               newList.Add(item);

           return Json(newList);
       }

       [HttpGet("status")]
       public JsonResult GetElevators()
       {
           List<Elevators> ElevatorsList = dbContext.Elevators.Where(x => x.Status == "Inactive" || x.Status == "Intervention").ToList();
           var newList = new List<Elevators>();
           foreach (var item in ElevatorsList)
               newList.Add(item);

           return Json(newList);
       }

   }
}