using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Log
{
    public class CrewTaskLogModel : CR_Crew_Task_Update_Log
    {
        public string Table { get; set; }
        public string Key { get; set; }
        public string Column { get; set; }
        public string Action { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }            

        public CR_Crew_Task_Update_Log ToModel()
        {
            CR_Crew_Task_Update_Log log = new CR_Crew_Task_Update_Log();
            log.UserName = this.UserName;
            log.Description = String.Format("UserName: {0}, Table: {1}, Key: {2}, Column: {3}, Action: {4}, OldValue: {5}, NewValue: {6}",
                                      UserName,
                                      Table,
                                      Key,
                                      Column,
                                      Action,
                                      OldValue,
                                      NewValue);
            log.Created = this.Created;
            log.Modified = this.Modified;
            log.Creator = this.Creator;
            log.Modifier = this.Modifier;
            log.Creatorid = this.Creatorid;
            log.Modifierid = this.Modifierid;
            log.FlightID = this.FlightID;
            return log;
        }
    }
}
