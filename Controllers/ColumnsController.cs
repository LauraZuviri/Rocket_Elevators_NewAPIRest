using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Rocket_Elevator_CS_API.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocket_Elevator_CS_API.Controllers
{
    [Route("api/[controller]")]
    public class ColumnsController : Controller
    {
        private Rocket_Elevators_developmentContext dbContext = new Rocket_Elevators_developmentContext();
        // GET: api/<controller>
        // Trying to get all columns
        [HttpGet]
        public JsonResult Get()
        {
            List<Columns> ColumnsList = dbContext.Columns.ToList();
            var newList = new List<Columns>();
            foreach (var item in ColumnsList)
                newList.Add(item);
            return Json(newList);
        }
    }
}