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
            Guard.IsNotNullOrWhiteSpace(user.Surname, nameof(user.Surname));
            if (!System.Net.Mail.MailAddress.TryCreate(user.Email, out _))
                throw new ArgumentException(nameof(user.Email));
            if (users.Count(u => u.Email == user.Email) > 0)
                throw new ArgumentException("Email already exists");
            users.Insert(user);
        }

        public User GetById(int id)
        {
            Guard.IsMoreThan(0, id, nameof(id));
            return users.GetById(id);
        }

        public User GetByEmail(string email)
        {
            if (!System.Net.Mail.MailAddress.TryCreate(email, out _))
                throw new ArgumentException(nameof(email));
            return users.Get(u => u.Email == email);
        }
    }
}
