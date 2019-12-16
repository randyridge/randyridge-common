using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RandyRidge.Common {
    /// <summary>
    ///     Provides common <see cref="IEnumerable{T}" /> extensions.
    /// </summary>
    public static class IEnumerableExtensions {
        /// <summary>
        ///     Executes the specified action for each member of the <see cref="IEnumerable{T}" />.
        /// </summary>
        /// <param name="enumerable">
        ///     An enumerable that contains the objects to execute the action upon.
        /// </param>
        /// <param name="action">
        ///     The action to perform on the items in the enumerable.
        /// </param>
        /// <typeparam name="T">
        ///     The type of the members of <paramref name="enumerable" />.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable" /> or <paramref name="action" /> is null.
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
        ///     Whether the enumerable is not null and is not empty.
        /// </summary>
        /// <param name="enumerable">
        ///     The enumerable to evaluate.
        /// </param>
        /// <typeparam name="T">
        ///     The type of the members of <paramref name="enumerable" />.
        /// </typeparam>
        /// <returns>
        ///     true if the enumerable is not null and is not empty; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasValue<T>(this IEnumerable<T>? enumerable) => enumerable?.Any() == true;

        /// <summary>
        ///     Returns whether the enumerable is null or empty.
        /// </summary>
        /// <param name="enumerable">
        ///     The enumerable to evaluate.
        /// </param>
        /// <typeparam name="T">
        ///     The type of the members of <paramref name="enumerable" />.
        /// </typeparam>
        /// <returns>
        ///     true if the enumerable is null or is empty; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable) => enumerable?.Any() != true;

        /// <summary>
        ///     Converts to specified byte array to its hexadecimal representation.
        /// </summary>
        /// <param name="bytes">
        ///     The bytes to convert.
        /// </param>
        /// <remarks>
        ///     All lowercase, no preceding 0x.
        /// </remarks>
        /// <returns>
        ///     The hexadecimal representation of the specified byte array.
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
    }
}
