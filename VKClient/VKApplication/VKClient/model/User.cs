using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using VKClient.VKApplication.VKClient.model;
using VKClient.VKApplication.VKClient.Service;

namespace VKClient.VKClasses
{
    public class User : HttpResponser
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool can_access_closed { get; set; }
        public bool is_closed { get; set; }

        public string GetUserName()
        {
            return this.first_name + " " + this.last_name;
        }

        async public Task<string> GetIdUser(string id)
        {
            if (int.TryParse(id, out int userId))
            {
                return id;
            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await VkGet("users.get", new Dictionary<string, string>
                    {
                        ["user_ids"] = id
                    });
                    var content = await response.Content.ReadAsStringAsync();
                    var deserialized = JsonSerializer.Deserialize<Response<List<User>>>(content);
                    userId = deserialized.response[0].id;
                    return userId.ToString();
                }
            }
        }

        async public Task<ListResponse<User>> ResponseListGetUsers(string id)
        {
            HttpResponseMessage response = await VkGet("users.get", new Dictionary<string, string>
            {
                ["user_ids"] = id
            });
            var content = await response.Content.ReadAsStringAsync();

            var deserializedResponseUser = JsonSerializer.Deserialize<ListResponse<User>>(content);
            if (deserializedResponseUser.response == null)
                return null;
            else return deserializedResponseUser;
        }
    }
}
