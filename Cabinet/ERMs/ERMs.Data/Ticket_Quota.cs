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
    
    public partial class Ticket_Quota
    {
        public int ID { get; set; }
        public Nullable<int> EmployeeTypeID { get; set; }
        public string EmployeeType { get; set; }
        public Nullable<int> FromYear { get; set; }
        public Nullable<int> ToYear { get; set; }
        public Nullable<int> ID90 { get; set; }
        public Nullable<int> ID75 { get; set; }
        public Nullable<int> ID50 { get; set; }
    }
}
