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
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> messages;

        public MessageService(IRepository<Message> messages)
        {
            this.messages = messages;
        }
        public void Add(Message message)
        {
            Guard.IsNotNullOrWhiteSpace(message.Title, nameof(Message.Title));
            Guard.IsMoreThan(0, message.SenderId, nameof(message.SenderId));
            messages.Insert(message);
        }

        public Message GetById(int id)
        {
            Guard.IsMoreThan(0, id, nameof(id));
            return messages.GetById(id);
        }

        public Message GetByUserId(int userid)
        {
            Guard.IsMoreThan(0, userid, nameof(userid));
            return messages.Get(message => message.SenderId == userid);
        }
    }
}
