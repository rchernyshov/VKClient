using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKClient.VKClasses
{
    public class Browser
    {
        public void OpenProfile(string userId)
        {
            string url = "https://vk.com/id" + userId;
            Process.Start(url);
        }
    }
}
