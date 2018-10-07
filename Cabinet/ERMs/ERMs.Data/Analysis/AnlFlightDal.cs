using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Analysis
{
   public class AnlFlightDal
    {

        ERMSEntities context;
        public AnlFlightDal()
        {
            context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel);
        }
        public List<ASP_GetFlights_Result> GetFlights(DateTime? fromdate, DateTime? todate, string keyword)
        {
            return context.ASP_GetFlights(fromdate, todate, keyword).ToList();

        }

    }
}
