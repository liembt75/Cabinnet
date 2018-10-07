using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class TicketModel
    {
        public enum TicketStatus
        {            
            Waiting = 0,
            Processing = 1,
            Accept = 2,
            Reject = 3,
            Done = 10,
        }

        public static Dictionary<string, TicketType> DicTicketType = new Dictionary<string, TicketType>()
        {
            {"ID90", TicketType.ID90 },
            {"ID75", TicketType.ID75 },
            {"ID50", TicketType.ID50 }
        };

        //public const string ID90 = "ID90";
        //public const string ID75 = "ID75";
        //public const string ID50 = "ID50";
        public enum TicketType
        {
            ID90 = 0,
            ID75 = 1,
            ID50 = 2
        };

        public TicketType GetTicketType(string strTicket)
        {
            return DicTicketType[strTicket];                        
        }

        public static Ticket_Quota TicketQuotaPlus(Ticket_Quota from, Ticket_Quota to)
        {
            if (from == null)
            {
                from = new Ticket_Quota();                
            }
            foreach (var type in DicTicketType)
            {
                if (from.GetType().GetProperty(type.Key).GetValue(from) == null)
                    from.GetType().GetProperty(type.Key).SetValue(from, 0);
            }

            if (to == null)
            {
                to = new Ticket_Quota();                
            }
            foreach (var type in DicTicketType)
            {
                if (to.GetType().GetProperty(type.Key).GetValue(to) == null)
                    to.GetType().GetProperty(type.Key).SetValue(to, 0);
            }

            foreach (var type in DicTicketType)
            {
                int soLuongVeFrom = (int)from.GetType().GetProperty(type.Key).GetValue(from);
                int soLuongVeTo = (int)to.GetType().GetProperty(type.Key).GetValue(to);
                from.GetType().GetProperty(type.Key).SetValue(from, soLuongVeFrom + soLuongVeTo);
            }
            return from;
        }

        public static Ticket_Quota TicketQuotaMinus(Ticket_Quota from, Ticket_Quota to)
        {
            //if (from == null)
            //{
            //    from = new Ticket_Quota();
            //}
            //if (from.ID90 == null)
            //    from.ID90 = 0;
            //if (from.ID75 == null)
            //    from.ID75 = 0;
            //if (from.ID50 == null)
            //    from.ID50 = 0;

            //if (to == null)
            //{
            //    to = new Ticket_Quota();
            //}

            //if (to.ID90 == null)
            //    to.ID90 = 0;
            //if (to.ID75 == null)
            //    to.ID75 = 0;
            //if (to.ID50 == null)
            //    to.ID50 = 0;

            //from.ID90 -= to.ID90;
            //from.ID75 -= to.ID75;
            //from.ID50 -= to.ID50;
            //return from;
            if (from == null)
            {
                from = new Ticket_Quota();
            }
            foreach (var type in DicTicketType)
            {
                if (from.GetType().GetProperty(type.Key).GetValue(from) == null)
                    from.GetType().GetProperty(type.Key).SetValue(from, 0);
            }

            if (to == null)
            {
                to = new Ticket_Quota();
            }
            foreach (var type in DicTicketType)
            {
                if (to.GetType().GetProperty(type.Key).GetValue(to) == null)
                    to.GetType().GetProperty(type.Key).SetValue(to, 0);
            }

            foreach (var type in DicTicketType)
            {
                int soLuongVeFrom = (int)from.GetType().GetProperty(type.Key).GetValue(from);
                int soLuongVeTo = (int)to.GetType().GetProperty(type.Key).GetValue(to);
                from.GetType().GetProperty(type.Key).SetValue(from, soLuongVeFrom - soLuongVeTo);
            }
            return from;
        }

        public static Ticket_Quota GetTicketQuota(Ticket_FormDetail formDetail)
        {
            //if (result.ID90 == null)
            //    result.ID90 = 0;
            //if (result.ID75 == null)
            //    result.ID75 = 0;
            //if (result.ID50 == null)
            //    result.ID50 = 0;

            //switch (formDetail.Type)
            //{
            //    case ID90:
            //        if (formDetail.TicketCount != null)
            //            result.ID90 += formDetail.TicketCount.Value;
            //        break;
            //    case ID75:
            //        if (formDetail.TicketCount != null)
            //            result.ID75 += formDetail.TicketCount.Value;
            //        break;
            //    case ID50:
            //        if (formDetail.TicketCount != null)
            //            result.ID50 += formDetail.TicketCount.Value;
            //        break;
            //}
            Ticket_Quota result = new Ticket_Quota();
            foreach (var type in DicTicketType)
            {
                if (result.GetType().GetProperty(type.Key).GetValue(result) == null)
                    result.GetType().GetProperty(type.Key).SetValue(result, 0);
            }
            if (formDetail.TicketCount != null)
            {
                int soLuongVe = (int)result.GetType().GetProperty(formDetail.Type).GetValue(result);
                result.GetType().GetProperty(formDetail.Type).SetValue(result, soLuongVe + formDetail.TicketCount.Value);
            }
            return result;
        }

        public static string XuatChuoiVe(int veIndex, int soVe, int veTotal, TicketType type, int employeeTypeID)
        {
            int veIndexLater = veIndex + soVe;
            StringBuilder result = new StringBuilder();
            switch (type)
            {
                case TicketType.ID50:
                    result.Append(soVe);
                    result.Append(" ID50");                    
                    break;
                case TicketType.ID75:                    
                    if (veTotal > 1000)
                    {
                        result.Append(soVe);
                        result.Append(" ID75");
                    }
                    else
                    {
                        result.Append(veIndexLater);
                        result.Append("/");
                        result.Append(veTotal);
                    }
                    break;
                case TicketType.ID90:
                    if (employeeTypeID != (int)EmployeeModel.EmployeeType.TiepVien)
                    {
                        result.Append(veIndexLater);
                        result.Append("/");
                        result.Append(veTotal);                        
                    }
                    else
                    {
                        if (veIndexLater <= 5)
                        {
                            result.Append(veIndexLater);
                            result.Append("/");
                            result.Append(5);
                        }
                        else
                        {
                            if (veIndex < 5)
                            {
                                result.Append(5);
                                result.Append("/");
                                result.Append(5);
                            }
                            if (result.Length > 0)
                            {
                                result.Append(" ");
                            }
                            result.Append(veIndexLater - 5);
                            result.Append("/");
                            result.Append(veTotal - 5);
                        }
                    }                    
                    break;
            }
            return result.ToString();
        }

        public static string XuatChuoiVeIn(int veIndex, int soVe, int veTotal, TicketType type, int employeeTypeID)
        {
            int veIndexLater = veIndex + soVe;
            StringBuilder result = new StringBuilder();
            switch (type)
            {
                case TicketType.ID50:
                    //result.Append(soVe);
                    result.Append("ID50 (mùa thấp điểm)");
                    break;
                case TicketType.ID75:
                    if (veTotal > 1000)
                    {
                        //result.Append(soVe);
                        result.Append("ID75 (mùa thấp điểm)");
                    }
                    else
                    {
                        result.Append("thứ ");
                        result.Append(veIndexLater);
                        result.Append("/");
                        result.Append(veTotal);
                        result.Append(" (tổng số vé chế độ)");                        
                    }
                    break;
                case TicketType.ID90:
                    if (employeeTypeID != (int)EmployeeModel.EmployeeType.TiepVien)
                    {
                        result.Append("thứ ");
                        result.Append(veIndexLater);
                        result.Append("/");
                        result.Append(veTotal);
                        result.Append(" (tổng số vé chế độ)");
                    }
                    else
                    {
                        if (veIndexLater <= 5)
                        {
                            result.Append("thứ ");
                            result.Append(veIndexLater);
                            result.Append("/");
                            result.Append(5);
                            result.Append(" (tổng số vé chế độ)");
                        }
                        else
                        {
                            if (veIndex < 5)
                            {
                                result.Append("thứ ");
                                result.Append(5);
                                result.Append("/");
                                result.Append(5);
                                result.Append(" (tổng số vé chế độ)");
                            }
                            if (result.Length > 0)
                            {
                                result.Append(" ");
                            }
                            result.Append("thứ ");
                            result.Append(veIndexLater - 5);
                            result.Append("/");
                            result.Append(veTotal - 5);
                            result.Append(" (tổng số vé chế độ)");
                        }
                    }
                    break;
            }
            return result.ToString();
        }
    }
}
