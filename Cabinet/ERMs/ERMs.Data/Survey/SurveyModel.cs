using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class SurveyModel : CR_Survey
    {
        public CR_FlightInfo FlightInfo { get; set; }
        public List<CR_Survey_Item> Items { get; set; }

        public SurveyModel ToModel(CR_Survey item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }
            return this;
        }

        public CR_Survey ToData()
        {
            CR_Survey returnValue = new CR_Survey();
            PropertyInfo[] sourceProperties = returnValue.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = returnValue.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(returnValue, sourcePi.GetValue(this, null), null);
            }
            return returnValue;
        }
    }
}
