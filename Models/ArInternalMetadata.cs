using System;
using System.Collections.Generic;

namespace Rocket_Elevator_CS_API.Models
{
    public partial class ArInternalMetadata
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
