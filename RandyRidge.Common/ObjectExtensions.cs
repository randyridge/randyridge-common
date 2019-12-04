using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace RandyRidge.Common {
    /// <summary>
    ///     Provides common <see cref="object" /> extensions.
    /// </summary>
    public static class ObjectExtensions {
        /// <summary>
        ///     Returns whether the specified object is not null.
        /// </summary>
        /// <param name="o">
        ///     The object to test.
        /// </param>
        /// <returns>
        ///     true if the object is not null; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasValue([NotNullWhen(true)] this object? o) => !(o is null);

        /// <summary>
        ///     Returns whether the specified object is null.
        /// </summary>
        /// <param name="o">
        ///     The object to test.
        /// </param>
        /// <returns>
        ///     true if the object is null; otherwise, false.
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNull([NotNullWhen(false)] this object? o) => o is null;
    }
}
