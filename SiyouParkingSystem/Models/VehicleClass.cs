using ParkingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiyouParkingSystem.Models
{
    public class VehicleClass
    {
        public int Id { get; set; }
        public int PlateNumber { get; set; }
        public string Model { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}