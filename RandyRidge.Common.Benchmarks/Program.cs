using BenchmarkDotNet.Running;

namespace RandyRidge.Common {
    internal static class Program {
        private static void Main() {
            BenchmarkRunner.Run<GuardBenchmarks>();
        }
    }
}
