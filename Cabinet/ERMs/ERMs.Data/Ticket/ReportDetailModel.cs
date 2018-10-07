using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Ticket
{
    public class ReportDetailModel
    {
        public string FullnameOffer { get; set; }
        public string OfficeOffer { get; set; }

        public string YearOffer { get; set; }

        public List<USP_GetFromDetail_Result> lstFormDetail = new List<USP_GetFromDetail_Result>();
    }
}
