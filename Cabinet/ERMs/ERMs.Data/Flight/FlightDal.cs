using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Flight
{
    public class FlightDal
    {

        
        public FlightDal()
        {
        
        }
        public List<FlightInfoModel> GetFlights(DateTime fromdate, DateTime todate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<FlightInfoModel> items = new List<FlightInfoModel>();
                var query = context.CR_FlightInfo.Where(o => o.Date >= fromdate && o.Date <= todate && (o.IsDeleted != true));
                foreach (var item in query)
                {
                    FlightInfoModel model = new FlightInfoModel().ToModel(item);
                    //API_USP_GetCrewDuty_by_Flight2_Result purser = context.API_USP_GetCrewDuty_by_Flight2(item.FlightID).FirstOrDefault();

                    //if (purser != null)
                    //    model.Purser = string.Format("{0} ({1})",purser.FirstNameVn,purser.CrewID);

                    items.Add(model);
                }

                return items;
            }
        }

        public List<CR_FlightInfo> GetFlights(DateTime fromdate, DateTime todate, string key)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_FlightInfo.Where(o => o.Date >= fromdate && o.Date <= todate && o.IsDeleted != true && (key == null || (key != null && (o.FlightNo.Contains(key) || o.Routing.Contains(key))))).ToList();
            }
        }

        public CR_FlightInfo GetFlight(int flightid)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                CR_FlightInfo item;
                var query = context.CR_FlightInfo.Where(o => o.FlightID == flightid);
                item = query.Single();
                return item;
            }
        }

        public CR_FlightInfo Verify(CR_FlightInfo item)
        {

            return null;
        }


        public List<CR_Flight_Crew> GetCrews(int flightID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<CR_Flight_Crew> items = context.CR_Flight_Crew.Where(o => o.FlightID == flightID).ToList();
                return items;
            }
        }

        public List<API_CR_USP_GetFlightCrew_Result> GetFlightCrewByFlightID(int flightID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.API_CR_USP_GetFlightCrew(flightID, null).ToList();
            }
        }

        public List<FlightInfoModel> GetFlights(DateTime? fromdate, DateTime? todate, string keyword, string crewID, bool? isGetAll, bool? isExclamation, bool? isGetDelete, int? pageNumber, int? pageSize)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<FlightInfoModel> items = new List<FlightInfoModel>();
                var query = context.API_CR_USP_GetFlightExclamationTask(fromdate, todate, crewID, isGetAll, isExclamation, isGetDelete, pageNumber, pageSize);
                //var query = context.API_CR_USP_GetFlight_ByKeyword(fromdate, todate, keyword, crewID, isGetAll, pageNumber, pageSize);            
                //var query = context.CR_FlightInfo.Where(o => o.Date >= fromdate && o.Date <= todate && (o.IsDeleted == null || (o.IsDeleted != null && o.IsDeleted != true)));
                foreach (var item in query)
                {
                    items.Add(new FlightInfoModel().ToModel(item));
                }

                return items;
            }
        }

        public CR_Flight_Dutyfree GetDutyFreeByFlightID(int flightID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_Flight_Dutyfree.Where(i => i.FlightID == flightID).FirstOrDefault();
            }
        }

        public CR_FlightInfo GetFlightByCondition(string flightNo, string routing, DateTime date)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_FlightInfo.Where(i => i.FlightNo == flightNo && i.Routing == routing && EntityFunctions.TruncateTime(i.Date) == EntityFunctions.TruncateTime(date)).FirstOrDefault();
            }
        }

        public void UpdateListDutyFree(List<CR_Flight_Dutyfree> lstUpdatedDutyFree)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                foreach (var dutyFree in lstUpdatedDutyFree)
                {
                    context.Entry(dutyFree).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public List<FlightInfoExModel> GetFlightsExternalUnit(DateTime? fromdate, DateTime? todate, string keyword)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {                
                var lstFlightInfo = context.CR_FlightInfo.Where(o => o.Date >= fromdate.Value && o.Date <= todate.Value &&
                (o.IsDeleted == null || (o.IsDeleted != null && o.IsDeleted != true)) &&
                (keyword == null || o.FlightNo.Contains(keyword) || o.Routing.Contains(keyword))).OrderBy(i => i.Departed);
                List<FlightInfoExModel> lstFlightInfoExModel = new List<FlightInfoExModel>();
                foreach (var fligtInfoModel in lstFlightInfo)
                {
                    lstFlightInfoExModel.Add(new FlightInfoExModel().ToCustomModel(fligtInfoModel));
                }
                return lstFlightInfoExModel;
            }
        }

        public List<FlightInfoModel> GetFlights(DateTime? fromdate, DateTime? todate, string keyword, string crewID, bool? isGetAll, bool? isExclamation, bool? isGetDelete, bool isGetLBMB, int? pageNumber, int? pageSize)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<FlightInfoModel> items = new List<FlightInfoModel>();
                var query = context.API_CR_USP_GetFlightExclamationTask1(fromdate, todate, crewID, isGetAll, isExclamation, isGetDelete, isGetLBMB, pageNumber, pageSize);
                //var query = context.API_CR_USP_GetFlight_ByKeyword(fromdate, todate, keyword, crewID, isGetAll, pageNumber, pageSize);            
                //var query = context.CR_FlightInfo.Where(o => o.Date >= fromdate && o.Date <= todate && (o.IsDeleted == null || (o.IsDeleted != null && o.IsDeleted != true)));
                foreach (var item in query)
                {
                    items.Add(new FlightInfoModel().ToModel(item));
                }

                return items;
            }
        }



        public List<CR_FlightInfo> GetFlightsAdmin(DateTime fromdate, DateTime todate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var query = context.CR_FlightInfo.Where(o => o.Date >= fromdate && o.Date <= todate);
                return query.ToList();
            }
        }

        public List<API_CR_USP_GetFlightCrewAdmin_Result> GetFlightCrewByFlightIDAdmin(int flightID, bool isGetDelete)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.API_CR_USP_GetFlightCrewAdmin(flightID, null, isGetDelete).OrderBy(i => i.IsDeleted).ToList();
            }
        }

        public List<API_CR_USP_GetFlightCrewAdminExternalUnit_Result> GetFlightCrewByFlightIDAdminExternalUnit(int flightID, bool isGetDelete)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.API_CR_USP_GetFlightCrewAdminExternalUnit(flightID, null, isGetDelete).OrderBy(i => i.IsDeleted).ToList();
            }
        }

        public CR_FlightInfo GetFlightInfoByFlightID(int flightID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    CR_FlightInfo flightInfo = context.CR_FlightInfo.Where(f => f.FlightID == flightID).FirstOrDefault();
                    return flightInfo;
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<FlightDutyModel> GetFlightDutyFree(DateTime fromdate, DateTime todate, string keyword)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    List<FlightDutyModel> lstFlightDuty = new List<FlightDutyModel>();
                    var query = context.USP_GetFlight_Dutyfree(fromdate, todate, keyword).ToList();
                    foreach (var item in query)
                    {
                        lstFlightDuty.Add(new FlightDutyModel().ToCustomModel(item));
                    }
                    return lstFlightDuty;
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<Sys_Flight_Sync> GetFlightSync(DateTime? fromdate, DateTime? todate, bool loadTime)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.Sys_Flight_Sync.Where(f =>
                                               (fromdate == null || f.Fromdate >= fromdate) &&
                                               (todate == null || f.Fromdate <= todate) &&
                                               ((loadTime == true && f.LoadTime != null) || (loadTime == false && f.LoadTime == null))).OrderByDescending(i => i.Created).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool UpdateFlightInfo(CR_FlightInfo flightInfo)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    context.Entry(flightInfo).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public CR_Flight_Crew GetFlightCrewByFlightCrewID(int id)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    CR_Flight_Crew flightCrew = context.CR_Flight_Crew.Where(f => f.ID == id).FirstOrDefault();
                    return flightCrew;
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool UpdateFlightCrew(CR_Flight_Crew flightCrew)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    context.Entry(flightCrew).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void AddFlightSync(List<Sys_Flight_Sync> lstAddedFlightSync)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    context.Sys_Flight_Sync.AddRange(lstAddedFlightSync);
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void AddFlightSync(Sys_Flight_Sync addedFlightSync)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    context.Sys_Flight_Sync.Add(addedFlightSync);
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        

        public List<API_CR_USP_GetBKFlightCrew_Result> GetBKFlightCrew(string flightNo, string routing, DateTime? date)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    string fromPlace = routing.Substring(0, routing.IndexOf("-"));
                    string endPlace = routing.Substring(routing.IndexOf("-") + 1);
                    return context.API_CR_USP_GetBKFlightCrew(flightNo, date, fromPlace, endPlace).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public void ReloadFlightDutyfree(DateTime fromdate, DateTime todate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {                    
                    context.USP_ReloadFlight_Dutyfree(fromdate, todate, ERMs.Sys.ConfigurationSetting.UserInfo.Code, ERMs.Sys.ConfigurationSetting.UserInfo.ShortName);
                }
                catch
                {
                    throw;
                }
            }
        }

        public void RemoveFlightSync(List<Sys_Flight_Sync> lstRemovedFlightSync)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    context.Sys_Flight_Sync.RemoveRange(lstRemovedFlightSync);
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public CR_Trip GetTripByCodeFly(string codeFly)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.CR_Trip.Where(t => t.CodeFly == codeFly).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool InsertFlightCrewFromBkFlightCrew(API_CR_USP_GetBKFlightCrew_Result bkFlightCrew)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    CR_Flight_Crew flightCrew = new CR_Flight_Crew();
                    var typeOfA = bkFlightCrew.GetType();
                    var typeOfB = flightCrew.GetType();
                    foreach (var propertyOfA in typeOfA.GetProperties())
                    {
                        var propertyOfB = typeOfB.GetProperty(propertyOfA.Name);
                        if (propertyOfB != null)
                            propertyOfB.SetValue(flightCrew, propertyOfA.GetValue(bkFlightCrew));
                    }
                    flightCrew.ID = 0;
                    context.CR_Flight_Crew.Add(flightCrew);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void UpdateFlightInfoNote(FlightInfoModel item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    CR_FlightInfo flightInfo = context.CR_FlightInfo.Where(i => i.FlightID == item.FlightID).FirstOrDefault();
                    if (flightInfo != null)
                    {
                        flightInfo.Modified = DateTime.Now;
                        flightInfo.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        flightInfo.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        flightInfo.SpecialInfo = item.SpecialInfo;
                    }
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<API_CR_USP_Flight_FinalReport_Get_Category_Result> GetFlightFinalReportCategory()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_Flight_FinalReport_Get_Category().ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<API_CR_USP_GetFlightFinalReport_Result> GetFlightFinalReport(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    if (fromFlightDate != null && toFlightDate != null)
                        return context.API_CR_USP_GetFlightFinalReport(fromdate, todate).Where(i => i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false)).Where(i => i.Date >= fromFlightDate && i.Date <= toFlightDate).OrderByDescending(i => i.Modified).ToList();
                    else
                        return context.API_CR_USP_GetFlightFinalReport(fromdate, todate).Where(i => i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false)).OrderByDescending(i => i.Modified).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public void AddFligthCrew(List<CR_Flight_Crew> lstCrewAddToDB)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    context.CR_Flight_Crew.AddRange(lstCrewAddToDB);
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<API_CR_USP_GetFlightFinalReport3_Result> GetFlightFinalReport(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate, DateTime? fromDepartmentCreated, DateTime? toDepartmentCreated, DateTime? fromDepartmentReplied, DateTime? toDepartmentReplied, int? emergency, int? reportStatus, string category, int? departmentID, string replier)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetFlightFinalReport3(fromdate, todate, fromFlightDate, toFlightDate, fromDepartmentCreated, toDepartmentCreated, fromDepartmentReplied, toDepartmentReplied, emergency, reportStatus, false, category, departmentID, replier).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<API_CR_USP_GetFlightFinalReport5_Result> GetFlightFinalReport(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate, DateTime? fromDepartmentCreated, DateTime? toDepartmentCreated, DateTime? fromDepartmentReplied, DateTime? toDepartmentReplied, DateTime? fromReplied, DateTime? toReplied, int? emergency, int? reportStatus, string category, int? departmentID, string replier)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetFlightFinalReport5(fromdate, todate, fromFlightDate, toFlightDate, fromDepartmentCreated, toDepartmentCreated, fromDepartmentReplied, toDepartmentReplied, fromReplied, toReplied, emergency, reportStatus, false, category, departmentID, replier).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<API_CR_USP_GetFlightFinalReport2_Result> GetFlightFinalReport(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate, bool isGetDelete, bool isGetAllCategory, string strCategory)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetFlightFinalReport2(fromdate, todate, fromFlightDate, toFlightDate, isGetDelete, isGetAllCategory, strCategory).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<API_CR_USP_GetFlightFinalReportDepartment_Result> GetFlightFinalReportDeparment(DateTime? fromdate, DateTime? todate, DateTime? fromFlightdate, DateTime? toFlightdate, bool isGetDelete, bool isGetAllCategory, int category, bool isGetAllDepartment, int departmentID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetFlightFinalReportDepartment(fromdate, todate, fromFlightdate, toFlightdate, isGetDelete, isGetAllCategory, category, isGetAllDepartment, departmentID).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<API_CR_USP_GetFlightCrew2_Result> GetFlightCrew2ByFlightID(int flightID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.API_CR_USP_GetFlightCrew2(flightID, null).ToList();
            }
        }

        public CR_Flight_FinalReport GetFlightFinalReportByID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.CR_Flight_FinalReport.Where(i => i.ID == iD && (i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false))).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        public API_CR_USP_GetFlightFinalReportByID_Result GetFullFlightFinalReportByID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetFlightFinalReportByID(iD).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<EX_Attachment> GetFlightFinalReportAttachmentByGroupID(int groupID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.EX_Attachment.Where(i => i.GroupID == groupID).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public void UpdateFlightFinalReportStatus(int id, int reportStatus, int userID, string userName)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    CR_Flight_FinalReport flightFinalReport = context.CR_Flight_FinalReport.Where(i => i.ID == id).FirstOrDefault();
                    if (flightFinalReport != null)
                    {
                        flightFinalReport.ReportStatus = reportStatus;
                        flightFinalReport.Modified = DateTime.Now;
                        flightFinalReport.Modifier = userName;
                        flightFinalReport.Modifierid = userID;
                        flightFinalReport.Replierid = userID.ToString();
                        flightFinalReport.Replied = DateTime.Now;
                        flightFinalReport.Replier = userName;
                    }
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void AddFinalReportRepliedLog(CR_Flight_FinalReport_Replied_Log log)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    context.CR_Flight_FinalReport_Replied_Log.Add(log);
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void UpdateFlightFinalReport(CR_Flight_FinalReport flightFinalReport)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    context.Entry(flightFinalReport).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<FlightAssessmentModel> GetListFlightAssessment(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    List<FlightAssessmentModel> lstFlightAssessment = new List<FlightAssessmentModel>();
                    var items = context.API_CR_USP_GetAssessmentList2(fromdate, todate, fromFlightDate, toFlightDate).ToList();
                    foreach (var item in items)
                    {
                        lstFlightAssessment.Add(new FlightAssessmentModel().ToModel(item));
                    }
                    return lstFlightAssessment;
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<ExamineeModel> GetExaminee()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var query = context.Sys_Account.Where(q => q.IsDeleted != null || q.IsDeleted != true);                
                return query.Select(q => new ExamineeModel { CrewID = q.CrewID, FirstNameVn = q.FirstNameVn, LastNameVn = q.LastNameVn }).ToList();
            }
        }

        public void deleteFlightAssessment(List<FlightAssessmentModel> lstFlightAssessment)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    foreach (var flightAssessment in lstFlightAssessment)
                    {
                        CR_Flight_Assessment deleteAssessment = context.CR_Flight_Assessment.Where(i => i.ID == flightAssessment.ID).FirstOrDefault();
                        if (deleteAssessment != null)
                        {
                            deleteAssessment.IsDeleted = true;
                            deleteAssessment.Modified = DateTime.Now;
                            deleteAssessment.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            deleteAssessment.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                            var lstAssessmentItemDeleted = context.CR_Flight_Assessment_Items.Where(i => i.FlightAssessmentID == deleteAssessment.ID).ToList();
                            lstAssessmentItemDeleted.ForEach(a =>
                            {
                                a.IsDeleted = true;
                                a.Modified = DateTime.Now;
                                a.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                a.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                            });
                        }
                    }
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<CR_Flight_Assessment_Items> GetFlightInfoByFlightAssessmentID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.CR_Flight_Assessment_Items.Where(i => i.FlightAssessmentID == iD).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<API_CR_USP_GetFlightAssessmentAvgScore_Result> GetFlightAssessmentAvgScore(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetFlightAssessmentAvgScore(fromdate, todate, fromFlightDate, toFlightDate).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<API_CR_USP_GetAssessmentTotal_Result> GetFlightAssessmentToTal(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetAssessmentTotal(fromdate, todate, fromFlightDate, toFlightDate).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<API_CR_USP_GetAssessmentAvgScoreByQuestion_Result> GetAssessmentAvgScoreByQuestion(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetAssessmentAvgScoreByQuestion(fromdate, todate, fromFlightDate, toFlightDate).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<API_CR_USP_GetAssAvgScoreGroupRouting_Result> GetAssAvgScoreGroupRouting(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetAssAvgScoreGroupRouting(fromdate, todate, fromFlightDate, toFlightDate).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<API_CR_USP_GetAssAvgScoreTypeTVRouting_Result> GetAssAvgScoreTypeTVRouting(DateTime? fromdate, DateTime? todate, DateTime? fromFlightDate, DateTime? toFlightDate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetAssAvgScoreTypeTVRouting(fromdate, todate, fromFlightDate, toFlightDate).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<HR_Department> GetDepartment()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.HR_Department.Where(i => i.Key != "ALL" && (i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false))).ToList();
            }
        }

        public void AddFlightFinalReportDepartment(CR_Flight_FinalReport_Department fd)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    context.CR_Flight_FinalReport_Department.Add(fd);
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result> GetFlightFinalReportDeparmentByFinalReportID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID(iD).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }



        public void UpdateFlightFinalReportDepartment(API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result flightFinalReportDepartment)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    CR_Flight_FinalReport_Department fd = context.CR_Flight_FinalReport_Department.Where(i => i.ID == flightFinalReportDepartment.ID).FirstOrDefault();
                    if (fd != null)
                    {
                        fd.ReplyInfo = flightFinalReportDepartment.ReplyInfo;
                        fd.Replierid = flightFinalReportDepartment.Replierid;
                        fd.Replied = flightFinalReportDepartment.Replied;
                        fd.Replier = flightFinalReportDepartment.Replier;
                    }
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }



        public List<HR_Department_Employee> GetDepartmentByEmployeeID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.HR_Department_Employee.Where(i => i.EmployeeID == iD).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }



        public List<CR_Flight_FinalReport_Replied_Log> GetFinalReportRepliedLogByFinalReportID(int finalReportID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_Flight_FinalReport_Replied_Log.Where(i => i.FinalReportID == finalReportID).ToList();
            }
        }

        public List<CR_Flight_FinalReport_Category> GetFinalReportCategory()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_Flight_FinalReport_Category.Where(i => i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false)).ToList();
            }
        }

        public void AddCategory(CR_Flight_FinalReport_Category category)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                context.CR_Flight_FinalReport_Category.Add(category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(CR_Flight_FinalReport_Category category)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<CR_Flight_FinalReport_SubCategory> GetFinalReportSubCategory()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_Flight_FinalReport_SubCategory.Where(i => i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false)).ToList();
            }
        }

        public List<CR_Flight_FinalReport_SubCategory> GetFinalReportSubCategoryByCateogryID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_Flight_FinalReport_SubCategory.Where(i => (i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false)) && i.CategoryID == iD).ToList();
            }
        }

        public void AddSubCategory(CR_Flight_FinalReport_SubCategory subcategory)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                context.CR_Flight_FinalReport_SubCategory.Add(subcategory);
                context.SaveChanges();
            }
        }

        public void UpdateSubCategory(CR_Flight_FinalReport_SubCategory category)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdateFlightInfoCrewTaskStatusByFlighID(int? flightID, int crewTaskStatus)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                CR_FlightInfo flightInfo = context.CR_FlightInfo.Where(f => f.FlightID == flightID).FirstOrDefault();
                if (flightInfo != null)
                {
                    flightInfo.CrewTaskStatus = crewTaskStatus;
                }
                context.SaveChanges();
            }
        }

        public List<Sys_Crew_Task_Category> GetCrewTaskCategory(int category)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Crew_Task_Category.Where(c => c.Category == category).ToList();
            }
        }

        #region Co cau may bay
        public List<CR_Airplane_Crew> GetAirplaneCrew()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                //return context.CR_Airplane_Crew.Where(i => i.Expired == null || (i.Expired != null && i.Expired > DateTime.Now)).OrderBy(i => i.Aircraft).ThenBy(i => i.Routing).ThenBy(i => i.Routing).ToList();
                return context.CR_Airplane_Crew.Where(i => i.Expired == null || (i.Expired != null && i.Expired > DateTime.Now)).OrderBy(i => i.Aircraft).ThenBy(i => i.Prior).ToList();
            }
        }

        public CR_Airplane_Crew UpdateAirplaneCrew(CR_Airplane_Crew item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    context.CR_Airplane_Crew.Add(item);
                }
                else
                {
                    item.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Modified = DateTime.Now;
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }

                context.SaveChanges();
                return item;
            }
        }
        #endregion

        public API_CR_USP_GetFlightCrewAdmin_Result UpdateDutyFree(API_CR_USP_GetFlightCrewAdmin_Result item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    CR_Flight_Crew flightCrew = context.CR_Flight_Crew.Where(i => i.ID == item.ID).FirstOrDefault();
                    string oldDutyFree = flightCrew.DutyFree;
                    flightCrew.DutyFree = item.DutyFree;
                    item.Modified = flightCrew.Modified = DateTime.Now;
                    item.Modifierid = flightCrew.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Modifier = flightCrew.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;

                    CR_Crew_Task_Update_Log log = new CR_Crew_Task_Update_Log();
                    log.FlightID = flightCrew.FlightID;
                    log.UserName = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    log.Description = string.Format("DutyFree, ID: {0}, OldDutyFree: {1}, NewDutyFree: {2}", flightCrew.ID, oldDutyFree, flightCrew.DutyFree);
                    log.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    log.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    log.Created = DateTime.Now;
                    context.CR_Crew_Task_Update_Log.Add(log);

                    context.SaveChanges();

                    return item;
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<FlightInfoModel> GetFlightCrewHistory(string crewID, DateTime fromdate, DateTime todate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return
                            (from c in context.CR_Flight_Crew
                             where c.CrewID == crewID
                             join f in context.CR_FlightInfo on c.FlightID equals f.FlightID into fc
                             from p in fc.DefaultIfEmpty()
                             where p.Date >= fromdate && p.Date <= todate && (p.IsDeleted == null || p.IsDeleted == false)
                             select new FlightInfoModel
                             {
                                 FlightNo = p.FlightNo,
                                 Departed = p.Departed,
                                 Arrived = p.Arrived,
                                 Routing = p.Routing,
                                 Aircraft = p.Aircraft,
                                 Classify = p.Classify,
                                 CkinC = p.CkinC,
                                 CkinY = p.CkinY,                                 
                                 Capacity = p.Capacity
                             }).OrderBy(i => i.Departed).ToList();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
