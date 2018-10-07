using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.HealthCare
{
    public class HealthCareModel : API_HR_USP_GetHealthCare_Result
    {
        public List<HR_HealthCare> Items { get; set; }
        HealthCareDal db = new HealthCareDal();
        public HealthCareModel()
        {
            Items = new List<HR_HealthCare>();
        }

        public HealthCareModel ToModel(API_HR_USP_GetHealthCare_Result item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }
            //this.Items.AddRange(db.GetHealthCareByCrewID(item.CrewID));
            return this;
        }
    }
}
