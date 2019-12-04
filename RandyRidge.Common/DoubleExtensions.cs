using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RandyRidge.Common {
    /// <summary>
    ///     Provides common <see cref="double" /> extensions.
    /// </summary>
    public static class DoubleExtensions {
        /// <summary>
        ///     Tests whether the specified value is about equal to the specified target, within an epsilon.
        /// </summary>
        /// <param name="value">
        ///     The value to test.
        /// </param>
        /// <param name="target">
        ///     The target for comparison.
        /// </param>
        /// <remarks>
        ///     This uses an epsilon of 1E-15.
        /// </remarks>
        /// <returns>
        ///     true if the values are within an epsilon; otherwise, false;
        /// </returns>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAboutEqualTo(this double value, double target) {
            var epsilon = Math.Max(Math.Abs(value), Math.Abs(target)) * 1E-15;
            return Math.Abs(value - target) <= epsilon;
        }
    }
}
