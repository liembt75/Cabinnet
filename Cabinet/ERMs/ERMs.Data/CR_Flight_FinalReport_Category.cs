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
    
    public partial class CR_Flight_FinalReport_Category
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public Nullable<int> Version { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public Nullable<int> Creatorid { get; set; }
        public Nullable<int> Modifierid { get; set; }
    }
}
