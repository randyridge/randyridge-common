using System;
using System.IO;
using IoPath = System.IO.Path;

namespace RandyRidge.Common.IO {
	/// <summary>
	///   Creates a random file in temporary space.
	/// </summary>
	public sealed class RandomFile : IDisposable {
		private bool isDisposed;

		/// <summary>
		///   Creates a temporary file with the specified extension.
		/// </summary>
		/// <param name="extension">
		///   The extension to give the file.
		/// </param>
		public RandomFile(string extension) {
			extension = Guard.NotNullOrWhiteSpace(extension, nameof(extension));
			Path = IoPath.Join(IoPath.GetTempPath(), $"{Guid.NewGuid().ToStringWithDigitsOnly()}.{extension.ReplaceInvariant(".", "")}");
			using var _ = File.Create(Path);
		}

		/// <summary>
		///   The path to the temporary file.
		/// </summary>
		public string Path { get; }

		/// <inheritdoc />
		public void Dispose() {
			Dispose(true);
		}

		private void Dispose(bool disposing) {
			if(isDisposed) {
				return;
			}

			if(disposing) {
				File.Delete(Path);
			}

			isDisposed = true;
		}
	}
}
