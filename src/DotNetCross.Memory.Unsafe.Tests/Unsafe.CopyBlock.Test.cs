using Xunit;

namespace DotNetCross.Memory.Tests
{
    public class Unsafe_CopyBlock_Test
    {
        const int SourceSize = 5;
        const int SourceFilledSize = SourceSize - 2;
        const int Offset = 3;
        const int DestinationSize = 6;

        [Fact]
        public unsafe void Int()
        {
            var srcPtr = stackalloc int[SourceSize];
            var dstPtr = stackalloc int[DestinationSize];
            for (int i = 0; i < SourceFilledSize; i++)
            {
                srcPtr[i] = 42;
            }

            var dstPtrOffset = dstPtr + Offset;
            Unsafe.CopyBlock(dstPtrOffset, srcPtr, SourceFilledSize * sizeof(int));

            for (int i = 0; i < Offset; i++)
            {
                Assert.Equal(0, dstPtr[i]);
            }
            for (int i = Offset; i < DestinationSize; i++)
            {
                Assert.Equal(42, dstPtr[i]);
            }
        }

        [Fact]
        public unsafe void Double()
        {
            var srcPtr = stackalloc double[SourceSize];
            var dstPtr = stackalloc double[DestinationSize];
            for (int i = 0; i < SourceSize - 2; i++)
            {
                srcPtr[i] = 42;
            }

            var dstPtrOffset = dstPtr + Offset;
            Unsafe.CopyBlock(dstPtrOffset, srcPtr, SourceFilledSize * sizeof(double));

            for (int i = 0; i < Offset; i++)
            {
                Assert.Equal(0, dstPtr[i]);
            }
            for (int i = Offset; i < DestinationSize; i++)
            {
                Assert.Equal(42, dstPtr[i]);
            }
        }
    }
}
