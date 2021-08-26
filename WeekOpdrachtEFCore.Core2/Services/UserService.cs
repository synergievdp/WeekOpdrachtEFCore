using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core2.Entities;
using WeekOpdrachtEFCore.Core2.Interfaces.Repositories;
using WeekOpdrachtEFCore.Core2.Interfaces.Services;

namespace WeekOpdrachtEFCore.Core2.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext context;
        private readonly DbSet<User> users;

        public UserService(DataContext context)
        {
            this.context = context;
            users = context.Set<User>();
        }
        public void Add(User user)
        {
            Guard.IsNotNullOrWhiteSpace(user.Surname, nameof(user.Surname));
            if (!System.Net.Mail.MailAddress.TryCreate(user.Email, out _))
                throw new ArgumentException("Email is invalid", nameof(user.Email));
            if (users.Count(u => u.Email == user.Email) > 0)
                throw new ArgumentException("Email already exists", nameof(user.Email));
            users.Add(user);
            context.SaveChanges();
        }

        public User GetById(int id)
        {
            Guard.IsMoreThan(0, id, nameof(id));
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User GetByEmail(string email)
        {
            if (!System.Net.Mail.MailAddress.TryCreate(email, out _))
                throw new ArgumentException("Email is invalid", nameof(email));
            return users.FirstOrDefault(u => u.Email == email);
        }
    }
}
