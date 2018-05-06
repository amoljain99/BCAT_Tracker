using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public class SimpleRestService : ISimpleRestService
    {
        public SimpleRestService()
        {

        }

        public void MakeRequest<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction)
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
               }
            );
        }

        private void MakeRequest(HttpWebRequest request, Action<string> successAction, Action<Exception> errorAction)
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
            }, null);
        }
        private T Deserializes<T>(string responseBody)
        {
            var toReturn = JsonConvert.DeserializeObject<T>(responseBody); // json _jsonConverter.DeserializeObject<T>(responseBody);
            return toReturn;
        } 

        public async void  GetAsync<T>(Action<T> successAction, Action<Exception> errorAction)
        {
            try
            {
                string page = "https://www.googleapis.com/books/v1/volumes?q={0}";
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(page))
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    successAction( Deserializes<T>(result));
                }
            }
            catch(Exception ex)
            {
                errorAction(ex);
            }
        }


        public virtual async  void PostAsync<T>(object obj, Action<T> successAction, Action<Exception> errorAction)
        {
            string result = "";
            try
            {
                string uri = "http://logbookandroidv3qa.skillsglobal.com/api/note/safety";
                var content = await Task.Run(() => JsonConvert.SerializeObject(obj));
                object obb = "{'PatientID': 167741,'EndDate': '2018-03-29T00:00:00','EmployeeID': 54757,'Token': 'c5d194a4-4720-42ee-9c36-0bc08bdab660','Username': 'amoltest1','UserType': 1,'AppVersion': '3.0.6','AppType': 2}";
                content = await Task.Run(() => JsonConvert.SerializeObject(obb));
                var httpClient = new HttpClient();
                var response = await httpClient.PostAsync(uri, new StringContent(content));
                response.EnsureSuccessStatusCode();
                 result = await response.Content.ReadAsStringAsync();
                successAction(Deserializes<T>(result));
            }
            catch (Exception ex)
            {
                errorAction(ex);
            } 
        }
    }
}
