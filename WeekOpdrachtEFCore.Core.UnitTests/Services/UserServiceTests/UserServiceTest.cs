using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;
using WeekOpdrachtEFCore.Core.Interfaces.Repositories;
using WeekOpdrachtEFCore.Core.Interfaces.Services;
using WeekOpdrachtEFCore.Core.Services;

namespace WeekOpdrachtEFCore.Core.UnitTests.Services.UserServiceTests
{
    public abstract class UserServiceTest
    {
        protected readonly IUserService sut;
        protected readonly Mock<IRepository<User>> repo;
        public UserServiceTest()
        {
            repo = new Mock<IRepository<User>>();
            sut = new UserService(repo.Object);
        }
    }
}
