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
    
    public partial class Ticket_FormDetail
    {
        public int ID { get; set; }
        public int FormID { get; set; }
        public Nullable<int> VNAReportID { get; set; }
        public Nullable<int> FamilyID { get; set; }
        public string Fullname { get; set; }
        public string Relationship { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string PID { get; set; }
        public string Route { get; set; }
        public string Base { get; set; }
        public Nullable<int> TicketCount { get; set; }
        public string Type { get; set; }
        public Nullable<int> Status { get; set; }
        public string Remark { get; set; }
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
