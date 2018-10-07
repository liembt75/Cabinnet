using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Flight
{
    public class FlightAssessmentModel : API_CR_USP_GetAssessmentList2_Result
    {
        public List<CR_Flight_Assessment_Items> Items { get; set; }

        public FlightAssessmentModel()
        {
            Items = new List<CR_Flight_Assessment_Items>();
        }

        public FlightAssessmentModel ToModel(API_CR_USP_GetAssessmentList2_Result item)
        {            
            this.Aircraft = item.Aircraft;
            this.Arrived = item.Arrived;            
            this.CrewID = item.CrewID;
            this.CrewID1 = item.CrewID1;
            this.Date = item.Date;
            this.Departed = item.Departed;            
            this.FlightNo = item.FlightNo;
            //this.FullName = item.FullName;
            //this.FullName1 = item.FullName1;
            this.FirstNameVn = item.FirstNameVn;
            this.FirstNameVn1 = item.FirstNameVn1;
            this.LastNameVn = item.LastNameVn;
            this.LastNameVn1 = item.LastNameVn1;
            this.main_base = item.main_base;
            this.main_base2 = item.main_base2;
            this.Job = item.Job;
            this.JOB2 = item.JOB2;
            this.Group = item.Group;
            this.GROUP2 = item.GROUP2;
            this.ID = item.ID;            
            this.Lesson = item.Lesson;            
            this.Routing = item.Routing;
            this.Strength = item.Strength;            
            this.Weakness = item.Weakness;
            this.TotalScore = item.TotalScore;
            this.Created = item.Created;
            return this;
        }

    }
}
