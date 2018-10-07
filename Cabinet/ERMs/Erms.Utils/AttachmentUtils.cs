using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class AttachmentUtils
    {
        public static string GetAttachmentUrl(string filePath)
        {
            return filePath.Replace(@"\", @"/").Replace(@"D:/Sites/APIServices", @"http://api.doantiepvien.com.vn").Replace(@"D:/Sites/CrewAPI", @"https://api.crew.vn");
        }

        public static string GetThumbAttachmentUrl(string filePath)
        {
            return filePath.Replace(@"\", @"/").Replace(@"D:/Sites/APIServices", @"http://api.doantiepvien.com.vn").Replace(@"D:/Sites/CrewAPI", @"https://api.crew.vn");
        }
    }
}
