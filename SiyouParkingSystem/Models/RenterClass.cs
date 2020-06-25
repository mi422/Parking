using ParkingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiyouParkingSystem.Models
{
    public class RenterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int QR_code { get; set; }
        public string Adress { get; set; }     
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}