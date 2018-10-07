using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class LoggedInDal
    {
        public Sys_LoggedIn getLoggedInByQRCode(int aID, string qrCode)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_LoggedIn.Where(i => i.AID == aID && i.QRCode == qrCode &&
                                                  (i.Activate == null || i.Activate != null && i.Activate == true)).FirstOrDefault();
            }
        }

        public void UpdateLoggedIn(Sys_LoggedIn item)
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
    }
}
