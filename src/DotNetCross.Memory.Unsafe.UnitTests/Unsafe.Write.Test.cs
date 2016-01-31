using Xunit;

namespace DotNetCross.Memory.UnitTests
{
    public class Unsafe_Write_Test
    {
        [Fact]
        public unsafe void Int()
        {
            var ptr = stackalloc int[1];
            *ptr = 17;
            Unsafe.Write<int>(ptr, 42);
            Assert.Equal(42, ptr[0]);
        }

        [Fact]
        public unsafe void Double()
        {
            var ptr = stackalloc double[1];
            *ptr = 17;
            Unsafe.Write<double>(ptr, 42);
            Assert.Equal(42, ptr[0]);
        }
    }
}
