using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class RouteModel
    {
        public TicketModel.TicketType ticketType;
        public List<Ticket_Airport> LstTicketAirport;
        public string Base;      

        public List<RouteDetail> lstRouteDetail = new List<RouteDetail>();
        public string routeString
        {
            get
            {
                if (lstRouteDetail.Count < 1)
                    return "";
                StringBuilder result = new StringBuilder();
                string oldTo = "";
                foreach (RouteDetail detail in lstRouteDetail)
                {
                    if (oldTo != detail.From)
                    {
                        if (result.Length > 0)
                            result.Append("//");
                        result.Append(detail.From);                        
                    }                                        
                    //result.Append(detail.From);
                    result.Append("-");
                    result.Append(detail.To);
                    oldTo = detail.To;
                }
                return result.ToString();
            }
        }

        public int soVe
        {
            get
            {
                if (lstRouteDetail.Count < 1)
                    return 0;                
                else
                    return (int)Math.Ceiling((double)lstRouteDetail.Count / 2); 
            }
        }

        public List<Ticket_Airport> LstTicketAirportTo(string codeFrom)
        {
            string route = LstTicketAirport.Where(t => t.Code == codeFrom).Select(t => t.Route).FirstOrDefault();
            if (!string.IsNullOrEmpty(route))
            {
                return LstTicketAirport.Where(t => route.Contains(t.Code)).ToList();
            }
            return new List<Ticket_Airport>();
        }

        public RouteModel()
        {
            TicketDal db = new TicketDal();
            LstTicketAirport = db.GetTicketAirport();
        }

        public void GetListRouteDetail(string routeString)
        {
            string[] arrRoute = routeString.Split(new char[] { '-' },
                               StringSplitOptions.RemoveEmptyEntries);
            RouteDetail routeDetail = null;
            string oldFrom = "";
            for (int i = 0; i < arrRoute.Length; i++)
            {
                if (string.IsNullOrEmpty(oldFrom))
                {
                    oldFrom = arrRoute[i];
                    continue;
                }
                else
                {
                    routeDetail = new RouteDetail();
                    routeDetail.From = oldFrom;
                    routeDetail.To = arrRoute[i].Substring(0, arrRoute[i].IndexOf("//") == -1 ? arrRoute[i].Length : arrRoute[i].IndexOf("//"));
                    if (arrRoute[i].IndexOf("//") > 0)
                        oldFrom = arrRoute[i].Substring(arrRoute[i].IndexOf("//") + 2);
                    else
                        oldFrom = routeDetail.To;
                    lstRouteDetail.Add(routeDetail);
                }                
                //routeDetail = new RouteDetail();
                //routeDetail = new RouteDetail();
                //routeDetail.From = arrRoute[i];
                //routeDetail.To = arrRoute[i + 1].Substring(0, arrRoute[i + 1].IndexOf(";") == -1 ? arrRoute[i + 1].Length : arrRoute[i + 1].IndexOf(";"));
                //lstRouteDetail.Add(routeDetail);

                //if (arrRoute[i + 1].IndexOf(";") > 0)
                //    oldFrom = arrRoute[i + 1].Substring(arrRoute[i + 1].IndexOf(";") + 1, arrRoute[i + 1].Length);
                //else
                //    oldFrom = routeDetail.To;
                //routeDetail = new RouteDetail();
                //routeDetail.From = arrRoute[i + 1].Substring(arrRoute[i + 1].IndexOf(";") + 1, arrRoute[i + 1].Length);
                //routeDetail.To = arrRoute[i + 2];                
            }            
        }
    }

    public class RouteDetail
    {
        public string From { get; set; }
        public string To { get; set; }        
    }
}
