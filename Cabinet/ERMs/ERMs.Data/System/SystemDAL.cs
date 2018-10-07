using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using System.Data.Entity.Core.Objects;
using ERMs.Sys;
using ERMs.Data.Support;

namespace ERMs.Data
{
    public class SystemDAL
    {
        public enum CRUD
        {
            C,
            R,
            U,
            D

        }

        

        public SystemDAL()
        {        
        }

        #region Role
        public List<Sys_Role> GetRoleList()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Role.ToList();
            }
        }

        public List<SYS_GetRoleActivity_Result> GetRoleActivityList(int RoleId)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.SYS_GetRoleActivity(RoleId).ToList();
            }
        }

        public bool UpdateRoleActivityList(List<SYS_GetRoleActivity_Result> lst)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                bool result = true;
                try
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        SYS_GetRoleActivity_Result m = lst[i];
                        if (m.ItemId.HasValue) //update
                        {
                            context.Sys_Role_Activity.Where(r => r.ID == m.ItemId).Update(r => new Sys_Role_Activity() { R = m.R, C = m.C, U = m.U, D = m.D });
                        }
                        else
                        {
                            Sys_Role_Activity mRA = new Sys_Role_Activity()
                            {
                                Activityid = m.ActivityId,
                                Roleid = m.RoleId,
                                C = m.C,
                                R = m.R,
                                U = m.U,
                                D = m.D
                            };
                            context.Sys_Role_Activity.Add(mRA);
                        }
                        if (i != 0 && i % 50 == 0)
                        {
                            context.SaveChanges();
                        }
                    }
                    context.SaveChanges();
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        public List<SYS_GetUsersbyActivity_Result> GetCRUDByActivityID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.SYS_GetUsersbyActivity(iD).ToList();
            }
        }

        public List<TiepVienLookUpModel> GetSysAccounts()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Account.Where(i => (i.IsDeleted == null || (i.IsDeleted != null && i.IsDeleted == false))).OrderBy(i => i.FirstNameVn).Select(i => new TiepVienLookUpModel { Code_tv = i.Code_tv, name_tv = i.name_tv, FirstNameVn = i.FirstNameVn }).ToList();
            }
        }


        #endregion

        #region User
        public List<Sys_Account> GetUserList(string SearchKey, int TopN = 4000)
        {
            if (SearchKey == null) SearchKey = "";

            List<Sys_Account> users = new List<Sys_Account>();
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var query = context.Sys_Account.AsQueryable();
                if (!string.IsNullOrEmpty(SearchKey))
                {
                    query = query.Where(s => s.CrewID == SearchKey
                                            || s.FirstNameVn == SearchKey 
                                            || s.Phone == SearchKey);
                }
                users.AddRange(query.OrderBy(s => s.CrewID).Take(TopN).ToList());

                if (users.Count == 0)
                {
                    query = context.Sys_Account.AsQueryable().Where(s =>  s.name_tv.IndexOf(SearchKey) >= 0 || s.Phone.IndexOf(SearchKey) >= 0);
                    users.AddRange(query.OrderBy(s => s.CrewID).Take(TopN).ToList());
                }

                return users;
            }
        }

        public List<SysActivityModel> GetActivities()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<SysActivityModel> lstAcitivtyModel = new List<SysActivityModel>();
                var lstActivity = context.Sys_Activity.OrderBy(o => o.ApplicationName);
                foreach (var activity in lstActivity)
                {
                    lstAcitivtyModel.Add(new SysActivityModel().ToModel(activity));
                }
                return lstAcitivtyModel;
            }

        }

        public SysActivityModel UpdateActivity(SysActivityModel item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                Sys_Activity itemDB = null;
                if (item.ID == 0)
                {
                    item.Modified = DateTime.Now;
                    item.Modifierid = ConfigurationSetting.UserInfo.Userid;
                    item.Modifier = ConfigurationSetting.UserInfo.FullName;
                    itemDB = item.ToData();
                    context.Sys_Activity.Add(itemDB);
                }
                else
                {                  
                    item.ActivityName = item.ActivityName;
                    item.ApplicationName = item.ApplicationName;
                    item.Code = item.Code;
                    item.Description = item.Description;

                    item.Isdeleted = item.Isdeleted;

                    item.Modified = DateTime.Now;
                    item.Modifierid = ConfigurationSetting.UserInfo.Userid;
                    item.Modifier = ConfigurationSetting.UserInfo.FullName;
                    itemDB = item.ToData();
                    context.Entry(itemDB).State = System.Data.Entity.EntityState.Modified;
                }

                context.SaveChanges();
                item.ID = itemDB.ID;
                return item;
            }

        }


        public Sys_Role UpdateRole(Sys_Role item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (item.ID == 0)
                {
                    item.Modified = DateTime.Now;
                    item.Modifierid = ConfigurationSetting.UserInfo.Userid;
                    item.Modifier = ConfigurationSetting.UserInfo.FullName;
                    context.Sys_Role.Add(item);
                }
                else
                {
                    Sys_Role model = context.Sys_Role.Where(o => o.ID == item.ID).FirstOrDefault();
                    if (model != null)
                    {
                        model.RoleName = item.RoleName;
                        model.Description = item.Description;
                        model.Note = item.Note;
                        model.Isdeleted = item.Isdeleted;

                        model.Modified = DateTime.Now;
                        model.Modifierid = ConfigurationSetting.UserInfo.Userid;
                        model.Modifier = ConfigurationSetting.UserInfo.FullName;

                    }
                }

                context.SaveChanges();

                return item;
            }
        }

        public List<SYS_GetRoleUser_Result> GetRoleUser(int roleID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.SYS_GetRoleUser(roleID).ToList();
            }
        }

        public List<SYS_GetUserActivity_Result> GetUserActivityList(int UserId)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.SYS_GetUserActivity(UserId).ToList();
            }
        }
       
        public bool UpdateUserActivityList(List<SYS_GetUserActivity_Result> lst)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                bool result = true;
                try
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        SYS_GetUserActivity_Result m = lst[i];
                        if (m.ItemId.HasValue) //update
                        {
                            context.Sys_User_Activity.Where(r => r.ID == m.ItemId).Update(r => new Sys_User_Activity() { R = m.R, C = m.C, U = m.U, D = m.D });
                        }
                        else
                        {
                            Sys_User_Activity mRA = new Sys_User_Activity()
                            {
                                Activityid = m.ActivityId,
                                Userid = m.UserId,
                                C = m.C,
                                R = m.R,
                                U = m.U,
                                D = m.D
                            };
                            context.Sys_User_Activity.Add(mRA);
                        }
                        if (i != 0 && i % 50 == 0)
                        {
                            context.SaveChanges();
                        }
                    }
                    context.SaveChanges();
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        public void DeleteRoleUser(int roleID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var userRole = context.Sys_User_Role.Where(i => i.ID == roleID).FirstOrDefault();
                if (userRole != null)
                {
                    context.Sys_User_Role.Remove(userRole);
                    context.SaveChanges();
                }
            }
        }

        public List<SYS_GetUserRole_Result> GetUserRoleList(int UserId)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.SYS_GetUserRole(UserId).ToList();
            }
        }

        public bool UpdateUserRoleList(List<SYS_GetUserRole_Result> lst)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                bool result = true;
                try
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        SYS_GetUserRole_Result m = lst[i];
                        if (m.HasRole == true && m.ItemId.HasValue) //update
                        {
                            //không cần làm gì vì đã có trong db
                        }
                        else if (m.HasRole == true && m.ItemId.HasValue == false)
                        {
                            //có check nhưng trong DB chưa có thì thêm mới vào
                            Sys_User_Role mUR = new Sys_User_Role()
                            {
                                Roleid = m.ID,
                                Userid = m.UserId
                            };
                            context.Sys_User_Role.Add(mUR);
                        }
                        else if (m.HasRole == false && m.ItemId.HasValue == true)
                        {
                            //có trong db mà ko check thì xóa
                            context.Sys_User_Role.Where(s => s.ID == m.ItemId).Delete();
                        }
                        else
                        {
                            //còn lại ko cần làm gì
                        }

                        if (i != 0 && i % 50 == 0)
                        {
                            context.SaveChanges();
                        }
                    }
                    context.SaveChanges();
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        public Sys_Role_Activity UpdateRoleActivity(int activityId, int roleId, CRUD crud, bool val)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {

                Sys_Role_Activity model;
                model = context.Sys_Role_Activity.Where(o => o.Activityid == activityId && o.Roleid == roleId).FirstOrDefault();
                if (model == null)
                {
                    model = new Sys_Role_Activity();
                    model.Created = DateTime.Now;
                    model.Creatorid = ConfigurationSetting.UserInfo.Userid;
                    model.Creator = ConfigurationSetting.UserInfo.FullName;
                    context.Sys_Role_Activity.Add(model);

                }

                model.Activityid = activityId;
                model.Roleid = roleId;
                switch (crud)
                {
                    case CRUD.C:
                        model.C = val;
                        break;
                    case CRUD.R:
                        model.R = val;
                        break;
                    case CRUD.U:
                        model.U = val;
                        break;
                    case CRUD.D:
                        model.D = val;
                        break;
                    default:
                        break;
                }

                model.Modified = DateTime.Now;
                model.Modifierid = ConfigurationSetting.UserInfo.Userid;
                model.Modifier = ConfigurationSetting.UserInfo.FullName;
                context.SaveChanges();

                return model;

            }

        }

        public Sys_User_Role AddUserRole(Sys_User_Role userRole)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                userRole.Created = DateTime.Now;
                userRole.Creatorid = ConfigurationSetting.UserInfo.Userid;
                userRole.Creator = ConfigurationSetting.UserInfo.FullName;
                context.Sys_User_Role.Add(userRole);
                context.SaveChanges();
                return userRole;
            }
        }

        public Sys_Account GetSysAccountByCrewID(string crewID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Account.Where(i => i.CrewID == crewID).FirstOrDefault();
            }
        }

        public Sys_Account GetUserByUserName(string mUserName)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Sys_Account.Where(i => i.Account == mUserName).FirstOrDefault();
            }
        }
        #endregion

        public void GetCRUD(int userID, string code, out bool create, out bool read, out bool update, out bool delete)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    ObjectParameter oCreate = new ObjectParameter("Create", false);
                    ObjectParameter oRead = new ObjectParameter("Read", false);
                    ObjectParameter oUpdate = new ObjectParameter("Update", false);
                    ObjectParameter oDelete = new ObjectParameter("Delete", false);

                    context.USP_GetCRUD(userID, code, oCreate, oRead, oUpdate, oDelete);

                    create = (bool)oCreate.Value;
                    read = (bool)oRead.Value;
                    update = (bool)oUpdate.Value;
                    delete = (bool)oDelete.Value;
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<CRUD> GetCRUD(string code)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                //bool create, read, update, delete;
                List<CRUD> ls = new List<CRUD>();
                try
                {
                    ObjectParameter oCreate = new ObjectParameter("Create", false);
                    ObjectParameter oRead = new ObjectParameter("Read", false);
                    ObjectParameter oUpdate = new ObjectParameter("Update", false);
                    ObjectParameter oDelete = new ObjectParameter("Delete", false);

                    context.USP_GetCRUD(ConfigurationSetting.UserInfo.Userid, code, oCreate, oRead, oUpdate, oDelete);

                    if ((bool)oCreate.Value) ls.Add(CRUD.C);
                    if ((bool)oRead.Value) ls.Add(CRUD.R);
                    if ((bool)oUpdate.Value) ls.Add(CRUD.U);
                    if ((bool)oDelete.Value) ls.Add(CRUD.D);
                }
                catch
                {
                }
                return ls;
            }
        }

        public Sys_Account GetSysAccountByName(string iName)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                try
                {
                    return context.Sys_Account.Where(i => i.name == iName).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<VHR_Employee_Department> GetEmployeeDepartment()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.VHR_Employee_Department.ToList();
            }
        }

        public List<SYS_GetDepartment_Result> GetDepartment(int employeeid)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.SYS_GetDepartment(employeeid).ToList();
            }
        }

        public int UpdateDepartment(int departmentid, int employeeid, bool value)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                HR_Department_Employee model = context.HR_Department_Employee.Where(o => o.DepartmentID == departmentid && o.EmployeeID == employeeid).FirstOrDefault();

                //insert
                if (model == null)
                {
                    if (value) //insert
                    {
                        model = new HR_Department_Employee();
                        model.DepartmentID = departmentid;
                        model.EmployeeID = employeeid;
                        model.Isdeleted = false;
                        model.Created = DateTime.Now;
                        model.Modified = DateTime.Now;
                        context.HR_Department_Employee.Add(model);
                    }
                }
                else //update
                {
                    model.Isdeleted = !value;
                    model.Created = DateTime.Now;
                    model.Modified = DateTime.Now;
                }
                context.SaveChanges();

            }

            return 0;
        }
        public int UpdateUserRole(int roleid, int employeeid, bool val)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                Sys_User_Role model;

                if (val) //insert
                {
                    model = new Sys_User_Role();
                    model.Roleid = roleid;
                    model.Userid = employeeid;

                    model.Created = DateTime.Now;
                    model.Creatorid = ConfigurationSetting.UserInfo.Userid;
                    model.Creator = ConfigurationSetting.UserInfo.FullName;

                   
                    model.Modified = DateTime.Now;

                    context.Sys_User_Role.Add(model);
                }
                else
                {
                    model = context.Sys_User_Role.Where(o => o.Roleid == roleid && o.Userid== employeeid).FirstOrDefault();
                    if(model != null) context.Sys_User_Role.Remove(model);
                }

                context.SaveChanges();

            }

            return 0;
        }

        public int UpdateUserActivity(int activityID, int employeeid, CRUD crud, bool val)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {

                Sys_User_Activity model;
                model = context.Sys_User_Activity.Where(o => o.Activityid == activityID && o.Userid == employeeid).FirstOrDefault();
                if (model == null)
                {
                    model = new Sys_User_Activity();
                    model.Created = DateTime.Now;
                    model.Creatorid = ConfigurationSetting.UserInfo.Userid;
                    model.Creator = ConfigurationSetting.UserInfo.FullName;
                    context.Sys_User_Activity.Add(model);

                }

                model.Activityid = activityID;
                model.Userid = employeeid;
                switch (crud)
                {
                    case CRUD.C:
                        model.C = val;
                        break;
                    case CRUD.R:
                        model.R = val;
                        break;
                    case CRUD.U:
                        model.U = val;
                        break;
                    case CRUD.D:
                        model.D = val;
                        break;
                    default:
                        break;
                }

                model.Modified = DateTime.Now;
                model.Modifierid = ConfigurationSetting.UserInfo.Userid;
                model.Modifier = ConfigurationSetting.UserInfo.FullName;
                context.SaveChanges();
                    
            }

            return 0;
        }

        public List<USP_GetAllCRUDByUserID_Result> GetAllCRUDByUserID(int userID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.USP_GetAllCRUDByUserID(userID).ToList();
            }            
        }

        #region Device Ipad
        public List<SysDeviceModel> GetSysDevice()
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                //return context.Sys_Device.OrderBy(i => i.CID).ToList();
                var lstDevice =  (from f in context.Sys_Device                        
                        join a in context.Sys_Account on f.PhoneNo.Trim() equals a.Phone.Trim() into ps
                        from p in ps.DefaultIfEmpty()                        
                        join b in context.Sys_Account.Where(i => i.Phone != null && i.Phone.Trim() != "")                        
                        on f.AuthUDID equals b.Phone into ps1                        
                        from p1 in ps1.DefaultIfEmpty()
                        orderby f.ID descending
                        select new SysDeviceModel()
                        {
                            device = f,
                            account = p,
                            auth = p1,
                            //ID = f.ID,
                            //AID = f.AID,
                            //CID = f.CID,
                            //PhoneNo = f.PhoneNo,
                            //OTPCode = f.OTPCode,
                            //UDID = f.UDID,
                            //Keycode = f.Keycode,
                            //PushToken = f.PushToken,
                            //DeviceName = f.DeviceName,
                            //DeviceType = f.DeviceType,
                            //DeviceOS = f.DeviceOS,
                            //Manufacture = f.Manufacture,
                            //OSType = f.OSType,
                            //IsNotify = f.IsNotify,
                            //MainDevice = f.MainDevice,
                            //LastLogin,
                            //OTPDate,
                            //OTPCount,
                            //OTPFailures,
                            //AuthUDID,
                            //Activate,
                            //Description,
                            //Note,
                            //Created,
                            //Creator,
                            //Modified,
                            //Modifier,
                            //Creatorid,
                            //Modifierid
                        }).ToList();
                foreach (var device in lstDevice)
                {
                    device.setProperties();
                }
                return lstDevice;
            }
        }

        public SysDeviceModel UpdateSysDevice(SysDeviceModel item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {

                Sys_Device entity = null;
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    entity = item.ToEntityModel();
                    context.Sys_Device.Add(entity);
                }
                else
                {
                    item.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Modified = DateTime.Now;
                    entity = item.ToEntityModel();
                    context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                }

                context.SaveChanges();
                item.ID = entity.ID;
                return item;
            }
        }
        #endregion
    }
}
