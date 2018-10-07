using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Sys
{
   public class SabreInfo
    {
        string empid, passcode;
        public string Empid
        {
            get
            {
                return empid;
            }
        }
        public string Passcode
        {
            get
            {
                return passcode;
            }
        }
        public string Suff
        {
            get
            {
                return "VN".PadRight(5).ToUpper();

            }
        }
        public string Duty { get { return "."; } }
        public string Area
        {
            get
            {
                return "A";
            }
        }

        public SabreInfo(string _Empid, string _Passcode)
        {
            this.empid = _Empid;
            this.passcode = _Passcode;
        }
    }
}
