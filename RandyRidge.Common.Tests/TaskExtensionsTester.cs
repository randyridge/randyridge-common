using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
	public static class TaskExtensionsTester {
		public sealed class FireAndForget {
			private int foo;

			[Fact]
			public void executes_task() {
				IncrementFooAsync().FireAndForget();
				foo.ShouldBe(42);
			}

			[Fact]
			public void swallows_exception() => ThrowAnExceptionAsync().FireAndForget();

			private static async Task ThrowAnExceptionAsync() {
				await Task.Delay(1).ForAwait();
				throw new ApplicationException("test");
			}

			private Task IncrementFooAsync() {
				foo = 42;
				return Task.Delay(1);
			}
		}

		public sealed class ForAwait {
			private static Task Task => Task.CompletedTask;

			private static Task<int> TaskOfT => Task.FromResult(42);

			private static ValueTask<int> ValueTaskOfT => new(42);

			[Fact]
			public async Task configures_task() {
				var ct = Task.ForAwait();
				await ct.ShouldBeOfType<ConfiguredTaskAwaitable>();
				await ct;
			}

			[Fact]
			public async Task configures_task_of_t() {
				var ct = TaskOfT.ForAwait();
				await ct.ShouldBeOfType<ConfiguredTaskAwaitable<int>>();
				await ct;
			}

			[Fact]
			public async Task configures_value_task_of_t() {
				var ct = ValueTaskOfT.ConfigureAwait(false);
				await ct.ShouldBeOfType<ConfiguredValueTaskAwaitable<int>>();
				await ct;
			}
		}

		public sealed class WithTimeout {
			[Fact]
			public async Task returns_task_when_it_completes_before_timeout() => await Task.Delay(1).WithTimeout(TimeSpan.FromMilliseconds(1000)).ForAwait();

			[Fact]
			public void throws_on_negative_timespan() => Should.ThrowAsync<ArgumentException>(async () => await Task.Delay(1).WithTimeout(TimeSpan.FromMilliseconds(-1)).ForAwait()).ForAwait();

			[Fact]
			public void throws_on_null_task() => Should.ThrowAsync<ArgumentNullException>(async () => await ((Task) null!).WithTimeout(TimeSpan.FromMilliseconds(1)).ForAwait()).ForAwait();

			[Fact]
			public void throws_timeout_exception_if_task_does_not_complete_within_timeout() => Should.ThrowAsync<TimeoutException>(async () => {
				await Task.Delay(100).WithTimeout(TimeSpan.FromMilliseconds(1)).ForAwait();
			});
		}

		public sealed class WithTimeoutEnumerable {
			[Fact]
			public async Task returns_tasks_when_they_complete_before_timeout() {
				var tasks = new[] {Task.Delay(1), Task.Delay(1)};
				await tasks.WithTimeout(TimeSpan.FromMilliseconds(1000)).ForAwait();
			}

			[Fact]
			public void throws_on_negative_timespan() {
				var tasks = new[] {Task.Delay(1), Task.Delay(1)};
				Should.ThrowAsync<ArgumentException>(async () => await tasks.WithTimeout(TimeSpan.FromMilliseconds(-1)).ForAwait());
			}

			[Fact]
			public void throws_on_null_tasks() => Should.ThrowAsync<ArgumentNullException>(async () => await ((Task[]) null!).WithTimeout(TimeSpan.FromMilliseconds(1)).ForAwait());

			[Fact]
			public void throws_timeout_exception_if_task_does_not_complete_within_timeout() {
				var tasks = new[] {Task.Delay(100), Task.Delay(100)};
				Should.ThrowAsync<TimeoutException>(async () => {
					await tasks.WithTimeout(TimeSpan.FromMilliseconds(1)).ForAwait();
				});
			}
		}

		public sealed class WithTimeoutGeneric {
			[Fact]
			public async Task returns_task_when_it_completes_before_timeout() {
				var result = await DelayTask(1).WithTimeout(TimeSpan.FromMilliseconds(1000)).ForAwait();
				result.ShouldBe(1);
			}

			[Fact]
			public void throws_on_negative_timespan() => Should.ThrowAsync<ArgumentException>(async () => await DelayTask(1).WithTimeout(TimeSpan.FromMilliseconds(-1)).ForAwait()).ForAwait();

			[Fact]
			public void throws_on_null_tasks() => Should.ThrowAsync<ArgumentNullException>(async () => await ((Task<int>) null!).WithTimeout(TimeSpan.FromMilliseconds(1)).ForAwait());

			[Fact]
			public void throws_timeout_exception_if_task_does_not_complete_within_timeout() => Should.ThrowAsync<TimeoutException>(async () => {
				await DelayTask(100).WithTimeout(TimeSpan.FromMilliseconds(1)).ForAwait();
			});

			private static async Task<int> DelayTask(int milliseconds) {
				await Task.Delay(milliseconds).ForAwait();
				return milliseconds;
			}
		}

		public sealed class WithTimeoutGenericEnumerable {
			[Fact]
			public async Task returns_task_when_it_completes_before_timeout() {
				var tasks = new[] {DelayTask(1), DelayTask(1)};
				var results = await tasks.WithTimeout(TimeSpan.FromMilliseconds(1000)).ForAwait();
				results.Length.ShouldBe(2);
			}

			[Fact]
			public void throws_on_negative_timespan() {
				var tasks = new[] {DelayTask(100), DelayTask(100)};
				Should.ThrowAsync<ArgumentException>(async () => await tasks.WithTimeout(TimeSpan.FromMilliseconds(-1)).ForAwait());
			}

			[Fact]
			public void throws_on_null_tasks() => Should.ThrowAsync<ArgumentNullException>(async () => await ((Task<int>[]) null!).WithTimeout(TimeSpan.FromMilliseconds(1)).ForAwait());

			[Fact]
			public void throws_timeout_exception_if_task_does_not_complete_within_timeout() {
				var tasks = new[] {DelayTask(100), DelayTask(100)};
				Should.ThrowAsync<TimeoutException>(async () => {
					await tasks.WithTimeout(TimeSpan.FromMilliseconds(1)).ForAwait();
				});
			}

			private static async Task<int> DelayTask(int milliseconds) {
				await Task.Delay(milliseconds).ForAwait();
				return milliseconds;
			}
		}
	}
}
