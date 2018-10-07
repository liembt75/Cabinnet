using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Task
{
  public  class SupportDal
    {

        public List<API_ER_USP_Get_Supports2_Result> GetTickets(DateTime fromdate, DateTime todate, string usercode, string keyword, int page, int records, int? status)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (status == null || (status != null && status != 1))
                {
                    var items = context.API_ER_USP_Get_Supports2(true, usercode, "", keyword, page, records)
                        .Where(i => i.Modified >= fromdate && i.Modified <= todate && (status == null || i.Status == status)).ToList();
                    return items;
                }
                else
                {
                    var items = context.API_ER_USP_Get_Supports2(true, usercode, "", keyword, page, records)
                        .Where(i => i.Modified >= fromdate && i.Modified <= todate && (i.Status == 3 || i.Status == 1)).ToList();
                    return items;
                }
            }

        }

        public void AddSupport(ER_Support support)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {

                context.ER_Support.Add(support);
                context.SaveChanges();                
            }
        }

        public List<API_ER_USP_Get_Support_BySupportID_Result> GetListSupportBySupportID(int supportId)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                //return context.ER_Support.Where(i => i.ID == supportId || i.ParentID == supportId)
                //    .GroupJoin(
                //    context.EX_Attachment,
                //    i => i.AttachmentId,
                //    a => a.GroupID,
                //    (i, a) => a.Select(c => new { ID = i.ID, Sender = i.Sender, Modified = i.Modified, FilePath = c.FilePath })
                //    .DefaultIfEmpty(new { ID = i.ID, Sender = i.Sender, Modified = i.Modified, FilePath = "" }).OrderBy(j => j.ID).ToList();               
                return context.API_ER_USP_Get_Support_BySupportID(supportId).ToList();
            }
        }

        public ER_Support GetSupportBySupportID(int supportId)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.ER_Support.Where(i => i.ID == supportId).FirstOrDefault();                    
            }
        }

        public void UpdateSupportStatus(API_ER_USP_Get_Support_BySupportID_Result support)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var supportTemp = context.ER_Support.Where(i => i.ID == support.ID).FirstOrDefault();
                if (supportTemp != null)
                {
                    supportTemp.Status = support.Status;
                    supportTemp.Modified = DateTime.Now;
                    supportTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    supportTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                }
                context.SaveChanges();
            }
        }

        public void UpdateSupportStatus(API_ER_USP_Get_Supports2_Result support)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var supportTemp = context.ER_Support.Where(i => i.ID == support.ID).FirstOrDefault();
                if (supportTemp != null)
                {
                    supportTemp.Status = support.Status;
                    supportTemp.Modified = DateTime.Now;
                    supportTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    supportTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                }
                context.SaveChanges();
            }
        }

        public void UpdateSupport(API_ER_USP_Get_Supports2_Result support)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var supportTemp = context.ER_Support.Where(i => i.ID == support.ID).FirstOrDefault();
                if (supportTemp != null)
                {
                    supportTemp.Status = support.Status;
                    supportTemp.Assignee = support.Assignee;
                    supportTemp.AssigneeName = support.AssigneeName;
                    supportTemp.Modified = DateTime.Now;
                    supportTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    supportTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                }
                context.SaveChanges();
            }
        }

        public void UpdateSupport(ER_Support support)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                context.Entry(support).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdateSupportStatusBySupportID(int supportId, short iStatus)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var supportTemp = context.ER_Support.Where(i => i.ID == supportId).FirstOrDefault();
                if (supportTemp != null)
                {
                    supportTemp.Status = iStatus;
                    supportTemp.Modified = DateTime.Now;
                    supportTemp.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    supportTemp.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                }
                context.SaveChanges();
            }
        }
    }
}
