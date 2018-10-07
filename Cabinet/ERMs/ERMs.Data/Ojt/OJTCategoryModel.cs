using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class OJTCategoryModel : CR_OJT_Category
    {
        public BindingList<OJTLessonModel> OJTLesson { get; set; }
        public OJTCategoryModel ToCustomModel(CR_OJT_Category item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }
            return this;
        }

        public CR_OJT_Category ToEntityModel()
        {
            CR_OJT_Category returnValue = new CR_OJT_Category();
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
