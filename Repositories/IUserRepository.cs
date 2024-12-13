using BookRecommender.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommender.Repositories
{
    public interface IUserRepository
    {
        public User? GetUserByUsername(string username);
        public List<User> GetAllUsers();
        public void AddUser(User user);
    }
}
