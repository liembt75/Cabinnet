using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class OJTDal
    {
        public List<OJTCategoryModel> GetListOJTCategory()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<OJTCategoryModel> lstCategoryModel = new List<OJTCategoryModel>();
                var lstCategory = context.CR_OJT_Category.ToList();
                foreach (var category in lstCategory)
                {
                    lstCategoryModel.Add(new OJTCategoryModel().ToCustomModel(category));
                }
                return lstCategoryModel;
            }
        }

        public OJTCategoryModel UpdateOJTCategory(OJTCategoryModel item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                CR_OJT_Category itemEntity = null;
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.CR_OJT_Category.Add(itemEntity);
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

        public List<OJTLessonModel> GetOJTLessonByOJTCategoryID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<OJTLessonModel> lstLessonModel = new List<OJTLessonModel>();
                var lstLesson = context.CR_OJT_Lesson.Where(i => i.CR_OJT_Category_ID == iD).ToList();
                foreach (var lesson in lstLesson)
                {
                    lstLessonModel.Add(new OJTLessonModel().ToCustomModel(lesson));
                }
                return lstLessonModel;
            }
        }

        public List<OJTLessonItemModel> GetOJTLessonItemByOJTLessonID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<OJTLessonItemModel> result = new List<OJTLessonItemModel>();
                var list = context.CR_OJT_Lesson_Item.Where(i => i.CR_OJT_Lesson_ID == iD).OrderBy(i => i.SN);
                foreach (var item in list)
                {
                    result.Add(new OJTLessonItemModel().ToCustomModel(item));
                }
                return result;
            }
        }

        public OJTLessonModel UpdateOJTLesson(OJTLessonModel item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                CR_OJT_Lesson itemEntity = null;
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.CR_OJT_Lesson.Add(itemEntity);
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

        public OJTLessonItemModel UpdateOJTLessonItem(OJTLessonItemModel item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                CR_OJT_Lesson_Item itemEntity = null;
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    itemEntity = item.ToEntityModel();
                    context.CR_OJT_Lesson_Item.Add(itemEntity);
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

        public List<OJTModel> GetListOJT(DateTime fromdate, DateTime todate, string key)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<OJTModel> lstOJTModel = new List<OJTModel>();
                var lstOJT = context.CR_OJT.Where(i => (fromdate == null || (fromdate != null && i.Date >= fromdate)) &&
                                                     (todate == null || (todate != null && i.Date <= todate)) &&
                                                     (key == null || key.Contains(i.ExamineeID) || key.Contains(i.ExamineeName)) && 
                                                     (i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false))).OrderByDescending(i => i.ID);
                foreach (var ojt in lstOJT)
                {
                    lstOJTModel.Add(new OJTModel().ToCustomModel(ojt));
                }
                return lstOJTModel;                
            }
        }

        public List<CR_OJT_Item> GetOJTItemByOJTID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_OJT_Item.Where(i => i.CR_OJT_ID == iD &&
                                                      i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false))
                                                      .OrderBy(i => i.Question).ToList();
            }
        }

        public CR_FlightInfo getFlightInfoByFlightID(int? flightID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_FlightInfo.Where(i => i.FlightID == flightID).FirstOrDefault();
            }
        }

        public List<Sys_Account> GetExamUser(string examineeID, string examinerID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Account.Where(i => i.CrewID == examineeID || i.CrewID == examinerID).ToList();                
            }
        }

        public Sys_Account GetExamner(string examinerID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Account.Where(i => i.CrewID == examinerID).FirstOrDefault();
            }
        }

        public Sys_Account GetExamnee(string examineeID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Account.Where(i => i.CrewID == examineeID).FirstOrDefault();
            }
        }

        public CR_Flight_Crew GetCrew(string examinerID, int? flightID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_Flight_Crew.Where(i => i.CrewID == examinerID && i.FlightID == flightID).FirstOrDefault();
            }
        }
    }
}
