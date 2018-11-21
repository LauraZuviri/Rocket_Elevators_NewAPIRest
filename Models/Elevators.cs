﻿using System;
using System.Collections.Generic;

namespace Rocket_Elevator_CS_API.Models
{
    public partial class Elevators
    {
        public long Id { get; set; }
        public long? ColumnId { get; set; }
        public int? SerialNumber { get; set; }
        public string Model { get; set; }
        public string BuildingType { get; set; }
        public string Status { get; set; }
        public string InspectionCertificate { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Columns Column { get; set; }
    }
}