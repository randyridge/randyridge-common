using BenchmarkDotNet.Attributes;

namespace RandyRidge.Common {
    [Config(typeof(DefaultBenchmarkConfig))]
    public class GuardBenchmarks {
        [Benchmark(Baseline = true)]
        public void ArgumentNotNull() => Guard.ArgumentNotNull(string.Empty, "argument");
    }
}
