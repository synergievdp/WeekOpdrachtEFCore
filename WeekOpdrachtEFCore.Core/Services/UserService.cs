using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;
using WeekOpdrachtEFCore.Core.Interfaces.Repositories;
using WeekOpdrachtEFCore.Core.Interfaces.Services;

namespace WeekOpdrachtEFCore.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }
        public void Add(User user)
        {
            if (users.Count(u => u.Email == user.Email) > 0)
                throw new ArgumentException("Email already exists");
            users.Insert(user);
        }

        public User GetById(int id)
        {
            return users.GetById(id);
        }

        public User GetByEmail(string email)
        {
            return users.Get(u => u.Email == email);
        }
    }
}
