using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class UserInfoModel
    {
        public static List<USP_GetAllCRUDByUserID_Result> lstCRUD = null;        

        public static List<USP_GetAllCRUDByUserID_Result> GetCRUID()
        {
            List<USP_GetAllCRUDByUserID_Result> result = new List<USP_GetAllCRUDByUserID_Result>();
            var items = lstCRUD.GroupBy(i => i.Code).Select(i => i.First().Code).ToList();
            foreach (var item in items)
            {
                USP_GetAllCRUDByUserID_Result temp = GetUnideCRUID(item);
                result.Add(temp);
            }
            return result;
        }

        private static USP_GetAllCRUDByUserID_Result GetUnideCRUID(string nodeChildName)
        {
            USP_GetAllCRUDByUserID_Result crud = new USP_GetAllCRUDByUserID_Result();
            crud.Code = nodeChildName;
            crud.C = false;
            crud.R = false;
            crud.U = false;
            crud.D = false;
            var items = lstCRUD.Where(i => i.Code == nodeChildName).ToList();            
            foreach (var item in items)
            {
                if (item.C.HasValue && item.C.Value) crud.C = true;
                if (item.R.HasValue && item.R.Value) crud.R = true;
                if (item.U.HasValue && item.U.Value) crud.U = true;
                if (item.D.HasValue && item.D.Value) crud.D = true;
                if (crud.C.HasValue && crud.C.Value &&
                    crud.R.HasValue && crud.R.Value &&
                    crud.U.HasValue && crud.U.Value &&
                    crud.D.HasValue && crud.D.Value)
                    break;
            }
            return crud;
        }

        public static USP_GetAllCRUDByUserID_Result GetCRUID(string nodeChildName)
        {
#if (DEBUG)
            //USP_GetAllCRUDByUserID_Result crud = new USP_GetAllCRUDByUserID_Result();
            //return lstCRUD.Where(i => i.Code == nodeChildName).FirstOrDefault();
            USP_GetAllCRUDByUserID_Result crud = new USP_GetAllCRUDByUserID_Result();
            crud.C = crud.D = crud.R = crud.U = true;
            return crud;
#else
        USP_GetAllCRUDByUserID_Result crud = new USP_GetAllCRUDByUserID_Result();
        return lstCRUD.Where(i => i.Code == nodeChildName).FirstOrDefault();         
#endif

        }
    }
}
