using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DotNetCross.Memory.Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BasicReadWriteBenchmarkShort>();
            BenchmarkRunner.Run<BasicReadWriteBenchmarkBgr>();
        }
    }
}
