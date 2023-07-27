using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VKClient.VKApplication.VKClient.model;
using VKClient.VKClasses;

namespace VKClient
{
    public class Album : HttpResponser
    {
        public int count { get; set; }
        public List<Photo> items { get; set; }

        async public Task<bool> isOpenSavedAlbum(string id)
        {
            if (await ResponseGetPhotos(id) == null)
            {
                return false;
            }
            else return true;
        }
        private async Task<Response<Album>> ResponseGetPhotos(string id)
        {
            HttpResponseMessage response = await VkGet("photos.get", new Dictionary<string, string>
            {
                ["owner_id"] = id,
                ["album_id"] = "saved",
                //["count"] = "1"
            });
            var content = await response.Content.ReadAsStringAsync();

            var deserializedResponseAlbum = JsonSerializer.Deserialize<Response<Album>>(content);
            if (deserializedResponseAlbum.response == null)
                return null;
            else return deserializedResponseAlbum;
        }

    }
}
