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
    
    public partial class CR_Flight_FinalReport
    {
        public int ID { get; set; }
        public Nullable<int> FlightID { get; set; }
        public string FlightInfo { get; set; }
        public string CrewID { get; set; }
        public string FullName { get; set; }
        public string MainPilot { get; set; }
        public string SecondPilot { get; set; }
        public Nullable<int> Emergency { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public Nullable<int> Attachments { get; set; }
        public Nullable<int> Version { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public Nullable<int> Creatorid { get; set; }
        public Nullable<int> Modifierid { get; set; }
        public Nullable<int> ReportStatus { get; set; }
        public string Replierid { get; set; }
        public string Replier { get; set; }
        public Nullable<System.DateTime> Replied { get; set; }
        public string ReplyDept { get; set; }
        public string ReplyInfo { get; set; }
    }
}
