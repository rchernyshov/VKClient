using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VKClient.VKClasses;

namespace VKClient
{
    public class Album : HttpResponser
    {
        public int count { get; set; }
        public List<Photo> items { get; set; }

        async public Task<bool> isOpenSavedAlbum(string id)
        {
            if (await Get(id) == null)
            {
                return false;
            }
            else return true;
        }
        public async Task<Response<Album>> Get(string id) 
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

    public class Photo
    {
        public int album_id { get; set; }
        public int date { get; set; }
        public int id { get; set; }
        public int owner_id { get; set; }
        public List<SizePhoto> sizes { get; set; }
        public string text { get; set; }
        public bool has_tags { get; set; }
    }

    public class SizePhoto
    {
        public int height { get; set; }
        public string type { get; set; }
        public int width { get; set; }
        public string url { get; set; }
    }


}
