using System.Runtime.InteropServices;
using Xunit;

namespace DotNetCross.Memory.UnitTests
{
    public class Unsafe_SizeOf_Test
    {
        [Fact]
        public unsafe void Primitives()
        {
            Assert.Equal(1, Unsafe.SizeOf<sbyte>());
            Assert.Equal(1, Unsafe.SizeOf<byte>());
            Assert.Equal(2, Unsafe.SizeOf<short>());
            Assert.Equal(2, Unsafe.SizeOf<ushort>());
            Assert.Equal(4, Unsafe.SizeOf<int>());
            Assert.Equal(4, Unsafe.SizeOf<uint>());
            Assert.Equal(8, Unsafe.SizeOf<long>());
            Assert.Equal(8, Unsafe.SizeOf<ulong>());
            Assert.Equal(4, Unsafe.SizeOf<float>());
            Assert.Equal(8, Unsafe.SizeOf<double>());
        }

        [Fact]
        public unsafe void ValueTypes()
        {
            Assert.Equal(3, Unsafe.SizeOf<ThreeBytes>());
            Assert.Equal(8, Unsafe.SizeOf<SequentialWithPacking>());

            Assert.Equal(4, Unsafe.SizeOf<Byte4>());
            Assert.Equal(8, Unsafe.SizeOf<Byte4Short2>());
            Assert.Equal(512, Unsafe.SizeOf<Byte512>());

            // TODO: For ExplicitSize it only works if there are fields at the right places, field offsets are ignored!
            //Assert.Equal(4, Unsafe.SizeOf<ExplicitSize>());
        }

#pragma warning disable 0649
        struct ThreeBytes
        {
            public byte b1;
            public byte b2;
            public byte b3;
        }
#pragma warning restore 0649        

        [StructLayout(LayoutKind.Sequential)]
        struct SequentialWithPacking
        {
            public byte b1;
            public float f1;
        }

        [StructLayout(LayoutKind.Explicit, Size = 27)]
        public class ExplicitSize
        {
            [FieldOffset(2)]
            public ushort us1;
            [FieldOffset(8)]
            public ushort us2;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Byte4
        {
            [FieldOffset(0)]
            public byte B0;
            [FieldOffset(1)]
            public byte B1;
            [FieldOffset(2)]
            public byte B2;
            [FieldOffset(3)]
            public byte B3;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Byte4Short2
        {
            [FieldOffset(0)]
            public byte B0;
            [FieldOffset(1)]
            public byte B1;
            [FieldOffset(2)]
            public byte B2;
            [FieldOffset(3)]
            public byte B3;
            [FieldOffset(4)]
            public short S4;
            [FieldOffset(6)]
            public short S6;
        }

        public unsafe struct Byte512
        {
            public fixed byte Bytes[512];
        }
    }
}
