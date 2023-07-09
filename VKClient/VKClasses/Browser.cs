using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKClient.VKClasses
{
    public static class Browser
    {
        public static void OpenProfile(string userId)
        {
            string url = "https://vk.com/id" + userId;
            Process.Start(url);
        }
    }
}
