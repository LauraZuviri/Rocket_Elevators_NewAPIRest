using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Rocket_Elevator_CS_API.Models;
using Newtonsoft.Json.Linq;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocket_Elevator_CS_API.Controllers
{
   [Route("api/elevators")]
   public class ElevatorController : Controller
   {
       private Rocket_Elevators_developmentContext dbContext = new Rocket_Elevators_developmentContext();
       // GET api/<controller>/5
       [HttpGet("{id}", Name = "GetElevators")]
       public string GetById(long id)
       {
           var item = dbContext.Elevators.Find(id);
           var _status = item.Status;
           var _id = dbContext.Elevators.Find(id).Id;
           if (item == null)
           {
               return "Please enter a valid id.";
           }
           return _status;
       }
       // PUT api/<controller>/5
       [HttpPut("{id}")]
       public string Update(long id, [FromBody] JObject body)
       {

           var elevator = dbContext.Elevators.Find(id);
           if (elevator == null)
           {
               return "Enter a valid elevator id.";
           }

           var previous_status = elevator.Status;
           var status = (string)body.SelectToken("status");
           if (status == "Active" || status == "Inactive" || status == "Alarm" || status == "Intervention")
           {
               elevator.Status = status;
               dbContext.Elevators.Update(elevator);
               dbContext.SaveChanges();
               return status;
           }
           else
           {
               return "Invalid status: Must be Active, Inactive, Alarm or Intervention";
           }
       }
       }
}