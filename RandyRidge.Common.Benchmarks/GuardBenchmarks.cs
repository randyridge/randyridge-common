using BenchmarkDotNet.Attributes;

namespace RandyRidge.Common {
	[Config(typeof(DefaultConfig))]
	public class GuardBenchmarks {
		[Benchmark(Baseline = true)]
		public void ArgumentNotNull() => Guard.NotNull(string.Empty, "argument");
	}
}
