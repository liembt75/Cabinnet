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
    
    public partial class HR_Forms
    {
        public int ID { get; set; }
        public string CID { get; set; }
        public string CName { get; set; }
        public Nullable<int> Category_ID { get; set; }
        public Nullable<System.DateTime> From_Date { get; set; }
        public Nullable<System.DateTime> To_Date { get; set; }
        public string Route { get; set; }
        public string FlightNo { get; set; }
        public string Content { get; set; }
        public Nullable<int> Attachments { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int Status { get; set; }
        public string Replierid { get; set; }
        public string Replier { get; set; }
        public Nullable<System.DateTime> Replied { get; set; }
        public string ReplyDept { get; set; }
        public string ReplyInfo { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public string Creatorid { get; set; }
        public string Modifierid { get; set; }
    }
}
