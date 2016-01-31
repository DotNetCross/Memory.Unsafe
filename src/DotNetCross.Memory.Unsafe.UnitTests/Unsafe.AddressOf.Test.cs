using Xunit;

namespace DotNetCross.Memory.UnitTests
{
    public class Unsafe_AddressOf_Test
    {
        [Fact]
        public unsafe void Int()
        {
            var ptr = stackalloc int[1];
            *ptr = 42;
            var addressOf = Unsafe.AddressOf<int>(ref *ptr);
            Assert.True(ptr == addressOf);
        }

        [Fact]
        public unsafe void Double()
        {
            var ptr = stackalloc double[1];
            *ptr = 42;
            var addressOf = Unsafe.AddressOf<double>(ref *ptr);
            Assert.True(ptr == addressOf);
        }
    }
}
