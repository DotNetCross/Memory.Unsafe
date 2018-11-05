using Xunit;

namespace DotNetCross.Memory.Tests
{
    public class Unsafe_Write_Test
    {
        public struct Bgr { public byte B; public byte G; public byte R; }

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

        [Fact]
        public unsafe void ValueType()
        {
            var ptr = stackalloc Bgr[1];
            *ptr = new Bgr { B = 1, G = 2, R = 3 };
            Unsafe.Write(ptr, new Bgr { B = 11, G = 22, R = 33 });
            Assert.Equal(11, ptr[0].B);
            Assert.Equal(22, ptr[0].G);
            Assert.Equal(33, ptr[0].R);
        }
    }
}
