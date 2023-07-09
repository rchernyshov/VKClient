using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VKClient.VKClasses
{
    public class Friends : HttpResponser
    {
        User user = new User();
        public int count { get; set; }
        public List<int> items { get; set; }

        async public Task<Response<Friends>> Get(string id)
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

            Response<Friends> responseFriends = await Get(id);
            if (responseFriends.response == null)
                return null;
            string ids = string.Join(",", responseFriends.response.items);
            ListResponse<User> listUsers = await user.Get(ids);
            return listUsers.response;
        }
        async public Task<List<User>> GetListFriendsWithOpenSavedAlbum(string id, int countResponse)
        {
            Album album = new Album();
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
            return CombineListsWithoutDuplicates<User>(listOfListsUsersWithSavedAlbum);

        }

        async public Task<List<User>> GetListFriendsWithOpenSavedAlbumAsync(string id, int countResponse)
        {
            Album album = new Album();
            List<User> listUsers = await GetListFriends(id);
            List<Task<List<User>>> tasks = new List<Task<List<User>>>();

            for (int i = 0; i < countResponse; i++)
            {
                tasks.Add(Task.Run(async () => await SetListFriendsWithOpenSavedAlbumAsync(listUsers)));
            }

            List<List<User>> listOfListsUsersWithSavedAlbum = tasks.Select(x => x.Result).ToList();

            return CombineListsWithoutDuplicates<User>(listOfListsUsersWithSavedAlbum);
        }
        private async Task<List<User>> SetListFriendsWithOpenSavedAlbumAsync(List<User> listUsers)
        {
            Album album = new Album();
            List<Task<User>> tasks = new List<Task<User>>();
            foreach (var user in listUsers)
            {
                tasks.Add(Task.Run(async () =>
                {
                    if (await album.isOpenSavedAlbum(user.id.ToString()))
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
            Album album = new Album();
            List<User> listFriendsWithOpenSavedAlbum = new List<User>();
            foreach (var user in listUsers)
            {
                if (await album.isOpenSavedAlbum(user.id.ToString()))
                {
                    listFriendsWithOpenSavedAlbum.Add(user);
                }
            }
            return listFriendsWithOpenSavedAlbum;
        }

        private List<T> CombineListsWithoutDuplicates<T>(List<List<T>> listsOfLists)
        {
            HashSet<T> combinedSet = new HashSet<T>();
            foreach (List<T> list in listsOfLists)
            {
                foreach (T item in list)
                {
                    combinedSet.Add(item);
                }
            }
            return combinedSet.ToList();
        }
    }
}
