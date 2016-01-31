using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BenchmarkDotNet;
using BenchmarkDotNet.Tasks;
using DotNetCross.Memory;


namespace DotNetCross.Memory.Benchmark
{
    public class BasicReadWriteBenchmark<T>
        where T : struct
    {
        public BasicReadWriteBenchmark()
        {

        }

        // NOTE: This includes cost of stack alloc
        [Benchmark]
        public void ReadFromStack()
        {
            unsafe
            {
                //var stackPtr = stackalloc byte[Marshal.SizeOf<T>()];
                //var value = Unsafe.Read<T>(stackPtr);
            }
        }

        // NOTE: This includes cost of stack alloc
        [Benchmark]
        public void WriteToStack()
        {
            unsafe
            {
                //var stackPtr = stackalloc byte[Marshal.SizeOf<T>()];
                //Unsafe.Write<T>(stackPtr, default(T));
            }
        }
    }

    public class BasicReadWriteBenchmarkByte : BasicReadWriteBenchmark<byte> { }
}
