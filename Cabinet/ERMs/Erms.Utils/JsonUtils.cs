using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class JsonUtils
    {
        public static void SerializeObject(Object T)
        {
            string test = JsonConvert.SerializeObject(T);
            //JObject test = new JObject(DateTime.Now);            
        }
    }
}
