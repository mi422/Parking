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
    
    public partial class Parking_sessions
    {
        public int Id { get; set; }
        public DateTime Entry_Date { get; set; }
        public DateTime Extry_Date { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int VehicleId { get; set; }
    
        public virtual Vehicle Vehicle { get; set; }
    }
}
