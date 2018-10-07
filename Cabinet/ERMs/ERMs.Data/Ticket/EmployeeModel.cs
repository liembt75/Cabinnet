using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class EmployeeModel
    {
        public enum EmployeeType
        {
            TiepVien = 41,
            Huu = 9999,
            MatDat = 9998            
        }

        public static Dictionary<string, EmployeeType> DicEmployeeType = new Dictionary<string, EmployeeType>()
        {
            {"Tiếp viên", EmployeeType.TiepVien },            
            {"Mặt đất", EmployeeType.MatDat },
            {"Hưu", EmployeeType.Huu }
        };
    }
}
