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
    
    public partial class CR_Flight_Assessment
    {
        public int ID { get; set; }
        public Nullable<int> FlightID { get; set; }
        public string CrewID { get; set; }
        public string FullName { get; set; }
        public string CrewID1 { get; set; }
        public string FullName1 { get; set; }
        public Nullable<int> LessonID { get; set; }
        public string Lesson { get; set; }
        public Nullable<double> TotalScore { get; set; }
        public string Strength { get; set; }
        public string Weakness { get; set; }
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