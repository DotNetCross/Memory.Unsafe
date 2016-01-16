using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;

namespace DotNetCross.Memory.Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var logger = new BenchmarkAccumulationLogger();
            //var sourceDiagnoser = new BenchmarkSourceDiagnoser();
            //var plugins = BenchmarkPluginBuilder.CreateDefault()
            //                    .AddLogger(logger)
            //                    .AddDiagnoser(sourceDiagnoser)
            //                    .Build();
            var runner = new BenchmarkRunner();
            runner.Run<Program>();
            //runner.Run<BasicReadWriteBenchmarkByte>();
            //    typeof(),
            //    typeof(BasicReadWriteBenchmark<short>),
            //    typeof(BasicReadWriteBenchmark<int>),
            //    typeof(BasicReadWriteBenchmark<long>),
            //    typeof(BasicReadWriteBenchmark<float>),
            //    typeof(BasicReadWriteBenchmark<double>)
        }

        [Benchmark]
        public void Test()
        {
            var a = 42 + 17;
            ++a;
        }
    }
}
