using Xunit;

namespace DotNetCross.Memory.Tests
{
    public class Unsafe_AsRef_Test
    {
        [Fact]
        public static unsafe void AsRef()
        {
            byte[] b = new byte[4] { 0x42, 0x42, 0x42, 0x42 };
            fixed (byte* p = b)
            {
                ref int r = ref Unsafe.AsRef<int>(p);
                Assert.Equal(0x42424242, r);

                r = 0x0EF00EF0;
                Assert.Equal(0xFE, b[0] | b[1] | b[2] | b[3]);
            }
        }

        [Fact]
        public static void InAsRef()
        {
            int[] a = new int[] { 0x123, 0x234, 0x345, 0x456 };

            ref int r = ref Unsafe.AsRef<int>(a[0]);
            Assert.Equal(0x123, r);

            r = 0x42;
            Assert.Equal(0x42, a[0]);
        }

        [Fact]
        public static void RefAs()
        {
            byte[] b = new byte[4] { 0x42, 0x42, 0x42, 0x42 };

            ref int r = ref Unsafe.As<byte, int>(ref b[0]);
            Assert.Equal(0x42424242, r);

            r = 0x0EF00EF0;
            Assert.Equal(0xFE, b[0] | b[1] | b[2] | b[3]);
        }
    }
}
