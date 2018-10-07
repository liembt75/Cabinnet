using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class NetUtils
    {
        public async static Task<string> PostMethod(string url, string contentType, Dictionary<string, string> headers, Dictionary<string, string> content)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    //if (!string.IsNullOrWhiteSpace(contentType))
                    //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(contentType));
                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }

                    var queryString = new FormUrlEncodedContent(content);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    HttpResponseMessage response = await client.PostAsync(url, queryString);
                    if (response.IsSuccessStatusCode)
                    {
                        //var buffer = .ReadAsBufferAsync();
                        //var byteArray = await response.Content.ReadAsByteArrayAsync();
                        //var strResult = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);

                        string strResult = await response.Content.ReadAsStringAsync();
                        response.Dispose();
                        JObject result = JObject.Parse(strResult);
                        if (result.HasValues)
                        {
                            string access_token = result["access_token"].ToString();
                            string token_Type = result["token_type"].ToString();
                            strResult = token_Type + " " + access_token;
                        }
                        return strResult;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
