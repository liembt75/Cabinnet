//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sys_SabreLoader
    {
        public int ID { get; set; }
        public Nullable<int> FlightId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string FlightNo { get; set; }
        public string Routing { get; set; }
        public Nullable<int> Category { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creatorid { get; set; }
        public string Modifierid { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
    }
}