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
using Xunit;

namespace WeekOpdrachtEFCore.Core.UnitTests.Services.UserServiceTests
{
    public class Add : UserServiceTest
    {
        

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("\t")]
        public void Should_ThrowArgumentNullException_When_SurnameInvalid(string surname)
        {
            Action action = () => sut.Add(new User() { Surname = surname });

            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("Surname", ex.ParamName);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("test@")]
        [InlineData("example.com")]
        [InlineData("@example.com")]
        public void Should_ThrowArgumentException_When_EmailInvalid(string email)
        {
            Action action = () => sut.Add(new User() { Surname = "Surname", Email = email });

            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("Email", ex.ParamName);
        }

        [Fact]
        public void Should_Throw_ArgumentException_When_EmailExists()
        {
            var user = new User() { Surname = "Surname", Email = "test@examepl.com" };
            repo.Setup(r => r.Count(u => u.Email == user.Email)).Returns(1);

            Action action = () => sut.Add(user);

            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("Email", ex.ParamName);
        }

        [Fact]
        public void Should_InsertUser_WhenValid()
        {
            var user = new User() { Surname = "Surname", Email = "test@example.com" };

            sut.Add(user);

            repo.Verify(r => r.Insert(user), Times.Once);
        }
    }
}
