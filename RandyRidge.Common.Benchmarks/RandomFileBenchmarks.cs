using BenchmarkDotNet.Attributes;
using RandyRidge.Common.IO;

namespace RandyRidge.Common;

[Config(typeof(DefaultConfig))]
public class RandomFileBenchmarks {
	[Benchmark]
	public void RandomFile() {
		using var file = new RandomFile(".jpg");
		using var file2 = new RandomFile("jpg");
	}
}
