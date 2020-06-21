using ParkingDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SiyouParkingSystem.Models
{
    public class AdminClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public System.DateTime Birth_date { get; set; }
        public System.DateTime Created_at { get; set; }
        public System.DateTime Updated_at { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}