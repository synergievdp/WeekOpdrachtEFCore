using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core2.Entities;
using Xunit;

namespace WeekOpdrachtEFCore.Core2.UnitTests.Services.UserServiceTests
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
            var user = new User() { Surname = "Surname", Email = "test@example.com" };

            Action action = () => sut.Add(user);

            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("Email", ex.ParamName);
        }

        [Fact]
        public void Should_InsertUser_When_Valid()
        {
            var user = new User() { Surname = "Surname", Email = "test2@example.com" };

            sut.Add(user);

            table.Verify(r => r.Add(user), Times.Once);
            context.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
