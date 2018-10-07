using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class TicketFormPrint
    {        
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Birthday { get; set; }
        public string JobTitle { get; set; }
        public string Company
        {
            get
            {
                return "Đoàn tiếp viên";
            }
        }
        public string SoVe { get; set; }
        public string LoaiVe { get; set; }
        public string Ngay
        {
            get
            {
                return DateTime.Now.Day.ToString();
            }
        }

        public string Thang
        {
            get
            {
                return DateTime.Now.Month.ToString();
            }
        }

        public string Nam
        {
            get
            {
                return DateTime.Now.Year.ToString();
            }
        }

        public TicketFormPrint(TicketFormModel iTicketForm)
        {
            ID = iTicketForm.ID;            
            SoVe = iTicketForm.Sove.ToString();
            LoaiVe = iTicketForm.LoaiVe;
            if (iTicketForm.employee != null)
            {
                Fullname = iTicketForm.employee.Fullname;
                JobTitle = iTicketForm.employee.JobTitle;            
                if (iTicketForm.employee.Birthday != null)
                    Birthday = iTicketForm.employee.Birthday.Value.ToString("dd/MM/yyyy");                
            }            
    }
    }
}
