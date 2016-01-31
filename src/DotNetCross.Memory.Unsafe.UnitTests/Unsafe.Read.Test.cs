using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DotNetCross.Memory.UnitTests
{
    public class UnsafeReadTest
    {
        [Fact]
        public unsafe void ReadInt()
        {
            int* ptr = stackalloc int[1];
            *ptr = 42;
            var v = Unsafe.Read<int>(ptr);
            Assert.Equal(42, v);
        }
    }
}
