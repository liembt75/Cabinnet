using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.HealthCare
{
    public class HealthCareDal
    {
        public List<HealthCareModel> GetHealthCare()
        {
            try
            {
                using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
                {
                    List<HealthCareModel> items = new List<HealthCareModel>();
                    var query = context.API_HR_USP_GetHealthCare();
                    foreach (var item in query)
                    {
                        HealthCareModel model = new HealthCareModel().ToModel(item);
                        items.Add(model);
                    }
                    return items;
                }
            }
            catch (Exception ex)
            { return new List<HealthCareModel>(); }
        }

        public List<HealthCareModel> GetHealthCare(DateTime? fromdate, DateTime? todate, DateTime? fromExpiredDate, DateTime? toExpiredDate)
        {
            try
            {
                using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
                {
                    List<HealthCareModel> items = new List<HealthCareModel>();
                    var query = context.API_HR_USP_GetHealthCare().AsEnumerable();
                    if (fromdate != null)
                        query = query.Where(i => i.Dotkham >= fromdate);
                    if (todate != null)
                        query = query.Where(i => i.Dotkham <= todate);
                    if (fromExpiredDate != null)
                        query = query.Where(i => i.Expired >= fromExpiredDate);
                    if (toExpiredDate != null)
                        query = query.Where(i => i.Expired <= toExpiredDate);
                    //var query = context.API_HR_USP_GetHealthCare().Where(i => (fromdate == null  || i.Dotkham >= fromdate) && (todate == null || i.Dotkham <= todate) && (fromExpiredDate == null || i.Expired >= fromExpiredDate) && (toExpiredDate == null || i.Expired <= toExpiredDate));
                    foreach (var item in query)
                    {
                        HealthCareModel model = new HealthCareModel().ToModel(item);
                        items.Add(model);
                    }
                    return items;
                }
            }
            catch (Exception ex)
            { return new List<HealthCareModel>(); }
        }

        public void Add(List<HR_HealthCare> lstHR_HealthCare)
        {
            try
            {
                using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
                {
                    context.HR_HealthCare.AddRange(lstHR_HealthCare);
                    context.SaveChanges();                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HR_HealthCare> GetHealthCareByCrewID(string crewID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.HR_HealthCare.Where(i => i.CrewID == crewID && i.Isdeleted == false).ToList();                
            }
        }

        public void DeleteHeathCareByHealthID(HealthCareModel iHealthCare)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var health = context.HR_HealthCare.Where(i => i.ID == iHealthCare.IDDotKham).FirstOrDefault();
                if (health != null)
                {
                    health.Modified = iHealthCare.Modified;
                    health.Modifierid = iHealthCare.Modifierid;
                    health.Modifier = iHealthCare.Modifier;
                    health.Isdeleted = true;
                    context.SaveChanges();
                }
            }
        }

        public void Update(HealthCareModel model)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                HR_HealthCare health = context.HR_HealthCare.Where(i => i.ID == model.IDDotKham).FirstOrDefault();
                if (health != null)
                {
                    health.Dotkham = model.Dotkham.Value;
                    health.Expired = model.Expired;
                    health.Modified = model.Modified;
                    health.Modifierid = model.Modifierid;
                    health.Modifier = model.Modifier;
                    context.SaveChanges();
                }
            }
        }
    } 
}
