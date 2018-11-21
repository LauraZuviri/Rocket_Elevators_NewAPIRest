using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Rocket_Elevator_CS_API.Models;
using Newtonsoft.Json;
using System;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocket_Elevator_CS_API.Controllers
{
    [Route("api/[controller]")]
    public class LeadsController : Controller
    {
        private Rocket_Elevators_developmentContext dbContext = new Rocket_Elevators_developmentContext();
        // GET: api/<controller>
        // Trying to get all columns
        [HttpGet]
        public JsonResult Get()
        {
            var expiry = DateTime.Now.AddDays(-30);
            List<Leads> LeadsList = dbContext.Leads.Where(x => x.CreatedAt >= expiry).ToList();
            var newList = new List<Leads>();
            foreach (var item in LeadsList)
                newList.Add(item);
            return Json(newList);
        }
    }
}