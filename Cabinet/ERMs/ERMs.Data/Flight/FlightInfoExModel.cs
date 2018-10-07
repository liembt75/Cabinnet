using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class FlightInfoExModel : CR_FlightInfo
    {
        public string strDeparted {
            get
            {
                if (Departed != null)
                {
                    return Departed.Value.ToString("HH:mm");
                }
                else
                    return "";
            }
        }
        public string strArrived
        {
            get
            {
                if (Arrived != null)
                {
                    string result = Arrived.Value.ToString("HH:mm");
                    if (Arrived != null && Departed != null && Arrived.Value.Day - Departed.Value.Day >= 1)
                        result += " +";
                    return result;
                }
                else
                    return "";
            }
        }

        public CR_FlightInfo ToEntityModel()
        {
            CR_FlightInfo returnValue = new CR_FlightInfo();
            PropertyInfo[] sourceProperties = returnValue.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = returnValue.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(returnValue, sourcePi.GetValue(this, null), null);
            }
            return returnValue;
        }

        public FlightInfoExModel ToCustomModel(CR_FlightInfo item)
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
