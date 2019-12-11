using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

namespace RandyRidge.Common {
    public sealed class DefaultBenchmarkConfig : ManualConfig {
        public DefaultBenchmarkConfig() {
            Add(MemoryDiagnoser.Default);

#if Windows
            Add(new NativeMemoryProfiler());
#endif

            Add(StatisticColumn.AllStatistics);

            Add(Job.Default
                .With(CoreRuntime.Core31)
                .With(Jit.RyuJit)
            );
        }
    }
}
