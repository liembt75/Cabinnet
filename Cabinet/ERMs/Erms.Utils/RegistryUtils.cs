using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class RegistryUtils
    {
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "Software\\Cabinet";
        const string keyName = userRoot + "\\" + subkey;

        public static void GetServerValue(out string server, out string database, out string userName, out string pass)
        {
            server = (string)Registry.GetValue(keyName, "server", null);
            database = (string)Registry.GetValue(keyName, "database", null);
            userName = (string)Registry.GetValue(keyName, "user", null);
            pass = (string)Registry.GetValue(keyName, "pass", null);
        }

        public static void AddServerValue(string valueName, string valueData, RegistryValueKind valueType)
        {
            Registry.SetValue(keyName, valueName, valueData, valueType);
        }      
    }
}
