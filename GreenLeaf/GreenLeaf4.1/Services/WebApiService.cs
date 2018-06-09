using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GreenLeaf4._1.Services
{
    public class WebApiService
    {
        /* This is our web service class. When we run the web api it spin up a server on a local host.
            Now we can get the data from our web api by calling the to the different routes ex. calling the route api/Employee will get a list of all the employees.
            If you look in the method GetDataFromWeb, you can see that we are retrieving the data as JSON and thats because its easier for us to handle.
            Later when we want to change it to a observablecollection we just use the json.deseriliazer to turn it into a observable.
            */
        private const string ServerUrl = "http://localhost:54081/";

        // We just need to provide a url to this method to request for data.
        // We use the method inside the singleton classes
        public static string GetDataFromWeb(string url)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        // Method to Post Task, Monitor, Employee, Comment, Station
        // C# has something call an object, which represent any object or classes.
        // That mean that we can use this method everywhere and it doesnt matter which object you put in here.
        public static async Task<string> PostTMECS(string url, object objectToPost)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var serializedString = JsonConvert.SerializeObject(objectToPost);
                    StringContent content = new StringContent(serializedString, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await client.PostAsync(url, content);
                    if (responseMessage.IsSuccessStatusCode) return await responseMessage.Content.ReadAsStringAsync();
                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        // Method to Delete Task, Monitor, Employee, Comment, Station
        // The delete method is never used and is only here because we want the app to be scalable.
        public static async Task<string> DeleteObjectAsync(string url)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage responseMessage = await client.DeleteAsync(url);
                    if (responseMessage.IsSuccessStatusCode) await responseMessage.Content.ReadAsStringAsync();
                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }


    }
}
