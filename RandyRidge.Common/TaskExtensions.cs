using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace RandyRidge.Common {
	/// <summary>
	///   Provides extension methods for <see cref="Task" /> and <see cref="Task{TResult}" />.
	/// </summary>
	public static class TaskExtensions {
		private const string TimeoutMustBeGreaterThanZero = "Timeout must be greater than zero.";

		/// <summary>
		///   Makes a task fire-and-forget safe.
		/// </summary>
		/// <param name="task">
		///   The task to modify.
		/// </param>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void FireAndForget(this Task? task) => task?.ContinueWith(t => GC.KeepAlive(t.Exception), TaskContinuationOptions.OnlyOnFaulted);

		/// <summary>
		///   Returns a ConfigureAwait(false) task.
		/// </summary>
		/// <param name="task">
		///   The task to modify.
		/// </param>
		/// <returns>
		///   A <see cref="ConfiguredTaskAwaitable" />.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///   Thrown if <paramref name="task" /> is null.
		/// </exception>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ConfiguredTaskAwaitable ForAwait(this Task? task) {
			task = Guard.NotNull(task, nameof(task));
			return task.ConfigureAwait(false);
		}

		/// <summary>
		///   Returns a ConfigureAwait(false) task.
		/// </summary>
		/// <param name="task">
		///   The task to modify.
		/// </param>
		/// <returns>
		///   A <see cref="ConfiguredTaskAwaitable{TResult}" />.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///   Thrown if <paramref name="task" /> is null.
		/// </exception>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ConfiguredTaskAwaitable<T> ForAwait<T>(this Task<T>? task) {
			task = Guard.NotNull(task, nameof(task));
			return task.ConfigureAwait(false);
		}

		/// <summary>
		///   Executes the specified tasks with the specified timeout.
		/// </summary>
		/// <param name="tasks">
		///   The tasks to execute.
		/// </param>
		/// <param name="timeout">
		///   The timeout value.
		/// </param>
		/// <returns>
		///   The task.
		/// </returns>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Task WithTimeout(this IEnumerable<Task>? tasks, TimeSpan timeout) {
			tasks = GuardTasks(tasks);
			timeout = GuardTimeout(timeout);
			return Task.WhenAll(tasks).WithTimeout(timeout);
		}

		/// <summary>
		///   Executes the specified task with the specified timeout.
		/// </summary>
		/// <param name="task">
		///   The task to execute.
		/// </param>
		/// <param name="timeout">
		///   The timeout value.
		/// </param>
		/// <returns>
		///   The task.
		/// </returns>
		/// <exception cref="TimeoutException">
		///   Thrown if the <paramref name="timeout" /> occurs before the <paramref name="task" /> completes.
		/// </exception>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async Task WithTimeout(this Task? task, TimeSpan timeout) {
			task = GuardTask(task);
			timeout = GuardTimeout(timeout);

			using var cts = new CancellationTokenSource();
			if(task != await Task.WhenAny(task, Task.Delay(timeout, cts.Token)).ForAwait()) {
				ThrowTimeoutException(timeout);
			}

			cts.Cancel();
			await task.ForAwait();
		}

		/// <summary>
		///   Executes the specified tasks with the specified timeout.
		/// </summary>
		/// <typeparam name="T">
		///   The task result type.
		/// </typeparam>
		/// <param name="tasks">
		///   The tasks to execute.
		/// </param>
		/// <param name="timeout">
		///   The timeout value.
		/// </param>
		/// <returns>
		///   The tasks.
		/// </returns>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Task<T[]> WithTimeout<T>(this IEnumerable<Task<T>>? tasks, TimeSpan timeout) {
			tasks = GuardTasks(tasks);
			timeout = GuardTimeout(timeout);
			return Task.WhenAll(tasks).WithTimeout(timeout);
		}

		/// <summary>
		///   Executes the specified task with the specified timeout.
		/// </summary>
		/// <typeparam name="T">
		///   The task type.
		/// </typeparam>
		/// <param name="task">
		///   The task to execute.
		/// </param>
		/// <param name="timeout">
		///   The timeout value.
		/// </param>
		/// <returns>
		///   The task.
		/// </returns>
		/// <exception cref="TimeoutException">
		///   Thrown if the <paramref name="timeout" /> occurs before the <paramref name="task" /> completes.
		/// </exception>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async Task<T> WithTimeout<T>(this Task<T>? task, TimeSpan timeout) {
			task = GuardTask(task);
			timeout = GuardTimeout(timeout);

			using var cts = new CancellationTokenSource();
			if(task != await Task.WhenAny(task, Task.Delay(timeout, cts.Token)).ForAwait()) {
				ThrowTimeoutException(timeout);
			}

			cts.Cancel();
			return await task.ForAwait();
		}

		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Task GuardTask(Task? task) => Guard.NotNull(task, nameof(task));

		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Task<T> GuardTask<T>(Task<T>? task) => Guard.NotNull(task, nameof(task));

		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static IEnumerable<Task> GuardTasks(IEnumerable<Task>? tasks) => Guard.NotNull(tasks, nameof(tasks));

		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static IEnumerable<Task<T>> GuardTasks<T>(IEnumerable<Task<T>>? tasks) => Guard.NotNull(tasks, nameof(tasks));

		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static TimeSpan GuardTimeout(TimeSpan timeout) => timeout < TimeSpan.Zero ? throw new ArgumentException(TimeoutMustBeGreaterThanZero, nameof(timeout)) : timeout;

		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void ThrowTimeoutException(TimeSpan timeout) => throw new TimeoutException($"Operation timed out after {timeout}.");
	}
}
