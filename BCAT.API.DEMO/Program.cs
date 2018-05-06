using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
 

namespace BCAT.API.DEMO
{
    public class Program

    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
         //   
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var ds = new GetSafetyNote() { apptype = 1, patientid = new List<int> { 1, 133 }, token = "sdfsdfsdf", username = "appstore" };
                var ss = CreateProductAsync(ds);
                Console.ReadLine();
            }
            catch (Exception ex) { throw ex; }

        }
        static async Task<Uri> CreateProductAsync(GetSafetyNote product)
        {
            try
            {
               // string urls = "http://logbookandroidv3qa.skillsglobal.com/api/note/safety";
                client.BaseAddress = new Uri("http://logbookandroidv3qa.skillsglobal.com/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/note/safety", content); //
               // response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    // product = await response.Content.ReadAsAsync<Product>();
                }
                // return URI of the created resource.
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    public class GetSafetyNote : UserContext
    {
        public List<int> patientid { get; set; }
    }
    public class UserContext
    {
        public string token { get; set; }
        public string username { get; set; }
        public int usertype { get; set; }
        public int apptype { get; set; }
    }

}
