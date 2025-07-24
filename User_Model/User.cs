using System;
using System.IO;
using System.Configuration;

namespace User_Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public void ConsoleRead()
        {
            Console.Write("Username: ");
            Username = Console.ReadLine();

            Console.Write("Password: ");
            Password = Console.ReadLine();

            Console.Write("Email: ");
            Email = Console.ReadLine();
        }

        public void ConsoleWrite()
        {
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Password: {Password}");
            Console.WriteLine($"Email: {Email}");
        }

        public override string ToString()
        {
            return $"{Username},{Password},{Email}";
        }
    }

}