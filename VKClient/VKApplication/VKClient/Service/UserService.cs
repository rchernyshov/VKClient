using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VKClient.VKClasses;

namespace VKClient.VKApplication.VKClient.Service
{
    public class UserService
    {
        async public Task<string> ExtractUserIdFromUrl(string msgUrl, User user)
        {
            if (string.IsNullOrEmpty(msgUrl))
                return null;
            if (int.TryParse(msgUrl, out int userId))
            {
                return msgUrl;
            }
            else
            {
                try
                {
                    var uri = new Uri(msgUrl);
                    var pathSegments = uri.Segments;
                    if (pathSegments.Length > 2 && pathSegments[1] == "id")
                    {
                        return pathSegments[2].TrimEnd('/').Replace("id", "");
                    }
                    else if (pathSegments[1] == "photo")
                    {
                        var query = HttpUtility.ParseQueryString(uri.Query);
                        if (query.AllKeys.Contains("oid"))
                            return query["oid"];
                        else
                            return null;
                    }
                    else if (pathSegments.Length > 1 && !pathSegments[1].Contains("."))
                    {
                        msgUrl = await user.GetIdUser(pathSegments[1].TrimEnd('/').Replace("id", ""));
                        return msgUrl;
                    }
                    else
                    {
                        // handle different url format if needed
                        return null;
                    }
                }
                catch (Exception ex) { return null; }
            }
        }
    }
}
