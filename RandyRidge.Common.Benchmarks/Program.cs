using BenchmarkDotNet.Running;

namespace RandyRidge.Common {
	internal static class Program {
		private static void Main() {
			var benchmarksAssembly = typeof(Program).Assembly;
			var benchmarkSwitcher = new BenchmarkSwitcher(benchmarksAssembly);
			benchmarkSwitcher.Run();
		}
	}
}
