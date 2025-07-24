using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Model;

namespace User_Model
{
    public class UserList
    {
        private string userFilePath;

        public List<User> Users { get; private set; }

        public UserList()
        {
            Users = new List<User>();
            userFilePath = Path.Combine(ConfigurationManager.AppSettings["UserFolder"], "users.txt");

            LoadAllUsers();
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            SaveAllUsers();
            Console.WriteLine("User added successfully.");
        }

        public void RemoveUser(string username)
        {
            var user = Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                Users.Remove(user);
                SaveAllUsers();
                Console.WriteLine("User removed successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public User FindUser(string username)
        {
            return Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayAllUsers()
        {
            if (Users.Count == 0)
            {
                Console.WriteLine("No users to display.");
                return;
            }

            foreach (var user in Users)
            {
                user.ConsoleWrite();
                Console.WriteLine();
            }
        }

        private void LoadAllUsers()
        {
            if (File.Exists(userFilePath))
            {
                var lines = File.ReadAllLines(userFilePath);
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    if (data.Length == 3)
                    {
                        var user = new User(data[0], data[1], data[2]);
                        Users.Add(user);
                    }
                }
            }
        }

        private void SaveAllUsers()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(userFilePath) ?? string.Empty);

            var lines = Users.Select(u => u.ToString()).ToArray();
            File.WriteAllLines(userFilePath, lines);
        }
    }
}