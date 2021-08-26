using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core2.Entities;

namespace WeekOpdrachtEFCore.Core2.Interfaces.Services
{
    public interface IMessageService
    {
        public void Add(Message message);
        public Message GetById(int id);
        public Message GetByUserId(int id);
    }
}
