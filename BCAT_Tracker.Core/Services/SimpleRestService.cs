using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public class SimpleRestService : ISimpleRestService
    {
        public SimpleRestService()
        {

        }

        public void MakeRequest<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction, object prd)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = verb;
            request.Accept = "application/json";

            MakeRequest(
               request,
               (response) =>
               {
                   if (successAction != null)
                   {
                       T toReturn;
                       try
                       {
                           toReturn = Deserializes<T>(response);
                       }
                       catch (Exception ex)
                       {
                           errorAction(ex);
                           return;
                       }
                       successAction(toReturn);
                   }
               },
               (error) =>
               {
                   errorAction?.Invoke(error);
               }, prd
            );
        }

        private void MakeRequest(HttpWebRequest request, Action<string> successAction, Action<Exception> errorAction, object prd)
        {
            request.BeginGetResponse(token =>
            {
                try
                {
                    using (var response = request.EndGetResponse(token))
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(stream);
                            successAction(reader.ReadToEnd());
                        }
                    }
                }
                catch (WebException ex)
                {
                    //Mvx.Error("ERROR: '{0}' when making {1} request to {2}", ex.Message, request.Method, request.RequestUri.AbsoluteUri);
                    errorAction(ex);
                }
            }, prd);
        }
        private T Deserializes<T>(string responseBody)
        {
            var toReturn = JsonConvert.DeserializeObject<T>(responseBody); // json _jsonConverter.DeserializeObject<T>(responseBody);
            return toReturn;
        }

        public async void GetAsync<T>(Action<T> successAction, Action<Exception> errorAction)
        {
            try
            {
                string page = "https://reqres.in/api/users?delay=3";
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(page))
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    successAction(Deserializes<T>(result));
                }
            }
            catch (Exception ex)
            {
                errorAction(ex);
            }
        }
         
        public virtual async void PostAsync<T>(object obj, Action<T> successAction, Action<Exception> errorAction)
        {
            string result = "";
            try
            {
                string uri = "https://www.googleapis.com/youtube/v3/subscriptions?part=snippet";
                //string uri = "http://logbookandroidv3qa.skillsglobal.com/api/note/safety";
                var content = await Task.Run(() => JsonConvert.SerializeObject(obj));
                //object obb = "{'PatientID': 167741,'EndDate': '2018-03-29T00:00:00','EmployeeID': 54757,'Token': 'c5d194a4-4720-42ee-9c36-0bc08bdab660','Username': 'amoltest1','UserType': 1,'AppVersion': '3.0.6','AppType': 2}";

                content = "{'snippet':{'resourceId':{'kind':'youtube#channel''channelId':'UC_x5XG1OV2P6uZZ5FSM9Ttw'}}}";
                //content = await Task.Run(() => JsonConvert.SerializeObject(obb));
                var httpClient = new HttpClient();
                var response = await httpClient.PostAsync(uri, new StringContent(content));
                //response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
                //response.
                //var res = Deserializes<T>(response.);

                successAction(Deserializes<T>(result));
            }
            catch (Exception ex)
            {
                errorAction(ex);
            }
        }


        public void GetaData<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction)
        {
            MakeRequests<T>(requestUrl, verb, successAction, errorAction).GetAwaiter().GetResult();
        }

        static HttpClient client = new HttpClient();
        public async Task MakeRequests<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction)
        {
            client.BaseAddress = new Uri("https://reqres.in/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            if (verb == "GET")
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var product = await response.Content.ReadAsAsync<T>();
                }
            }
            else
            {
                //Product prd = new Product
                //{
                //    Name = "Gizmo",
                //    Price = 100,
                //    Category = "Widgets"
                //};
                var columns = new Dictionary<string, string>
            {
                { "email", "peter@klaven"}
            };

                var prd = JsonConvert.SerializeObject(columns);

                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("/api/login", prd);
                    response.EnsureSuccessStatusCode();
                    // var product = await response.Content.ReadAsAsync<T>();
                    //successAction(product);
                }
                catch (Exception ex)
                {
                    var res = ex.InnerException;
                }
            }

        }



        public async Task MakeRequestsn<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction)
        {
            client.BaseAddress = new Uri("https://reqres.in/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            if (verb == "GET")
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var product = await response.Content.ReadAsAsync<T>();
                }
            }
            else
            {

                var columns = new Dictionary<string, string>
            {
                { "email", "Mathew@g.com"},
                { "password", "Thompson"},

            };

                var prd = JsonConvert.SerializeObject(columns);

                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                   "api/register", prd);
                    response.EnsureSuccessStatusCode();
                    // var product = await response.Content.ReadAsAsync<T>();
                    //successAction(product);
                }
                catch (Exception ex)
                {
                    var res = ex.InnerException;
                }
            }

        }


    }
}
