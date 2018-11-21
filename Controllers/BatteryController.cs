using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Rocket_Elevator_CS_API.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocket_Elevator_CS_API.Controllers
{
    [Route("api/[controller]")]
    public class BatteryController : Controller
    {
        private Rocket_Elevators_developmentContext dbContext = new Rocket_Elevators_developmentContext();
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string GetBatteries(long id)
        {
            var battery = dbContext.Batteries.Where(x => x.Id == id).First();
            var column = dbContext.Columns.Where(x => x.BatteryId == battery.Id).First();
            var elevator = dbContext.Elevators.Where(x => x.ColumnId == column.Id).First();
            return battery.Status;
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public string Put(long id, string value)
        {
            var battery = dbContext.Batteries.Where(x => x.Id == id).First();
            var column = dbContext.Columns.Where(x => x.BatteryId == battery.Id).First();
            var elevator = dbContext.Elevators.Where(x => x.ColumnId == column.Id).First();
            if (value.ToLower() == "active" || value.ToLower() == "inactive" || value.ToLower() == "intervention")
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
                battery.Status = value;
                column.Status = value;
                elevator.Status = value;
                dbContext.SaveChanges();
                return battery.Status;
            }
            else
            {
                return "Error";
            }
        }
    }
}