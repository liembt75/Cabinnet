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
    
    public partial class CR_FlightInfo_Netline
    {
        public int ID { get; set; }
        public Nullable<int> LEG_NO { get; set; }
        public Nullable<System.DateTime> UTCDate { get; set; }
        public Nullable<System.DateTime> UTCDepart { get; set; }
        public Nullable<System.DateTime> UTCArrive { get; set; }
        public string AC { get; set; }
        public string REGAC { get; set; }
        public string FLT_NO { get; set; }
        public string STA { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> E_DATE { get; set; }
        public string SANBAYDI { get; set; }
        public string SANBAYDEN { get; set; }
        public string THOIGIANDI { get; set; }
        public string THOIGIANDEN { get; set; }
        public string E_SECTOR_SCHEDULE { get; set; }
        public string ETD { get; set; }
        public string ETA { get; set; }
        public Nullable<decimal> E_TIME { get; set; }
        public string E_SECTOR_ACTUAL { get; set; }
        public string ATD { get; set; }
        public string ATA { get; set; }
        public Nullable<decimal> A_TIME { get; set; }
        public Nullable<decimal> CHAM_TIME { get; set; }
        public string DLCODE { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public Nullable<int> Refflightid { get; set; }
        public Nullable<bool> Auto { get; set; }
    }
}
