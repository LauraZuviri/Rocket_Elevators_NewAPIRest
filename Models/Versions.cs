using System;
using System.Collections.Generic;

namespace Rocket_Elevator_CS_API.Models
{
    public partial class Versions
    {
        public long Id { get; set; }
        public string ItemType { get; set; }
        public int ItemId { get; set; }
        public string Event { get; set; }
        public string Whodunnit { get; set; }
        public string Object { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
