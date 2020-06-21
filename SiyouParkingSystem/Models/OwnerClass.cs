using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingDataAccess;

namespace SiyouParkingSystem.Models
{
    public class OwnerClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public int QR_code { get; set; }
        public string Adress { get; set; }
        public System.DateTime Birth_date { get; set; }
        public System.DateTime Created_at { get; set; }
        public System.DateTime Updated_at { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}