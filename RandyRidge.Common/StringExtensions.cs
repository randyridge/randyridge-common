using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace RandyRidge.Common {
    /// <summary>
    ///     Provides common <see cref="string" /> extensions.
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        ///     Reports whether the specified string is null or an empty string.
        /// </summary>
        /// <param name="text">
        ///     The <see cref="string" /> to check.
        /// </param>
        /// <returns>
        ///     true if the string is null or an empty string; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty(this string? text) => string.IsNullOrEmpty(text);

        /// <summary>
        ///     Reports whether the specified string is null, an empty string, or only contains whitespace characters.
        /// </summary>
        /// <param name="text">
        ///     The <see cref="string" /> to check.
        /// </param>
        /// <returns>
        ///     true if the string is null, an empty string, or only contains whitespace characters; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrWhiteSpace(this string? text) => string.IsNullOrWhiteSpace(text);

        /// <summary>
        ///     Converts the specified string to UTF-8 bytes.
        /// </summary>
        /// <param name="text">
        ///     The text to convert.
        /// </param>
        /// <returns>
        ///     The bytes for the UTF-8 encoding of the text.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="text" /> is null.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ToUtfBytes(this string? text) {
            text = Guard.NotNull(text, nameof(text));
            return text.Length == 0 ? Array.Empty<byte>() : Encoding.UTF8.GetBytes(text);
        }

        /// <summary>
        ///     Performs an invariant culture string replace.
        /// </summary>
        /// <param name="text">
        ///     The text to replace.
        /// </param>
        /// <param name="oldValue">
        ///     The old value to replace.
        /// </param>
        /// <param name="newValue">
        ///     The new value to replace with.
        /// </param>
        /// <returns>
        ///     The replaced text.
        /// </returns>
        [DebuggerHidden]
        public static string ReplaceInvariant(this string text, string? oldValue, string? newValue) {
            text = Guard.NotNull(text, nameof(text));
            oldValue = Guard.NotNull(oldValue, nameof(oldValue));
            return text.Replace(oldValue, newValue, StringComparison.InvariantCulture);
        }
    }
}
