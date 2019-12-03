using BenchmarkDotNet.Running;

namespace RandyRidge.Common {
    internal static class Program {
        private static void Main() {
            var summary = BenchmarkRunner.Run<GuardBenchmarks>();
        }
    }
}
