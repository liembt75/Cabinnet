using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class ListUtils
    {
        public static void LoadRows<T>(DataTable dt, IList<T> list)
        {
            Type elementType = typeof(T);
            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                dt.Columns.Add(propInfo.Name, ColType);
            }
            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = dt.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    if (dt.Columns.Contains(propInfo.Name))
                        row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                dt.Rows.Add(row);
            }

        }
    }
}
