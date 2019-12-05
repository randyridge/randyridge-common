using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RandyRidge.Common {
    /// <summary>
    ///     Provides common <see cref="ICollection{T}" /> extensions.
    /// </summary>
    public static class ICollectionExtensions {
        /// <summary>
        ///     Returns whether the specified collection is not null and is not empty.
        /// </summary>
        /// <param name="collection">
        ///     The collection to test.
        /// </param>
        /// <typeparam name="T">
        ///     The type of object.
        /// </typeparam>
        /// <returns>
        ///     true if the collection is not null and is not empty; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasValue<T>(this ICollection<T>? collection) => collection != null && collection.Count > 0;

        /// <summary>
        ///     Returns whether the specified collection is null or is empty.
        /// </summary>
        /// <param name="collection">
        ///     The collection to test.
        /// </param>
        /// <typeparam name="T">
        ///     The type of object.
        /// </typeparam>
        /// <returns>
        ///     true if the collection is null or is empty; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this ICollection<T>? collection) => collection == null || collection.Count == 0;
    }
}
