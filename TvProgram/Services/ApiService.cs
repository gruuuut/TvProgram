using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TvProgram.Entities;

namespace TvProgram.Services
{
    public class ApiService
    {
        public List<Favori> GetFilms(string url, string jsonContent)
        {            
            return Process<List<Favori>>(url, jsonContent);
        }

        public TResponse Process<TResponse>(string host, string api)
        {
            // Execute Api call Async
            var httpResponseMessage = MakeApiCall(host, api);

            // Process Json string result to fetch final deserialized model
            return FetchResult<TResponse>(httpResponseMessage);
        }

        public HttpResponseMessage MakeApiCall(string host, string api)

        {
            // Create HttpClient
            var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }) { BaseAddress = new Uri(host) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Make an API call and receive HttpResponseMessage
            HttpResponseMessage responseMessage = client.GetAsync(api, HttpCompletionOption.ResponseContentRead).GetAwaiter().GetResult();

            return responseMessage;
        }

        public T FetchResult<T>(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode)
            {
                // Convert the HttpResponseMessage to string
                var resultArray = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                // Json.Net Deserialization
                return JsonConvert.DeserializeObject<T>(resultArray);
            }
            return default(T);
        }
        //on my login button click 
        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    CallAPI.POST("login-validate", "{ \"email\":" + txtUserName.Text + " ,\"password\":" + txtPassword.Text + ",\"time\": " + DateTime.Now.ToString("yyyy-MM-dd h:mm tt") + "}");
        //}
    }
}
