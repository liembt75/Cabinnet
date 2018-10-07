using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class OJTLessonItemModel : CR_OJT_Lesson_Item
    {
        public Color TextColorValue { get; set; }
        public OJTLessonItemModel ToCustomModel(CR_OJT_Lesson_Item item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }
            if (!string.IsNullOrWhiteSpace(item.TextColor))
                this.TextColorValue = ColorTranslator.FromHtml(item.TextColor);
            return this;
        }

        public CR_OJT_Lesson_Item ToEntityModel()
        {
            CR_OJT_Lesson_Item returnValue = new CR_OJT_Lesson_Item();
            PropertyInfo[] sourceProperties = returnValue.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = returnValue.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(returnValue, sourcePi.GetValue(this, null), null);
            }
            if (this.TextColorValue != null)
                returnValue.TextColor = HexConverter(this.TextColorValue);
            return returnValue;
        }

        private String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
    }
}
