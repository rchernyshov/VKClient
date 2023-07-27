using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace VKClient.VKClasses
{
    public class WorkWithFile
    {
        public WorkWithFile(string filePath) { 
            this.filePath = filePath;
        }
        public WorkWithFile(string[] filePaths)
        {
            this.filePaths = filePaths;
        }

        public string[] filePaths { get; set; }
        public string filePath { get; set; }
        public void Save(User obj)
        {
            if (filePath == null)
            {
                return;
            }

            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
            }
        }
        public void Save(List<User> listObj)
        {
            if (filePath == null)
            {
                return;
            }

            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                serializer.Serialize(stream, listObj);
            }
        }
        public List<List<User>> OpenMulty2Files()
        {
            try
            {
                if (filePaths.Length != 2)
                {
                    return null;
                }
            }
            catch
            { 
                return null; 
            }

            List<List<User>> deserializedLists = new List<List<User>>();

            foreach (string filePath in filePaths)
            {
                if (File.Exists(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                    using (FileStream stream = new FileStream(filePath, FileMode.Open))
                    {
                        try
                        {
                            List<User> deserializedList = (List<User>)serializer.Deserialize(stream);
                            deserializedLists.Add(deserializedList);
                        }
                        catch (InvalidOperationException e)
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }

            return deserializedLists;
        }
        public List<User> Open()
        {
            if (filePath == null)
            {
                return null;
            }
            List<User> deserializedList = new List<User>();

            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    try
                    {
                        deserializedList = (List<User>)serializer.Deserialize(stream);
                    }
                    catch (InvalidOperationException e)
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
            return deserializedList;
        }

        public List<User> CompareListsDelete(List<List<User>> lists)
        {
            if (lists == null)
                return null;
            else if (lists.Count != 2)
            {
                return null;
            }

            List<User> list1 = lists[0];
            List<User> list2 = lists[1];


            List<User> uniqueList = new List<User>();
            uniqueList.Add(null);
            foreach (User user1 in list1)
            {
                bool isUnique = true;
                foreach (User user2 in list2)
                {
                    if (user1.id == user2.id)
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    uniqueList.Add(user1);
                }
            }
            return uniqueList;
        }
        public List<User> CompareListsAdd(List<List<User>> lists)
        {
            if (lists == null)
                return null;
            else if (lists.Count != 2)
            {
                return null;
            }

            List<User> list1 = lists[0];
            List<User> list2 = lists[1];

            List<User> uniqueList = new List<User>();
            uniqueList.Add(null);
            foreach (User user2 in list2)
            {
                bool isUnique = true;
                foreach (User user1 in list1)
                {
                    if (user2.id == user1.id)
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    uniqueList.Add(user2);
                }
            }
            return uniqueList;
        }
        public string GetParentFolder()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
            DirectoryInfo parentDirectory = directoryInfo.Parent;
            string folderName = parentDirectory.Name;
            return folderName;
        }

    }

    public class FavoriteUsers : WorkWithFile
    {
        static string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Избранное");
        static readonly string filePath = Path.Combine(folderPath, "Favoriets.xml");
        public FavoriteUsers() : base(filePath) { }
        public void SaveFavoriets(List<User> favoriteUsers)
        {
            string folderPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            Save(favoriteUsers);
        }
    }
}
