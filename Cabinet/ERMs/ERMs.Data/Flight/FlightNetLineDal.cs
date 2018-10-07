using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class FlightNetLineDal
    {
        public List<USP_GetFlight_NetLine_Result> GetFlightNetLine(DateTime fromdate, DateTime todate, string keyword)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.USP_GetFlight_NetLine(fromdate, todate, keyword).ToList();
            }
        }

        public List<CR_FlightInfo_Netline> GetNetLineFlight(DateTime fromdate, DateTime todate, string keyword)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_FlightInfo_Netline.Where(i => i.UTCDate >= fromdate && i.UTCDate <= todate).OrderBy(i => i.UTCDepart).ToList();
            }
        }

        public List<CR_FlightInfo_Netline> GetDTVFlight(DateTime fromdate, DateTime todate, string keyword)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.CR_FlightInfo_Netline.Where(i => i.UTCDate >= fromdate && i.UTCDate <= todate && i.Refflightid == null).OrderBy(i => i.UTCDepart).ToList();
            }
        }

        public List<CR_FlightInfo> GetDTVFlight(DateTime fromdate, DateTime todate, string keyword, List<CR_FlightInfo_Netline> lstNetLineFlightRef)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var lstRefflightid = lstNetLineFlightRef.Select(j => j.Refflightid);
                return context.CR_FlightInfo.Where(i => i.Date >= fromdate && i.Date <= todate && (i.IsDeleted == null || i.IsDeleted == false) && !lstRefflightid.Contains(i.FlightID)).ToList();
            }
        }

        public bool SetFlightReference(USP_GetFlight_NetLine_Result rowFlightInfo, USP_GetFlight_NetLine_Result rowFlightInfoNetLine)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    var flightInfoNetLineEntity = context.CR_FlightInfo_Netline.Where(i => i.ID == rowFlightInfoNetLine.ID).FirstOrDefault();
                    if (flightInfoNetLineEntity != null)
                    {
                        flightInfoNetLineEntity.Refflightid = rowFlightInfo.FlightID;
                        flightInfoNetLineEntity.Auto = false;
                        flightInfoNetLineEntity.Modified = DateTime.Now;
                        flightInfoNetLineEntity.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.ShortName;
                        context.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
        }


        #region Use FORM FO NETLINE
        public List<USP_GetFlights_NL_FO_byKeyword_Result> GetFOFlights(DateTime fromdate, DateTime todate, string keyword)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.USP_GetFlights_NL_FO_byKeyword(fromdate,todate,keyword).ToList();
            }
        }

        public List<USP_GetFlights_NL_FO_byFLT_Result> GetFlights_byFLT(DateTime fltdate,string flightNo, string route)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.USP_GetFlights_NL_FO_byFLT(fltdate, route, flightNo).ToList();
            }
        }

        public int Match(int flightid, USP_GetFlights_NL_FO_byFLT_Result occ)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                //xoa ref id
                var items = context.CR_FlightInfo_Netline.Where(i => i.Refflightid == flightid).ToList();
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        item.Refflightid = null;
                        item.Modified = DateTime.Now;
                        item.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;

                    }
                }
                var model = context.CR_FlightInfo_Netline.Where(i => i.ID == occ.NlID).FirstOrDefault();
                if (model == null) return 0;

                model.Refflightid = flightid;
                model.Auto = false;
                model.Modified = DateTime.Now;
                model.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                context.SaveChanges();
            }

            return 1;
        }

        public int FoCancel(int  flightid)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {

                var model = context.CR_FlightInfo.Where(i => i.FlightID == flightid).FirstOrDefault();
                if (model == null) return 0;

                model.IsDeleted  = true;
                model.isLocked = true;
                model.Modified = DateTime.Now;
                model.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                context.SaveChanges();
            }

            return 1;
        }

        #endregion

    }
}
