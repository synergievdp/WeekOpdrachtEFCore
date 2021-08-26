using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Interfaces.Repositories;
using WeekOpdrachtEFCore.Core.Interfaces.Services;
using WeekOpdrachtEFCore.Core.Services;

namespace WeekOpdrachtEFCore.Core.UnitTests.Services.MessageServiceTests
{
    public abstract class MessageServiceTest
    {
        protected readonly IMessageService sut;
        protected readonly Mock<IMessageRepository> repo;
        public MessageServiceTest()
        {
            repo = new Mock<IMessageRepository>();
            sut = new MessageService(repo.Object);
        }
    }
}
