using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComputerVisionSample
{
    class Program
    {
        static async Task Main(string[] args)
        {            
            string endpoint = "https://northeurope.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Tags&details=Landmarks&language=en";
            string imgUrl = "https://storageinfluencer.blob.core.windows.net/social-media-images/1e8bfef3-f070-44b9-9ae4-4b0d8a31316d.jpg";

            // ... Use HttpClient.
            HttpClient client = new HttpClient();
            //Auth header
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "wololo");
            //content type header
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            dynamic jsonObject = new JObject();
            jsonObject.url = imgUrl;
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(new Uri(endpoint), content);
            
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            Console.ReadKey();

            
        }
    }
}
