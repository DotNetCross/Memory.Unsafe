using Xunit;

namespace DotNetCross.Memory.Tests
{
    public class Unsafe_RefAtByteOffset_Test
    {
        public class ObjectValue
        {
            public int Value = 42;
        }

        [Fact]
        public static unsafe void RefAtByteOffset_Object()
        {
            var obj = new ObjectValue();
            ref var valueRef = ref obj.Value;
            
            var valueByteOffset = Unsafe.ByteOffset(obj, ref valueRef);

            ref var byteOffsetValueRef = ref Unsafe.RefAtByteOffset<int>(obj, valueByteOffset);
            byteOffsetValueRef = 17;

            Assert.True(Unsafe.AreSame(ref valueRef, ref byteOffsetValueRef));
            Assert.Equal(17, obj.Value);
        }

        [Fact]
        public static unsafe void RefAtByteOffset_Array()
        {
            var array = new byte[] { 0, 1, 2};
            ref var valueRef = ref array[1];

            var valueByteOffset = Unsafe.ByteOffset(array, ref valueRef);

            ref var byteOffsetValueRef = ref Unsafe.RefAtByteOffset<byte>(array, valueByteOffset);
            byteOffsetValueRef = 17;

            ref var nextValueRef = ref Unsafe.Add(ref byteOffsetValueRef, 1);
            nextValueRef = 42;

            Assert.True(Unsafe.AreSame(ref valueRef, ref byteOffsetValueRef));
            Assert.Equal(17, array[1]);
            Assert.Equal(42, array[2]);
        }
    }
}
