using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Sys
{
    public class ActiveDirInfo
    {
        string ipAddress;

        public string LDAP { get { return string.Format("LDAP://{0}/", ipAddress.Trim()); } }
        public string User { get { return ""; } }
        public string Password { get { return ""; } }
        public ActiveDirInfo(string ip)
        {
            this.ipAddress = ip;
        }
    }
}
