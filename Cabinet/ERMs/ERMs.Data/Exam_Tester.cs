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
    
    public partial class Exam_Tester
    {
        public int ID { get; set; }
        public string Crewid { get; set; }
        public Nullable<int> Flightid { get; set; }
        public int BankTest_ID { get; set; }
        public Nullable<int> Category { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> ScoreExpec { get; set; }
        public Nullable<int> ScoreResult { get; set; }
        public Nullable<System.DateTime> TestDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public string Note { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public string Creatorid { get; set; }
        public string Modifierid { get; set; }
    }
}
