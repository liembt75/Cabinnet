using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class DBFUtils
    {
        public DataTable GetYourData(string textSource)
        {
            DataTable YourResultSet = new DataTable();            
            OleDbConnection yourConnectionHandler = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=D:\\");
            yourConnectionHandler.Open();

            if (yourConnectionHandler.State == ConnectionState.Open)
            {
                //string mySQL = "select * from qlns.DBF where manv='0004'";  // dbf table name
                string mySQL = "select * from ctgbtt1704.DBF";  // dbf table name

                OleDbCommand MyQuery = new OleDbCommand(mySQL, yourConnectionHandler);
                OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);

                DA.Fill(YourResultSet);

                yourConnectionHandler.Close();
            }
            return YourResultSet;
        }
    }
}
