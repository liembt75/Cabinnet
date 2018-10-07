using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class MeetingDal
    {
        public List<Meeting_Detail> GetMeetingDetail(DateTime? fromDate, DateTime? toDate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Meeting_Detail.Where(i => (fromDate == null || i.Date >= fromDate) &&
                                                         (toDate == null || i.Date <= toDate) &&
                                                         (i.IsDeleted == null || i.IsDeleted != false)).OrderBy(i => i.Date).ToList();
            }
        }

        public List<Meeting_Section> GetListMeetingSection()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Meeting_Section.Where(i => i.Active == null || i.Active == true).ToList();
            }
        }

        public Meeting_Detail UpdateMeetingDetail(Meeting_Detail item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {                
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;                    
                    context.Meeting_Detail.Add(item);
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

        public IEnumerable<Meeting_Detail> GetMeetingDetail(DateTime? fromDate, DateTime? toDate, int meetingSectionID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Meeting_Detail.Where(i => (fromDate == null || i.Date >= fromDate) &&
                                                         (toDate == null || i.Date <= toDate) &&
                                                         i.MeetingSection == meetingSectionID &&
                                                         (i.IsDeleted == null || i.IsDeleted != false)).OrderBy(i => i.Date).ToList();
            }
        }
    }
}
