using Erms.Utils;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Sys
{
  public  class UserInfo
    {
        //public string userName;
        int _Userid;
        string  _Code, _FullName, _UserName, _ShortName, _Token,  _Department;

        public int Userid
        {
            get
            {
                return _Userid;
            }

        }
        public string UserName
        {
            get
            {
                return _UserName;
            }
        }
        public string Code
        {
            get
            {
                return _Code;
            }
        }
        public string ShortName
        {
            get
            {
                return _ShortName;
            }
        }
        public string FullName
        {
            get
            {
                return _FullName;
            }
        }

        public string Token
        {
            get
            {
                return _Token;
            }
        }
     
        public string Department {
            get
            {
                return _Department;
            }
        }

        public UserInfo()
        {
            _Userid = 0;
            _Code = "";
            _FullName = "";
            _ShortName = "";

        }

        public void Signin(string user, string pass)
        {            
            string domainIP = "EAAAAKBH8ZJSk0hkvoj8CpWM/TV8pFE7lBS54XqrgtZqzaOH";                                 
            string sqlServerVietnamRedant = "EAAAAL5lHHJUn4Bpz7R3mP4J9xc5dMvqj3AyDJttKEbTbFjE";            
            string sqlDatabaseVietnamRedant = "EAAAAD+67mFveESi+iQmSVBKDQvsXzugpy6sUi7vOUejoKN/";
            string sqlDatabaseCMS = "EAAAAEsnEiekdNZMyh7yVFMA4SQPv6PTPjPc+jMCAU+ebnys";

            domainIP = Crypto.DecryptStringAES(domainIP, "dtv");
            sqlServerVietnamRedant = Crypto.EncryptStringAES(sqlServerVietnamRedant, "dtv");
            sqlDatabaseVietnamRedant = Crypto.EncryptStringAES(sqlDatabaseVietnamRedant, "dtv");
            sqlDatabaseCMS = Crypto.EncryptStringAES(sqlDatabaseCMS, "dtv");

#if (DEBUG)
#else
            //userName = user;
            using (DirectoryEntry de = new DirectoryEntry(@"LDAP://" + domainIP, user, pass))
            {
                try
                {
                    string name = de.Name.ToString();
                    //this.user = user;
                }
                catch
                {
                    throw new Exception("Tên đăng nhập và mật khẩu không đúng");
                }
            }
#endif


            
            string strServer, strDatabase, strUser, strPass;
            //string secretKey = Environment.MachineName;
            //RegistryUtils.GetServerValue(out strServer, out strDatabase, out strUser, out strPass);
            //if (strServer != null) strServer = Crypto.DecryptStringAES(strServer, secretKey);
            //if (strDatabase != null) strDatabase = Crypto.DecryptStringAES(strDatabase, secretKey);
            //if (strUser != null) strUser = Crypto.DecryptStringAES(strUser, secretKey);
            //if (strPass != null) strPass = Crypto.DecryptStringAES(strPass, secretKey);

            strServer = "118.69.198.212";
            strDatabase = "ERMS";
            strUser = "kit";
            strPass = "12345^&*()";

            //DatabaseInfo database = new DatabaseInfo(sqlServer, sqlDatabase, sqlUser, sqlPassword, sqlServerVietnamRedant, sqlDatabaseVietnamRedant, sqlUser, sqlPassword, sqlDatabaseCMS);
            DatabaseInfo database = new DatabaseInfo(strServer, strDatabase, strUser, strPass, sqlServerVietnamRedant, sqlDatabaseVietnamRedant, strUser, strPass, sqlDatabaseCMS);
            //DatabaseInfo database = new DatabaseInfo(sqlServer, sqlDatabase, sqlUser,sqlPassword, sqlServerVietnamRedant, sqlDatabaseVietnamRedant, sqlUser, sqlPassword, sqlDatabaseCMS);
            ActiveDirInfo author = new ActiveDirInfo(domainIP);

            //Get Userinfo from Database            
            this.LoadSysAccount(database.ConnectionString, user);

            ConfigurationSetting.SetConfiguration(this, database, author);
            //Set Sabre account;
            //ConfigurationSetting.SetSabreAccount(new SabreInfo(sabreUser, sabrPasscode));

            

        }

        public void InitDatabase()
        {
            string domainIP = "EAAAAKBH8ZJSk0hkvoj8CpWM/TV8pFE7lBS54XqrgtZqzaOH";
            string sqlServerVietnamRedant = "EAAAAL5lHHJUn4Bpz7R3mP4J9xc5dMvqj3AyDJttKEbTbFjE";
            string sqlDatabaseVietnamRedant = "EAAAAD+67mFveESi+iQmSVBKDQvsXzugpy6sUi7vOUejoKN/";
            string sqlDatabaseCMS = "EAAAAEsnEiekdNZMyh7yVFMA4SQPv6PTPjPc+jMCAU+ebnys";

            domainIP = Crypto.DecryptStringAES(domainIP, "dtv");
            sqlServerVietnamRedant = Crypto.EncryptStringAES(sqlServerVietnamRedant, "dtv");
            sqlDatabaseVietnamRedant = Crypto.EncryptStringAES(sqlDatabaseVietnamRedant, "dtv");
            sqlDatabaseCMS = Crypto.EncryptStringAES(sqlDatabaseCMS, "dtv");
            
            string strServer, strDatabase, strUser, strPass;
            //string secretKey = Environment.MachineName;
            //RegistryUtils.GetServerValue(out strServer, out strDatabase, out strUser, out strPass);
            //if (strServer != null) strServer = Crypto.DecryptStringAES(strServer, secretKey);
            //if (strDatabase != null) strDatabase = Crypto.DecryptStringAES(strDatabase, secretKey);
            //if (strUser != null) strUser = Crypto.DecryptStringAES(strUser, secretKey);
            //if (strPass != null) strPass = Crypto.DecryptStringAES(strPass, secretKey);
            strServer = "118.69.198.212";
            strDatabase = "ERMS";
            strUser = "kit";
            strPass = "12345^&*()";

            //DatabaseInfo database = new DatabaseInfo(sqlServer, sqlDatabase, sqlUser, sqlPassword, sqlServerVietnamRedant, sqlDatabaseVietnamRedant, sqlUser, sqlPassword, sqlDatabaseCMS);
            DatabaseInfo database = new DatabaseInfo(strServer, strDatabase, strUser, strPass, sqlServerVietnamRedant, sqlDatabaseVietnamRedant, strUser, strPass, sqlDatabaseCMS);
            ActiveDirInfo author = new ActiveDirInfo(domainIP);

            ConfigurationSetting.SetConfiguration(this, database, author);
            //Set Sabre account;
            //ConfigurationSetting.SetSabreAccount(new SabreInfo(sabreUser, sabrPasscode));
        }

        public void InitUser(string CID)
        {
            using (LinqModelDataContext context = new LinqModelDataContext(ConfigurationSetting.Database.ConnectionString))
            {
                Sys_Account item = context.Sys_Accounts.Where(o => o.CrewID == CID && (o.IsDeleted == false || o.IsDeleted == null)).FirstOrDefault();
                if (item != null)
                {
                    this._UserName = item.Account;
                    this._Userid = item.ID;
                    this._Code = item.CrewID;
                    this._ShortName = item.FirstNameVn;
                    this._FullName = string.Format("{0} {1}", item.LastNameVn, item.FirstNameVn);
                    this._UserName = item.Account;
                    this._Token = item.Token;

                    this._Department = "N/A";
                    return;
                }

            }
        }

        private void LoadSysAccount(string connectionString, string user)
        {
            using (LinqModelDataContext context = new LinqModelDataContext(connectionString))
            {
                Sys_Account item = context.Sys_Accounts.Where(o => o.Account == user && (o.IsDeleted == false || o.IsDeleted == null)).FirstOrDefault();
                if(item != null)
                {
                    this._UserName = item.Account;
                    this._Userid = item.ID;
                    this._Code = item.CrewID;
                    this._ShortName = item.FirstNameVn;
                    this._FullName = string.Format("{0} {1}", item.LastNameVn, item.FirstNameVn);
                    this._UserName = item.Account;
                    this._Token = item.Token;

                    this._Department = "N/A";
                    return;
                }

            }
        }
    }
}
