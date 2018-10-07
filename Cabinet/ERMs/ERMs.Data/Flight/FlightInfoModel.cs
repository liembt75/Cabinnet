using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Flight
{
  public  class FlightInfoModel:CR_FlightInfo
    {

        public int Task { get; set; }
        public List<API_CR_USP_GetFlightCrewAdmin_Result> Crews { get; set; }
        public string Purser { get; set; }
        public int Marked { get; set; }
        //public string Task { get; set; }

        public FlightInfoModel()
        {
            Crews = new List<API_CR_USP_GetFlightCrewAdmin_Result>();
        }

        public FlightInfoModel ToModel(CR_FlightInfo item)
        {
            this.FlightID = item.FlightID;
            this.FlightNo = item.FlightNo;
            this.Routing = item.Routing;
            this.Aircraft = item.Aircraft;

            this.Date = item.Date;
            this.Departed = item.Departed;
            this.Classify = item.Classify;

            this.TotalPax = item.TotalPax;
            this.TotalPaxC = item.TotalPaxC;
            this.TotalPaxY = item.TotalPaxY;
            this.TotalVIP = item.TotalVIP;
            this.Creatorid = item.Creatorid;
            this.Modifierid = item.Modifierid;
            this.PurserName = item.PurserName;
            this.Purserid = item.Purserid;
            this.Carry = item.Carry;
            this.TotalINF = item.TotalINF;
            this.TotalSM = item.TotalSM;
            this.IsDeleted = item.IsDeleted;
            this.isLocked = item.isLocked.HasValue ? item.isLocked.Value : false;
            this.SpecialInfo = item.SpecialInfo;

            this.CrewTaskStatus = item.CrewTaskStatus;
            this.Task = this.CrewTaskStatus == 1 ? this.CrewTaskStatus.Value : (this.Departed > DateTime.Now ? 0 : 2);

            return this;
        }

        /// <summary>
        /// Unused
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        //public FlightInfoModel ToModel(API_CR_USP_GetFlight_ByKeyword_Result item)
        //{
        //    this.FlightID = item.FlightID;
        //    this.FlightNo = item.FlightNo;
        //    this.Routing = item.Routing;
        //    this.Aircraft = item.Aircraft;

        //    this.Date = item.Date;
        //    this.Departed = item.Departed;
                        
        //    this.TotalPax = item.TotalPax;
        //    this.TotalPaxC = item.TotalPaxC;
        //    this.TotalPaxY = item.TotalPaxY;
        //    this.TotalVIP = item.TotalVIP;
        //    this.Creatorid = item.Creatorid;
        //    this.Modifierid = item.Modifierid;
        //    this.PurserName = item.PurserName;
        //    this.Purserid = item.Purserid;
        //    this.Carry = item.Carry;
        //    this.TotalINF = item.TotalINF;
        //    this.TotalSM = item.TotalSM;
        //    this.IsDeleted = item.IsDeleted;
           

        //    this.CrewTaskStatus = item.CrewTaskStatus;
        //    this.Task = this.CrewTaskStatus == 1 ? this.CrewTaskStatus.Value : (this.Departed > DateTime.Now ? 0 : 2);

        //    return this;
        //}

        public FlightInfoModel ToModel(API_CR_USP_GetFlightExclamationTask_Result item)
        {
            this.FlightID = item.FlightID;
            this.FlightNo = item.FlightNo;
            this.Routing = item.Routing;
            this.Aircraft = item.Aircraft;

            this.Date = item.Date;
            this.Departed = item.Departed;

            this.Classify = item.Classify;
            this.TotalPax = item.TotalPax;
            this.TotalPaxC = item.TotalPaxC;
            this.TotalPaxY = item.TotalPaxY;
            this.TotalVIP = item.TotalVIP;
            this.Creatorid = item.Creatorid;
            this.Modifierid = item.Modifierid;
            this.PurserName = item.PurserName;
            this.Purserid = item.Purserid;
            this.Carry = item.Carry;
            this.TotalINF = item.TotalINF;
            this.TotalSM = item.TotalSM;
            this.IsDeleted = item.IsDeleted;
            this.isLocked = item.isLocked.HasValue? item.isLocked.Value: false;
            this.Arrived = item.Arrived;
            this.SpecialInfo = item.SpecialInfo;

            this.CrewTaskStatus = item.CrewTaskStatus;
            this.Task = this.CrewTaskStatus == 1 ? this.CrewTaskStatus.Value : (this.Departed > DateTime.Now ? 0 : 2);

            return this;
        }

        public FlightInfoModel ToModel(API_CR_USP_GetFlightExclamationTask1_Result item)
        {
            this.FlightID = item.FlightID;
            this.FlightNo = item.FlightNo;
            this.Routing = item.Routing;
            this.Aircraft = item.Aircraft;

            this.Date = item.Date;
            this.Departed = item.Departed;

            this.Classify = item.Classify;
            //this.TotalPax = item.TotalPax;
            this.TotalPaxC = item.TotalPaxC;
            this.TotalPaxY = item.TotalPaxY;
            this.TotalVIP = item.TotalVIP;
            //this.Creatorid = item.Creatorid;
            //this.Modifierid = item.Modifierid;
            this.PurserName = item.PurserName;
            this.Purserid = item.Purserid;
            this.Carry = item.Carry;
            this.TotalINF = item.TotalINF;
            this.TotalSM = item.TotalSM;
            this.IsDeleted = item.IsDeleted;
            this.isLocked = item.isLocked.HasValue ? item.isLocked.Value : false;
            this.Arrived = item.Arrived;
            //this.SpecialInfo = item.SpecialInfo;
            this.Marked = item.Marked;

            this.CrewTaskStatus = item.CrewTaskStatus;
            this.Task = this.CrewTaskStatus == 1 ? this.CrewTaskStatus.Value : (this.Departed > DateTime.Now ? 0 : 2);

            return this;
        }
    }
}
