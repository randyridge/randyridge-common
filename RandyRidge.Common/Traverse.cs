using System;
using System.Collections.Generic;

namespace RandyRidge.Common {
	/// <summary>
	///   Provides common object traversal operations.
	/// </summary>
	public static class Traverse {
		/// <summary>
		///   Traverses across a recursive type using the specified function.
		/// </summary>
		/// <typeparam name="T">
		///   The type to traverse.
		/// </typeparam>
		/// <param name="head">
		///   The head to start traversal from.
		/// </param>
		/// <param name="next">
		///   The function to use to traverse the object.
		/// </param>
		/// <returns>
		///   An enumerable of traversed types.
		/// </returns>
		public static IEnumerable<T> Across<T>(T head, Func<T?, T?> next) where T : class {
			head = Guard.NotNull(head, nameof(head));
			next = Guard.NotNull(next, nameof(next));
			var item = head;
			while(item != null!) {
				yield return item;
				item = next(item)!;
			}
		}
	}
}
