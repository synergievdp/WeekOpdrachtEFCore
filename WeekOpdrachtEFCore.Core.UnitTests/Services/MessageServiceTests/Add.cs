using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;
using Xunit;

namespace WeekOpdrachtEFCore.Core.UnitTests.Services.MessageServiceTests
{
    public class Add : MessageServiceTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("\t")]
        public void Should_ThrowArgumentNullException_When_TitleInvalid(string title)
        {
            Action action = () => sut.Add(new Message() { Title = title });

            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("Title", ex.ParamName);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_ThrowArgumentException_WhenIdIsInvalid(int id)
        {
            Action action = () => sut.Add(new Message() { Title = "Title", SenderId = id });

            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("SenderId", ex.ParamName);
        }

        [Fact]
        public void Should_InsertMessage_WhenValid()
        {
            var message = new Message() { Title = "Title", SenderId = 1 };

            sut.Add(message);

            repo.Verify(r => r.Insert(message), Times.Once);
        }
    }
}
