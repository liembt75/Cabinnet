using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class TicketFormModel : Ticket_Form
    {
        public enum TicketFormStatus
        {
            Creating = -1,
            Waiting = 0,
            Processing = 1,
            Accept = 2,
            Reject = 3,
            OverQuota = 4,
            Done = 10
        }

        public bool canEdit = true;
        public TicketFormStatus TicketStatus { get; set; }

        public Ticket_Employee employee = null;
        public List<Ticket_FormDetail> LstFormDetail = null;
        public Ticket_Quota ticketQuota;
        public Ticket_Quota ticketQuotaRemain;

        public Ticket_Quota TicketQuotaReserved
        {
            get
            {
                Ticket_Quota result = new Ticket_Quota();
                foreach (var formDetail in LstFormDetail)
                {
                    result = TicketModel.TicketQuotaPlus(result, TicketModel.GetTicketQuota(formDetail));
                }
                return result;
            }
        }

        public int Sove
        {
            get
            {
                int result = 0;
                result += TicketQuotaReserved.ID90.Value + TicketQuotaReserved.ID75.Value + TicketQuotaReserved.ID50.Value;
                return result;
            }
        }

        public bool OverQuota
        {
            get
            {
                foreach (var type in TicketModel.DicTicketType)
                {
                    int ticketRemain = (int)ticketQuotaRemain.GetType().GetProperty(type.Key).GetValue(ticketQuotaRemain);
                    int ticketReserve = (int)TicketQuotaReserved.GetType().GetProperty(type.Key).GetValue(TicketQuotaReserved);
                    if (ticketReserve > 0 && ticketRemain < ticketReserve)
                        return true;
                }
                return false;
            }
        }

        public string LoaiVe
        {
            get
            {
                StringBuilder result = new StringBuilder();
                int veIndex = 0;
                int soVe = 0;
                int veTotal = 0;
                TicketModel.TicketType type = TicketModel.TicketType.ID90;
                int employeeTypeID = employee.EmployeeTypeID.Value;
                if (TicketQuotaReserved.ID90 > 0)
                {
                    veIndex = ticketQuota.ID90.Value - ticketQuotaRemain.ID90.Value;
                    soVe = TicketQuotaReserved.ID90.Value;
                    veTotal = ticketQuota.ID90.Value;
                    result.Append(TicketModel.XuatChuoiVeIn(veIndex, soVe, veTotal, type, employeeTypeID));
                    //if (employee.EmployeeTypeID == (int)EmployeeModel.EmployeeType.TiepVien)
                    //{                        
                    //    int veIndex = ticketQuota.ID90.Value - ticketQuotaRemain.ID90.Value;
                    //    int vereservedIndex = veIndex + TicketQuotaReserved.ID90.Value;
                    //    if (vereservedIndex <= 5)
                    //    {                            
                    //        result.Append(vereservedIndex);
                    //        result.Append("/");
                    //        result.Append(5);
                    //        result.Append(" ");
                    //    }
                    //    else
                    //    {
                    //        if (veIndex < 5)
                    //        {
                    //            result.Append(5 - veIndex);
                    //            result.Append("/");
                    //            result.Append(5);
                    //            result.Append(" ");
                    //        }
                    //        result.Append(vereservedIndex - 5);
                    //        result.Append("/");
                    //        result.Append(ticketQuota.ID90.Value - 5);
                    //        result.Append(" ");
                    //    }                        
                    //}
                    //else
                    //{
                    //    result.Append(ticketQuota.ID90 - ticketQuotaRemain.ID90 + TicketQuotaReserved.ID90);
                    //    result.Append("/");
                    //    result.Append(ticketQuota.ID90);
                    //    result.Append(" ");
                    //}
                }
                if (TicketQuotaReserved.ID75 > 0)
                {
                    if (result.Length > 0)
                    {
                        result.Append(", ");
                    }
                    veIndex = ticketQuota.ID75.Value - ticketQuotaRemain.ID75.Value;
                    soVe = TicketQuotaReserved.ID75.Value;
                    veTotal = ticketQuota.ID75.Value;
                    type = TicketModel.TicketType.ID75;
                    result.Append(TicketModel.XuatChuoiVeIn(veIndex, soVe, veTotal, type, employeeTypeID));

                    //result.Append(ticketQuota.ID75 - ticketQuotaRemain.ID75 + TicketQuotaReserved.ID75);
                    //result.Append("/");
                    //result.Append(ticketQuota.ID75);
                    //result.Append(" ");
                }
                if (TicketQuotaReserved.ID50 > 0)
                {
                    if (result.Length > 0)
                    {
                        result.Append(", ");
                    }
                    veIndex = ticketQuota.ID50.Value - ticketQuotaRemain.ID50.Value;
                    soVe = TicketQuotaReserved.ID50.Value;
                    veTotal = ticketQuota.ID50.Value;
                    type = TicketModel.TicketType.ID50;
                    result.Append(TicketModel.XuatChuoiVeIn(veIndex, soVe, veTotal, type, employeeTypeID));

                    //result.Append(ticketQuota.ID50 - ticketQuotaRemain.ID50 + TicketQuotaReserved.ID50);
                    //result.Append("/");
                    //result.Append(ticketQuota.ID50);
                    //result.Append(" ");
                }
                return result.ToString();
            }
        }

        public TicketFormModel()
        {
            TicketDal db = new TicketDal();
            CID = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
            if (!string.IsNullOrEmpty(CID) && LstFormDetail == null)
            {
                employee = db.GetTicketEmployee(CID);
                LstFormDetail = db.GetTicketFormDetailByFamily(CID);
            }
            Fullname = employee.Fullname;
            TicketStatus = TicketFormStatus.Creating;

            if (!string.IsNullOrEmpty(CID) && employee.EmployeeTypeID != null)
            {
                ticketQuota = db.GetTicketQuota(employee);
                if (ticketQuota == null)
                {
                    ticketQuota = new Ticket_Quota();
                }
                foreach (var type in TicketModel.DicTicketType)
                {
                    if (ticketQuota.GetType().GetProperty(type.Key).GetValue(ticketQuota) == null)
                        ticketQuota.GetType().GetProperty(type.Key).SetValue(ticketQuota, 0);
                }
                ticketQuotaRemain = db.GetTicketQuota(employee);
                Ticket_Quota ticketBonus = db.GetTicketBonus(employee.CID);
                Ticket_Quota ticketDetails = db.GetTicketQuotaFromTicketDetails(employee.CID, null);

                ticketQuotaRemain = TicketModel.TicketQuotaPlus(ticketQuotaRemain, ticketBonus);
                ticketQuotaRemain = TicketModel.TicketQuotaMinus(ticketQuotaRemain, ticketDetails);
            }
        }

        public TicketFormModel(string cid)
        {
            TicketDal db = new TicketDal();
            if (!string.IsNullOrEmpty(cid) && LstFormDetail == null)
            {
                employee = db.GetTicketEmployee(cid);
                LstFormDetail = db.GetTicketFormDetailByFamily(cid);
            }

            CID = employee.CID;
            Fullname = employee.Fullname;
            TicketStatus = TicketFormStatus.Creating;

            if (!string.IsNullOrEmpty(CID) && employee.EmployeeTypeID != null)
            {
                ticketQuota = db.GetTicketQuota(employee);
                if (ticketQuota == null)
                {
                    ticketQuota = new Ticket_Quota();
                }
                foreach (var type in TicketModel.DicTicketType)
                {
                    if (ticketQuota.GetType().GetProperty(type.Key).GetValue(ticketQuota) == null)
                        ticketQuota.GetType().GetProperty(type.Key).SetValue(ticketQuota, 0);
                }
                ticketQuotaRemain = db.GetTicketQuota(employee);
                Ticket_Quota ticketBonus = db.GetTicketBonus(employee.CID);
                Ticket_Quota ticketDetails = db.GetTicketQuotaFromTicketDetails(employee.CID, null);

                ticketQuotaRemain = TicketModel.TicketQuotaPlus(ticketQuotaRemain, ticketBonus);
                ticketQuotaRemain = TicketModel.TicketQuotaMinus(ticketQuotaRemain, ticketDetails);
            }
        }

        public TicketFormModel(Ticket_Form iTicketForm)
        {
            TicketDal db = new TicketDal();
            //if  (iTicketForm.CID == ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString())
            //{
            if (iTicketForm.Status != null)
            {
                ID = iTicketForm.ID;
                CID = iTicketForm.CID;
                Fullname = iTicketForm.Fullname;
                TicketStatus = (TicketFormStatus)Enum.ToObject(typeof(TicketFormStatus), iTicketForm.Status.Value);
                if (!string.IsNullOrEmpty(CID))
                {
                    employee = db.GetTicketEmployee(CID);
                }

                bool getFamily = true;
                Ticket_Quota ticketDetails = null;
                int? exlusiveFormID = null;
                switch (iTicketForm.Status.Value)
                {
                    case (int)TicketFormStatus.Waiting:
                    case (int)TicketFormStatus.OverQuota:
                        exlusiveFormID = iTicketForm.ID;
                        break;
                    case (int)TicketFormStatus.Processing:
                    case (int)TicketFormStatus.Accept:
                    case (int)TicketFormStatus.Done:
                    case (int)TicketFormStatus.Reject:                    
                        getFamily = false;
                        break;
                }
                if (iTicketForm.CID != ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString())
                    getFamily = false;

                LstFormDetail = db.GetTicketFormDetailByFormID(CID, iTicketForm.ID, getFamily);
                if (!string.IsNullOrEmpty(CID) && employee.EmployeeTypeID != null)
                {
                    ticketQuota = db.GetTicketQuota(employee);
                    if (ticketQuota == null)
                    {
                        ticketQuota = new Ticket_Quota();
                    }
                    foreach (var type in TicketModel.DicTicketType)
                    {
                        if (ticketQuota.GetType().GetProperty(type.Key).GetValue(ticketQuota) == null)
                            ticketQuota.GetType().GetProperty(type.Key).SetValue(ticketQuota, 0);
                    }
                    ticketQuotaRemain = db.GetTicketQuota(employee);
                    Ticket_Quota ticketBonus = db.GetTicketBonus(employee.CID);
                    ticketDetails = db.GetTicketQuotaFromTicketDetails(employee.CID, exlusiveFormID);

                    ticketQuotaRemain = TicketModel.TicketQuotaPlus(ticketQuotaRemain, ticketBonus);
                    ticketQuotaRemain = TicketModel.TicketQuotaMinus(ticketQuotaRemain, ticketDetails);
                }

            }
            //}            

        }

        public void Save()
        {
            TicketDal db = new TicketDal();
            db.SaveTicketForm(this);
        }

        public void Reject(string comment)
        {
            TicketDal db = new TicketDal();
            this.Contents = comment;
            db.RejectTicketForm(this);
        }

        public bool HaveWaitingTicket()
        {
            TicketDal db = new TicketDal();
            return db.HaveWaitingTicket(employee.CID);
        }
    }
}
