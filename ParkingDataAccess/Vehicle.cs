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
    
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            this.Parking_sessions = new HashSet<Parking_sessions>();
        }
    
        public int Id { get; set; }
        public int PlateNumber { get; set; }
        public string Model { get; set; }
        public System.DateTime Created_at { get; set; }
        public System.DateTime Updated_at { get; set; }
        public int UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parking_sessions> Parking_sessions { get; set; }
        public virtual User User { get; set; }
    }
}