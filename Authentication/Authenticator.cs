using BookRecommender.DBObjects;
using BookRecommender.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommender.Authentication
{
    public class Authenticator
    {
        private readonly IUserRepository _userRepository;

        public Authenticator(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public void AuthenticationMenu()
        {
            Console.WriteLine("Welcome \n Digit 1 to Login, 2 to Register");
            int.TryParse(Console.ReadLine(), out int choice);
            if (choice == 1)
            {
                Login();
            }
            else if (choice == 2)
            {
                Register();
            }
            else
            {
                Console.WriteLine("Wrong digit.");
                AuthenticationMenu();
            }
        }
        public void Login()
        {
            Console.WriteLine("Insert Username:");
            var username = Console.ReadLine();
            Console.WriteLine("Insert Password:");
            var pwd = Console.ReadLine();
            var correctUser = CheckCredentials(username, pwd);
            if (correctUser != null)
            {
                CurrentUser.Username = username;
                CurrentUser.Password = pwd;
                Console.WriteLine("Successful Login!");
            }
            else
            {
                Console.WriteLine("Something wrong with the Login");
                AuthenticationMenu();
            }


        }

        public void Register()
        {
            
            string username = "";
            string password;
            string email;
            string firstname;
            string lastname;

            bool canUseUsername = false;
            while (canUseUsername == false)
            {
                Console.WriteLine("Insert new Username:");
                var choice = Console.ReadLine();
                var check = _userRepository.GetUserByUsername(choice);
                if (check != null)
                {
                    Console.WriteLine("Already existing username. Choose another one");
                }
                else
                {
                    username = choice;
                    canUseUsername = true;
                }
            }

            Console.WriteLine("Insert your First Name: ");
            firstname = Console.ReadLine();
            Console.WriteLine("Insert your Surname: ");
            lastname = Console.ReadLine();  
            Console.WriteLine("Insert your Email: ");
            email = Console.ReadLine();
            Console.WriteLine("Choose a new Password: ");
            password = Console.ReadLine();

            //TODO: check if some fields are nul

            _userRepository.AddUser(new User
            {
                Email = email,
                Username = username,
                Password = password,
                Name = firstname,
                Surname = lastname,
            });

            Console.WriteLine("Registration ok: Back to main page.");
            AuthenticationMenu();
           
        }

        public User? CheckCredentials(string username, string pwd)
        {
            var users = _userRepository.GetAllUsers();
            var correctUser = users.Where(x => x.Username == username && x.Password == pwd).SingleOrDefault();
            return correctUser;
        }
    }
}
