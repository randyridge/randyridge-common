using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace RandyRidge.Common;

/// <summary>
///   Provides common <see cref="IEnumerable{T}" /> extensions.
/// </summary>
public static class IEnumerableExtensions {
	/// <summary>
	///   Executes the specified action for each member of the <see cref="IEnumerable{T}" />.
	/// </summary>
	/// <param name="enumerable">
	///   An enumerable that contains the objects to execute the action upon.
	/// </param>
	/// <param name="action">
	///   The action to perform on the items in the enumerable.
	/// </param>
	/// <typeparam name="T">
	///   The type of the members of <paramref name="enumerable" />.
	/// </typeparam>
	/// <exception cref="ArgumentNullException">
	///   Thrown if <paramref name="enumerable" /> or <paramref name="action" /> is null.
	/// </exception>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ForEach<T>(this IEnumerable<T>? enumerable, Action<T> action) {
		enumerable = Guard.NotNull(enumerable, nameof(enumerable));
		Guard.NotNull(action, nameof(action));
		foreach(var value in enumerable) {
			action(value);
		}
	}

	/// <summary>
	///   Executes the specified asynchronous action for each member of the enumerable />.
	/// </summary>
	/// <param name="enumerable">
	///   An enumerable that contains the objects to execute the action upon.
	/// </param>
	/// <param name="degreeOfParallelism">
	///   The maximum number of concurrent tasks.
	/// </param>
	/// <param name="action">
	///   The action to perform on the items in the enumerable.
	/// </param>
	/// <typeparam name="T">
	///   The type of the members of <paramref name="enumerable" />.
	/// </typeparam>
	/// <returns>
	///   A task representing the completion of the operation.
	/// </returns>
	public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, int degreeOfParallelism, Func<T, Task> action) {
		Guard.NotNull(enumerable, nameof(enumerable));
		Guard.NotNull(action, nameof(action));
		var tasks = new List<Task>();
		using var throttler = new SemaphoreSlim(degreeOfParallelism);
		foreach(var element in enumerable) {
			await throttler.WaitAsync().ForAwait();
			tasks.Add(Task.Run(async () => {
				try {
					await action(element).ForAwait();
				}
				finally {
					// ReSharper disable once AccessToDisposedClosure
					throttler.Release();
				}
			}));
		}

		await Task.WhenAll(tasks).ForAwait();
	}

	/// <summary>
	///   Whether the enumerable is not null and is not empty.
	/// </summary>
	/// <param name="enumerable">
	///   The enumerable to evaluate.
	/// </param>
	/// <typeparam name="T">
	///   The type of the members of <paramref name="enumerable" />.
	/// </typeparam>
	/// <returns>
	///   true if the enumerable is not null and is not empty; otherwise, false.
	/// </returns>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasValue<T>(this IEnumerable<T>? enumerable) => enumerable?.Any() == true;

	/// <summary>
	///   Returns whether the enumerable is null or empty.
	/// </summary>
	/// <param name="enumerable">
	///   The enumerable to evaluate.
	/// </param>
	/// <typeparam name="T">
	///   The type of the members of <paramref name="enumerable" />.
	/// </typeparam>
	/// <returns>
	///   true if the enumerable is null or is empty; otherwise, false.
	/// </returns>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable) => enumerable?.Any() != true;

	/// <summary>
	///   Materializes the specified enumerable to a collection.
	/// </summary>
	/// <typeparam name="T">
	///   The type contained in the enumerable.
	/// </typeparam>
	/// <param name="enumerable"></param>
	/// <returns>
	///   The enumerable materialized as a collection.
	/// </returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ICollection<T> Materialize<T>(this IEnumerable<T>? enumerable) {
		if(enumerable == null) {
			return Array.Empty<T>();
		}

		return enumerable as ICollection<T> ?? enumerable.ToList();
	}

	/// <summary>
	///   Converts to specified byte array to its hexadecimal representation.
	/// </summary>
	/// <param name="bytes">
	///   The bytes to convert.
	/// </param>
	/// <remarks>
	///   All lowercase, no preceding 0x.
	/// </remarks>
	/// <returns>
	///   The hexadecimal representation of the specified byte array.
	/// </returns>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToHex(this IEnumerable<byte>? bytes) {
		bytes = Guard.NotNull(bytes, nameof(bytes));

		var result = new StringBuilder();
		foreach(var b in bytes) {
			result.Append(b.ToHex());
		}

		return result.ToString();
	}

	/// <summary>
	///   Converts the specified <paramref name="enumerable" /> to a sorted dictionary
	///   given the specified <paramref name="keySelector" />.
	/// </summary>
	/// <typeparam name="TKey">
	///   The type of the key.
	/// </typeparam>
	/// <typeparam name="TValue">
	///   The type of the value.
	/// </typeparam>
	/// <param name="enumerable">
	///   The enumeration to iterate upon.
	/// </param>
	/// <param name="keySelector">
	///   The key/value selection and generation function.
	/// </param>
	/// <returns>
	///   The sorted <paramref name="enumerable" /> according to <paramref name="keySelector" />.
	/// </returns>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(this IEnumerable<TValue> enumerable, Func<TValue, TKey>? keySelector) where TKey : notnull {
		enumerable = Guard.NotNull(enumerable, nameof(enumerable));
		keySelector = Guard.NotNull(keySelector, nameof(keySelector));
		var result = new SortedDictionary<TKey, TValue>();
		foreach(var item in enumerable) {
			result.Add(keySelector(item), item);
		}

		return result;
	}

	/// <summary>
	///   Returns an enumerable without null items.
	/// </summary>
	/// <param name="enumerable">
	///   The enumerable to evaluate.
	/// </param>
	/// <typeparam name="T">
	///   The type of the members of <paramref name="enumerable" />.
	/// </typeparam>
	/// <returns>
	///   An enumerable without null items.
	/// </returns>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T>? enumerable) {
		return enumerable == null ? Array.Empty<T>() : enumerable.Where(x => x != null);
	}
}
