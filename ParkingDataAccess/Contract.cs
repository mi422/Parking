//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkingDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract
    {
        public int Id { get; set; }
        public int RenterId { get; set; }
        public int ParkingId { get; set; }
        public System.DateTime Rent { get; set; }
        public System.DateTime End_rent { get; set; }
        public System.DateTime Created_at { get; set; }
        public System.DateTime Updated_at { get; set; }
    
        public virtual Parking Parking { get; set; }
        public virtual Renter Renter { get; set; }
    }
}