using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WeekOpdrachtEFCore.Core2.UnitTests.Services.UserServiceTests
{
    public class GetById : UserServiceTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_ThrowArgumentException_When_IdIsInvalid(int id)
        {
            Action action = () => sut.GetById(id);

            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("id", ex.ParamName);
        }

        [Fact]
        public void Should_GetUser_When_IdIsValid()
        {
            var id = 1;

            var actual = sut.GetById(id);

            Assert.NotNull(actual);
        }
    }
}
