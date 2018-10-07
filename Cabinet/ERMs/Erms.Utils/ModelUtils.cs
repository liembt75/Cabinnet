using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class ModelUtils
    {
        public static void CopyProperties(object from, object to)
        {
            foreach (PropertyInfo property in from.GetType().GetProperties())
            {
                if (!property.CanRead || (property.GetIndexParameters().Length > 0))
                    continue;

                PropertyInfo other = to.GetType().GetProperty(property.Name);
                if ((other != null) && (other.CanWrite))
                    other.SetValue(to, property.GetValue(from, null), null);                
            }
        }
    }
}
