using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DataAccess
{
    class Class1
    {

        public void Get()
        {

            using (var context = new ERMSEntities())
            {
                var model = new CR_FlightInfo()
                {
                    FlightNo = "VN01234" 
                    ,Date = DateTime.Today
                };
                //context.Database.Connection.ConnectionString
                context.CR_FlightInfo.Add(model);
                context.SaveChanges();
            }
        }
    }
}
