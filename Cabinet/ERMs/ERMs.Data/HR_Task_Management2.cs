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
    
    public partial class HR_Task_Management2
    {
        public int ID { get; set; }
        public int TaskID { get; set; }
        public int AssigneeID { get; set; }
        public Nullable<int> Progress { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public string Creatorid { get; set; }
        public string Modifierid { get; set; }
    }
}
