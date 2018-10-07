using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Flight
{
    public class FlightFinalReportModel : API_CR_USP_GetFlightFinalReport_Result
    {
        public string strBreak { get; set; }
        public string strCreated { get; set; }
        public string strDate { get; set; }

        public string strCategory { get; set; }
        public FlightFinalReportModel ToModel(API_CR_USP_GetFlightFinalReport_Result item, List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory)
        {
            this.Aircraft = item.Aircraft;
            this.Attachments = item.Attachments;
            this.Category = item.Category;
            this.strCategory = ReplaceCustom(new StringBuilder(item.Category), lstCategory).ToString();
            this.Content = item.Content;
            this.Created = item.Created;
            this.strCreated = item.Created.Value.ToString("dd/MM/yyyy hh:mm:ss");
            this.Creator = item.Creator;
            this.Creatorid = item.Creatorid;
            this.CrewID = item.CrewID;
            this.Date = item.Date;
            this.strDate = item.Date.Value.ToString("dd/MM/yyyy hh:mm:ss");
            this.Emergency = item.Emergency;
            this.FlightID = item.FlightID;
            this.FlightNo = item.FlightNo;
            this.FullName = item.FullName;
            this.ID = item.ID;
            this.IsDeleted = item.IsDeleted;
            this.MainPilot = item.MainPilot;
            this.Modified = item.Modified;
            this.Modifier = item.Modifier;
            this.Modifierid = item.Modifierid;
            this.Replied = item.Replied;
            this.Replier = item.Replier;
            this.Replierid = item.Replierid;
            this.ReplyDept = item.ReplyDept;
            this.ReplyInfo = item.ReplyInfo;
            this.ReportStatus = item.ReportStatus;
            this.Routing = item.Routing;
            this.SecondPilot = item.SecondPilot;
            this.Version = item.Version;
            this.TotalPaxC = item.TotalPaxC;
            this.TotalPaxY = item.TotalPaxY;
            this.Email = item.Email;
            this.Phone = item.Phone;
            return this;
        }

        public FlightFinalReportModel ToModel(API_CR_USP_GetFlightFinalReport2_Result item, List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory)
        {
            this.Aircraft = item.Aircraft;
            this.Attachments = item.Attachments;
            this.Category = item.Category;
            this.strCategory = ReplaceCustom(new StringBuilder(item.Category), lstCategory).ToString();
            this.Content = item.Content;
            this.Created = item.Created;
            this.strCreated = item.Created.Value.ToString("dd/MM/yyyy hh:mm:ss");
            this.Creator = item.Creator;
            this.Creatorid = item.Creatorid;
            this.CrewID = item.CrewID;
            this.Date = item.Date;
            this.strDate = item.Date.Value.ToString("dd/MM/yyyy hh:mm:ss");
            this.Emergency = item.Emergency;
            this.FlightID = item.FlightID;
            this.FlightNo = item.FlightNo;
            this.FullName = item.FullName;
            this.ID = item.ID;
            this.IsDeleted = item.IsDeleted;
            this.MainPilot = item.MainPilot;
            this.Modified = item.Modified;
            this.Modifier = item.Modifier;
            this.Modifierid = item.Modifierid;
            this.Replied = item.Replied;
            this.Replier = item.Replier;
            this.Replierid = item.Replierid;
            this.ReplyDept = item.ReplyDept;
            this.ReplyInfo = item.ReplyInfo;
            this.ReportStatus = item.ReportStatus;
            this.Routing = item.Routing;
            this.SecondPilot = item.SecondPilot;
            this.Version = item.Version;
            this.TotalPaxC = item.TotalPaxC;
            this.TotalPaxY = item.TotalPaxY;
            this.Email = item.Email;
            this.Phone = item.Phone;
            return this;
        }

        public FlightFinalReportModel ToModel(API_CR_USP_GetFlightFinalReport3_Result item, List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory)
        {
            this.Aircraft = item.Aircraft;
            //this.Attachments = item.Attachments;
            this.Category = item.Category;
            this.strCategory = ReplaceCustom(new StringBuilder(item.Category), lstCategory).ToString();
            this.Content = item.Content;
            this.Created = item.Created;
            this.strCreated = item.Created.Value.ToString("dd/MM/yyyy hh:mm:ss");
            //this.Creator = item.Creator;
            //this.Creatorid = item.Creatorid;
            //this.CrewID = item.CrewID;
            this.Date = item.Date;
            this.strDate = item.Date.Value.ToString("dd/MM/yyyy hh:mm:ss");
            this.Emergency = item.Emergency;
            this.FlightID = item.FlightID;
            this.FlightNo = item.FlightNo;
            this.FullName = item.FullName;
            this.ID = item.ID;
            //this.IsDeleted = item.IsDeleted;
            this.MainPilot = item.MainPilot;
            //this.Modified = item.Modified;
            //this.Modifier = item.Modifier;
            //this.Modifierid = item.Modifierid;
            this.Replied = item.Replied;
            this.Replier = item.Replier;
            //this.Replierid = item.Replierid;
            //this.ReplyDept = item.ReplyDept;
            this.ReplyInfo = item.ReplyInfo;
            this.ReportStatus = item.ReportStatus;
            this.Routing = item.Routing;
            //this.SecondPilot = item.SecondPilot;
            //this.Version = item.Version;
            this.TotalPaxC = item.TotalPaxC;
            this.TotalPaxY = item.TotalPaxY;
            this.Email = item.Email;
            this.Phone = item.Phone;
            return this;
        }

        public FlightFinalReportModel ToModel(API_CR_USP_GetFlightFinalReportByID_Result item, List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory)
        {
            this.Aircraft = item.Aircraft;
            this.Attachments = item.Attachments;
            this.Category = item.Category;
            this.strCategory = ReplaceCustom(new StringBuilder(item.Category), lstCategory).ToString();
            this.Content = item.Content;
            this.Created = item.Created;
            this.strCreated = item.Created.Value.ToString("dd/MM/yyyy hh:mm:ss");
            this.Creator = item.Creator;
            this.Creatorid = item.Creatorid;
            this.CrewID = item.CrewID;
            this.Date = item.Date;
            this.strDate = item.Date.Value.ToString("dd/MM/yyyy hh:mm:ss");
            this.Emergency = item.Emergency;
            this.FlightID = item.FlightID;
            this.FlightNo = item.FlightNo;
            this.FullName = item.FullName;
            this.ID = item.ID;
            this.IsDeleted = item.IsDeleted;
            this.MainPilot = item.MainPilot;
            this.Modified = item.Modified;
            this.Modifier = item.Modifier;
            this.Modifierid = item.Modifierid;
            this.Replied = item.Replied;
            this.Replier = item.Replier;
            this.Replierid = item.Replierid;
            this.ReplyDept = item.ReplyDept;
            this.ReplyInfo = item.ReplyInfo;
            this.ReportStatus = item.ReportStatus;
            this.Routing = item.Routing;
            this.SecondPilot = item.SecondPilot;
            this.Version = item.Version;
            this.TotalPaxC = item.TotalPaxC;
            this.TotalPaxY = item.TotalPaxY;
            this.Email = item.Email;
            this.Phone = item.Phone;
            return this;
        }

        public StringBuilder ReplaceCustom(StringBuilder sb, List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory)
        {
            sb = sb.Replace(",", " - ");
            for (int i = lstCategory.Count - 1; i >= 0; i--)
            {
                API_CR_USP_Flight_FinalReport_Get_Category_Result category = lstCategory[i];
                sb.Replace(category.SubCategoryID.ToString(), string.Format("({0}) {1}", category.Category, category.SubCategory));
            }

            return sb;
        }
    }
}
