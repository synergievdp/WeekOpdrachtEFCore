using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WeekOpdrachtEFCore.Core2.UnitTests.Services.UserServiceTests
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
        public void Should_GetUser_When_EmailIsValid()
        {
            var email = "test@example.com";

            var actual = sut.GetByEmail(email);

            Assert.NotNull(actual);
        }
    }
}
