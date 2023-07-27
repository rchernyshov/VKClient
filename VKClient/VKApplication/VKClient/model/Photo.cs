using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKClient.VKApplication.VKClient.model
{
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
}
