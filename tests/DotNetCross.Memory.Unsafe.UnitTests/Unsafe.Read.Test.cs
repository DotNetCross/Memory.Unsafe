using Xunit;

namespace DotNetCross.Memory.UnitTests
{
    public class Unsafe_Read_Test
    {
        [Fact]
        public unsafe void Int()
        {
            var ptr = stackalloc int[1];
            *ptr = 42;
            var v = Unsafe.Read<int>(ptr);
            Assert.Equal(42, v);
        }

        [Fact]
        public unsafe void Double()
        {
            var ptr = stackalloc double[1];
            *ptr = 42;
            var v = Unsafe.Read<double>(ptr);
            Assert.Equal(42, v);
        }
    }
}
