using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class ReportModel : Ticket_VNAReport
    {

        public enum ReportStatus
        {
            Waiting = 0,
            Accept = 1,
            Reject = 2,
            Done = 3
        }        
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public EmployeeModel.EmployeeType EmployeeType { get; set; }
        public TicketModel.TicketType TicketType { get; set; }

        public List<USP_GetFromDetail1_Result> lstFormDetail;
        public List<FormReportModel> lstFormReportModel;
        public int? ThamNienFrom { get; set; }
        public enum ReportType
        {
            TCTV = 0,
            KTCTV = 1,
            TCMD = 2,
            KTCMD = 3,
            HUU = 4
        }

        public ReportType LoaiReport { get; set; }

        public string TieuChuan
        {
            get
            {
                //switch (EmployeeType)
                //{
                //    case EmployeeModel.EmployeeType.Huu:
                //        return "Tiêu chuẩn vé ID CB - NV Nghi huu";                        
                //    case EmployeeModel.EmployeeType.MatDat:
                //        if (TicketType == TicketModel.TicketType.ID75 && ThamNienFrom.HasValue && ThamNienFrom.Value >= 10)
                //            return "Ngoài tiêu chuẩn khối mặt đất";
                //        return "Tiêu chuẩn vé ID khối mặt đất";                        
                //    case EmployeeModel.EmployeeType.TiepVien:
                //        if (TicketType == TicketModel.TicketType.ID75 && ThamNienFrom.HasValue && ThamNienFrom.Value >= 10)
                //            return "Ngoài tiêu chuẩn khối Tiếp viên";
                //        return "Tiêu chuẩn vé ID khối Tiếp viên";                        
                //    default:
                //        return "";
                //}
                switch (LoaiReport)
                {
                    case ReportType.TCTV:
                        return "Tiêu chuẩn vé ID khối Tiếp viên";
                    case ReportType.KTCTV:
                        return "Ngoài tiêu chuẩn khối Tiếp viên";
                    case ReportType.TCMD:
                        return "Tiêu chuẩn vé ID khối mặt đất";
                    case ReportType.KTCMD:
                        return "Ngoài tiêu chuẩn khối mặt đất";
                    case ReportType.HUU:
                        return "Tiêu chuẩn vé ID CB - NV Nghi huu";
                    default:
                        return "";
                }
            }

        }

        public ReportModel()
        {
            Day = DateTime.Now.Day.ToString();
            Month = DateTime.Now.Month.ToString();
            Year = DateTime.Now.Year.ToString();

            lstFormDetail = new List<USP_GetFromDetail1_Result>();
            lstFormReportModel = new List<FormReportModel>();
        }

        public void SaveAndPrint()
        {
            TicketDal db = new TicketDal();
            db.SaveVNAReport(this);
        }

        public void Save()
        {
            TicketDal db = new TicketDal();
            db.SaveVNAReportNew(this);
        }
    }
}
