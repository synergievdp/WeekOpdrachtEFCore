using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core2.Entities;
using WeekOpdrachtEFCore.Core2.Interfaces.Services;
using WeekOpdrachtEFCore.Core2.Services;

namespace WeekOpdrachtEFCore.Core2.UnitTests.Services.MessageServiceTests
{
    public abstract class MessageServiceTest
    {
        protected readonly IMessageService sut;
        protected readonly Mock<DataContext> context;
        protected readonly Mock<DbSet<Message>> table;
        public MessageServiceTest()
        {
            table = new Mock<DbSet<Message>>();

            var items = new Message[] {
                new Message() { Id = 1, Title = "Title", SenderId = 1}
            }.AsQueryable();
            table.As<IQueryable<Message>>().Setup(m => m.Provider).Returns(items.Provider);
            table.As<IQueryable<Message>>().Setup(m => m.Expression).Returns(items.Expression);
            table.As<IQueryable<Message>>().Setup(m => m.ElementType).Returns(items.ElementType);
            table.As<IQueryable<Message>>().Setup(m => m.GetEnumerator()).Returns(() => items.GetEnumerator());

            var options = new DbContextOptionsBuilder<DataContext>().Options;
            context = new Mock<DataContext>(options);
            context.Setup(c => c.Set<Message>()).Returns(table.Object);
            sut = new MessageService(context.Object);
        }
    }
}
