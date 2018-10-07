using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class TourDal
    {
        public List<Tours2018> GetTours()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Tours2018.OrderByDescending(i => i.ID).ToList();
            }
        }

        public Tours2018 UpdateTour(Tours2018 item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (item.ID == 0)
                {                    
                    context.Tours2018.Add(item);
                }
                else
                {                    
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }

                context.SaveChanges();
                return item;
            }
        }

        public List<GetRegister2018_Result> GetRegister(List<string> lstMSNV)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                
                if (lstMSNV.Count > 0)
                {
                    return context.GetRegister2018().Where(q => lstMSNV.Any(f => q.MSNV.Contains(f))).ToList();
                }
                return context.GetRegister2018().ToList();
            }
        }

        public GetRegister2018_Result UpdateRegister(GetRegister2018_Result item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var tourEntity = context.TourRegister2018.Where(i => i.ID == item.ID).FirstOrDefault();
                if (tourEntity != null)
                {
                    tourEntity.TinhTrang = item.TinhTrang;
                    tourEntity.NgayCapNhat = DateTime.Now;
                    tourEntity.NguoiCapNhat = ERMs.Sys.ConfigurationSetting.UserInfo.UserName;
                }
                context.SaveChanges();
                return item;
            }
        }

        public void AddListTourRegister(List<TourRegister2018> lstTour)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                context.TourRegister2018.AddRange(lstTour);                
                context.SaveChanges();                
            }
        }

        public bool TourExist(TourRegister2018 tour)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var tourRegister = context.TourRegister2018.Where(i => i.MSNV == tour.MSNV && i.HoTen == tour.HoTen && i.QuanHe == tour.QuanHe && (i.TinhTrang == 0 || i.TinhTrang == 2)).FirstOrDefault();
                if (tourRegister == null)
                    return false;
                else
                    return true;                
            }
        }

        public bool UserPermit(TourRegister2018 tour)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var tourUser = context.TourUser2018.Where(i => i.MSNV == tour.MSNV).FirstOrDefault();
                if (tourUser == null)
                    return false;
                else
                    return true;
            }
        }
        

        public void UpdateStatusListRegister(List<GetRegister2018_Result> lstRegister)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                foreach (var item in lstRegister)
                {
                    var tourEntity = context.TourRegister2018.Where(i => i.ID == item.ID).FirstOrDefault();
                    if (tourEntity != null)
                    {
                        tourEntity.TinhTrang = item.TinhTrang;
                        tourEntity.NgayCapNhat = DateTime.Now;
                        tourEntity.NguoiCapNhat = ERMs.Sys.ConfigurationSetting.UserInfo.UserName;
                    }                    
                }
                context.SaveChanges();
            }
        }
    }
}
