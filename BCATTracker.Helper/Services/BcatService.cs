using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BCATTracker.Helper.Services
{
    public class BcatServices
    {

        public void GetaData(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction)
        {
            MakeRequest<T>(requestUrl, verb, successAction, errorAction).GetAwaiter().GetResult();
        }


        public async Task MakeRequest<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:65264/");
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
                HttpResponseMessage response = await client.PostAsJsonAsync(
               "api/products", "");
                response.EnsureSuccessStatusCode();
                //var product = await response.Content.ReadAsAsync<T>();
               // successAction(product);

            }

        }
    }
}
