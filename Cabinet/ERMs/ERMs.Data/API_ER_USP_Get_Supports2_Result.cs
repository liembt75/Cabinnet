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
    
    public partial class API_ER_USP_Get_Supports2_Result
    {
        public Nullable<long> RowNo { get; set; }
        public int ID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Sender { get; set; }
        public string Assignee { get; set; }
        public string AssigneeName { get; set; }
        public string Message { get; set; }
        public Nullable<int> AttachmentId { get; set; }
        public string Note { get; set; }
        public Nullable<short> Rating { get; set; }
        public Nullable<short> Star { get; set; }
        public Nullable<short> Status { get; set; }
        public string StatusText { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Creatorid { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Modifierid { get; set; }
        public string Modifier { get; set; }
    }
}
