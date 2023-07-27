using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace VKClient.VKClasses
{
    public class HttpResponser
    {
        private readonly HttpClientHandler handler;
        private readonly HttpClient client;

        public HttpResponser()
        {
            handler = new HttpClientHandler();
            client = new HttpClient(handler, false);

            //ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.FindServicePoint(new Uri("https://api.vk.com")).ConnectionLeaseTimeout = 60000;
        }

        protected string PrettyJson(string unPrettyJson)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

            return JsonSerializer.Serialize(jsonElement, options);
        }

        async protected Task<HttpResponseMessage> VkGet(string method, Dictionary<string, string> parameters)
        {
            var builder = new UriBuilder($"https://api.vk.com/method/{method}");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["v"] = Key.GetVERSION();
            query["access_token"] = Key.GetUSER_ACCESS_TOKEN();

            foreach (var key in parameters.Keys)
            {
                query[key] = parameters[key];
            }

            builder.Query = query.ToString();
            string url = builder.ToString();

            System.Threading.Thread.Sleep(334);


            return await client.GetAsync(url);
        }
    }

}
