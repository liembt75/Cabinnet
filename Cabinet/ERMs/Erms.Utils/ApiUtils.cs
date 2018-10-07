using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class ApiUtils
    {
        const string UPLOADER_URL = "https://api.crew.vn";
        const string UPLOADER_API = "api/filemanager/taskuploadfiles";
        const string SUPPORT_UPLOADER_API = "api/filemanager/supportuploadfiles";
        public static int UploadFiles(List<string> lstFiles, string userID, string userToken)
        {

            try
            {
                int groupID = -1;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UPLOADER_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    MultipartFormDataContent content = new MultipartFormDataContent();
                    content.Add(new StringContent(userID), "UserID");
                    content.Add(new StringContent(userToken), "Token");
                    foreach (var attachFilePath in lstFiles)
                    {
                        if (!string.IsNullOrWhiteSpace(attachFilePath))
                        {
                            FileStream objFileStream = new FileStream(attachFilePath, FileMode.Open, FileAccess.Read);
                            int len = (int)objFileStream.Length;
                            Byte[] byteArray = new Byte[len];
                            objFileStream.Read(byteArray, 0, len);
                            content.Add(new ByteArrayContent(byteArray, 0, byteArray.Count()), "attach", attachFilePath);
                        }
                    }

                    HttpResponseMessage response = client.PostAsync(UPLOADER_API, content).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        JObject result = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                        if (result.HasValues)
                        {
                            if ((string)result["ErrorCode"] == "0")
                            {
                                groupID = (int)result["Data"]["AttachmentID"];
                            }
                        }
                    }
                }
                return groupID;
            }
            catch (Exception ex) { throw; }
        }

        public static int UploadSupportFiles(List<string> lstFiles, string userID, string userToken, string supportID)
        {

            try
            {
                int groupID = -1;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UPLOADER_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    MultipartFormDataContent content = new MultipartFormDataContent();
                    content.Add(new StringContent(userID), "UserID");
                    content.Add(new StringContent(userToken), "Token");
                    content.Add(new StringContent(""), "Assignee");
                    content.Add(new StringContent(supportID), "SupportID");
                    foreach (var attachFilePath in lstFiles)
                    {
                        if (!string.IsNullOrWhiteSpace(attachFilePath))
                        {
                            FileStream objFileStream = new FileStream(attachFilePath, FileMode.Open, FileAccess.Read);
                            int len = (int)objFileStream.Length;
                            Byte[] byteArray = new Byte[len];
                            objFileStream.Read(byteArray, 0, len);
                            content.Add(new ByteArrayContent(byteArray, 0, byteArray.Count()), "attach", attachFilePath);
                        }
                    }

                    HttpResponseMessage response = client.PostAsync(SUPPORT_UPLOADER_API, content).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        JObject result = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                        if (result.HasValues)
                        {
                            if ((string)result["ErrorCode"] == "0")
                            {
                                groupID = (int)result["Data"]["AttachmentId"];
                            }
                        }
                    }
                }
                return groupID;
            }
            catch (Exception ex) { throw; }
        }
    }
}
