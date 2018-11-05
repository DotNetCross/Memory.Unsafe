using Xunit;

namespace DotNetCross.Memory.Tests
{
    public class Unsafe_As_Test
    {
        [Fact]
        public unsafe void Pinnable()
        {
            var array = new int[2];
            array[0] = 42;
            array[1] = 17;
            fixed (void* pinPtr = &Unsafe.As<Pinnable>(array).Pin)
            {
                void* firstPtr = Unsafe.AsPointer(ref array[0]);

                Assert.Equal(42, Unsafe.Read<int>(firstPtr));
                Assert.Equal(17, Unsafe.Read<int>((byte*)firstPtr + sizeof(int)));
            }
        }
    }
}
