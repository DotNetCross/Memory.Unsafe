using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

namespace DotNetCross.Memory.Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            Func<Job> baseJob = () => Job.Default;
            var iterationTime = new TimeInterval(50, TimeUnit.Millisecond);
            var runtimes = new Runtime[] { CoreRuntime.Core21, CoreRuntime.Core31, ClrRuntime.Net461 };
            // Platforms doesn't work
            //var platforms = new Platform[] { Platform.X64, Platform.X86 };

            var config = DefaultConfig.Instance;
            foreach (var runtime in runtimes)
            {
                //foreach (var platform in platforms)
                {
                    var job = baseJob()
                        
                        .WithRuntime(runtime)
                        .WithIterationTime(iterationTime);//.WithPlatform(platform);
                    if (runtime == CoreRuntime.Core31) { job = job.AsBaseline(); }
                    config = config.AddJob(job);
                }
            }
            config = config.AddJob(Job.LegacyJitX86.WithIterationTime(iterationTime));
            config = config.AddJob(Job.LegacyJitX64.WithIterationTime(iterationTime));
            config = config.AddJob(Job.RyuJitX64.WithIterationTime(iterationTime));

            BenchmarkRunner.Run<BasicReadWriteBenchmarkBgr>(config);

            //BenchmarkSwitcher
            //    .FromTypes(new[] { typeof(BasicReadWriteBenchmarkBgr) })
            //    .Run(args, config);

            //BenchmarkRunner.Run<BasicReadWriteBenchmarkShort>();
            //BenchmarkRunner.Run<BasicReadWriteBenchmarkBgr>();

            //var b = new BasicReadWriteBenchmarkBgr();
            //for (int i = 0; i < 1000; i++)
            //{
            //    b.ReadFromStack();
            //    b.WriteToStack();
            //    b.WriteRefToStack();
            //}
        }
    }
}
