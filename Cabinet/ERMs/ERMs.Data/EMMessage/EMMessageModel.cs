using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class EMMessageModel : EM_Message
    {
        public List<EM_Message> Items { get; set; }
        public EMMessageModel ToCustomModel(EM_Message item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }
            return this;
        }

        public EM_Message ToEntityModel()
        {
            EM_Message returnValue = new EM_Message();
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
