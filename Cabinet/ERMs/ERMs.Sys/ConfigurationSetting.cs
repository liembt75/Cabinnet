using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Sys
{
  public  class ConfigurationSetting
    {

        static UserInfo userInfo;
        public static UserInfo UserInfo
        {
            get
            {
                return userInfo;
            }
        }

        static SabreInfo sabreInfo;
        public static SabreInfo SabreInfo
        {
            get
            {
                if (sabreInfo == null) return new SabreInfo("", "");
                return sabreInfo;
            }
        }

        static DatabaseInfo database;
        public static DatabaseInfo Database
        {
            get
            {
              return  database;
            }
        }

        static ActiveDirInfo author;
        public static ActiveDirInfo ActiveDirInfo
        {
            get
            {
                return author;
            }
        }

        internal static void SetConfiguration(UserInfo _UserInfo, DatabaseInfo _DatabaseInfo, ActiveDirInfo _ActiveDir)
        {
            userInfo = _UserInfo;
            database = _DatabaseInfo;
            author = _ActiveDir;

        }

        public static void SetSabreAccount(SabreInfo si)
        {
            sabreInfo = si;
        }
      
    }
}
