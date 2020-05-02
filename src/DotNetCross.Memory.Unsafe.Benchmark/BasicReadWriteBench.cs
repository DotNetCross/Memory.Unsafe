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

    [LegacyJitX86Job, LegacyJitX64Job, RyuJitX64Job]
    public class BasicReadWriteBench<T>
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

    public class BasicReadWriteBenchmarkByte : BasicReadWriteBench<byte> { }
    public class BasicReadWriteBenchmarkShort : BasicReadWriteBench<short> { }
    public class BasicReadWriteBenchmarkInt : BasicReadWriteBench<int> { }
    public class BasicReadWriteBenchmarkBgr : BasicReadWriteBench<Bgr> { }
}
