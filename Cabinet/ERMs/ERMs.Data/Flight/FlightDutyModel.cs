using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class FlightDutyModel : USP_GetFlight_Dutyfree_Result
    {
        public List<API_CR_USP_GetFlightCrewAdmin_Result> Crews { get; set; }

        public FlightDutyModel()
        {
            Crews = new List<API_CR_USP_GetFlightCrewAdmin_Result>();
        }

        public FlightDutyModel ToCustomModel(USP_GetFlight_Dutyfree_Result item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }
            return this;
        }
    }
}
