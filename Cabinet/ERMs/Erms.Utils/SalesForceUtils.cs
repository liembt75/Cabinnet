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
    public class SalesForceUtils
    {
        const string AUTHENTICATION_URL = "https://test.salesforce.com/services/oauth2/token?";
        const string RETRIEVECASE_BYLASTMODIFIEDDATE_URL = @"https://vnacx--uat.cs58.my.salesforce.com/services/data/v20.0/query/?q=SELECT+Origin,Subject,Description,Ticket_Number__c,Ticket_other_info__c,Class_of_service__c,Priority,Category__c,Sub_Category__c,Other__c,Status,Sub_Status__c,Compensation__c,Form_of_compensation__c,Proposed_Solution__c,Amount_MCO__c,CurrencyIsoCode,Miles__c,Miles_amount__c,Tickets__c,Tickets_amount__c,Total_Amount__c,CreatedDate,ClosedDate,SuppliedName,SuppliedEmail,SuppliedPhone,Web_Gender__c,Web_Birthday__c,Web_Nationality__c,Web_FFP_Number__c,Web_Tier__c,Web_Address__c,Web_Flight_Number__c,Web_From__c,Web_To__c,Web_Departure_Date__c,Web_Aircraft__c,Type,Has_Child__c,ParentId,Special__c,Location__c,Web_Tier_Value__c,Origin_Detail__c,Seat_Number__c+FROM+Case+WHERE+Origin='VNCrew'+AND+LastModifiedDate=TODAY";
        const string RETRIEVECASE_BYID_URL = @"https://vnacx--uat.cs58.my.salesforce.com/services/data/v20.0/query/?q=SELECT+Origin,Subject,Description,Ticket_Number__c,Ticket_other_info__c,Class_of_service__c,Priority,Category__c,Sub_Category__c,Other__c,Status,Sub_Status__c,Compensation__c,Form_of_compensation__c,Proposed_Solution__c,Amount_MCO__c,CurrencyIsoCode,Miles__c,Miles_amount__c,Tickets__c,Tickets_amount__c,Total_Amount__c,CreatedDate,ClosedDate,SuppliedName,SuppliedEmail,SuppliedPhone,Web_Gender__c,Web_Birthday__c,Web_Nationality__c,Web_FFP_Number__c,Web_Tier__c,Web_Address__c,Web_Flight_Number__c,Web_From__c,Web_To__c,Web_Departure_Date__c,Web_Aircraft__c,Type,Has_Child__c,ParentId,Special__c,Location__c,Web_Tier_Value__c,Origin_Detail__c,Seat_Number__c+FROM+Case+WHERE+Origin='VNCrew'+AND+id='{0}'";
        const string DELETECASE_BYID_URL = @"https://vnacx--uat.cs58.my.salesforce.com/services/data/v42.0/sobjects/Case/{0}";
        const string UPDATECASE_BYID_URL = @"https://vnacx--uat.cs58.my.salesforce.com/services/data/v42.0/sobjects/Case/{0}";
        const string INSERTCASE_URL = @"https://vnacx--uat.cs58.my.salesforce.com/services/data/v42.0/sobjects/Case";

        public async static Task<string> Authentication()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AUTHENTICATION_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    var contents = new Dictionary<string, string>
                    {
                        { "grant_type", "password" },
                        { "client_id", "3MVG99S6MzYiT5k9Zi_aoc.dquWAEZ2MsfnXhQ91eBvGn5GuR8xb34R0oxtFXPybeZWJ93j0x5wz.UnC1FYRS" },
                        { "client_secret", "2204506710967604570" },
                        { "username", "vncrew@vna.vn.uat" },
                        { "password", "Vna@2018" },
                    };
                    var queryString = new FormUrlEncodedContent(contents);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    HttpResponseMessage response = await client.PostAsync(AUTHENTICATION_URL, queryString);
                    if (response.IsSuccessStatusCode)
                    {
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

        public async static Task<string> RetrieveCaseByID(string key, string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = string.Format(RETRIEVECASE_BYID_URL, id);
                    //get by date
                    //string url = @"https://vnacx--uat.cs58.my.salesforce.com/services/data/v20.0/query/?q=SELECT+Origin,Subject,Description,Ticket_Number__c,Ticket_other_info__c,Class_of_service__c,Priority,Category__c,Sub_Category__c,Other__c,Status,Sub_Status__c,Compensation__c,Form_of_compensation__c,Proposed_Solution__c,Amount_MCO__c,CurrencyIsoCode,Miles__c,Miles_amount__c,Tickets__c,Tickets_amount__c,Total_Amount__c,CreatedDate,ClosedDate,SuppliedName,SuppliedEmail,SuppliedPhone,Web_Gender__c,Web_Birthday__c,Web_Nationality__c,Web_FFP_Number__c,Web_Tier__c,Web_Address__c,Web_Flight_Number__c,Web_From__c,Web_To__c,Web_Departure_Date__c,Web_Aircraft__c,Type,Has_Child__c,ParentId,Special__c,Location__c,Web_Tier_Value__c,Origin_Detail__c,Seat_Number__c+FROM+Case+WHERE+Origin='VNCrew'+AND+CreatedDate>=2018-07-01T00:00:00Z";
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", key);                    
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    string strResult = await client.GetStringAsync(url);
                    return strResult;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async static Task<bool> DeleteCaseByID(string key, string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = string.Format(DELETECASE_BYID_URL, id);
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", key);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    HttpResponseMessage message = await client.DeleteAsync(url);
                    return message.IsSuccessStatusCode;                    
                }
            }
            catch
            {
                return false;
            }
        }

        public async static Task<bool> UpdateCaseByID(string key, string id, string content)
        {
            try
            {                
                using (var client = new HttpClient())
                {
                    string url = string.Format(UPDATECASE_BYID_URL, id);
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", key);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    var method = new HttpMethod("PATCH");
                    var request = new HttpRequestMessage(method, new Uri(url))
                    {
                        Content = new StringContent(content, Encoding.UTF32, "application/json")
                };
                    try
                    {
                        HttpResponseMessage message = await client.SendAsync(request);
                        return message.IsSuccessStatusCode;
                    }
                    catch 
                    {                        
                        return false;
                    }                    
                }
            }
            catch
            {
                return false;
            }
        }

        public async static Task<string> InsertCase(string key, string content)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AUTHENTICATION_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", key);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;                    
                    var queryString = new StringContent(content, Encoding.UTF32, "application/json");                    
                    HttpResponseMessage response = await client.PostAsync(INSERTCASE_URL, queryString);
                    if (response.IsSuccessStatusCode)
                    {
                        string strResult = await response.Content.ReadAsStringAsync();
                        response.Dispose();
                        JObject result = JObject.Parse(strResult);
                        if (result.HasValues)
                        {
                            strResult = result["id"].ToString();                                                        
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
