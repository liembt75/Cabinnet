using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class HRFormModel : HR_Forms
    {
        public string LastNameVn { get; set; }
        public string FirstNameVn { get; set; }

        public string FullNameVn { get; set; }
        public string type_tv { get; set; }
        public string class_tv { get; set; }
        public string Group { get; set; }

        public string Base { get; set; }

        public string Term { get; set; }

        public string AttachmentText
        {
            get
            {
                if (Attachments != null && Attachments != 0)
                    return "Có";
                else
                    return "";
            }
            set { }
        }

        public HR_Forms ToEntityModel()
        {
            HR_Forms returnValue = new HR_Forms();
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
