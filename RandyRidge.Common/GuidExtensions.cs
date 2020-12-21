using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace RandyRidge.Common {
	/// <summary>
	///   Provides common <see cref="Guid" /> extensions.
	/// </summary>
	public static class GuidExtensions {
		private const string DigitOnlyFormatSpecifier = "N";

		/// <summary>
		///   Formats the <see cref="Guid" /> without dashes.
		/// </summary>
		/// <param name="g">
		///   The <see cref="Guid" /> to format.
		/// </param>
		/// <returns>
		///   The string in "N" format.
		/// </returns>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string ToStringWithDigitsOnly(this Guid g) => g.ToString(DigitOnlyFormatSpecifier, CultureInfo.InvariantCulture);
	}
}
