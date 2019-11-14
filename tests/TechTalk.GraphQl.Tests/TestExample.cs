using FluentAssertions;
using Xunit;

namespace TechTalk.GraphQl.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestExample()
        {
            var exmaple = true;

            exmaple.Should().BeTrue();
        }
    }
}