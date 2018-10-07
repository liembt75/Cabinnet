using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class BriefingDal
    {
        public List<BR_BriefingDiary> GetBriefingDiary(DateTime? fromdate, DateTime? todate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.BR_BriefingDiary.Where(i => (fromdate == null || (fromdate != null && i.Ngay >= fromdate)) &&
                                                     (todate == null || (todate != null && i.Ngay <= todate)) &&
                                                     i.Status == 0).OrderByDescending(i => i.UpdatedDate).ToList();
            }
        }

        public List<SysAccBrfDiaryModel> GetSysAcc()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Account.Where(i =>
                            (i.IsDeleted == null || i.IsDeleted != null && i.IsDeleted != true) &&
                            i.end_date == null &&
                            i.type_tv != null && i.type_tv != "")
                            .OrderBy(i => i.FirstNameVn)
                            .Select(i => new SysAccBrfDiaryModel() { FirstNameVn = i.FirstNameVn, name_tv = i.name_tv, CrewID = i.CrewID, Group = i.Group})                       
                            .ToList();
            }
        }

        public void UpdateDiary(BR_BriefingDiary nhatky)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (nhatky.ID <= 0)
                {
                    context.BR_BriefingDiary.Add(nhatky);
                }
                else
                {
                    context.Entry(nhatky).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();                
            }
        }
    }
}
