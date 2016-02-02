using Xunit;

namespace DotNetCross.Memory.UnitTests
{
    public class Unsafe_AsPointer_Test
    {
        [Fact]
        public unsafe void Int()
        {
            var ptr = stackalloc int[1];
            *ptr = 42;
            var actualPtr = Unsafe.AsPointer<int>(ref *ptr);
            Assert.True(ptr == actualPtr);
        }

        [Fact]
        public unsafe void Double()
        {
            var ptr = stackalloc double[1];
            *ptr = 42;
            var actualPtr = Unsafe.AsPointer<double>(ref *ptr);
            Assert.True(ptr == actualPtr);
        }
    }
}
