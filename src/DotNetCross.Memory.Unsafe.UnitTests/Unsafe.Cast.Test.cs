using Xunit;

namespace DotNetCross.Memory.UnitTests
{
    public class Unsafe_Cast_Test
    {
        [Fact]
        public unsafe void Pinnable()
        {
            var array = new int[2];
            array[0] = 42;
            array[1] = 17;
            // Hmm Cast for object needs a cast to object! Not good...
            fixed (void* pinPtr = &Unsafe.Cast((object)array).ToPinnable().Pin)
            {
                void* firstPtr = Unsafe.AddressOf(ref array[0]);

                Assert.Equal(42, Unsafe.Read<int>(firstPtr));
                Assert.Equal(17, Unsafe.Read<int>((byte*)firstPtr + sizeof(int)));
            }
        }

        [Fact]
        public unsafe void ValueType_To()
        {
            int integer = 42;
            // Yeah this isn't working at all, no way to this as such apparently...
            // might do it with if/else for types which the JIT might inline...
            double f64 = Unsafe.Cast(integer).To<double>();
            Assert.Equal(42.0, f64);
        }
    }
}
