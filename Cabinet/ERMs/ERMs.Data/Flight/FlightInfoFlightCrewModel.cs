using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Flight
{
    public class FlightInfoFlightCrewModel: CR_FlightInfo
    {
        public string strFlightID { get; set; }
        public string FlightInfoNo { get; set; }
        public string Task { get; set; }
        public string FirstNameVn { get; set; }
        public string LastNameVn { get; set; }
        public string CrewID { get; set; }
        public string Ability { get; set; }
        public string FO_Job { get; set; }
        public string FO_Cfg { get; set; }
        public string Job { get; set; }
        public string CA { get; set; }
        public string ANN { get; set; }
        public string Training { get; set; }
        public string VIP { get; set; }       
        public string DutyFree { get; set; }
        public string CrewNo { get; set; }

        public static List<FlightInfoFlightCrewModel> ToModel(FlightInfoModel flightInfoModel, int FlightInfoNo)
        {
            FlightDal db = new FlightDal();
            List<FlightInfoFlightCrewModel> lstResult = new List<FlightInfoFlightCrewModel>();
            
            FlightInfoFlightCrewModel flightInfoFlightCrewModel = null;
            foreach (var flightCrew in db.GetFlightCrewByFlightID(flightInfoModel.FlightID))
            {
                flightInfoFlightCrewModel = new FlightInfoFlightCrewModel();
                flightInfoFlightCrewModel.FirstNameVn = flightCrew.FirstNameVn;
                flightInfoFlightCrewModel.LastNameVn = flightCrew.LastNameVn;
                flightInfoFlightCrewModel.CrewID = flightCrew.CrewID;
                flightInfoFlightCrewModel.Ability = flightCrew.Ability;
                flightInfoFlightCrewModel.FO_Cfg = flightCrew.FO_Cfg;
                flightInfoFlightCrewModel.FO_Job = flightCrew.FO_Job;
                flightInfoFlightCrewModel.Job = flightCrew.Job;
                flightInfoFlightCrewModel.CA = flightCrew.CA;
                flightInfoFlightCrewModel.ANN = flightCrew.ANN;
                flightInfoFlightCrewModel.Training = flightCrew.Training;
                flightInfoFlightCrewModel.VIP = flightCrew.VIP;
                flightInfoFlightCrewModel.DutyFree = flightCrew.DutyFree;

                flightInfoFlightCrewModel.FlightNo = flightInfoModel.FlightNo;
                flightInfoFlightCrewModel.Date = flightInfoModel.Date;
                flightInfoFlightCrewModel.Routing = flightInfoModel.Routing;

                lstResult.Add(flightInfoFlightCrewModel);
            }
            if (lstResult.Count > 0)
            {
                flightInfoFlightCrewModel = lstResult[0];                
                flightInfoFlightCrewModel.FlightID = flightInfoModel.FlightID;
                flightInfoFlightCrewModel.strFlightID = flightInfoFlightCrewModel.FlightID.ToString();
                flightInfoFlightCrewModel.FlightNo = flightInfoModel.FlightNo;
                flightInfoFlightCrewModel.Routing = flightInfoModel.Routing;
                flightInfoFlightCrewModel.Aircraft = flightInfoModel.Aircraft;

                flightInfoFlightCrewModel.Date = flightInfoModel.Date;
                flightInfoFlightCrewModel.Departed = flightInfoModel.Departed;

                flightInfoFlightCrewModel.TotalPax = flightInfoModel.TotalPax;
                flightInfoFlightCrewModel.TotalPaxC = flightInfoModel.TotalPaxC;
                flightInfoFlightCrewModel.TotalPaxY = flightInfoModel.TotalPaxY;
                flightInfoFlightCrewModel.TotalVIP = flightInfoModel.TotalVIP;
                flightInfoFlightCrewModel.Creatorid = flightInfoModel.Creatorid;
                flightInfoFlightCrewModel.Modifierid = flightInfoModel.Modifierid;
                flightInfoFlightCrewModel.Purserid = flightInfoModel.Purserid;
                flightInfoFlightCrewModel.PurserName = flightInfoModel.PurserName;

                flightInfoFlightCrewModel.CrewTaskStatus = flightInfoModel.CrewTaskStatus;
                flightInfoFlightCrewModel.Task = flightInfoModel.CrewTaskStatus == 1 ? "Done" : (flightInfoFlightCrewModel.Departed > DateTime.Now ? "Comming" : "Pending");
                flightInfoFlightCrewModel.FlightInfoNo = FlightInfoNo.ToString();
                flightInfoFlightCrewModel.CrewNo = lstResult.Count.ToString();
            }
            return lstResult;
        }
    }
}
