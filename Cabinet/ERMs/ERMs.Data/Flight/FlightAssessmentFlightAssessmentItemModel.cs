using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Flight
{
    public class FlightAssessmentFlightAssessmentItemModel : API_CR_USP_GetAssessmentList2_Result
    {
        public string FlightAssessmentNo { get; set; }
        public string Question { get; set; }
        public int? Score { get; set; }

        public string strID { get; set; }

        public static List<FlightAssessmentFlightAssessmentItemModel> ToModel(API_CR_USP_GetAssessmentList2_Result flightAssessment, int flightAssessmentNo)
        {
            FlightDal flightDB = new FlightDal();
            List<FlightAssessmentFlightAssessmentItemModel> lstResult = new List<FlightAssessmentFlightAssessmentItemModel>();

            FlightAssessmentFlightAssessmentItemModel flightAssessmentFlightAssessmentItemModel = null;
            foreach (var flightCrew in flightDB.GetFlightInfoByFlightAssessmentID(flightAssessment.ID))
            {
                flightAssessmentFlightAssessmentItemModel = new FlightAssessmentFlightAssessmentItemModel();
                flightAssessmentFlightAssessmentItemModel.Question = flightCrew.Question;
                flightAssessmentFlightAssessmentItemModel.Score = flightCrew.Score;

                lstResult.Add(flightAssessmentFlightAssessmentItemModel);
                
                flightAssessmentFlightAssessmentItemModel.strID = flightAssessment.ID.ToString();
                flightAssessmentFlightAssessmentItemModel.Aircraft = flightAssessment.Aircraft;
                flightAssessmentFlightAssessmentItemModel.Arrived = flightAssessment.Arrived;
                flightAssessmentFlightAssessmentItemModel.Created = flightAssessment.Created;
                //flightAssessmentFlightAssessmentItemModel.Creator = flightAssessment.Creator;
                //flightAssessmentFlightAssessmentItemModel.Creatorid = flightAssessment.Creatorid;
                flightAssessmentFlightAssessmentItemModel.CrewID = flightAssessment.CrewID;
                flightAssessmentFlightAssessmentItemModel.CrewID1 = flightAssessment.CrewID1;
                flightAssessmentFlightAssessmentItemModel.Date = flightAssessment.Date;
                flightAssessmentFlightAssessmentItemModel.Departed = flightAssessment.Departed;
                flightAssessmentFlightAssessmentItemModel.FlightNo = flightAssessment.FlightNo;
                //flightAssessmentFlightAssessmentItemModel.FullName = flightAssessment.FullName;
                //flightAssessmentFlightAssessmentItemModel.FullName1 = flightAssessment.FullName1;
                flightAssessmentFlightAssessmentItemModel.FirstNameVn = flightAssessment.FirstNameVn;
                flightAssessmentFlightAssessmentItemModel.LastNameVn = flightAssessment.LastNameVn;
                flightAssessmentFlightAssessmentItemModel.FirstNameVn1 = flightAssessment.FirstNameVn1;
                flightAssessmentFlightAssessmentItemModel.LastNameVn1 = flightAssessment.LastNameVn1;
                flightAssessmentFlightAssessmentItemModel.Lesson = flightAssessment.Lesson;
                //flightAssessmentFlightAssessmentItemModel.LessonID = flightAssessment.LessonID;
                flightAssessmentFlightAssessmentItemModel.Routing = flightAssessment.Routing;
                flightAssessmentFlightAssessmentItemModel.Strength = flightAssessment.Strength;
                flightAssessmentFlightAssessmentItemModel.Weakness = flightAssessment.Weakness;
                flightAssessmentFlightAssessmentItemModel.TotalScore = flightAssessment.TotalScore;
                flightAssessmentFlightAssessmentItemModel.FlightAssessmentNo = flightAssessmentNo.ToString();
                flightAssessmentFlightAssessmentItemModel.Group = flightAssessment.Group;
                flightAssessmentFlightAssessmentItemModel.GROUP2 = flightAssessment.GROUP2;
                flightAssessmentFlightAssessmentItemModel.main_base = flightAssessment.main_base;
                flightAssessmentFlightAssessmentItemModel.main_base2 = flightAssessment.main_base2;                
            }
            if (lstResult.Count > 0)
            {
                flightAssessmentFlightAssessmentItemModel = lstResult[0];
                flightAssessmentFlightAssessmentItemModel.strID = flightAssessment.ID.ToString();
            //    flightAssessmentFlightAssessmentItemModel.Aircraft = flightAssessment.Aircraft;
            //    flightAssessmentFlightAssessmentItemModel.Arrived = flightAssessment.Arrived;
            //    flightAssessmentFlightAssessmentItemModel.Created = flightAssessment.Created;
            //    flightAssessmentFlightAssessmentItemModel.Creator = flightAssessment.Creator;
            //    flightAssessmentFlightAssessmentItemModel.Creatorid = flightAssessment.Creatorid;
            //    flightAssessmentFlightAssessmentItemModel.CrewID = flightAssessment.CrewID;
            //    flightAssessmentFlightAssessmentItemModel.CrewID1 = flightAssessment.CrewID1;
            //    flightAssessmentFlightAssessmentItemModel.Date = flightAssessment.Date;
            //    flightAssessmentFlightAssessmentItemModel.Departed = flightAssessment.Departed;
            //    flightAssessmentFlightAssessmentItemModel.FlightNo = flightAssessment.FlightNo;
            //    flightAssessmentFlightAssessmentItemModel.FullName = flightAssessment.FullName;
            //    flightAssessmentFlightAssessmentItemModel.FullName1 = flightAssessment.FullName1;
            //    flightAssessmentFlightAssessmentItemModel.Lesson = flightAssessment.Lesson;
            //    flightAssessmentFlightAssessmentItemModel.LessonID = flightAssessment.LessonID;
            //    flightAssessmentFlightAssessmentItemModel.Routing = flightAssessment.Routing;
            //    flightAssessmentFlightAssessmentItemModel.Strength = flightAssessment.Strength;
            //    flightAssessmentFlightAssessmentItemModel.Weakness = flightAssessment.Weakness;
            //    flightAssessmentFlightAssessmentItemModel.TotalScore = flightAssessment.TotalScore;
            //    flightAssessmentFlightAssessmentItemModel.FlightAssessmentNo = flightAssessmentNo.ToString();

            }
            return lstResult;
        }
    }
}
