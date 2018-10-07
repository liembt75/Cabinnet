using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class FormDal
    {
        public List<HR_Form_Category> GetFormCategory()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.HR_Form_Category.Where(i => i.Active == null || i.Active != null && i.Active != false).ToList();
            }
        }

        //public List<HR_Forms> GetListForm(DateTime fromdate, DateTime todate, string key, int status)
        public List<HRFormModel> GetListForm(DateTime? fromdate, DateTime? todate, DateTime? fromFromDate, DateTime? toFromDate, DateTime? fromToDate, DateTime? toToDate, string key, int status)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return (from f in context.HR_Forms
                           where ((fromdate == null || (fromdate != null && f.Date >= fromdate)) &&
                                (todate == null || (todate != null && f.Date <= todate)) &&
                                (fromFromDate == null || (fromFromDate != null && f.From_Date >= fromFromDate)) &&
                                (toFromDate == null || (toFromDate != null && f.From_Date <= toFromDate)) &&
                                (fromToDate == null || (fromToDate != null && f.To_Date >= fromToDate)) &&
                                (fromToDate == null || (fromToDate != null && f.To_Date <= toToDate)) &&
                                (status == 0 || f.Status == status) &&                                
                                (key == null || key.Contains(f.CID) || key.Contains(f.CName)))                           
                           join a in context.Sys_Account
                           on f.CID equals a.CrewID
                        orderby f.ID descending
                        select new HRFormModel()
                           {
                               ID = f.ID,
                               CID = f.CID,
                               CName = f.CName,
                               Category_ID = f.Category_ID,
                               From_Date = f.From_Date,
                               To_Date = f.To_Date,
                               Route = f.Route,
                               FlightNo = f.FlightNo,
                               Content = f.Content,
                               Attachments = f.Attachments,
                               Date = f.Date,
                               Status = f.Status,
                               Replierid = f.Replierid,
                               Replier = f.Replier,
                               Replied = f.Replied,
                               ReplyDept = f.ReplyDept,
                               ReplyInfo = f.ReplyInfo,
                               IsDeleted = f.IsDeleted,
                               Created = f.Created,
                               Modified = f.Modified,
                               Creator = f.Creator,
                               Modifier = f.Modifier,
                               Creatorid = f.Creatorid,
                               Modifierid = f.Modifierid,
                               LastNameVn = a.LastNameVn,
                               FirstNameVn = a.FirstNameVn,
                               FullNameVn = a.LastNameVn + " " + a.FirstNameVn,
                               type_tv = a.type_tv,
                               class_tv = a.class_tv,
                               Group = a.Group,
                               Base = a.main_base,
                               Term = a.term_tv
                           }).ToList();
                //return context.HR_Forms.Where(i => (fromdate == null || (fromdate != null && i.Date >= fromdate)) &&
                //                                     (todate == null || (todate != null && i.Date <= todate)) &&
                //                                     (status == -1 || i.Status == status) &&
                //                                     (key == null || key.Contains(i.CID) || key.Contains(i.CName)))                                                     
                //                                     .OrderByDescending(i => i.ID).ToList();
            }
        }

        public List<HRFormModel> GetListForm(DateTime? fromdate, DateTime? todate, DateTime? fromFromDate, DateTime? toFromDate, DateTime? fromToDate, DateTime? toToDate, string key, int status, int categoryID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return (from f in context.HR_Forms
                        where ((fromdate == null || (fromdate != null && f.Date >= fromdate)) &&
                             (todate == null || (todate != null && f.Date <= todate)) &&
                             (fromFromDate == null || (fromFromDate != null && f.From_Date >= fromFromDate)) &&
                             (toFromDate == null || (toFromDate != null && f.From_Date <= toFromDate)) &&
                             (fromToDate == null || (fromToDate != null && f.To_Date >= fromToDate)) &&
                             (fromToDate == null || (fromToDate != null && f.To_Date <= toToDate)) &&
                             (status == 0 || f.Status == status) &&
                             (f.IsDeleted ==  null || f.IsDeleted == false) &&
                             (f.Category_ID == categoryID) &&
                             (key == null || key.Contains(f.CID) || key.Contains(f.CName)))
                        join a in context.Sys_Account
                        on f.CID equals a.CrewID
                        orderby f.ID descending
                        select new HRFormModel()
                        {
                            ID = f.ID,
                            CID = f.CID,
                            CName = f.CName,
                            Category_ID = f.Category_ID,
                            From_Date = f.From_Date,
                            To_Date = f.To_Date,
                            Route = f.Route,
                            FlightNo = f.FlightNo,
                            Content = f.Content,
                            Attachments = f.Attachments,
                            Date = f.Date,
                            Status = f.Status,
                            Replierid = f.Replierid,
                            Replier = f.Replier,
                            Replied = f.Replied,
                            ReplyDept = f.ReplyDept,
                            ReplyInfo = f.ReplyInfo,
                            IsDeleted = f.IsDeleted,
                            Created = f.Created,
                            Modified = f.Modified,
                            Creator = f.Creator,
                            Modifier = f.Modifier,
                            Creatorid = f.Creatorid,
                            Modifierid = f.Modifierid,
                            LastNameVn = a.LastNameVn,
                            FirstNameVn = a.FirstNameVn,
                            FullNameVn = a.LastNameVn + " " + a.FirstNameVn,
                            type_tv = a.type_tv,
                            class_tv = a.class_tv,
                            Group = a.Group,
                            Base = a.main_base,
                            Term = a.term_tv
                        }).ToList();
                //return context.HR_Forms.Where(i => (fromdate == null || (fromdate != null && i.Date >= fromdate)) &&
                //                                     (todate == null || (todate != null && i.Date <= todate)) &&
                //                                     (status == -1 || i.Status == status) &&
                //                                     (key == null || key.Contains(i.CID) || key.Contains(i.CName)))                                                     
                //                                     .OrderByDescending(i => i.ID).ToList();
            }
        }

        public HR_Forms getFormByFormID(int id)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.HR_Forms.Where(i => i.ID == id).FirstOrDefault();
            }
        }

        public List<EX_Attachment> GetAttachmentByAttachmentID(int groupID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.EX_Attachment.Where(i => i.GroupID == groupID).ToList();
            }            
        }

        public HRFormModel UpdateForm(HRFormModel item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                HR_Forms itemEntity = null;
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.HR_Forms.Add(itemEntity);
                }
                else
                {
                    item.Replied = DateTime.Now;
                    item.Replier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Replierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    //item.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    //item.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    //item.Modified = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.Entry(itemEntity).State = System.Data.Entity.EntityState.Modified;
                }

                context.SaveChanges();
                item.ID = itemEntity.ID;
                return item;
            }
        }

        public void UpdateStatusListForm(List<HRFormModel> lstForms)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                HR_Forms itemEntity = null;
                foreach (HRFormModel item in lstForms)
                {
                    item.Replied = DateTime.Now;
                    item.Replier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Replierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Modified = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.Entry(itemEntity).State = System.Data.Entity.EntityState.Modified;
                }                
                context.SaveChanges();                
            }
        }



        public void UpdateListForm(List<HR_Forms> lstForm)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {                
                foreach (HR_Forms item in lstForm)
                {
                    item.Replied = DateTime.Now;
                    item.Replier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Replierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Modified = DateTime.Now;                    
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }
        }


        public List<HR_Form_Category> GetListFormCategory()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.HR_Form_Category.ToList();
            }
        }

        public void UpdateFormCategory(HR_Form_Category item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {                                
                item.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                item.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                item.Modified = DateTime.Now;
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                
                context.SaveChanges();
            }
        }

        public List<HRFormModel> GetListFormByUser(string userID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return (from f in context.HR_Forms
                        where f.CID == userID && 
                              (f.IsDeleted.HasValue == false || f.IsDeleted.HasValue && f.IsDeleted.Value == false)
                        join a in context.Sys_Account
                        on f.CID equals a.CrewID
                        orderby f.ID descending
                        select new HRFormModel()
                        {
                            ID = f.ID,
                            CID = f.CID,
                            CName = f.CName,
                            Category_ID = f.Category_ID,
                            From_Date = f.From_Date,
                            To_Date = f.To_Date,
                            Route = f.Route,
                            FlightNo = f.FlightNo,
                            Content = f.Content,
                            Attachments = f.Attachments,
                            Date = f.Date,
                            Status = f.Status,
                            Replierid = f.Replierid,
                            Replier = f.Replier,
                            Replied = f.Replied,
                            ReplyDept = f.ReplyDept,
                            ReplyInfo = f.ReplyInfo,
                            IsDeleted = f.IsDeleted,
                            Created = f.Created,
                            Modified = f.Modified,
                            Creator = f.Creator,
                            Modifier = f.Modifier,
                            Creatorid = f.Creatorid,
                            Modifierid = f.Modifierid,
                            LastNameVn = a.LastNameVn,
                            FirstNameVn = a.FirstNameVn,
                            FullNameVn = a.LastNameVn + " " + a.FirstNameVn,
                            type_tv = a.type_tv,
                            class_tv = a.class_tv,
                            Group = a.Group,
                            Base = a.main_base
                        }).ToList();
            }
        }

        public void addListFormCategory(List<HR_Form_Category> lstAddedFormCategory)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                foreach (var addedFormCategory in lstAddedFormCategory)
                {
                    if (context.HR_Form_Category.Where(i => i.Code == addedFormCategory.Code).FirstOrDefault() == null)
                        context.HR_Form_Category.Add(addedFormCategory);
                }
                context.SaveChanges();
            }
        }

        public Sys_Account getAccountByCID(string cID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Account.Where(i => i.CrewID == cID).FirstOrDefault();
            }
        }

        public Ticket_Employee getTicketEmployeeByCID(string cID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Ticket_Employee.Where(e => e.CID == cID && e.RelationshipID == null && (e.IsDeleted == null || e.IsDeleted == false)).FirstOrDefault();
            }
        }
    }
}
