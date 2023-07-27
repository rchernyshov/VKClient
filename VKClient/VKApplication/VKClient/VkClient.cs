using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKClient.VKApplication.VKClient.model;
using VKClient.VKApplication.VKClient.Service;
using VKClient.VKClasses;

namespace VKClient.VKApplication.VKClient
{
    public class VkClient
    {
        public VkClient()
        {
            browser = new Browser();
            user = new User();
            listUsers = new List<User>();
            friends = new Friends();
            album = new Album();
        }

        public Browser browser { get; set; }
        public Friends friends { get; set; }
        public User user { get; set; }
        public List<User> listUsers { get; set; }
        public Album album { get; set; }
        public async Task<List<User>> MakeRequestFriendsWithOpenSavedAlbumAsync(string msgUrl)
        {
            try
            {
                await SetInfoAboutCurrUser(msgUrl);
                listUsers = await friends.GetListFriendsWithOpenSavedAlbum(user.id.ToString());

                if (listUsers.Count == 0)
                {
                    throw new InvalidOperationException("У чела нет друзей(");
                }

                return listUsers;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException: {ex.Message}");
                throw;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}");
                return null;
            }
        }

        public async Task<List<User>> MakeRequestFriendsAsync(string msgUrl)
        {
            try
            {
                await SetInfoAboutCurrUser(msgUrl);
                listUsers = await friends.GetListFriends(user.id.ToString());

                if (listUsers.Count == 0)
                {
                    throw new InvalidOperationException("У чела нет друзей(");
                }

                return listUsers;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException: {ex.Message}");
                throw;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}");
                return null;
            }
        }

        async public Task<bool> SetInfoAboutCurrUser(string msgUrl)
        {
            UserService userService = new UserService();
            string userId = await userService.ExtractUserIdFromUrl(msgUrl, user);
            if (userId == null)
            {
                return false;
                throw new ArgumentNullException(nameof(userId), "User ID cannot be null.");
            }
            else
            {
                ListResponse<User> users = await user.ResponseListGetUsers(userId);
                user = users.response[0];
                return true;
            }
        }
    }
}
