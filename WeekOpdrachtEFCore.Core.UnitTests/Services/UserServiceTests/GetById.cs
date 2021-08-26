using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WeekOpdrachtEFCore.Core.UnitTests.Services.UserServiceTests
{
    public class GetById : UserServiceTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_ThrowArgumentException_WhenIdIsInvalid(int id)
        {
            Action action = () => sut.GetById(id);

            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("id", ex.ParamName);
        }

        [Fact]
        public void Should_GetUser_WhenIdIsValid()
        {
            var id = 1;

            sut.GetById(id);

            repo.Verify(r => r.Get(u => u.Id == id), Times.Once);
        }
    }
}
