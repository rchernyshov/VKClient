using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKClient.VKClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using VkNet.Enums.SafetyEnums;
using System.Diagnostics;
using System.Net;
using System.Web.UI.WebControls;
using VkNet.Model;
using VkNet;
using Newtonsoft.Json.Linq;

namespace VKClient
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            
        }

        static string GetAccessToken(string clientId, string clientSecret, string redirectUri)
        {
            string authorizeUrl = string.Format($"https://oauth.vk.com/authorize?client_id={0}&redirect_uri={1}&response_type=code", clientId, redirectUri);

            Console.WriteLine("Авторизация в ВКонтакте");
            Console.WriteLine(authorizeUrl);
            Console.Write("Введите код подтверждения: ");
            string code = Console.ReadLine();

            string tokenUrl = string.Format("https://oauth.vk.com/access_token?client_id={0}&client_secret={1}&redirect_uri={2}&code={3}", clientId, clientSecret, redirectUri, code);

            WebRequest request = WebRequest.Create(tokenUrl);
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string responseText = reader.ReadToEnd();
                JObject jsonResponse = JObject.Parse(responseText);
                string accessToken = jsonResponse["access_token"].ToString();
                return accessToken;
            }
        }































        //        public static void VkAuth1()
        //        {
        //            var login = "89092125006";
        //            var password = "Waflyavk1";

        //            var Vk = new HttpClient();
        //            Vk.DefaultRequestHeaders.Add("Connection", "close");
        //            string url = string.Format($"https://oauth.vk.com/token?scope=nohttps%2Call&client_id={Key.GetIDApplication()}&client_secret={Key.GetSECURE_KEY()}&2fa_supported=1&lang=ru&grant_type=password&username={0}&password ={1}&libverify_support = 1", 
        //login, password);

        //            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //            request.Method = "GET";
        //            request.Host = "oauth.vk.com";
        //            //request.UserAgent = "qwert";
        //            request.ContentType = "application/x-www-form-urlencoded";
        //            request.KeepAlive = false;

        //            using (HttpWebResponse responsevk = (HttpWebResponse)request.GetResponse())
        //            using (var stream = responsevk.GetResponseStream())
        //            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
        //            {

        //                Debug.WriteLine(streamReader.ReadToEnd());

        //            }

        //            Console.ReadLine();
        //        }



    }

}
