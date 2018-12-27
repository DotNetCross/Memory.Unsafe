using System;
using Xunit;

namespace DotNetCross.Memory.Tests
{
    public class Unsafe_ByteOffset_Test
    {
        [Fact]
        public static unsafe void ByteOffset_BoxedInt()
        {
            var obj = (object)42;
            ref var valueRef = ref Unsafe.Unbox<int>(obj);
            
            var valueByteOffset = Unsafe.ByteOffset(obj, ref valueRef);

            ref var byteOffsetValueRef = ref Unsafe.RefAtByteOffset<int>(obj, valueByteOffset);
            byteOffsetValueRef = 17;

            Assert.True(Unsafe.AreSame(ref valueRef, ref byteOffsetValueRef));
            Assert.Equal(17, (int)obj);
            // Currently, we can assume that the offset inside the object is equal
            // to the pointer size. This is highly runtime dependent though.
            Assert.Equal((long)Unsafe.SizeOf<IntPtr>(), (long)valueByteOffset);
            Assert.True((long)valueByteOffset >= (long)Unsafe.SizeOf<IntPtr>());
        }

        [Fact]
        public static unsafe void ByteOffset_Array()
        {
            var array = new int[] { 0,1,2,3,4,5,6 };
            ref var valueRef = ref array[2];

            var valueByteOffset = Unsafe.ByteOffset(array, ref valueRef);

            ref var byteOffsetValueRef = ref Unsafe.RefAtByteOffset<int>(array, valueByteOffset);
            byteOffsetValueRef = 17;

            Assert.True(Unsafe.AreSame(ref valueRef, ref byteOffsetValueRef));
            Assert.Equal(17, array[2]);
        }

        [Fact]
        public static unsafe void ByteOffset_Array_ElementOffsets()
        {
            var array = new byte[] { 0, 1, 2 };

            var valueByteOffset0 = Unsafe.ByteOffset(array, ref array[0]);
            var valueByteOffset2 = Unsafe.ByteOffset(array, ref array[2]);
            var diff = (long)valueByteOffset2 - (long)valueByteOffset0;

            Assert.Equal(new IntPtr(sizeof(IntPtr) * 2), valueByteOffset0);
            Assert.Equal(2L, diff);
        }
    }
}
