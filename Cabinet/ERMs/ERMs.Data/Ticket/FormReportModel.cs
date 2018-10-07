using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class FormReportModel
    {
        public int FormID { get; set; }
        public int ID { get; set; }
        //public string Type { get; set; }
        public int Number { get; set; }
        //public string FullNameOffer { get; set; }
        public string FullNameOffer
        {
            get
            {
                if (formDetail != null)
                {
                    return formDetail.FullNameOffer;
                }
                else
                    return "";
            }
        }
        public string OfficeOffer { get; set; }

        //public string YearOffer { get; set; }
        public string YearOffer
        {
            get
            {
                if (formDetail != null && formDetail.YearOffer != null)
                {
                    return formDetail.YearOffer.ToString();
                }
                else
                    return "";
            }
        }

        //public string FullName { get; set; }
        public string FullName
        {
            get
            {
                StringBuilder result = new StringBuilder();
                foreach (var formDetail in lstFormDetail)
                {
                    if (result.Length > 0)
                        result.Append("\r\n");
                    if (string.IsNullOrEmpty(formDetail.Fullname))
                    {
                        result.Append(" ");
                    }
                    else
                    {
                        result.Append(formDetail.Fullname);
                    }                    
                }
                return result.ToString();
            }
        }

        //public string Birthday { get; set; }
        public string Birthday
        {
            get
            {
                StringBuilder result = new StringBuilder();
                foreach (var formDetail in lstFormDetail)
                {
                    if (result.Length > 0)
                        result.Append("\r\n");
                    if (formDetail.Birthday != null)
                        result.Append(formDetail.Birthday.Value.ToString("yyyy"));
                    else
                        result.Append(" ");
                }
                return result.ToString();
            }
        }

        //public string PID { get; set; }
        public string PID
        {
            get
            {
                StringBuilder result = new StringBuilder();
                foreach (var formDetail in lstFormDetail)
                {
                    if (result.Length > 0)
                        result.Append("\r\n");
                    if (string.IsNullOrEmpty(formDetail.PID))
                    {
                        result.Append(" ");                        
                    }
                    else
                    {
                        result.Append(formDetail.PID);
                    }
                }
                return result.ToString();
            }
        }

        //public string Relationship { get; set; }
        public string Relationship
        {
            get
            {
                StringBuilder result = new StringBuilder();
                foreach (var formDetail in lstFormDetail)
                {
                    if (result.Length > 0)
                        result.Append("\r\n");
                    if (string.IsNullOrEmpty(formDetail.Relationship))
                        result.Append("Bản thân");
                    else
                        result.Append(formDetail.Relationship);
                }
                return result.ToString();
            }
        }

        //public string Route { get; set; }
        public string Route
        {
            get
            {
                StringBuilder result = new StringBuilder();
                foreach (var formDetail in lstFormDetail)
                {
                    if (result.Length > 0)
                        result.Append("\r\n");
                    if (string.IsNullOrEmpty(formDetail.Route))
                        result.Append(" ");
                    else
                        result.Append(formDetail.Route);                    
                }
                return result.ToString();
            }
        }

        //public string Base { get; set; }
        public string Base
        {
            get
            {
                StringBuilder result = new StringBuilder();
                foreach (var formDetail in lstFormDetail)
                {
                    if (result.Length > 0)
                        result.Append("\r\n");
                    if (string.IsNullOrEmpty(formDetail.Base))
                        result.Append(" ");
                    else
                        result.Append(formDetail.Base);
                }
                return result.ToString();
            }
        }

        //public string TicketIndex { get; set; }
        public string TicketIndex
        {
            get
            {
                if (lstFormDetail.Count > 0)
                {
                    StringBuilder sb = new StringBuilder(); 
                    int veIndex = 0;
                    int soVe = 0;
                    int veTotal = 0;
                    TicketModel.TicketType? ticketType = null;
                    int employeeTypeID = formDetail.EmployeeTypeID.Value;
                    foreach (USP_GetFromDetail1_Result item in lstFormDetail)
                    {
                        if (ticketType == null || ticketType != TicketModel.DicTicketType[item.Type])
                        {
                            if (ticketType != null)
                            {                                
                                sb.Append(TicketModel.XuatChuoiVe(veIndex, soVe, veTotal, ticketType.Value, employeeTypeID));
                                sb.Append("\r\n");
                            }

                            veIndex = item.TicketIndex.Value;
                            soVe = 0;                            
                            ticketType = TicketModel.DicTicketType[item.Type];
                            veTotal = (int)formDetail.GetType().GetProperty(item.Type).GetValue(item);
                        }
                        soVe += item.TicketCount.Value;                        
                    }                    
                    sb.Append(TicketModel.XuatChuoiVe(veIndex, soVe, veTotal, ticketType.Value, employeeTypeID));
                    return sb.ToString();
                }
                return "";



                //if (formDetail != null)
                //{
                //    int veIndex = formDetail.TicketIndex.Value;
                //    int soVe = lstFormDetail.Select(t => t.TicketCount.Value).Sum();
                //    int veTotal = (int)formDetail.GetType().GetProperty(formDetail.Type).GetValue(formDetail);                    
                //    TicketModel.TicketType ticketType = TicketModel.DicTicketType[formDetail.Type];
                //    int employeeTypeID = formDetail.EmployeeTypeID.Value;
                //    return TicketModel.XuatChuoiVe(veIndex, soVe, veTotal, ticketType, employeeTypeID);                    
                //}
                //return "";
            }
        }

        public USP_GetFromDetail1_Result formDetail { get; set; }
        

        public List<USP_GetFromDetail1_Result> lstFormDetail = new List<USP_GetFromDetail1_Result>(); 

        public static List<ReportModel> GetListReport(List<USP_GetFromDetail1_Result> lstFormDetail, ReportModel.ReportType reportType)
        {
            List<ReportModel> lstReportModel = new List<ReportModel>();
            ReportModel report = null;
            //Sort form detail 
            lstFormDetail = lstFormDetail.OrderBy(i => i.FormID).ThenByDescending(i => i.Type).ThenByDescending(i => i.PID).ThenByDescending(i => i.Relationship).ToList();
            List<FormReportModel> lstFormReportModel = new List<FormReportModel>();
            FormReportModel formReport = null;
            for (int i = 0; i < lstFormDetail.Count; i++)
            {
                USP_GetFromDetail1_Result formDetail = lstFormDetail[i];
                if (report == null || (report != null && report.lstFormReportModel.Count == 10))
                {
                    report = new ReportModel();
                    report.lstFormReportModel = new List<FormReportModel>();
                    report.LoaiReport = reportType;
                    report.FormCode = string.Format("{0}: {1} {2}", formDetail.Type, formDetail.FullNameOffer, formDetail.Route);
                    if (report.FormCode.Length > 50)
                    {
                        report.FormCode = report.FormCode.Substring(0, 49);
                    }
                    lstReportModel.Add(report);                    
                }
                if (formReport == null || (formReport != null && formReport.FormID != formDetail.FormID))
                {
                    formReport = new FormReportModel();
                    formReport.FormID = formDetail.FormID;
                    formReport.formDetail = formDetail;
                    report.lstFormReportModel.Add(formReport);                    
                }                                
                formReport.lstFormDetail.Add(formDetail);
            }
            return lstReportModel;
        }

        //public void SetProperties()
        //{
        //    //Mac dinh co 1 dong mot formdetail
        //    int soDong = 1;


        //    StringBuilder resultFullName = new StringBuilder();
        //    StringBuilder resultBirthday = new StringBuilder();
        //    StringBuilder resultPID = new StringBuilder();
        //    StringBuilder resultRelationship = new StringBuilder();
        //    StringBuilder resultRoute = new StringBuilder();
        //    StringBuilder resultBase = new StringBuilder();            

        //    foreach (var formDetail in lstFormDetail)
        //    {
        //        if (resultFullName.Length > 0)
        //            resultFullName.Append("\r\n");
        //        if (string.IsNullOrEmpty(formDetail.Fullname))
        //        {
        //            resultFullName.Append(" ");
        //        }
        //        else
        //        {
        //            resultFullName.Append(formDetail.Fullname);
        //        }

        //        if (resultFullName.Length > 0 && (resultFullName.Length / 26 + 1) > 1 && (resultFullName.Length / 26 + 1) > soDong)
        //            soDong = (resultFullName.Length / 26 + 1);

        //        if (resultBirthday.Length > 0)
        //            resultBirthday.Append("\r\n");
        //        if (formDetail.Birthday != null)
        //            resultBirthday.Append(formDetail.Birthday.Value.ToString("yyyy"));
        //        else
        //            resultBirthday.Append(" ");

        //        if (resultPID.Length > 0)
        //            resultPID.Append("\r\n");
        //        if (string.IsNullOrEmpty(formDetail.PID))
        //        {
        //            resultPID.Append(" ");
        //        }
        //        else
        //        {
        //            resultPID.Append(formDetail.PID);
        //        }

        //        if (resultRelationship.Length > 0)
        //            resultRelationship.Append("\r\n");
        //        if (string.IsNullOrEmpty(formDetail.Relationship))
        //            resultRelationship.Append("Bản thân");
        //        else
        //            resultRelationship.Append(formDetail.Relationship);

        //        if (resultRoute.Length > 0)
        //            resultRoute.Append("\r\n");
        //        if (string.IsNullOrEmpty(formDetail.Route))
        //            resultRoute.Append(" ");
        //        else
        //            resultRoute.Append(formDetail.Route);

        //        if (resultRoute.Length > 0 && (resultRoute.Length / 16 + 1) > 1 && (resultRoute.Length / 16 + 1) > soDong)
        //            soDong = (resultRoute.Length / 16 + 1);

        //        if (resultBase.Length > 0)
        //            resultBase.Append("\r\n");
        //        if (string.IsNullOrEmpty(formDetail.Base))
        //            resultBase.Append(" ");
        //        else
        //            resultBase.Append(formDetail.Base);

        //        if (soDong > 1)
        //        {
        //            for (int i = 2; i <= soDong; i++)
        //            {
        //                resultBirthday.Append("\r\n");
        //                resultPID.Append("\r\n");
        //                resultBase.Append("\r\n");
        //                resultRelationship.Append("\r\n");
        //                if ((resultFullName.Length / 26 + 1) < i)
        //                {
        //                    resultFullName.Append("\r\n");
        //                }
        //                if ((resultRoute.Length / 26 + 1) < i)
        //                {
        //                    resultRoute.Append("\r\n");
        //                }
        //            }
        //        }
        //    }


        //    if (formDetail != null)
        //    {
        //        FullNameOffer = formDetail.FullNameOffer;
        //    }
        //    else
        //        FullNameOffer = "";

        //    if (formDetail != null && formDetail.YearOffer != null)
        //    {
        //        YearOffer = formDetail.YearOffer.Value.ToString();
        //    }
        //    else
        //        YearOffer = "";
        //    FullName = resultFullName.ToString();
        //    Birthday = resultBirthday.ToString();
        //    PID = resultPID.ToString();
        //    Relationship = resultRelationship.ToString();
        //    Route = resultRoute.ToString();
        //    Base = resultBase.ToString();

        //    int veIndex = formDetail.TicketIndex.Value;
        //    int soVe = lstFormDetail.Select(t => t.TicketCount.Value).Sum();
        //    int veTotal = (int)formDetail.GetType().GetProperty(formDetail.Type).GetValue(formDetail);
        //    TicketModel.TicketType ticketType = TicketModel.DicTicketType[formDetail.Type];
        //    int employeeTypeID = formDetail.EmployeeTypeID.Value;
        //    TicketIndex = TicketModel.XuatChuoiVe(veIndex, soVe, veTotal, ticketType, employeeTypeID);
        //}       
    }
}
