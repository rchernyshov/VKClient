using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using VKClient.VKClasses;
using System.Web;
using System.CodeDom;
using System.Security.Policy;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VKClient
{
    public partial class VKClientForm : Form
    {
        Friends friends = new Friends();
        User user = new User();
        List<User> listUsers = new List<User>();
        List<User> listFavoriets = new List<User>();
        FavoriteUsers fileFavoriets = new FavoriteUsers();

        public VKClientForm()
        {
            InitializeComponent();
            listFavoriets = fileFavoriets.Open();
            FillComboboxFavoriets(listFavoriets);
        }
        public void PrintList(List<User> list)
        {
            foreach (var item in list)
            {
                if (item == null)
                    continue;
                listBoxResponse.Items.Add(item.GetUserName());
            }
        }
        public void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                listBoxResponse.Items.Add(item.ToString());
            }
        }
        public void FillComboboxFavoriets(List<User> list)
        {
            comboBoxFavoriets.Items.Clear();
            foreach(var item in list)
            {
                comboBoxFavoriets.Items.Add(item.GetUserName());
            }
        }
        public void ClearMainBox()
        {
            listBoxResponse.Items.Clear();
        }
        public void AddResponseText(string text)
        {
            listBoxResponse.Items.Add(text);
        }
        async public Task<bool> SetInfoAboutCurrUser()
        {
            string userId = await ExtractUserIdFromUrl(textBoxUserID.Text);
            if (userId == null) 
                return false;
            else
            {
                ListResponse<User> users = await user.Get(userId);
                user = users.response[0];
                return true;
            }
        }

        async Task<string> ExtractUserIdFromUrl(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            if (int.TryParse(input, out int userId))
            {
                return input;
            }
            else
            {
                try
                {
                    var uri = new Uri(input);
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
                       input = await user.GetIdUser(pathSegments[1].TrimEnd('/').Replace("id", ""));
                       return input;
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

        async private void buttonMakeRequest_Click(object sender, EventArgs e)
        {
            ClearMainBox();
            if (await SetInfoAboutCurrUser())
            {
                AddResponseText("Гружу...");

                if (radioBtnFriends.Checked)
                    if (checkBoxSavedPhoto.Checked)
                    {
                        progressFill(await user.GetCountFriends());
                        listUsers = await friends.GetListFriendsWithOpenSavedAlbum(user.id.ToString(), ((int)numericUpDownCyles.Value));
                        
                    }
                    else listUsers = await friends.GetListFriends(user.id.ToString());

                try
                {
                      if (listUsers.Count == 0)
                      {
                        AddResponseText("У чела нет друзей(");
                          return;
                      }

                      ClearMainBox();
                      PrintList(listUsers);
                }
                catch (Exception ex) {
                    AddResponseText("Неверно указан id пользователя");
                    return;
                }
            }
            else
            {
                AddResponseText("Неверно указан id пользователя");
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{user.GetUserName()}"); // не работает
            string filePath = Path.Combine(folderPath, DateTime.Now.ToString("yyyy-MM-dd") + ".xml");
            WorkWithFile fileSave = new WorkWithFile(filePath);
            try
            {
                fileSave.Save(listUsers);
            }
            catch { return; }
        }
        private void btnSaveHow_Click(object sender, EventArgs e)
        {
            WorkWithFile fileSave = new WorkWithFile(Explorer.SaveDialog());
            try
            {
                fileSave.Save(listUsers);
            }
            catch { return; }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            WorkWithFile fileOpen = new WorkWithFile(Explorer.OpenDialog());
            try
            {
                ClearMainBox();
                PrintList(fileOpen.Open());
                textBoxUserID.Text = fileOpen.GetParentFolder();
            }
            catch { return; }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            ClearMainBox();
            textBoxUserID.Text = string.Empty;
            listUsers.Clear();
            comboBoxFavoriets.Text = "Список избранных";
            progressBar.Value = 0;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            WorkWithFile filesCompare = new WorkWithFile(Explorer.OpenDialog(true));

            List<List<User>> usersForCompare = filesCompare.OpenMulty2Files();
            if (usersForCompare == null)
                return;

            List<User> usersAdd = filesCompare.CompareListsAdd(usersForCompare);
            List<User> usersDelete = filesCompare.CompareListsDelete(usersForCompare);
            listUsers.Clear();
            ClearMainBox();
            if (usersAdd.Count != 1)
            {
                listUsers.AddRange(usersAdd);
                AddResponseText("Добавленные пользователи:");
                PrintList(usersAdd);
            }
            if (usersDelete.Count != 1)
            {
                listUsers.AddRange(usersDelete);
                AddResponseText("Удаленные пользователи:");
                PrintList(usersDelete);
            }
            if (usersAdd.Count == 1 && usersDelete.Count == 1)
                AddResponseText("Добавленных и удаленных пользователей нет");
        }

        private void checkBoxSavedPhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSavedPhoto.Checked)
            {
                lblCycles.Enabled = true;
                numericUpDownCyles.Enabled = true;
            }
            if(!checkBoxSavedPhoto.Checked) {
                lblCycles.Enabled = false;
                numericUpDownCyles.Enabled = false;
            }
        }

        async private void btnFavorietsAdd_Click(object sender, EventArgs e)
        {
            if(await SetInfoAboutCurrUser())
            {
                listFavoriets.Add(user);
                UpdateCombobox();
            }
        }

        private void btnFavorietsDelete_Click(object sender, EventArgs e)
        {
            listFavoriets.RemoveAt(comboBoxFavoriets.SelectedIndex);
            UpdateCombobox();
        }

        public void UpdateCombobox()
        {
            fileFavoriets.SaveFavoriets(listFavoriets);
            listFavoriets.Clear();
            listFavoriets = fileFavoriets.Open();
            FillComboboxFavoriets(listFavoriets);
            comboBoxFavoriets.Text = "Избранное";
        }

        private void comboBoxFavoriets_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxUserID.Text = listFavoriets[comboBoxFavoriets.SelectedIndex].id.ToString();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if(listBoxResponse.SelectedItems.Count == 0)
                {
                    Browser.OpenProfile(listFavoriets[comboBoxFavoriets.SelectedIndex].id.ToString());
                }
                else
                {
                    Browser.OpenProfile(listUsers[listBoxResponse.SelectedIndex].id.ToString());
                }
            }
            catch {
                AddResponseText("Пользователь не выбран");
            }
        }

        private void listBoxResponse_DoubleClick(object sender, EventArgs e)
        {
            btnProfile_Click(sender, e);
        }

        private void btnAllProfiles_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var user in listUsers)
                {
                    try
                    {
                        Browser.OpenProfile(user.id.ToString());
                    }
                    catch { }
                }
            }
            catch
            {
                AddResponseText("Ошибка");
            }
        }

        private async void progressFill(int countFriends)
        {
            double time = countFriends * 0.334; // time in seconds
            int steps = 100; // number of steps in the progress bar
            double stepTime = time * 1000 / steps; // time for each step in milliseconds

            for (int i = 0; i <= steps; i++)
            {
                progressBar.Value = i;
                await System.Threading.Tasks.Task.Delay((int)stepTime);
            }
        }
    }
}
