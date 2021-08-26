using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;
using Xunit;

namespace WeekOpdrachtEFCore.Core.UnitTests.Services.UserServiceTests
{
    public class GetByEmail : UserServiceTest
    {
        [Theory]
        [InlineData(" ")]
        [InlineData("test@")]
        [InlineData("example.com")]
        [InlineData("@example.com")]
        public void Should_ThrowArgumentException_When_EmailInvalid(string email)
        {
            Action action = () => sut.GetByEmail(email);

            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("email", ex.ParamName);
        }

        [Fact]
        public void Should_GetUser_WhenEmailIsValid()
        {
            var email = "test@example.com";

            sut.GetByEmail(email);

            repo.Verify(r => r.Get(u => u.Email == email), Times.Once);
        }
    }
}
