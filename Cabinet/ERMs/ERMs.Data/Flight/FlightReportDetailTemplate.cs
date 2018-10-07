using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Flight
{
    public class FlightReportDetailTemplate : API_CR_USP_GetFlightFinalReport2_Result
    {
        public int IDTemPlate { get; set; }
        public string StrDate { get; set; }

        public string FRIndex { get; set; }
        public FlightReportDetailTemplate ToModel(API_CR_USP_GetFlightFinalReport2_Result item)
        {
            this.Date = item.Date;
            this.StrDate = item.Date.Value.ToString("dd/MM/yyyy");
            this.FlightNo = item.FlightNo;
            this.Routing = item.Routing;
            this.Aircraft = item.Aircraft;
            this.Content = item.Content;
            this.FullName = item.FullName;
            this.RegisterNo = item.RegisterNo;
            return this;
        }
    }
}
