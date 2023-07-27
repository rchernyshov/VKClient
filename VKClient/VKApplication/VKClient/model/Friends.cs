using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VKClient.VKApplication.VKClient;
using VKClient.VKApplication.VKClient.model;
using VKClient.VKApplication.VKClient.Service;

namespace VKClient.VKClasses
{
    public class Friends : HttpResponser
    {
        public int count { get; set; }
        public List<int> items { get; set; }

        async public Task<int> GetCountFriends(User user)
        {
            Response<Friends> response;
            response = await ResponseGetFriends(user.id.ToString());
            return response.response.count;
        }

        async public Task<Response<Friends>> ResponseGetFriends(string id)
        {
            HttpResponseMessage response = await VkGet("friends.get", new Dictionary<string, string>
            {
                ["user_id"] = id
            });
            var content = await response.Content.ReadAsStringAsync();

            var deserializedResponseFriends = JsonSerializer.Deserialize<Response<Friends>>(content);
            return deserializedResponseFriends;
        }

        async public Task<List<User>> GetListFriends(string id)
        {
            VkClient client = new VkClient();
            Response<Friends> responseFriends = await ResponseGetFriends(id);
            if (responseFriends.response == null)
                return null;
            string ids = string.Join(",", responseFriends.response.items);
            ListResponse<User> listUsers = await client.user.ResponseListGetUsers(ids);
            return listUsers.response;
        }
        async public Task<List<User>> GetListFriendsWithOpenSavedAlbum(string id, int countResponse)
        {
            ListUtil listUtil = new ListUtil();
            List<User> listUsers = await GetListFriends(id);
            List<List<User>> listOfListsUsersWithSavedAlbum = new List<List<User>>();
            for (int i = 0; i < countResponse; i++)
            {
                listOfListsUsersWithSavedAlbum.Add(new List<User>());
            }

            for (int i = 0; i < countResponse; i++)
            {
                listOfListsUsersWithSavedAlbum[i] = await SetListFriendsWithOpenSavedAlbum(listUsers);
            }
            return listUtil.CombineListsWithoutDuplicates<User>(listOfListsUsersWithSavedAlbum);

        }
        async public Task<List<User>> GetListFriendsWithOpenSavedAlbum(string id)
        {
            Album album = new Album();
            return await GetListFriends(id);

        }

        async public Task<List<User>> GetListFriendsWithOpenSavedAlbumAsync(string id, int countResponse)
        {
            ListUtil listUtil = new ListUtil();
            List<User> listUsers = await GetListFriends(id);
            List<Task<List<User>>> tasks = new List<Task<List<User>>>();

            for (int i = 0; i < countResponse; i++)
            {
                tasks.Add(Task.Run(async () => await SetListFriendsWithOpenSavedAlbumAsync(listUsers)));
            }

            List<List<User>> listOfListsUsersWithSavedAlbum = tasks.Select(x => x.Result).ToList();

            return listUtil.CombineListsWithoutDuplicates<User>(listOfListsUsersWithSavedAlbum);
        }
        private async Task<List<User>> SetListFriendsWithOpenSavedAlbumAsync(List<User> listUsers)
        {
            VkClient client = new VkClient();
            List<Task<User>> tasks = new List<Task<User>>();
            foreach (var user in listUsers)
            {
                tasks.Add(Task.Run(async () =>
                {
                    if (await client.album.isOpenSavedAlbum(user.id.ToString()))
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }));
            }
            List<User> listFriendsWithOpenSavedAlbum = (await Task.WhenAll(tasks)).Where(x => x != null).ToList();
            return listFriendsWithOpenSavedAlbum;
        }
        async private Task<List<User>> SetListFriendsWithOpenSavedAlbum(List<User> listUsers)
        {
            VkClient client = new VkClient();
            List<User> listFriendsWithOpenSavedAlbum = new List<User>();
            foreach (var user in listUsers)
            {
                if (await client.album.isOpenSavedAlbum(user.id.ToString()))
                {
                    listFriendsWithOpenSavedAlbum.Add(user);
                }
            }
            return listFriendsWithOpenSavedAlbum;
        }
    }
}
