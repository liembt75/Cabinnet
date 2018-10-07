using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Task
{
    public class TaskDal
    {
     
        public List<TaskModel> GetTasks(DateTime fromdate, DateTime todate, string keyword, int pageNumber, int pageSize, bool isAll, bool isCompleted, bool isInProgress, bool isLate, string departments, int accountID)
        { 
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {

                //List<TaskModel> items = context.HR_GetTasks(crewid,fromdate,todate,status, department,keyword).Select( o => new TaskModel {
                List < TaskModel > items = context.API_HR_USP_GetTasks2(fromdate, todate, keyword, pageNumber, pageSize, isAll, isCompleted, isInProgress, isLate, departments, accountID).Select(o => new TaskModel {
                    ID = o.ID,
                    Date = o.TaskDate,
                    Title = o.Title,
                    Description = o.Description,
                    TaskMaster = o.TaskMaster,
                    Deadline = o.Deadline,
                    Completed = o.Completed,
                    Progress = o.Progress,
                    Reason = o.Reason,
                    DueDate = o.DueDate,                    
                    AttachmentGroupId = o.AttachmentGroupId,
                    IsDeleted = o.IsDeleted,               
                    Assignees1 = o.Assignee,
                    Assignees2 = o.Assignee2,
                    FullNameWithDept = o.FullNameWithDept,
                    ArrayNote = o.ArrayNote
                }).OrderByDescending(o => o.ID).ToList();

                //foreach (var item in items)
                //{
                //    item.Items.Add(new TaskDetailModel(item.Description));
                //}

                return items;
            }         
        }


        public TaskModel  GetTask(int id)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {

                TaskModel item = context.HR_Task.Where(o => o.ID == id).Select(o => new TaskModel
                {
                    ID = o.ID,
                    Date = o.Date,
                    Title = o.Title,
                    Description = o.Description,
                    TaskMaster = o.TaskMaster,
                    Deadline = o.Deadline,
                    Completed = o.Completed,
                    Progress = o.Progress,
                    Reason = o.Reason,
                    DueDate = o.DueDate,
                    Note = o.Note,
                    AttachmentGroupId = o.AttachmentGroupId,
                    IsDeleted = o.IsDeleted,
                    Created = o.Created,
                    Modified = o.Modified,
                    Creator = o.Creator,
                    Modifier = o.Modifier,
                    Creatorid = o.Creatorid,
                    Modifierid = o.Modifierid

                }).FirstOrDefault();

                return item;
            }

        }

        public void Save(TaskModel item)
        {

            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                //Insert
                if (item.ID <= 0)
                    context.HR_Task.Add(item.ToTask());
                else
                {
                    HR_Task model = context.HR_Task.Where(o => o.ID == item.ID).FirstOrDefault();
                    if (model == null) return;
                    model.Title = item.Title;
                    model.Description = item.Description;

                    model.DueDate = item.DueDate < new DateTime(2000, 6, 1) ? null : item.DueDate;
                    model.Reason = item.Reason;

                }

                context.SaveChanges();

            }

        }

        public TaskModel GetTaskByID(int id)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                TaskModel item = context.HR_Task.Where(o => o.ID == id).Select(o => new TaskModel
                {
                    ID = o.ID,
                    Date = o.Date,
                    Title = o.Title,
                    Description = o.Description,
                    TaskMaster = o.TaskMaster,
                    Deadline = o.Deadline,
                    Completed = o.Completed,
                    Progress = o.Progress,
                    Reason = o.Reason,
                    DueDate = o.DueDate,
                    Note = o.Note,
                    AttachmentGroupId = o.AttachmentGroupId,
                    IsDeleted = o.IsDeleted,
                    Created = o.Created,
                    Modified = o.Modified,
                    Creator = o.Creator,
                    Modifier = o.Modifier,
                    Creatorid = o.Creatorid,
                    Modifierid = o.Modifierid,                          
                }).FirstOrDefault();
                item.lstHR_Task_Management = context.API_HR_USP_GetTaskManagementByTaskID(id).ToList();
                item.lstHR_Task_Management2 = context.API_HR_USP_GetTaskManagement2ByTaskID(id).ToList();
                return item;
            }

        }

        public void Save(HR_Task task, List<HR_Task_Management> lstTaskManageMent, List<HR_Task_Management2> lstTaskManageMent2)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.HR_Task.Add(task);
                        context.SaveChanges();
                        foreach (HR_Task_Management taskManagement in lstTaskManageMent)
                        {
                            taskManagement.TaskID = task.ID;
                        }
                        foreach (HR_Task_Management2 taskManagement2 in lstTaskManageMent2)
                        {
                            taskManagement2.TaskID = task.ID;
                        }
                        context.HR_Task_Management.AddRange(lstTaskManageMent);
                        context.HR_Task_Management2.AddRange(lstTaskManageMent2);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public void UpdateTaskManagement(API_HR_USP_GetTaskManagementByTaskID_Result employee)
        {
            try
            {
                using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
                {
                    HR_Task_Management taskManageMent = context.HR_Task_Management.Where(i => i.ID == employee.ID).FirstOrDefault();
                    taskManageMent.Progress = employee.Progress;
                    taskManageMent.Reason = employee.Reason;
                    taskManageMent.Note = employee.Note;
                    taskManageMent.Modified = DateTime.Now;
                    taskManageMent.Modifierid = employee.AccountID.ToString();
                    taskManageMent.Modifier = employee.LastNameVn + " " + employee.FirstNameVn;
                    context.SaveChanges();
                }
            }
            catch { throw; }
        }

        public List<EX_Attachment> GetTaskAttachmentByGroupID(int groupID)
        {
            try
            {
                using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
                {
                    return context.EX_Attachment.Where(i => i.GroupID == groupID).ToList();
                }                
            }
            catch
            {
                return null;
            }
        }
    }
}
