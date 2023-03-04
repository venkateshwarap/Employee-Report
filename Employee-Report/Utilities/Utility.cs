using Employee.DataModel.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Net.Http;

namespace EmployeeDetails.Api.Utilities
{
    public static class Utility
    {
        public static T GetResponseData<T>(Object? value)
        {
            if (value is null)
            {
                return (T)value!;
            }

            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            var response =  JsonConvert.DeserializeObject<T>(value!.ToString()!, jsonSerializerSettings)!;
            return response;
        }
        public static List<T> Deserialize<T>(this string SerializedJSONString)
        {
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            var stuff = JsonConvert.DeserializeObject<List<T>>(jsonSerializerSettings!.ToString()!);
            return stuff;
        }
        #region HttpClient API Request 
        #region Get Request
        public static async Task<Response> HttpClientGetAsync(string config, HttpClient client)
        {
            #region geting the response and DeserializeObject
            Response response = new Response();
            HttpResponseMessage apiresponse = await client.GetAsync(config);
            if(apiresponse.IsSuccessStatusCode)
            response = await apiresponse.Content.ReadAsAsync<Response>();
            return response;
            #endregion
        }
        #endregion

        #region Get Request by String Id
        public static async Task<Response> HttpClientGetAsync(string config, string Id, HttpClient client)
        {
            #region geting the response and DeserializeObject
            Response response = new Response();
            HttpResponseMessage apiresponse = await client.GetAsync(config + Id);
            if (apiresponse.IsSuccessStatusCode)
                response = await apiresponse.Content.ReadAsAsync<Response>();
            return response;
            #endregion
        }
        #endregion

        #region Get Request by int Id
        public static async Task<Response> HttpClientGetAsync(string config, int Id, HttpClient client)
        {
            #region geting the response and DeserializeObject
            Response response = new Response();
            HttpResponseMessage apiresponse = await client.GetAsync(config);
            if (apiresponse.IsSuccessStatusCode)
                response = await apiresponse.Content.ReadAsAsync<Response>();
            return response;
            #endregion
        }
        #endregion

        #region Post Request
        public static async Task<Response> HttpClientPostAsync(string config, HttpClient client, object requestData)
        {
            #region geting the response and DeserializeObject
            Response response = new Response();
            HttpResponseMessage apiresponse = await client.PostAsJsonAsync(config, requestData);
            response = await apiresponse.Content.ReadAsAsync<Response>();
            return response;
            #endregion
        }
        #endregion

        #region Put Request by int Id
        public static async Task<Response> HttpClientPutAsync(string config, HttpClient client, object requestData,int id)
        {
            #region geting the response
            Response response = new Response();
            HttpResponseMessage apiresponse = await client.PutAsJsonAsync(config+id,requestData);
            if(apiresponse.IsSuccessStatusCode)
            response = await apiresponse.Content.ReadAsAsync<Response>();
            return response;
            #endregion
        }
        #endregion

        #region Put Request by string Id
        public static async Task<Response> HttpClientPutAsync(string config, HttpClient client, object requestData)
        {
            #region geting the response
            Response response = new Response();
            HttpResponseMessage apiresponse = await client.PutAsJsonAsync(config, requestData);
            if (apiresponse.IsSuccessStatusCode)
                response = await apiresponse.Content.ReadAsAsync<Response>();
            return response;
            #endregion
        }
        #endregion

        #region Delete Request
        public static async Task<Response> HttpClientDeleteAsync(string config, HttpClient client,int id)
        {
            #region geting the response
            HttpResponseMessage apiresponse;
            Response response = new Response();
            if (id > 0)
            {
                 apiresponse = await client.DeleteAsync(config + id);
            }
            else
            {
                apiresponse = await client.DeleteAsync(config);
            }
            if (apiresponse.IsSuccessStatusCode)
            {
                response = await apiresponse.Content.ReadAsAsync<Response>();
            }
            return response;
            #endregion
        }
        #endregion

        #region Delete Request by string
        public static async Task<Response> HttpClientDeleteAsync(string config, HttpClient client, string id)
        {
            #region geting the response
            HttpResponseMessage apiresponse = new HttpResponseMessage();
            Response response = new Response();
            if (id != null)
            {
                apiresponse = await client.DeleteAsync(config + id);
            }
            if (apiresponse.IsSuccessStatusCode)
            {
                response = await apiresponse.Content.ReadAsAsync<Response>();
            }
            return response;
            #endregion
        }
        #endregion

        #region convert list object to string array
        public static string[] ListObjectToString(object resp)
        {
            string[] response = ((IEnumerable)resp!).Cast<object>()
                               .Select(x => x.ToString())
                               .ToArray()!;
            return response;
        }
        #endregion
        #endregion

    }
}