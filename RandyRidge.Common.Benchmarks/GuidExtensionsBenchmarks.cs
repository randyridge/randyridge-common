using BenchmarkDotNet.Attributes;

namespace RandyRidge.Common;

[Config(typeof(DefaultConfig))]
public class GuidExtensionsBenchmarks {
	[Benchmark(Baseline = true)]
	public void ToStringWithDigitsOnly() => Guid.Empty.ToStringWithDigitsOnly();
}
