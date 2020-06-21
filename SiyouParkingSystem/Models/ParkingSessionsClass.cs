using ParkingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiyouParkingSystem.Models
{
    public class ParkingSessionsClass
    {
        public int Id { get; set; }
        public DateTime Entry_date { get; set; }
        public DateTime Extry_date { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}