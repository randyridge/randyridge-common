using System;
using System.IO;
using System.Security.Cryptography;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
	public abstract class StreamExtensionsTester {
		private static readonly HashAlgorithm Md5HashAlgorithm = MD5.Create();
		private readonly MemoryStream memoryStream;

		protected StreamExtensionsTester() {
			memoryStream = new MemoryStream("test".ToUtfBytes());
		}

		public sealed class Reset : StreamExtensionsTester {
			[Fact]
			public void sets_position_0() {
				memoryStream.Position = 1;
				memoryStream.Reset();
				memoryStream.Position.ShouldBe(0);
			}

			[Fact]
			public void throws_on_null_stream() => Should.Throw<ArgumentNullException>(() => ((Stream) null!).Reset());
		}

		public sealed class ToHash : StreamExtensionsTester {
			[Fact]
			public void hashes() {
				var hashBytes = memoryStream.ToHash(Md5HashAlgorithm);
				hashBytes.ShouldNotBeNull();
				hashBytes.ShouldNotBeEmpty();
			}

			[Fact]
			public void throws_on_null_hash_algorithm() => Should.Throw<ArgumentNullException>(() => memoryStream.ToHash(null!));

			[Fact]
			public void throws_on_null_stream() => Should.Throw<ArgumentNullException>(() => ((Stream) null!).ToHash(Md5HashAlgorithm));
		}

		public sealed class ToHashText : StreamExtensionsTester {
			[Fact]
			public void hashes() {
				var hashBytes = memoryStream.ToHashText(Md5HashAlgorithm);
				hashBytes.ShouldNotBeNull();
				hashBytes.ShouldNotBeEmpty();
			}

			[Fact]
			public void throws_on_null_hash_algorithm() => Should.Throw<ArgumentNullException>(() => memoryStream.ToHashText(null!));

			[Fact]
			public void throws_on_null_stream() => Should.Throw<ArgumentNullException>(() => ((Stream) null!).ToHashText(Md5HashAlgorithm));
		}
	}
}
