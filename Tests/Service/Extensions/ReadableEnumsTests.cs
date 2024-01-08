using Service.Enums;
using Service.Extensions;
using Xunit;

namespace Tests.Service.Extensions
{
    public class ReadableEnumsTests
    {
        [Fact]
        public void GivenAStatus_WhenTheToReadableStringFunctionIsCalled_ShouldReturnTheCorrectString()
        {
            var status = Status.Accepted;
            var result = status.ToReadableString();
            Assert.Equal("Accepted", result);
        }

        [Fact]
        public void GivenAType_WhenTheToReadableStringFunctionIsCalled_ShouldReturnTheCorrectString()
        {
            var type = Types.Hybrid;
            var result = type.ToReadableString();
            Assert.Equal("Hybrid", result);
        }
    }
}