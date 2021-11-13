using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace RandyRidge.Common;

/// <summary>
///   Provides common <see cref="byte" /> extensions.
/// </summary>
public static class ByteExtensions {
	/// <summary>
	///   Converts the specified byte to a hexadecimal string.
	/// </summary>
	/// <param name="b">
	///   The byte to convert.
	/// </param>
	/// <returns>
	///   The hexadecimal representation of the specified byte.
	/// </returns>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToHex(this byte b) => b.ToString("x2", CultureInfo.InvariantCulture);
}
