//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERMs.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CR_Trip
    {
        public int TripID { get; set; }
        public string TripName { get; set; }
        public string Routing { get; set; }
        public string Group { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Startdate { get; set; }
        public Nullable<System.DateTime> Finishdate { get; set; }
        public string Status { get; set; }
        public string CodeFly { get; set; }
        public Nullable<int> Version { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public string Creatorid { get; set; }
        public string Modifierid { get; set; }
    }
}
