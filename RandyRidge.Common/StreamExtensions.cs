using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace RandyRidge.Common {
	/// <summary>
	///   Provides extension methods for <see cref="Stream" />.
	/// </summary>
	public static class StreamExtensions {
		/// <summary>
		///   If the stream is seekable, reset to position 0.
		/// </summary>
		/// <param name="stream">
		///   The stream to reset.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///   Thrown if <paramref name="stream" /> is null.
		/// </exception>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Reset(this Stream stream) {
			stream = Guard.NotNullOrEmpty(stream, nameof(stream));
			if(stream.CanSeek) {
				stream.Position = 0;
			}
		}

		/// <summary>
		///   Hashes the specified stream with the specified hash algorithm.
		/// </summary>
		/// <param name="stream">
		///   The stream to hash.
		/// </param>
		/// <param name="hashAlgorithm">
		///   The hash algorithm.
		/// </param>
		/// <returns>
		///   The hashed byte array.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///   Thrown if <paramref name="stream" /> or <paramref name="hashAlgorithm" /> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		///   Thrown if <paramref name="stream" /> is empty.
		/// </exception>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[] ToHash(this Stream stream, HashAlgorithm hashAlgorithm) {
			stream = Guard.NotNullOrEmpty(stream, nameof(stream));
			hashAlgorithm = Guard.NotNull(hashAlgorithm, nameof(hashAlgorithm));
			return hashAlgorithm.ComputeHash(stream);
		}

		/// <summary>
		///   Hashes the specified stream with the specified hash algorithm.
		/// </summary>
		/// <param name="stream">
		///   The bytes to hash.
		/// </param>
		/// <param name="hashAlgorithm">
		///   The hash algorithm.
		/// </param>
		/// <returns>
		///   The hexadecimal string representation of the hashed byte array.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///   Thrown if <paramref name="stream" /> or <paramref name="hashAlgorithm" /> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		///   Thrown if <paramref name="stream" /> is empty.
		/// </exception>
		[DebuggerHidden]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string ToHashText(this Stream stream, HashAlgorithm hashAlgorithm) {
			stream = Guard.NotNullOrEmpty(stream, nameof(stream));
			hashAlgorithm = Guard.NotNull(hashAlgorithm, nameof(hashAlgorithm));
			return ToHash(stream, hashAlgorithm).ToHex();
		}
	}
}
