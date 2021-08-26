using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WeekOpdrachtEFCore.Core.UnitTests.Services.MessageServiceTests
{
    public class GetByUserId : MessageServiceTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_ThrowArgumentException_WhenIdIsInvalid(int id)
        {
            Action action = () => sut.GetByUserId(id);

            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("userid", ex.ParamName);
        }

        [Fact]
        public void Should_GetUser_WhenIdIsValid()
        {
            var id = 1;

            sut.GetByUserId(id);

            repo.Verify(r => r.Get(u => u.SenderId == id), Times.Once);
        }
    }
}
