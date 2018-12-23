using Xunit;

namespace DotNetCross.Memory.Tests
{
    public class Unsafe_AsRefAtByteOffset_Test
    {
        public class ObjectValue
        {
            public int Value = 42;
        }

        [Fact]
        public static unsafe void AsRefAtByteOffset()
        {
            var obj = new ObjectValue();
            ref var valueRef = ref obj.Value;
            
            var valueByteOffset = Unsafe.ByteOffset(obj, ref valueRef);

            ref var byteOffsetValueRef = ref Unsafe.AsRefAtByteOffset<int>(obj, valueByteOffset);
            byteOffsetValueRef = 17;

            Assert.True(Unsafe.AreSame(ref valueRef, ref byteOffsetValueRef));
            Assert.Equal(17, obj.Value);
        }
    }
}
