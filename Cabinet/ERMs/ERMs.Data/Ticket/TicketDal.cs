using Erms.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERMs.Data.Ticket;
using System.Collections;

namespace ERMs.Data
{
    public class TicketDal
    {
        public List<Ticket_FormDetail> GetTicketFormDetailByFamily(string CID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var lstTicketFormDetail = new List<Ticket_FormDetail>();
                var lstItem = context.Ticket_Employee.Where(e => e.CID == CID && (e.IsDeleted == null || e.IsDeleted == false)).OrderBy(e => e.RelationshipID);
                Ticket_FormDetail ticketFormDetail = new Ticket_FormDetail();
                foreach (var item in lstItem)
                {
                    ticketFormDetail = new Ticket_FormDetail();
                    ticketFormDetail.FamilyID = item.FamilyID;
                    ticketFormDetail.Fullname = item.Fullname;
                    ticketFormDetail.Relationship = item.Relationship;
                    ticketFormDetail.Birthday = item.Birthday;
                    ticketFormDetail.PID = item.PID;
                    lstTicketFormDetail.Add(ticketFormDetail);
                }
                return lstTicketFormDetail;
            }
        }

        public List<USP_GetFromDetail1_Result> GetTicketFormDetail(string ticketType, string ticketBase, int? employeeType, int? thamnienFrom, int? thamnienTo)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {                
                return context.USP_GetFromDetail1(ticketType, ticketBase,employeeType, thamnienFrom, thamnienTo).ToList();                
            }
        }

        public List<Ticket_FormDetail> GetTicketFormDetailByFormID(string CID, int fromID, bool getFamily)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {                
                var lstTicketFormDetail = context.Ticket_FormDetail.Where(e => e.FormID == fromID && (e.IsDeleted ==null || e.IsDeleted == false)).OrderBy(e => e.Relationship).ToList();
                if (getFamily)
                {
                    var lstItem = context.Ticket_Employee.Where(e => e.CID == CID).OrderBy(e => e.RelationshipID);
                    Ticket_FormDetail ticketFormDetail = new Ticket_FormDetail();
                    foreach (var item in lstItem)
                    {
                        Ticket_FormDetail formDetailExits = lstTicketFormDetail.Where(t => t.Fullname == item.Fullname && t.FamilyID == item.FamilyID && (t.IsDeleted == null || t.IsDeleted == false)).FirstOrDefault();
                        if (formDetailExits == null)
                        {
                            ticketFormDetail = new Ticket_FormDetail();
                            ticketFormDetail.FamilyID = item.FamilyID;
                            ticketFormDetail.Fullname = item.Fullname;
                            ticketFormDetail.Relationship = item.Relationship;
                            ticketFormDetail.Birthday = item.Birthday;
                            ticketFormDetail.PID = item.PID;
                            lstTicketFormDetail.Add(ticketFormDetail);
                        }
                    }
                }
                return lstTicketFormDetail;
            }
        }

        public List<Ticket_Airport> GetTicketAirport()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Ticket_Airport.Where(i => (i.IsDeleted == null || i.IsDeleted != true)).ToList();
            }
        }

        public Ticket_Employee GetTicketEmployee(string CID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {                
                return context.Ticket_Employee.Where(e => e.CID == CID && e.RelationshipID == null && (e.IsDeleted == null || e.IsDeleted == false)).FirstOrDefault();                
            }
        }

        public Ticket_Quota GetTicketBonus(string cID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                Ticket_Quota quota = new Ticket_Quota();
                Ticket_Bonus ticketBonus = context.Ticket_Bonus.Where(t => t.CID == cID && (t.Expired ==null || t.Expired > DateTime.Now) && (t.IsDeleted == null || t.IsDeleted == false)).FirstOrDefault();
                if (ticketBonus != null)
                {
                    ModelUtils.CopyProperties(ticketBonus, quota);
                }
                return quota;
            }
        }

        public List<Ticket_FormDetail> GetTicketFormDetail(DateTime fromdate, DateTime todate, string key)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Ticket_FormDetail.Where(i => (fromdate == null || (fromdate != null && i.Created >= fromdate)) &&
                                                     (todate == null || (todate != null && i.Created <= todate)) &&
                                                     (key == null || i.Fullname.Contains(key) || i.Creator.Contains(key) || i.Creatorid.Contains(key)) &&
                                                     (i.Status == (int)TicketModel.TicketStatus.Processing || i.Status == (int)TicketModel.TicketStatus.Done || i.Status == (int)TicketModel.TicketStatus.Accept) &&
                                                     (i.IsDeleted == null || i.IsDeleted != null && i.IsDeleted == false)).OrderByDescending(i => i.ID).ToList();                
            }
        }

        public void UpdateReportFormCode(Ticket_VNAReport _ticketVNAReport)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Ticket_VNAReport report = context.Ticket_VNAReport.Where(i => i.ID == _ticketVNAReport.ID &&
                                                                             (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                        if (report != null)
                        {
                            report.FormCode = _ticketVNAReport.FormCode;
                            report.Modified = DateTime.Now;
                            report.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            report.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        }                        


                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            }
        }

        public void UpdateTicketFormDetail(Ticket_FormDetail ticketFormDetail)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                ticketFormDetail.Modified = DateTime.Now;
                ticketFormDetail.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                ticketFormDetail.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                context.Entry(ticketFormDetail).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }            
        }

        public Ticket_Quota GetTicketQuota(Ticket_Employee ticketEmployee)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (ticketEmployee.WorkStartDate == null)
                    return new Ticket_Quota();
                int thamNien = DateTime.Now.Year - ticketEmployee.WorkStartDate.Value.Year;
                return context.Ticket_Quota.Where(t => t.EmployeeTypeID == ticketEmployee.EmployeeTypeID && thamNien >= t.FromYear && thamNien < t.ToYear).FirstOrDefault();
            }
        }

        public Ticket_Quota GetTicketQuotaFromTicketDetails(string cID, int? exlusiveFormID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                Ticket_Quota quota = new Ticket_Quota();
                quota.ID90 = quota.ID75 = quota.ID50 = 0;
                var items = from d in context.Ticket_FormDetail
                            where (d.IsDeleted == null || d.IsDeleted == false) && d.Status != (int)TicketModel.TicketStatus.Reject && d.Created.Value.Year == DateTime.Now.Year
                            join f in context.Ticket_Form.Where(t => (t.IsDeleted == null || t.IsDeleted == false)) on d.FormID equals f.ID                             
                            into temp
                            from j in temp.DefaultIfEmpty()
                            where j.CID == cID && (exlusiveFormID == null || exlusiveFormID != null && d.FormID != exlusiveFormID)                                                           
                            select new
                            {
                                TicketCount = d.TicketCount,
                                Type = d.Type
                            };
                foreach (var item in items)
                {
                    if (item.TicketCount != null)
                    {
                        int soLuongVeFrom = (int)quota.GetType().GetProperty(item.Type).GetValue(quota);
                        quota.GetType().GetProperty(item.Type).SetValue(quota, soLuongVeFrom + item.TicketCount.Value);
                        
                        //switch (item.Type)
                        //{
                        //    case TicketModel.ID90:
                        //        quota.ID90 += item.TicketCount.Value;
                        //        break;
                        //    case TicketModel.ID75:
                        //        quota.ID75 += item.TicketCount.Value;
                        //        break;
                        //    case TicketModel.ID50:
                        //        quota.ID50 += item.TicketCount.Value;
                        //        break;
                        //}
                    }
                }
                return quota;
            }
        }

        

        public void SaveTicketForm(TicketFormModel ticketFormModel)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Ticket_Form form = null;
                        switch (ticketFormModel.TicketStatus)
                        {
                            case TicketFormModel.TicketFormStatus.Creating:
                                form = new Ticket_Form();
                                form.CID = ticketFormModel.CID;
                                form.Fullname = ticketFormModel.Fullname;
                                form.Contents = ticketFormModel.Contents;     
                                if (ticketFormModel.OverQuota)
                                    form.Status = (int)TicketFormModel.TicketFormStatus.OverQuota;
                                else
                                    form.Status = (int)TicketFormModel.TicketFormStatus.Waiting;
                                form.Created = DateTime.Now;
                                form.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                form.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                context.Ticket_Form.Add(form);
                                context.SaveChanges();

                                foreach (var formDetail in ticketFormModel.LstFormDetail)
                                {
                                    if (string.IsNullOrEmpty(formDetail.Route))
                                        continue;
                                    formDetail.FormID = form.ID;
                                    formDetail.Created = DateTime.Now;
                                    formDetail.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                    formDetail.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                    formDetail.Status = (int)TicketModel.TicketStatus.Waiting;
                                    context.Ticket_FormDetail.Add(formDetail);
                                }
                                context.SaveChanges();
                                dbContextTransaction.Commit();
                                if (ticketFormModel.OverQuota)
                                    ticketFormModel.TicketStatus = TicketFormModel.TicketFormStatus.OverQuota;
                                else
                                    ticketFormModel.TicketStatus = TicketFormModel.TicketFormStatus.Waiting;
                                ticketFormModel.ID = form.ID;
                                break;
                            case TicketFormModel.TicketFormStatus.Waiting:                                
                            case TicketFormModel.TicketFormStatus.OverQuota:
                                form = context.Ticket_Form.Where(t => t.ID == ticketFormModel.ID).FirstOrDefault();
                                if (form != null)
                                {
                                    form.Modified = DateTime.Now;
                                    form.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                    form.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                    if (ticketFormModel.OverQuota)
                                        form.Status = (int)TicketFormModel.TicketFormStatus.OverQuota;
                                    else
                                        form.Status = (int)TicketFormModel.TicketFormStatus.Waiting;
                                    List<Ticket_FormDetail> lstOldFormDetail = context.Ticket_FormDetail.Where(td => td.FormID == form.ID).ToList();
                                    foreach (var detail in lstOldFormDetail)
                                    {
                                        detail.IsDeleted = true;
                                    }
                                    foreach (var formDetail in ticketFormModel.LstFormDetail)
                                    {
                                        if (string.IsNullOrEmpty(formDetail.Route))
                                            continue;
                                        formDetail.FormID = form.ID;
                                        formDetail.Created = DateTime.Now;
                                        formDetail.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                        formDetail.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                        formDetail.Status = (int)TicketModel.TicketStatus.Waiting;
                                        context.Ticket_FormDetail.Add(formDetail);
                                    }
                                    context.SaveChanges();
                                    dbContextTransaction.Commit();
                                    if (ticketFormModel.OverQuota)
                                        ticketFormModel.TicketStatus = TicketFormModel.TicketFormStatus.OverQuota;
                                    else
                                        ticketFormModel.TicketStatus = TicketFormModel.TicketFormStatus.Waiting;
                                    ticketFormModel.ID = form.ID;
                                }
                                break;
                        }                                               
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();                        
                    }
                }                
            }
        }

        public void RejectTicketForm(TicketFormModel ticketFormModel)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Ticket_Form form = null;                        
                        form = context.Ticket_Form.Where(t => t.ID == ticketFormModel.ID).FirstOrDefault();
                        if (form != null)
                        {
                            form.Modified = DateTime.Now;
                            form.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            form.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            form.Status = (int)TicketFormModel.TicketFormStatus.Reject;
                            form.Contents = ticketFormModel.Contents;                         
                            List<Ticket_FormDetail> lstOldFormDetail = context.Ticket_FormDetail.Where(td => td.FormID == form.ID).ToList();
                            foreach (var detail in lstOldFormDetail)
                            {
                                detail.Status = (int)TicketModel.TicketStatus.Reject;
                            }
                            
                            context.SaveChanges();
                            dbContextTransaction.Commit();                            
                        }                                
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public List<Ticket_Form> GetTicketFormByUserID(DateTime? fromYear, DateTime? toYear)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Ticket_Form.Where(t => t.CID == ERMs.Sys.ConfigurationSetting.UserInfo.Code &&
                            (fromYear == null || t.Created >= fromYear) &&
                            (toYear == null || t.Created <= toYear) &&                            
                            (t.IsDeleted == null || t.IsDeleted == false)).OrderByDescending(t => t.ID).ToList();
            }
        }

        public List<Ticket_Form> GetTicketFormByStatus(TicketFormModel.TicketFormStatus status, DateTime? fromYear, DateTime? toYear)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Ticket_Form.Where(t => t.Status == (int)status &&
                                            (fromYear == null || t.Created >= fromYear) &&
                                            (toYear == null || t.Created <= toYear) &&                                            
                                            t.Status != (int)TicketFormModel.TicketFormStatus.Reject &&
                                            (t.IsDeleted == null || t.IsDeleted == false)).OrderByDescending(t => t.ID).ToList();
            }
        }

        public bool HaveWaitingTicket(string cID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (context.Ticket_Form.Where(t => t.CID == cID && (t.Status == (int)TicketFormModel.TicketFormStatus.Waiting || t.Status == (int)TicketFormModel.TicketFormStatus.OverQuota) && (t.IsDeleted == null || t.IsDeleted == false)).FirstOrDefault() != null)
                    return true;
                return false;                  
            }
        }

        public void SaveVNAReport(ReportModel reportModel)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Ticket_VNAReport report = new Ticket_VNAReport();
                        report.FormCode = reportModel.FormCode;
                        report.Created = DateTime.Now;
                        report.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        report.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        report.FormDate = DateTime.Now;
                        report.Status = (int)ReportModel.ReportStatus.Waiting;
                        report.Type = reportModel.Type;
                        context.Ticket_VNAReport.Add(report);
                        //context.SaveChanges();

                        Ticket_Form ticketForm = null;
                        FormReportModel formReport = null;
                        int formReportIndex = 1;
                        foreach (var formDetail in reportModel.lstFormDetail)
                        {
                            Ticket_FormDetail ticketFormDetail = context.Ticket_FormDetail.Where(t => t.ID == formDetail.ID).FirstOrDefault();
                            if (ticketFormDetail != null)
                            {
                                ticketFormDetail.VNAReportID = report.ID;
                                ticketFormDetail.Status = (int)TicketModel.TicketStatus.Processing;
                                ticketFormDetail.Modified = DateTime.Now;
                                ticketFormDetail.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                ticketFormDetail.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            }
                            if (ticketForm == null || (ticketForm != null && ticketForm.ID != formDetail.FormID))
                            {
                                formReport = new FormReportModel();
                                //formReport.Number = formReportIndex;
                                //formReport.Type = reportModel.Type;
                                formReport.ID = reportModel.ID;
                                formReport.formDetail = formDetail;                                
                                reportModel.lstFormReportModel.Add(formReport);                                
                                formReportIndex++;                                

                                ticketForm = context.Ticket_Form.Where(t => t.ID == formDetail.FormID &&
                                                    t.Status != (int)TicketFormModel.TicketFormStatus.Reject &&
                                                    t.Status != (int)TicketFormModel.TicketFormStatus.Accept &&
                                                    t.Status != (int)TicketFormModel.TicketFormStatus.Processing).FirstOrDefault();
                                if (ticketForm != null)
                                {
                                    ticketForm.Status = (int)TicketFormModel.TicketFormStatus.Processing;
                                    ticketForm.Modified = DateTime.Now;
                                    ticketForm.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                    ticketForm.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                }
                            }

                            formReport.lstFormDetail.Add(formDetail);
                            //formReport.SetProperties();
                        }
                        reportModel.lstFormReportModel = reportModel.lstFormReportModel.OrderBy(i => i.FullNameOffer).ToList();
                        for (int i = 1; i<= reportModel.lstFormReportModel.Count; i++)
                        {
                            reportModel.lstFormReportModel[i - 1].Number = i;
                        }
                        //context.SaveChanges();
                        //dbContextTransaction.Commit();                        
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                    
                }         
            }
        }

        public void SaveVNAReportNew(ReportModel reportModel)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Ticket_VNAReport report = new Ticket_VNAReport();
                        report.FormCode = reportModel.FormCode;
                        report.Created = DateTime.Now;
                        report.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        report.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        report.FormDate = DateTime.Now;
                        report.Status = (int)ReportModel.ReportStatus.Waiting;
                        report.Type = reportModel.Type;
                        context.Ticket_VNAReport.Add(report);
                        context.SaveChanges();
                        int index = 1;
                        foreach (var formReport in reportModel.lstFormReportModel)
                        {                            
                            foreach (var formDetail in formReport.lstFormDetail)
                            {
                                Ticket_FormDetail ticketFormDetail = context.Ticket_FormDetail.Where(t => t.ID == formDetail.ID).FirstOrDefault();
                                if (ticketFormDetail != null)
                                {
                                    ticketFormDetail.VNAReportID = report.ID;
                                    ticketFormDetail.Status = (int)TicketModel.TicketStatus.Processing;
                                    ticketFormDetail.Modified = DateTime.Now;
                                    ticketFormDetail.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                    ticketFormDetail.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                }
                            }
                            Ticket_Form ticketForm = context.Ticket_Form.Where(t => t.ID == formReport.FormID &&
                                                    t.Status != (int)TicketFormModel.TicketFormStatus.Reject &&
                                                    t.Status != (int)TicketFormModel.TicketFormStatus.Accept &&
                                                    t.Status != (int)TicketFormModel.TicketFormStatus.Processing).FirstOrDefault();
                            if (ticketForm != null)
                            {
                                ticketForm.Status = (int)TicketFormModel.TicketFormStatus.Processing;
                                ticketForm.Modified = DateTime.Now;
                                ticketForm.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                ticketForm.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            }
                            formReport.Number = index;
                            index++;
                        }
                        context.SaveChanges();
                        dbContextTransaction.Commit();     




                        //for (int i = 1; i <= reportModel.lstFormReportModel.Count; i++)
                        //{
                        //    reportModel.lstFormReportModel[i - 1].Number = i;
                        //}
                        //Ticket_Form ticketForm = null;
                        //FormReportModel formReport = null;
                        //int formReportIndex = 1;
                        //foreach (var formDetail in reportModel.lstFormDetail)
                        //{
                        //    Ticket_FormDetail ticketFormDetail = context.Ticket_FormDetail.Where(t => t.ID == formDetail.ID).FirstOrDefault();
                        //    if (ticketFormDetail != null)
                        //    {
                        //        ticketFormDetail.VNAReportID = report.ID;
                        //        ticketFormDetail.Status = (int)TicketModel.TicketStatus.Processing;
                        //        ticketFormDetail.Modified = DateTime.Now;
                        //        ticketFormDetail.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        //        ticketFormDetail.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        //    }
                        //    if (ticketForm == null || (ticketForm != null && ticketForm.ID != formDetail.FormID))
                        //    {
                        //        formReport = new FormReportModel();
                        //        //formReport.Number = formReportIndex;
                        //        //formReport.Type = reportModel.Type;
                        //        formReport.ID = reportModel.ID;
                        //        formReport.formDetail = formDetail;
                        //        reportModel.lstFormReportModel.Add(formReport);
                        //        formReportIndex++;

                        //        ticketForm = context.Ticket_Form.Where(t => t.ID == formDetail.FormID &&
                        //                            t.Status != (int)TicketFormModel.TicketFormStatus.Reject &&
                        //                            t.Status != (int)TicketFormModel.TicketFormStatus.Accept &&
                        //                            t.Status != (int)TicketFormModel.TicketFormStatus.Processing).FirstOrDefault();
                        //        if (ticketForm != null)
                        //        {
                        //            ticketForm.Status = (int)TicketFormModel.TicketFormStatus.Processing;
                        //            ticketForm.Modified = DateTime.Now;
                        //            ticketForm.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        //            ticketForm.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        //        }
                        //    }

                        //    formReport.lstFormDetail.Add(formDetail);
                        //    //formReport.SetProperties();
                        //}
                        //reportModel.lstFormReportModel = reportModel.lstFormReportModel.OrderBy(i => i.FullNameOffer).ToList();
                        //for (int i = 1; i <= reportModel.lstFormReportModel.Count; i++)
                        //{
                        //    reportModel.lstFormReportModel[i - 1].Number = i;
                        //}
                        ////context.SaveChanges();
                        ////dbContextTransaction.Commit();                        
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            }
        }


        public List<Ticket_Employee> GetEmployee()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                //ArrayList result = new ArrayList();
                //result.AddRange(context.Ticket_Employee.Where(t => (t.IsDeleted == null || t.IsDeleted == false)).Select(t => new { t.ID, t.Fullname }).ToList());
                //return result;
                return context.Ticket_Employee.Where(t => (t.IsDeleted == null || t.IsDeleted == false) && t.FamilyID == null).OrderBy(i => i.FirstName).ThenBy(t=> t.CID).ToList();                
            }
        }


        public List<Ticket_VNAReport> GetVNAReport(DateTime? fromYear, DateTime? toYear)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {               
                return context.Ticket_VNAReport.Where(t => (t.IsDeleted == null || t.IsDeleted == false) &&
                                                            (fromYear == null || t.Created >= fromYear) &&
                                                                (toYear == null || t.Created <= toYear)).OrderByDescending(t => t.ID).ToList();
            }
        }

        //public List<Ticket_FormDetail> GetTicketFormDetailByReportID(int vnaReportID)
        //{
        //    using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
        //    {
        //        //return context.Ticket_FormDetail.Where(t => t.VNAReportID == vnaReportID && (t.IsDeleted == null || t.IsDeleted == false)).OrderByDescending(t => new { t.FormID, t.ID}).ToList();
        //        return context.USP_GetFromDetailByReportID(vnaReportID).ToList();
        //    }
        //}

        public List<USP_GetFromDetailByReportID_Result> GetTicketFormDetailByReportID(int vnaReportID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                //return context.Ticket_FormDetail.Where(t => t.VNAReportID == vnaReportID && (t.IsDeleted == null || t.IsDeleted == false)).OrderByDescending(t => new { t.FormID, t.ID}).ToList();
                return context.USP_GetFromDetailByReportID(vnaReportID).ToList();
            }
        }

        public void AcceptReport(Ticket_VNAReport ticketVNAReport, List<Ticket_FormDetail> lstFormDetail)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Ticket_VNAReport report = context.Ticket_VNAReport.Where(i => i.ID == ticketVNAReport.ID).FirstOrDefault();
                        if (report != null)
                        {
                            report.Status = (int)ReportModel.ReportStatus.Accept;
                            report.Modified = DateTime.Now;
                            report.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            report.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        }
                        bool allReject = true;                        
                        foreach (var formDetail in lstFormDetail)
                        {
                            Ticket_FormDetail detail = context.Ticket_FormDetail.Where(i => i.ID == formDetail.ID).FirstOrDefault();                            
                            if (detail != null)
                            {
                                detail.Status = formDetail.Status;
                                detail.Remark = formDetail.Remark;
                                detail.Modified = DateTime.Now;
                                detail.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                detail.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;

                                if (formDetail.Status == (int)TicketModel.TicketStatus.Reject)
                                {
                                    Ticket_Form formTempTemp = context.Ticket_Form.Where(i => i.ID == detail.FormID).FirstOrDefault();
                                    if (formTempTemp != null)
                                    {
                                        formTempTemp.Status = (int)TicketFormModel.TicketFormStatus.Reject;
                                        formTempTemp.Modified = DateTime.Now;
                                        formTempTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                        formTempTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                    }
                                }
                                else
                                {
                                    allReject = false;
                                }
                            }                            
                        }
                        context.SaveChanges();
                        Ticket_Form formTemp = null;
                        foreach (var formDetail in lstFormDetail)
                        {
                            if (formTemp == null || formTemp.ID != formDetail.FormID)
                            {
                                formTemp = context.Ticket_Form.Where(i => i.ID == formDetail.FormID &&
                                                                                 (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                                Ticket_FormDetail detailRemain = context.Ticket_FormDetail.Where(i => i.FormID == formTemp.ID && i.Status != (int)TicketModel.TicketStatus.Accept && i.Status != (int)TicketModel.TicketStatus.Done && (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                                if (detailRemain == null)
                                {
                                    formTemp.Status = (int)TicketFormModel.TicketFormStatus.Accept;
                                    formTemp.Modified = DateTime.Now;
                                    formTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                    formTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                }
                            }
                            //if (formDetail.Status == (int)TicketModel.TicketStatus.Reject)
                            //{
                            //    formTemp.Status = (int)TicketFormModel.TicketFormStatus.Reject;
                            //    formTemp.Modified = DateTime.Now;
                            //    formTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            //    formTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            //}                                                     
                        }  
                        //Neu tat ca la reject cap nhat hang report la done
                        //Khong can qua buoc tra ve lai cho tiep vien moi done
                        if (allReject)
                        {
                            if (report != null)
                            {
                                report.Status = (int)ReportModel.ReportStatus.Done;
                                report.Modified = DateTime.Now;
                                report.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                report.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            }
                        }
                        //if (lstFormDetail.Count > 0)
                        //{
                        //    Ticket_FormDetail detail = lstFormDetail[0];
                        //    Ticket_Form form = context.Ticket_Form.Where(i => i.ID == detail.FormID).FirstOrDefault();
                        //    if (form != null)
                        //    {
                        //        if (isReject)
                        //        {
                        //            form.Status = (int)TicketFormModel.TicketFormStatus.Reject;
                        //        }                                
                        //        else
                        //        {
                        //            //Kiem tra cac detail xem coi co cai nao proccess ko
                        //            //Neu co thi khong cap nhat form
                        //            //Neu khong cap nhat dang accept
                        //            Ticket_FormDetail detailRemain = context.Ticket_FormDetail.Where(i => i.FormID == detail.FormID && i.Status == (int)TicketModel.TicketStatus.Processing && (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                        //            if (detailRemain == null)
                        //            {
                        //                form.Status = (int)TicketFormModel.TicketFormStatus.Accept;
                        //            }                                    
                        //        }
                        //    }
                        //}                        
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            }
        }

        public void AcceptReport(Ticket_VNAReport ticketVNAReport, List<USP_GetFromDetailByReportID_Result> lstFormDetail)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Ticket_VNAReport report = context.Ticket_VNAReport.Where(i => i.ID == ticketVNAReport.ID).FirstOrDefault();
                        if (report != null)
                        {
                            report.Status = (int)ReportModel.ReportStatus.Accept;
                            report.Modified = DateTime.Now;
                            report.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            report.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        }
                        bool allReject = true;
                        foreach (var formDetail in lstFormDetail)
                        {
                            Ticket_FormDetail detail = context.Ticket_FormDetail.Where(i => i.ID == formDetail.ID).FirstOrDefault();
                            if (detail != null)
                            {
                                detail.Status = formDetail.Status;
                                detail.Remark = formDetail.Remark;
                                detail.Modified = DateTime.Now;
                                detail.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                detail.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;

                                if (formDetail.Status == (int)TicketModel.TicketStatus.Reject)
                                {
                                    Ticket_Form formTempTemp = context.Ticket_Form.Where(i => i.ID == detail.FormID).FirstOrDefault();
                                    if (formTempTemp != null)
                                    {
                                        formTempTemp.Status = (int)TicketFormModel.TicketFormStatus.Reject;
                                        formTempTemp.Modified = DateTime.Now;
                                        formTempTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                        formTempTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                    }
                                }
                                else
                                {
                                    allReject = false;
                                }
                            }
                        }
                        context.SaveChanges();
                        Ticket_Form formTemp = null;
                        foreach (var formDetail in lstFormDetail)
                        {
                            if (formTemp == null || formTemp.ID != formDetail.FormID)
                            {
                                formTemp = context.Ticket_Form.Where(i => i.ID == formDetail.FormID &&
                                                                                 (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                                Ticket_FormDetail detailRemain = context.Ticket_FormDetail.Where(i => i.FormID == formTemp.ID && i.Status != (int)TicketModel.TicketStatus.Accept && i.Status != (int)TicketModel.TicketStatus.Done && (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                                if (detailRemain == null)
                                {
                                    formTemp.Status = (int)TicketFormModel.TicketFormStatus.Accept;
                                    formTemp.Modified = DateTime.Now;
                                    formTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                    formTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                }
                            }
                            //if (formDetail.Status == (int)TicketModel.TicketStatus.Reject)
                            //{
                            //    formTemp.Status = (int)TicketFormModel.TicketFormStatus.Reject;
                            //    formTemp.Modified = DateTime.Now;
                            //    formTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            //    formTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            //}                                                     
                        }
                        //Neu tat ca la reject cap nhat hang report la done
                        //Khong can qua buoc tra ve lai cho tiep vien moi done
                        if (allReject)
                        {
                            if (report != null)
                            {
                                report.Status = (int)ReportModel.ReportStatus.Done;
                                report.Modified = DateTime.Now;
                                report.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                report.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            }
                        }
                        //if (lstFormDetail.Count > 0)
                        //{
                        //    Ticket_FormDetail detail = lstFormDetail[0];
                        //    Ticket_Form form = context.Ticket_Form.Where(i => i.ID == detail.FormID).FirstOrDefault();
                        //    if (form != null)
                        //    {
                        //        if (isReject)
                        //        {
                        //            form.Status = (int)TicketFormModel.TicketFormStatus.Reject;
                        //        }                                
                        //        else
                        //        {
                        //            //Kiem tra cac detail xem coi co cai nao proccess ko
                        //            //Neu co thi khong cap nhat form
                        //            //Neu khong cap nhat dang accept
                        //            Ticket_FormDetail detailRemain = context.Ticket_FormDetail.Where(i => i.FormID == detail.FormID && i.Status == (int)TicketModel.TicketStatus.Processing && (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                        //            if (detailRemain == null)
                        //            {
                        //                form.Status = (int)TicketFormModel.TicketFormStatus.Accept;
                        //            }                                    
                        //        }
                        //    }
                        //}                        
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            }
        }


        public void UpdateReportWhenDone(USP_GetFromDetailByReportID_Result ticketFormDetail)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Cap nhat status cho form detail
                        Ticket_FormDetail formDetail = context.Ticket_FormDetail.Where(i => i.ID == ticketFormDetail.ID).FirstOrDefault();
                        if (formDetail != null)
                        {
                            formDetail.Status = ticketFormDetail.Status;
                            formDetail.Modified = DateTime.Now;
                            formDetail.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            formDetail.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;                            
                        }

                        //Kiem tra vnareport
                        //Neu con ve chua tra cho tiep vien status = accpet thi khong cap nhat
                        //Neu tat ca la da tra hoac tu choi thi cap nhat status done
                        Ticket_FormDetail formDetailReportRemain = context.Ticket_FormDetail.Where(i => i.ID != ticketFormDetail.ID && 
                                                                            i.VNAReportID == ticketFormDetail.VNAReportID &&
                                                                            i.Status == (int)TicketModel.TicketStatus.Accept).FirstOrDefault();
                        if (formDetailReportRemain == null) // Neu khong con form detail nao chua accept, chi con reject hoac done
                        {
                            Ticket_VNAReport report = context.Ticket_VNAReport.Where(i => i.ID == ticketFormDetail.VNAReportID &&
                                                                             (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                            if (report != null)
                            {
                                report.Status = (int)ReportModel.ReportStatus.Done;
                                report.Modified = DateTime.Now;
                                report.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                report.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            }
                        }

                        //Kiem tra form
                        //Neu con form detail chua tra cho tiep vien status = accpet hoac dang process thi khong cap nhat
                        //Neu tat ca la da tra hoac tu choi thi cap nhat status done, chi tru truong hop reject
                        Ticket_FormDetail formDetailFormRemain = context.Ticket_FormDetail.Where(i => i.ID != ticketFormDetail.ID &&
                                                                            i.FormID == ticketFormDetail.FormID &&
                                                                            i.Status != (int)TicketModel.TicketStatus.Reject &&
                                                                            i.Status != (int)TicketModel.TicketStatus.Done &&
                                                                            (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                        if (formDetailFormRemain == null) // Neu khong con form detail nao van con trang thai accept hoac trang thai process hoac waiting
                        {
                            Ticket_Form form = context.Ticket_Form.Where(i => i.ID == ticketFormDetail.FormID &&
                                                                             (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                            if (form != null && form.Status != (int)TicketFormModel.TicketFormStatus.Reject)
                            {
                                form.Status = (int)TicketFormModel.TicketFormStatus.Done;
                                form.Modified = DateTime.Now;
                                form.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                form.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            }
                        }

                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            }
        }

        public void DenyReport(Ticket_VNAReport _ticketVNAReport, List<Ticket_FormDetail> lstFormDetail)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Ticket_VNAReport report = context.Ticket_VNAReport.Where(i => i.ID == _ticketVNAReport.ID &&
                                                                             (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                        if (report != null)
                        {
                            report.IsDeleted = true;                            
                            report.Modified = DateTime.Now;
                            report.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            report.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        }

                        foreach (var formDetail in lstFormDetail)
                        {
                            Ticket_FormDetail formDetailUpdate = context.Ticket_FormDetail.Where(i => i.ID == formDetail.ID).FirstOrDefault();
                            if (formDetailUpdate != null)
                            {
                                formDetailUpdate.VNAReportID = null;
                                formDetailUpdate.Status = (int)TicketModel.TicketStatus.Waiting;
                                formDetailUpdate.Remark = "";
                                formDetailUpdate.Modified = DateTime.Now;
                                formDetailUpdate.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                formDetailUpdate.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            }                            
                        }
                        context.SaveChanges();

                        //Kiem tra cac form detail cua form xem co cai nao bi reject khong
                        //Neu co thi khong update form vi form do da bi reject
                        //Neu khong thi update form sang Waiting
                        Ticket_Form form = null;
                        foreach (var formDetail in lstFormDetail)
                        {
                            if (form == null || form.ID != formDetail.FormID)
                            {
                                form = context.Ticket_Form.Where(i => i.ID == formDetail.FormID &&
                                                                                 (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                                Ticket_FormDetail formDetailFromRemain = context.Ticket_FormDetail.Where(i => i.ID != formDetail.ID &&
                                                                            i.FormID == formDetail.FormID &&
                                                                            i.Status != (int)TicketModel.TicketStatus.Waiting).FirstOrDefault();
                                if (formDetailFromRemain == null)
                                {
                                    form.Status = (int)TicketFormModel.TicketFormStatus.Waiting;
                                    form.Modified = DateTime.Now;
                                    form.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                    form.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                }
                            }
                        }
                        //formDetailFromRemain = context.Ticket_FormDetail.Where(i => i.ID != formDetail.ID &&
                        //                                                    i.FormID == formDetail.FormID &&
                        //                                                    i.Status != (int)TicketModel.TicketStatus.Waiting).FirstOrDefault();
                        //if (formDetailFromRemain == null)   //ko co cai nao khac waiting thi updat form waiting
                        //{
                        //    Ticket_Form form = context.Ticket_Form.Where(i => i.ID == formDetail.FormID &&
                        //                                                 (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                        //    if (form != null)
                        //    {
                        //        form.Status = (int)TicketFormStatus.Waiting;
                        //        form.Modified = DateTime.Now;
                        //        form.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        //        form.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        //    }
                        //}



                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            }
        }

        public void DenyReport(Ticket_VNAReport _ticketVNAReport, List<USP_GetFromDetailByReportID_Result> lstFormDetail)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Ticket_VNAReport report = context.Ticket_VNAReport.Where(i => i.ID == _ticketVNAReport.ID &&
                                                                             (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                        if (report != null)
                        {
                            report.IsDeleted = true;
                            report.Modified = DateTime.Now;
                            report.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            report.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        }

                        foreach (var formDetail in lstFormDetail)
                        {
                            Ticket_FormDetail formDetailUpdate = context.Ticket_FormDetail.Where(i => i.ID == formDetail.ID).FirstOrDefault();
                            if (formDetailUpdate != null)
                            {
                                formDetailUpdate.VNAReportID = null;
                                formDetailUpdate.Status = (int)TicketModel.TicketStatus.Waiting;
                                formDetailUpdate.Remark = "";
                                formDetailUpdate.Modified = DateTime.Now;
                                formDetailUpdate.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                formDetailUpdate.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            }
                        }
                        context.SaveChanges();

                        //Kiem tra cac form detail cua form xem co cai nao bi reject khong
                        //Neu co thi khong update form vi form do da bi reject
                        //Neu khong thi update form sang Waiting
                        Ticket_Form form = null;
                        foreach (var formDetail in lstFormDetail)
                        {
                            if (form == null || form.ID != formDetail.FormID)
                            {
                                form = context.Ticket_Form.Where(i => i.ID == formDetail.FormID &&
                                                                                 (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                                Ticket_FormDetail formDetailFromRemain = context.Ticket_FormDetail.Where(i => i.ID != formDetail.ID &&
                                                                            i.FormID == formDetail.FormID &&
                                                                            i.Status != (int)TicketModel.TicketStatus.Waiting).FirstOrDefault();
                                if (formDetailFromRemain == null)
                                {
                                    form.Status = (int)TicketFormModel.TicketFormStatus.Waiting;
                                    form.Modified = DateTime.Now;
                                    form.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                    form.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                }
                            }
                        }
                        //formDetailFromRemain = context.Ticket_FormDetail.Where(i => i.ID != formDetail.ID &&
                        //                                                    i.FormID == formDetail.FormID &&
                        //                                                    i.Status != (int)TicketModel.TicketStatus.Waiting).FirstOrDefault();
                        //if (formDetailFromRemain == null)   //ko co cai nao khac waiting thi updat form waiting
                        //{
                        //    Ticket_Form form = context.Ticket_Form.Where(i => i.ID == formDetail.FormID &&
                        //                                                 (i.IsDeleted == null || i.IsDeleted == false)).FirstOrDefault();
                        //    if (form != null)
                        //    {
                        //        form.Status = (int)TicketFormStatus.Waiting;
                        //        form.Modified = DateTime.Now;
                        //        form.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        //        form.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        //    }
                        //}



                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            }
        }


        public Ticket_VNAReport GetTicketVNAReportByID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Ticket_VNAReport.Where(t => (t.IsDeleted == null || t.IsDeleted == false) && t.ID == iD).FirstOrDefault();
            }
        }

        #region Booking
        public List<USP_Ticket_Booking_Result> GetBooking(DateTime fromdate, DateTime todate, string keyword)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var models = context.USP_Ticket_Booking(fromdate,todate,keyword).ToList();

                return models;
            }
          
        }

        public void UpdateTicketBookPending(List<USP_Ticket_Booking_Result> lstBookingPending)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {                
                foreach (var booking in lstBookingPending)
                {
                    Ticket_Booking tb = context.Ticket_Booking.Where(b => b.ID == booking.ID).FirstOrDefault();
                    if (tb != null)
                    {
                        tb.Pending = booking.Pending;
                        tb.Modified = DateTime.Now;
                        tb.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        tb.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    }
                }

                context.SaveChanges();                                                            
            }
        }
        #endregion

        public void UpdateEmployeeFromVietnamRedant(string iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (VietnamRedantEntities contextVietnamRedant = new VietnamRedantEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforVietnamRedantModel))
                {
                    var lstEmployee = contextVietnamRedant.PView_giadinh1.Where(i => i.mans == iD).ToList();
                    foreach (var employee in lstEmployee)
                    {
                        var ticketEmployee = context.Ticket_Employee.Where(i => i.CID == employee.mans && i.FamilyID == employee.giadinhid).FirstOrDefault();
                        if (ticketEmployee == null)
                        {
                            Ticket_Employee addedEmployee = new Ticket_Employee();
                            addedEmployee.CID = employee.mans;
                            addedEmployee.EmployeeTypeID = employee.loains;
                            addedEmployee.EmployeeType = employee.loainhansu;
                            addedEmployee.FamilyID = employee.giadinhid;
                            addedEmployee.Fullname = employee.hoten;
                            addedEmployee.Relationship = employee.quanhe;
                            addedEmployee.RelationshipID = employee.loaiquanhe;
                            addedEmployee.Birthday = employee.ngaysinh;
                            addedEmployee.PID = employee.cmnd_so;
                            addedEmployee.DepartmentID = employee.bophanlamviec.ToString();
                            addedEmployee.Department = employee.bophan;
                            addedEmployee.Retired = employee.nghiviec;
                            addedEmployee.Seniority = null;
                            addedEmployee.WorkStartDate = employee.bienche_tct;
                            addedEmployee.JobTitle = null;
                            addedEmployee.FirstName = employee.Firstname;
                            context.Ticket_Employee.Add(addedEmployee);
                        }
                        else
                        {
                            ticketEmployee.CID = employee.mans;
                            ticketEmployee.EmployeeTypeID = employee.loains;
                            ticketEmployee.EmployeeType = employee.loainhansu;
                            ticketEmployee.FamilyID = employee.giadinhid;
                            ticketEmployee.Fullname = employee.hoten;
                            ticketEmployee.Relationship = employee.quanhe;
                            ticketEmployee.RelationshipID = employee.loaiquanhe;
                            ticketEmployee.Birthday = employee.ngaysinh;
                            ticketEmployee.PID = employee.cmnd_so;
                            ticketEmployee.DepartmentID = employee.bophanlamviec.ToString();
                            ticketEmployee.Department = employee.bophan;
                            ticketEmployee.Retired = employee.nghiviec;
                            ticketEmployee.Seniority = null;
                            ticketEmployee.WorkStartDate = employee.bienche_tct;
                            ticketEmployee.JobTitle = null;
                            ticketEmployee.FirstName = employee.Firstname;
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        public Ticket_Airport UpdateAirport(Ticket_Airport item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    context.Ticket_Airport.Add(item);
                }
                else
                {
                    Ticket_Airport model = context.Ticket_Airport.Where(o => o.ID == item.ID).FirstOrDefault();
                    if (model != null)
                    {
                        model.Code = item.Code;
                        model.Name = item.Name;
                        model.Country = item.Country;
                        model.Route = item.Route;
                        model.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        model.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        model.Modified = DateTime.Now;
                    }
                }

                context.SaveChanges();
                return item;
            }
        }
    }
}
