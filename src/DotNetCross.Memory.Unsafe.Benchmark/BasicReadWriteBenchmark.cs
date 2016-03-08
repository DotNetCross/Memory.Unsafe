using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using DotNetCross.Memory;


namespace DotNetCross.Memory.Benchmark
{
    public struct Bgr { public byte B; public byte G; public byte R; }

    [Config("jobs=AllJits")]
    public class BasicReadWriteBenchmark<T>
        where T : struct
    {

        // NOTE: This includes cost of stack alloc
        [Benchmark]
        public void ReadFromStack()
        {
            unsafe
            {
                var stackPtr = stackalloc byte[Unsafe.SizeOf<T>()];
                var value = Unsafe.Read<T>(stackPtr);
            }
        }

        // NOTE: This includes cost of stack alloc
        [Benchmark]
        public void WriteToStack()
        {
            unsafe
            {
                var stackPtr = stackalloc byte[Unsafe.SizeOf<T>()];
                T value = default(T);
                Unsafe.Write<T>(stackPtr, value);
            }
        }

        // NOTE: This includes cost of stack alloc
        [Benchmark]
        public void WriteRefToStack()
        {
            unsafe
            {
                var stackPtr = stackalloc byte[Unsafe.SizeOf<T>()];
                T value = default(T);
                Unsafe.Write<T>(stackPtr, ref value);
            }
        }
    }

    public class BasicReadWriteBenchmarkByte : BasicReadWriteBenchmark<byte> { }
    public class BasicReadWriteBenchmarkShort : BasicReadWriteBenchmark<short> { }
    public class BasicReadWriteBenchmarkInt : BasicReadWriteBenchmark<int> { }
    public class BasicReadWriteBenchmarkBgr : BasicReadWriteBenchmark<Bgr> { }
}
