using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RandyRidge.Common {
    /// <summary>
    ///     Provides extension methods for <see cref="Array" />.
    /// </summary>
    public static class ArrayExtensions {
        /// <summary>
        ///     Returns whether the specified array is not null and is not empty.
        /// </summary>
        /// <param name="array">
        ///     The array to test.
        /// </param>
        /// <typeparam name="T">
        ///     The type of object.
        /// </typeparam>
        /// <returns>
        ///     true if the array is not null and is not empty; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasValue<T>(this T[]? array) => array != null && array.Length > 0;

        /// <summary>
        ///     Returns whether the specified collection is null or is empty.
        /// </summary>
        /// <param name="array">
        ///     The array to test.
        /// </param>
        /// <typeparam name="T">
        ///     The type of object.
        /// </typeparam>
        /// <returns>
        ///     true if the array is null or is empty; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this T[]? array) => array == null || array.Length == 0;

        /// <summary>
        ///     Determines whether the specified arrays are structurally equal.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of array elements.
        /// </typeparam>
        /// <param name="array">
        ///     An array to compare.
        /// </param>
        /// <param name="other">
        ///     The other array to compare.
        /// </param>
        /// <returns>
        ///     true if the two arrays are equal; otherwise, false.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="array" /> is null.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StructureEquals<T>(this T[]? array, T[]? other) {
            array = Guard.ArgumentNotNull(array, nameof(array));
            return other != null && ((IStructuralEquatable) array).Equals(other, EqualityComparer<T>.Default);
        }
    }
}
