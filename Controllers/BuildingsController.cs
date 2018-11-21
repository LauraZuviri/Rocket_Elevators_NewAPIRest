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
    public class BuildingsController : Controller
    {
        private Rocket_Elevators_developmentContext dbContext = new Rocket_Elevators_developmentContext();
        // GET: api/<controller>
        // Trying to get all columns
        [HttpGet]
        public List<Buildings> Get()
        {
            List<Buildings> BuildingsList = dbContext.Buildings.Include("Batteries").ToList();

            List <Buildings> buildings = new List<Buildings>();

            foreach (var building in BuildingsList) {
                foreach (var battery in building.Batteries){
                    if (battery.Status == "Intervention")
                        Console.WriteLine(battery.Status);
                        buildings.Add(building);

                    foreach (var column in battery.Columns)
                    {
                        if (column.Status == "Intervention")
                        buildings.Add(building);
                        foreach (var elevator in column.Elevators)
                        {
                            if (elevator.Status == "Intervention")
                                buildings.Add(building);
                        }
                    }
                }
            }


            return buildings;
        }
    }
}