using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;

namespace WeekOpdrachtEFCore.Core.Interfaces.Services
{
    public interface IMessageService
    {
        public void Add(Message message);
        public Message GetById(int id);
        public Message GetByUserId(int id);
    }
}
