using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class SysDeviceModel : Sys_Device
    {
        public string FullNameVn { get; set; }
        public string FullNameAuthVn { get; set; }

        public string CrewID { get; set; }

        public Sys_Device device { get; set; }
        public Sys_Account account { get; set; }
        public Sys_Account auth { get; set; }

        public void setProperties()
        {
            PropertyInfo[] sourceProperties = device.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(device, null), null);
            }

            if (account != null)
            {
                this.FullNameVn = account.LastNameVn + " " + account.FirstNameVn;
                this.CrewID = account.CrewID;                
            }
            if (auth != null)
                this.FullNameAuthVn = auth.LastNameVn + " " + auth.FirstNameVn;
        }

        public Sys_Device ToEntityModel()
        {
            Sys_Device returnValue = new Sys_Device();
            PropertyInfo[] sourceProperties = returnValue.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = returnValue.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(returnValue, sourcePi.GetValue(this, null), null);
            }
            return returnValue;
        }
        //public SysDeviceModel(Sys_Device device, Sys_Account account, Sys_Account auth)
        //{
        //    PropertyInfo[] sourceProperties = device.GetType().GetProperties();
        //    foreach (PropertyInfo sourcePi in sourceProperties)
        //    {
        //        PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
        //        destinationPi.SetValue(this, sourcePi.GetValue(device, null), null);
        //    }

        //    this.FullNameVn = account.LastNameVn + " " + account.FirstNameVn;
        //    this.FullNameAuthVn = auth.LastNameVn + " " + auth.FirstNameVn;

        //    //if (!string.IsNullOrWhiteSpace(item.TextColor))
        //    //    this.TextColorValue = ColorTranslator.FromHtml(item.TextColor);

        //    //()
        //    //            {
        //    //    ID = f.ID,
        //    //                AID = f.AID,
        //    //                CID = f.CID,
        //    //                PhoneNo = f.PhoneNo,
        //    //                OTPCode = f.OTPCode,
        //    //                UDID = f.UDID,
        //    //                Keycode = f.Keycode,
        //    //                PushToken = f.PushToken,
        //    //                DeviceName = f.DeviceName,
        //    //                DeviceType = f.DeviceType,
        //    //                DeviceOS = f.DeviceOS,
        //    //                Manufacture = f.Manufacture,
        //    //                OSType = f.OSType,
        //    //                IsNotify = f.IsNotify,
        //    //                MainDevice = f.MainDevice,
        //    //                LastLogin,
        //    //                OTPDate,
        //    //                OTPCount,
        //    //                OTPFailures,
        //    //                AuthUDID,
        //    //                Activate,
        //    //                Description,
        //    //                Note,
        //    //                Created,
        //    //                Creator,
        //    //                Modified,
        //    //                Modifier,
        //    //                Creatorid,
        //    //                Modifierid
        //    //            }
        //}
    }
}
