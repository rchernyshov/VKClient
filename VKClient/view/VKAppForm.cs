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
using VKClient.VKApplication.VKClient;

namespace VKClient
{
    public partial class VKClientForm : Form
    {
        VkClient client;
        List<User> listFavoriets = new List<User>();
        FavoriteUsers fileFavoriets = new FavoriteUsers();

        public VKClientForm()
        {
            InitializeComponent();
            client = new VkClient();
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
        private void clear()
        {
            ClearMainBox();
            textBoxUserID.Text = string.Empty;
            client.listUsers.Clear();
            comboBoxFavoriets.Text = "Список избранных";
            progressBar.Value = 0;
        }
        public void UpdateCombobox()
        {
            fileFavoriets.SaveFavoriets(listFavoriets);
            listFavoriets.Clear();
            listFavoriets = fileFavoriets.Open();
            FillComboboxFavoriets(listFavoriets);
            comboBoxFavoriets.Text = "Избранное";
        }



        async private void buttonMakeRequest_Click(object sender, EventArgs e)
        {
            ClearMainBox();
            if (radioBtnFriends.Checked)
                if (checkBoxSavedPhoto.Checked)
                {
                    PrintList(await client.MakeRequestFriendsWithOpenSavedAlbumAsync(textBoxUserID.Text));
                }
                else PrintList(await client.MakeRequestFriendsAsync(textBoxUserID.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{client.user.GetUserName()}"); // не работает
            string filePath = Path.Combine(folderPath, DateTime.Now.ToString("yyyy-MM-dd") + ".xml");
            WorkWithFile fileSave = new WorkWithFile(filePath);
            try
            {
                fileSave.Save(client.listUsers);
            }
            catch { return; }
        }
        private void btnSaveHow_Click(object sender, EventArgs e)
        {
            WorkWithFile fileSave = new WorkWithFile(Explorer.SaveDialog());
            try
            {
                fileSave.Save(client.listUsers);
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

        private void btnCompare_Click(object sender, EventArgs e)
        {
            WorkWithFile filesCompare = new WorkWithFile(Explorer.OpenDialog(true));

            List<List<User>> usersForCompare = filesCompare.OpenMulty2Files();
            if (usersForCompare == null)
                return;

            List<User> usersAdd = filesCompare.CompareListsAdd(usersForCompare);
            List<User> usersDelete = filesCompare.CompareListsDelete(usersForCompare);
            client.listUsers.Clear();
            ClearMainBox();
            if (usersAdd.Count != 1)
            {
                client.listUsers.AddRange(usersAdd);
                AddResponseText("Добавленные пользователи:");
                PrintList(usersAdd);
            }
            if (usersDelete.Count != 1)
            {
                client.listUsers.AddRange(usersDelete);
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
            if(await client.SetInfoAboutCurrUser(textBoxUserID.Text))
            {
                listFavoriets.Add(client.user);
                UpdateCombobox();
            }
        }

        private void btnFavorietsDelete_Click(object sender, EventArgs e)
        {
            listFavoriets.RemoveAt(comboBoxFavoriets.SelectedIndex);
            UpdateCombobox();
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
                    client.browser.OpenProfile(listFavoriets[comboBoxFavoriets.SelectedIndex].id.ToString());
                }
                else
                {
                    client.browser.OpenProfile(client.listUsers[listBoxResponse.SelectedIndex].id.ToString());
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
                foreach (var user in client.listUsers)
                {
                    try
                    {
                        client.browser.OpenProfile(user.id.ToString());
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
