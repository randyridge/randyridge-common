﻿using BenchmarkDotNet.Running;

namespace RandyRidge.Common;

internal static class Program {
	private static void Main(string[] args) =>
		new BenchmarkSwitcher(typeof(Program).Assembly).Run(args);
}
