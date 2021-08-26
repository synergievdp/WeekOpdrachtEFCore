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

namespace WeekOpdrachtEFCore.Core2.UnitTests.Services.UserServiceTests
{
    public abstract class UserServiceTest
    {
        protected readonly IUserService sut;
        protected readonly Mock<DataContext> context;
        protected readonly Mock<DbSet<User>> table;

        public UserServiceTest()
        {
            table = new Mock<DbSet<User>>();

            var items = new User[] {
            new User() { Id = 1, Surname = "Surname", Email = "test@example.com" }
            }.AsQueryable();

            table.As<IQueryable<User>>().Setup(m => m.Provider).Returns(items.Provider);
            table.As<IQueryable<User>>().Setup(m => m.Expression).Returns(items.Expression);
            table.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(items.ElementType);
            table.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => items.GetEnumerator());

            context = new Mock<DataContext>();
            context.Setup(c => c.Set<User>()).Returns(table.Object);
            sut = new UserService(context.Object);
        }
    }
}
