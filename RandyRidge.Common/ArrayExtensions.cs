using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

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
        ///     Compares two byte arrays in length-constant time.
        /// </summary>
        /// <remarks>
        ///     This comparison method is used to prevent timing attacks.
        /// </remarks>
        /// <param name="array">
        ///     An array to compare.
        /// </param>
        /// <param name="other">
        ///     The other array to compare.
        /// </param>
        /// <returns>
        ///     true if the arrays are equal; otherwise, false.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="array" /> is null.
        /// </exception>
        public static bool LinearEquals(this byte[]? array, byte[]? other) {
            array = Guard.ArgumentNotNull(array, nameof(array));

            if(other == null) {
                return false;
            }

            var difference = (uint) array.Length ^ (uint) other.Length;
            for(var i = 0; i < array.Length && i < other.Length; i++) {
                difference |= (uint) (array[i] ^ other[i]);
            }

            return difference == 0;
        }

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
        public static bool StructureEquals<T>(this T[]? array, T[]? other) {
            array = Guard.ArgumentNotNull(array, nameof(array));
            return other != null && ((IStructuralEquatable) array).Equals(other, EqualityComparer<T>.Default);
        }

        /// <summary>
        ///     Hashes the specified byte array with the specified hash algorithm.
        /// </summary>
        /// <param name="bytes">
        ///     The bytes to hash.
        /// </param>
        /// <param name="hashAlgorithm">
        ///     The hash algorithm.
        /// </param>
        /// <returns>
        ///     The hexadecimal representation of the hashed byte array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="bytes" /> or <paramref name="hashAlgorithm" /> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="bytes" /> is empty.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToHashText(this byte[]? bytes, HashAlgorithm hashAlgorithm) {
            Guard.ArgumentNotNullOrEmpty(bytes, nameof(bytes));
            Guard.ArgumentNotNull(hashAlgorithm, nameof(hashAlgorithm));
            return hashAlgorithm.ComputeHash(bytes).ToHex();
        }
    }
}
