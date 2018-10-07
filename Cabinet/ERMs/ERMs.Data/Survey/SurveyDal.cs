using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class SurveyDal
    {
        public List<SurveyCategoryModel> GetListSurveyCategory()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<SurveyCategoryModel> result = new List<SurveyCategoryModel>();
                var lstCategory = context.CR_Survey_Category;
                foreach (var category in lstCategory)
                {
                    result.Add(new SurveyCategoryModel().ToCustomModel(category));
                }
                return result;
            }
        }

        public SurveyCategoryModel UpdateSurveyCategory(SurveyCategoryModel item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                CR_Survey_Category itemEntity = null;
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.CR_Survey_Category.Add(itemEntity);
                }
                else
                {
                    item.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Modified = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.Entry(itemEntity).State = System.Data.Entity.EntityState.Modified;
                }                
                context.SaveChanges();
                item.ID = itemEntity.ID;
                return item;
            }
        }

        public List<CR_Survey_Banking_Item> GetListSurveyBankingItem()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_Survey_Banking_Item.ToList();
            }
        }

        public SurveyBankingItemModel UpdateSurveyBankingItem(SurveyBankingItemModel item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                CR_Survey_Banking_Item itemEntity = null;
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.CR_Survey_Banking_Item.Add(itemEntity);
                }
                else
                {
                    item.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Modified = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.Entry(itemEntity).State = System.Data.Entity.EntityState.Modified;
                }                
                context.SaveChanges();
                item.ID = itemEntity.ID;
                return item;
            }
        }

        public List<SurveyModel> GetListSurvey(DateTime fromdate, DateTime todate, string key)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var lstSurvey = context.CR_Survey.Where(i => (fromdate == null || (fromdate != null && i.Date >= fromdate)) &&
                                                     (todate == null || (todate != null && i.Date <= todate)) &&
                                                     (key == null || key.Contains(i.CID) || key.Contains(i.FullName) || i.CR_Survey_Category.Contains(key)) &&
                                                     (i.IsDeleted != null && i.IsDeleted == false)).OrderByDescending(i => i.ID).ToList();

                List<SurveyModel> lstSurveyModel = new List<SurveyModel>();
                foreach (var survey in lstSurvey)
                {
                    lstSurveyModel.Add(new SurveyModel().ToModel(survey));
                }
                return lstSurveyModel;
            }
        }

        public List<CR_Survey_Item> GetSurveyItemBySurveyID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_Survey_Item.Where(i => i.CR_Survey_ID == iD && 
                                                        (i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false)))
                                                        .OrderBy(i => i.Question).ToList();                
            }
        }

        public List<CR_Survey_Item> GetSurveyItemBySurvey(CR_Survey survey)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<CR_Survey_Item> lstSurveyItem = context.CR_Survey_Item.Where(i => i.CR_Survey_ID == survey.ID &&
                                                        (i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false)))
                                                        .OrderBy(i => i.Question).ToList();
                lstSurveyItem.ForEach(i => i.CR_Survey = survey);
                return lstSurveyItem;
            }
        }

        public List<SurveyBankingItemModel> GetListSurveyBankingItemBySurveyCategoryID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<SurveyBankingItemModel> result = new List<SurveyBankingItemModel>();
                var query = context.CR_Survey_Banking_Item.Where(i => i.CR_Survey_Category_ID == iD).OrderBy(i => i.SN).ToList();
                foreach (var item in query)
                {
                    result.Add(new SurveyBankingItemModel().ToCustomModel(item));
                }
                return result;
            }
        }

        public CR_FlightInfo getFlightInfoByFlightID(int? flightID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_FlightInfo.Where(i => i.FlightID == flightID).FirstOrDefault();
            }
        }
    }
}
