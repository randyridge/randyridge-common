using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace RandyRidge.Common;

/// <summary>
///   Provides extension methods for byte arrays.
/// </summary>
public static class ByteArrayExtensions {
	/// <summary>
	///   Compares two byte arrays in length-constant time.
	/// </summary>
	/// <remarks>
	///   This comparison method is used to prevent timing attacks.
	/// </remarks>
	/// <param name="array">
	///   An array to compare.
	/// </param>
	/// <param name="other">
	///   The other array to compare.
	/// </param>
	/// <returns>
	///   true if the arrays are equal; otherwise, false.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	///   Thrown if <paramref name="array" /> is null.
	/// </exception>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool LinearEquals(this byte[]? array, byte[]? other) {
		array = Guard.NotNull(array, nameof(array));

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
	///   Hashes the specified byte array with the specified hash algorithm.
	/// </summary>
	/// <param name="bytes">
	///   The bytes to hash.
	/// </param>
	/// <param name="hashAlgorithm">
	///   The hash algorithm.
	/// </param>
	/// <returns>
	///   The hashed byte array.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	///   Thrown if <paramref name="bytes" /> or <paramref name="hashAlgorithm" /> is null.
	/// </exception>
	/// <exception cref="ArgumentException">
	///   Thrown if <paramref name="bytes" /> is empty.
	/// </exception>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] ToHash(this byte[]? bytes, HashAlgorithm hashAlgorithm) {
		bytes = Guard.NotNullOrEmpty(bytes, nameof(bytes));
		hashAlgorithm = Guard.NotNull(hashAlgorithm, nameof(hashAlgorithm));
		return hashAlgorithm.ComputeHash(bytes);
	}

	/// <summary>
	///   Hashes the specified byte array with the specified hash algorithm.
	/// </summary>
	/// <param name="bytes">
	///   The bytes to hash.
	/// </param>
	/// <param name="hashAlgorithm">
	///   The hash algorithm.
	/// </param>
	/// <returns>
	///   The hexadecimal string representation of the hashed byte array.
	/// </returns>
	/// <exception cref="ArgumentNullException">
	///   Thrown if <paramref name="bytes" /> or <paramref name="hashAlgorithm" /> is null.
	/// </exception>
	/// <exception cref="ArgumentException">
	///   Thrown if <paramref name="bytes" /> is empty.
	/// </exception>
	[DebuggerHidden]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToHashText(this byte[]? bytes, HashAlgorithm hashAlgorithm) {
		bytes = Guard.NotNullOrEmpty(bytes, nameof(bytes));
		hashAlgorithm = Guard.NotNull(hashAlgorithm, nameof(hashAlgorithm));
		return ToHash(bytes, hashAlgorithm).ToHex();
	}
}
