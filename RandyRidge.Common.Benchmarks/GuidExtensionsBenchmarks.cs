using System;
using BenchmarkDotNet.Attributes;

namespace RandyRidge.Common {
    [Config(typeof(DefaultBenchmarkConfig))]
    public class GuidExtensionsBenchmarks {
        [Benchmark(Baseline = true)]
        public void ToStringWithDigitsOnly() => Guid.Empty.ToStringWithDigitsOnly();
    }
}
