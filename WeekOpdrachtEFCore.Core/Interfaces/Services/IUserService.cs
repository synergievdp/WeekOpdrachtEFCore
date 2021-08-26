using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;

namespace WeekOpdrachtEFCore.Core.Interfaces.Services
{
    public interface IUserService
    {
        public void Add(User user);
        public User GetById(int id);
        public User GetByEmail(string email);
    }
}
