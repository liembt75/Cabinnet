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
    
    public partial class CR_OJT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CR_OJT()
        {
            this.CR_OJT_Item = new HashSet<CR_OJT_Item>();
        }
    
        public int ID { get; set; }
        public Nullable<int> FlightID { get; set; }
        public string FltInfo { get; set; }
        public string ExaminerID { get; set; }
        public string ExaminerName { get; set; }
        public string ExamineeID { get; set; }
        public string ExamineeName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> CR_OJT_Lesson_ID { get; set; }
        public string CR_OJT_Lesson { get; set; }
        public string CR_OJT_Category { get; set; }
        public Nullable<double> TotalScore { get; set; }
        public string Comment { get; set; }
        public string Suggestion { get; set; }
        public Nullable<System.DateTime> Signed { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public string Creatorid { get; set; }
        public string Modifierid { get; set; }
        public string SignedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CR_OJT_Item> CR_OJT_Item { get; set; }
    }
}
