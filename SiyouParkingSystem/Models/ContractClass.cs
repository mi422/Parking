using ParkingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiyouParkingSystem.Models
{
    public class ContractClass
    {
         
        public int Id { get; set; }
        public int RenterId { get; set; }
        public int ParkingId { get; set; }
        public DateTime Rent { get; set; }
        public DateTime End_rent { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public virtual Parking Parking { get; set; }
        public virtual Renter Renter { get; set; }
    }
}
 