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
    
    public partial class HR_HealthCare
    {
        public int ID { get; set; }
        public string CrewID { get; set; }
        public System.DateTime Dotkham { get; set; }
        public Nullable<double> Chieucao { get; set; }
        public Nullable<double> Cannang { get; set; }
        public string chitietsuckhoe { get; set; }
        public string trangthaikham { get; set; }
        public Nullable<System.DateTime> Expired { get; set; }
        public bool Isdeleted { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Creatorid { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Modifierid { get; set; }
        public string Modifier { get; set; }
    }
}
