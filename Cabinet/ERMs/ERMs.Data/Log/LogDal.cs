using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Log
{
    public class LogDal
    {
        public void Add(CR_Crew_Task_Update_Log log)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                context.CR_Crew_Task_Update_Log.Add(log);
                context.SaveChanges();
            }
        }
    }
}
