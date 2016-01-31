using Xunit;

namespace DotNetCross.Memory.UnitTests
{
    public class Unsafe_InitBlock_Test
    {
        const int Size = 7;
        const int Offset = 3;
        const int InitSize = 3;

        [Fact]
        public unsafe void Byte()
        {
            var ptr = stackalloc byte[Size];

            var ptrOffset = ptr + Offset;
            Unsafe.InitBlock(ptrOffset, 42, InitSize);

            Assert.Equal(0, ptr[0]);
            Assert.Equal(0, ptr[1]);
            Assert.Equal(0, ptr[2]);
            Assert.Equal(42, ptr[3]);
            Assert.Equal(42, ptr[4]);
            Assert.Equal(42, ptr[5]);
            Assert.Equal(0, ptr[6]);
        }
    }
}
