using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class EMMessageDal
    {
        public List<EMMessageModel> GetListParentMessage(DateTime? fromdate, DateTime? todate, string searchString)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<EMMessageModel> result = new List<EMMessageModel>();
                var lstItem = context.EM_Message.Where(i => (fromdate == null || (fromdate != null && i.SmsTimeOut >= fromdate)) &&
                                                     (todate == null || (todate != null && i.SmsTimeOut <= todate)) &&
                                                     i.ParentID == null &&
                                                     (string.IsNullOrEmpty(searchString) || 
                                                     i.ReceiverID == searchString ||
                                                     i.Receiver.Contains(searchString) ||
                                                     i.PhoneNo == searchString)).OrderByDescending(i => i.ID);
                foreach (var item in lstItem)
                {
                    result.Add(new EMMessageModel().ToCustomModel(item));
                }
                return result;
            }
        }

        public List<EM_Message> GetListChildMessageByParentMessageID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<EMMessageModel> result = new List<EMMessageModel>();
                return context.EM_Message.Where(i => i.ParentID == iD).ToList();                
            }
        }

        public List<CR_GetNews_Result> GetNews(DateTime? fromDate, DateTime? toDate, string keyword)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_GetNews(fromDate, toDate, keyword).ToList();
            }
        }

        public string GetHtmlNewByID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.EM_News.Where(i => i.ID == iD).Select(i => i.Html).FirstOrDefault();
            }
        }
    }
}
