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
    public class MessageService : IMessageService
    {
        private readonly DataContext context;
        private readonly DbSet<Message> messages;

        public MessageService(DataContext context)
        {
            this.context = context;
            messages = context.Set<Message>();
        }
        public void Add(Message message)
        {
            Guard.IsNotNullOrWhiteSpace(message.Title, nameof(Message.Title));
            Guard.IsMoreThan(0, message.SenderId, nameof(message.SenderId));
            messages.Add(message);
            context.SaveChanges();
        }

        public Message GetById(int id)
        {
            Guard.IsMoreThan(0, id, nameof(id));
            return messages.Include(m => m.Sender).FirstOrDefault(m => m.Id == id);
        }

        public Message GetByUserId(int userid)
        {
            Guard.IsMoreThan(0, userid, nameof(userid));
            return messages.Include(m => m.Sender).FirstOrDefault(message => message.SenderId == userid);
        }
    }
}
