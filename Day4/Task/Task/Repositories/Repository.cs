using System.Collections.Generic;
using System.Linq;
using Task.Models;

namespace Task.Repositories
{
    public class Repository
    {
        private readonly List<User> users = new List<User> {
            new User {UserId = 1, FirstName = "Ivan",
                LastName = "Ivanov", Role = Role.Admin},
            new User {UserId = 2, FirstName = "Petr",
                LastName = "Petrov", Role = Role.User},
            new User {UserId = 3, FirstName = "Sidor",
                LastName = "Sidorov", Role = Role.User},
            new User {UserId = 4, FirstName = "Vasya",
                LastName = "Vasilyev", Role = Role.Guest}
        };

        public User FindUser(int id)
        {
            return users.FirstOrDefault(user => user.UserId == id);
        }

        public List<User> GetAll()
        {
            return users;
        } 
    }
}