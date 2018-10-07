using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Task
{
   public class TaskModel:HR_GetTasks_Result
    {
        public string FullNameWithDept { get; set; }

        public string ArrayNote { get; set; }
        //public List<TaskDetailModel> Items { get; set; }
        public List<API_HR_USP_GetTaskManagementByTaskID_Result> lstHR_Task_Management { get; set; }
        public List<API_HR_USP_GetTaskManagement2ByTaskID_Result> lstHR_Task_Management2 { get; set; }

        public TaskModel()
        {
            //Items = new List<Data.Task.TaskDetailModel>();
            lstHR_Task_Management = new List<API_HR_USP_GetTaskManagementByTaskID_Result>();
            lstHR_Task_Management2 = new List<API_HR_USP_GetTaskManagement2ByTaskID_Result>();
        }

        internal HR_Task ToTask()
        {
            throw new NotImplementedException();
        }
    }
}
