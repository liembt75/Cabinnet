using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Sys
{
    public class DatabaseInfo
    {
        string server, catalog, userid, password;
        public string Server { get { return server; } }
        public string Catalog { get { return catalog; } }
        public string User { get { return userid; } }
        public string Password { get { return password; } }
        
        public string ServerVietnamRedant { get; set; }
        public string CatalogVietnamRedant { get; set; }
        public string UserVietnamRedant { get; set; }
        public string PasswordVietnamRedant { get; set; }

        public string CatalogCMS { get; set; }
        public string ConnectionString
        {
            get
            {
                //data source = (local); initial catalog = ERMS;
                return string.Format("Data Source={0}; Initial Catalog={1}; User id={2}; Password={3};MultipleActiveResultSets=True;App=EntityFramework", Server, Catalog, User, Password);
            }
        }

        
        public string ConnectionStringforERMSModel
        {
            get
            {
                //data source = (local); initial catalog = ERMS;
                return string.Format(@"metadata = res://*/ERMSModel.csdl|res://*/ERMSModel.ssdl|res://*/ERMSModel.msl;provider=System.Data.SqlClient;provider connection string= ""data source={0};initial catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True;application name=EntityFramework&quot;""", Server, Catalog, User, Password);
            }
        }

        public string ConnectionStringforVietnamRedantModel
        {
            get
            {
                if (string.IsNullOrEmpty(ServerVietnamRedant))
                    return string.Format(@"metadata = res://*/VietnamRedantModel.csdl|res://*/VietnamRedantModel.ssdl|res://*/VietnamRedantModel.msl;provider=System.Data.SqlClient;provider connection string= ""data source={0};initial catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True;application name=EntityFramework&quot;""", "10.105.2.252", "VietnamRedant", User, Password);                
                //data source = (local); initial catalog = ERMS;
                return string.Format(@"metadata = res://*/VietnamRedantModel.csdl|res://*/VietnamRedantModel.ssdl|res://*/VietnamRedantModel.msl;provider=System.Data.SqlClient;provider connection string= ""data source={0};initial catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True;application name=EntityFramework&quot;""", ServerVietnamRedant, CatalogVietnamRedant, UserVietnamRedant, PasswordVietnamRedant);
            }
        }

        public string ConnectionStringforCMSModel
        {
            get
            {                
                return string.Format(@"metadata=res://*/CMSModel.csdl|res://*/CMSModel.ssdl|res://*/CMSModel.msl;provider=System.Data.SqlClient;provider connection string= ""data source={0};initial catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True;application name=EntityFramework&quot;""", Server, CatalogCMS, User, Password);
            }
        }

        public DatabaseInfo(string _Server, string _Catalog, string _Userid, string _Password)
        {
            server = _Server;
            catalog = _Catalog;
            userid = _Userid;
            password = _Password;
        }

        public DatabaseInfo(string _Server, string _Catalog, string _Userid, string _Password, string _ServerVietnamRedant, string _CatalogVietnamRedant, string _UseridVietnamRedant, string _PasswordVietnamRedant, string _CatalogCMS)
        {
            server = _Server;
            catalog = _Catalog;
            userid = _Userid;
            password = _Password;

            //Nhan su cap nhat ve
            ServerVietnamRedant = _ServerVietnamRedant;
            CatalogVietnamRedant = _CatalogVietnamRedant;
            UserVietnamRedant = _UseridVietnamRedant;
            PasswordVietnamRedant = _PasswordVietnamRedant;

            //Tuyen dung web vncrew
            CatalogCMS = _CatalogCMS;
        }
    }
}
