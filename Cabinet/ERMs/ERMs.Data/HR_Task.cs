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
    
    public partial class HR_Task
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> TaskMaster { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public Nullable<System.DateTime> Completed { get; set; }
        public Nullable<int> Progress { get; set; }
        public string Reason { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string Note { get; set; }
        public Nullable<int> AttachmentGroupId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public string Creatorid { get; set; }
        public string Modifierid { get; set; }
    }
}
