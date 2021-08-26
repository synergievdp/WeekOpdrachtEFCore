using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;
using WeekOpdrachtEFCore.Core.Interfaces.Repositories;

namespace WeekOpdrachtEFCore.Data.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DataContext context) : base(context)
        {
        }

        protected override IQueryable<Message> GetQuery(Expression<Func<Message, bool>> filter = null)
        {
            return base.GetQuery(filter).Include(m => m.Sender);
        }
    }
}
