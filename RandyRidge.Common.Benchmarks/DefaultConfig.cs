﻿using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

namespace RandyRidge.Common;

public sealed class DefaultConfig : ManualConfig {
	public DefaultConfig() {
		AddDiagnoser(MemoryDiagnoser.Default);

//#if Windows
//			AddDiagnoser(new NativeMemoryProfiler());
//			AddDiagnoser(new EtwProfiler());
//#endif

		AddColumn(StatisticColumn.AllStatistics);

		AddJob(
			Job.Default
				.WithRuntime(CoreRuntime.Core50)
		);
	}
}
