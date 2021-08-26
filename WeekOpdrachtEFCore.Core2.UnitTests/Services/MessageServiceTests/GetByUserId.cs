using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core2.Entities;
using Xunit;

namespace WeekOpdrachtEFCore.Core2.UnitTests.Services.MessageServiceTests
{
    public class GetByUserId : MessageServiceTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_ThrowArgumentException_When_IdIsInvalid(int id)
        {
            Action action = () => sut.GetByUserId(id);

            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("userid", ex.ParamName);
        }

        [Fact]
        public void Should_GetUser_When_IdIsValid()
        {
            var id = 1;

            var actual = sut.GetByUserId(id);

            Assert.NotNull(actual);
        }
    }
}
