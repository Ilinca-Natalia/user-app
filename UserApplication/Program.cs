using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProject;
using User_Model;

namespace UserProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserList userList = new UserList();

            while (true)
            {
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Remove User");
                Console.WriteLine("3. Find User");
                Console.WriteLine("4. Display All Users");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            User newUser = new User("", "", "");
                            newUser.ConsoleRead();
                            userList.AddUser(newUser);
                            break;
                        }

                    case "2":
                        {
                            Console.Write("Enter the username to remove: ");
                            string usernameToRemove = Console.ReadLine();
                            userList.RemoveUser(usernameToRemove);
                            break;
                        }

                    case "3":
                        {
                            Console.Write("Enter the username to find: ");
                            string usernameToFind = Console.ReadLine();
                            var foundUser = userList.FindUser(usernameToFind);
                            if (foundUser != null)
                            {
                                foundUser.ConsoleWrite();
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                            break;
                        }

                    case "4":
                        {
                            userList.DisplayAllUsers();
                            break;
                        }

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}