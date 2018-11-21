using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Rocket_Elevator_CS_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocket_Elevator_CS_API.Controllers
{
   [Route("api/intervention")]
   public class InterventionsController : Controller
   {
       private Rocket_Elevators_developmentContext dbContext = new Rocket_Elevators_developmentContext();

        // GET api/interventions
       [HttpGet("status")]
       public JsonResult GetInterventions()
       {
           
           List<Interventions> InterventionsList = dbContext.Interventions.Where(x => x.Status == "Pending" && x.StartDate == "").ToList();
           var newList = new List<Interventions>();
           foreach (var intervention in InterventionsList)
               newList.Add(intervention);

           return Json(newList);
       }

       // PUT api/interventions
       [HttpPut("Inprogress/{id}")]
       public string Update(long id)
       {
           var intervention = dbContext.Interventions.Find(id);
           if (intervention == null)
           {
               return "Enter a valid intervention id.";
           }

           if (intervention.Status != "Pending")
           {
               return "Intervention is not in pending status" ;
           }
           else
           {
                intervention.Status = "In progress";
                var start_date = DateTime.Now.ToString("yyyy/MM/dd H:mm:ss");
                intervention.StartDate = start_date;
                dbContext.Interventions.Update(intervention);
                dbContext.SaveChanges();
               
                return "Intervention succesfully changed to Pending";
           }
       }

       // PUT api/interventions
       [HttpPut("Completed/{id}")]
       public string UpdateCompleted(long id)
       {
           var intervention = dbContext.Interventions.Find(id);
           if (intervention == null)
           {
               return "Enter a valid intervention id.";
           }

           if (intervention.Status != "In progress") 
           {
               return "Intervention is not In progress status" ;
           }
           else
           {
                intervention.Status = "Completed";
                var end_date = DateTime.Now.ToString("yyyy/MM/dd H:mm:ss");
                intervention.EndDate = end_date;
                dbContext.Interventions.Update(intervention);
                dbContext.SaveChanges();
               
                return "Intervention succesfully changed to Completed";
            }
       }
    }
}






