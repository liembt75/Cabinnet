using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Ticket
{
    public class TicketAirportModel
    {
        public string CodeFrom { get; set; }
        public string CodeTo { get; set; }
        public List<Ticket_Airport> LstCodeFrom { get; set; }
        public List<Ticket_Airport> lstCodeTo()
        {
            TicketDal db = new TicketDal();
            if (LstCodeFrom == null)
            {
                LstCodeFrom = db.GetTicketAirport();
            }
            string route = LstCodeFrom.Where(t => t.Code == CodeFrom).Select(t => t.Route).FirstOrDefault();
            return LstCodeFrom.Where(t => route.Contains(t.Code)).ToList();            
        }
    }    
}
