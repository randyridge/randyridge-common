using System.Diagnostics;
using System.Runtime.CompilerServices;

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
    }
}
