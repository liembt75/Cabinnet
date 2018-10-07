using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class TicketFormDetailPrint
    {
        public int FormID { get; set; }
        public string Number { get; set; }
        public string FullnameOffer { get; set; }
        public string JobTitleOffer { get; set; }
        public string CompanyOffer { get; set; }
        public string YearOffer { get; set; }

        public string Fullname { get; set; }
        public string Birthday { get; set; }
        public string Pid { get; set; }
        public string Relationship { get; set; }
        public string Route { get; set; }
        public string Base { get; set; }        

        public TicketFormDetailPrint(int iNumber, TicketFormModel form, Ticket_FormDetail formDetail)
        {            
            Number = iNumber.ToString();
            if (form.employee != null)
            {
                FullnameOffer = form.employee.Fullname;
                JobTitleOffer = form.employee.JobTitle;
                if (form.employee.WorkStartDate != null)
                {
                    //YearOffer = (DateTime.Now.Year - form.employee.WorkStartDate.Value.Year).ToString();
                    YearOffer = form.employee.WorkStartDate.Value.Month.ToString() + "/" + form.employee.WorkStartDate.Value.Year.ToString();
                }
                Fullname = formDetail.Fullname;
                if (formDetail.Birthday != null)
                    Birthday = formDetail.Birthday.Value.Year.ToString();
                Pid = formDetail.PID;
                Relationship = formDetail.Relationship == null ? "Bản thân" : formDetail.Relationship;
                Route = formDetail.Route;
                Base = formDetail.Base;
                FormID = formDetail.FormID;
            }
        }
    }
}
