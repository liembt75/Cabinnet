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
    
    public partial class API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result
    {
        public int ID { get; set; }
        public int FinalReportID { get; set; }
        public int DepartmentID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Note { get; set; }
        public string ReplyInfo { get; set; }
        public Nullable<int> Replierid { get; set; }
        public string Replier { get; set; }
        public Nullable<System.DateTime> Replied { get; set; }
        public Nullable<int> Creatorid { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string Code { get; set; }
        public string SubCategory { get; set; }
    }
}
