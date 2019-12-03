using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandyRidge.Common {
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [RPlotExporter, RankColumn]
    public class GuardBenchmarks {
        [Benchmark(Baseline = true)]
        public void GuardWithout() {
            Guard.ArgumentNotNull(string.Empty, "argument");
        }
    }
}
