using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core2.Entities;
using Xunit;

namespace WeekOpdrachtEFCore.Core2.UnitTests.Services.MessageServiceTests
{
    public class GetById : MessageServiceTest
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
        public void Should_GetMessage_When_IdIsValid()
        {
            var id = 1;

            var expected = sut.GetById(id);

            Assert.NotNull(expected);
        }
    }
}
