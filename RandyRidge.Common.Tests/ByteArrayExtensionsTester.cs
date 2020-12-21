using System;
using System.Security.Cryptography;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
	public static class ByteArrayExtensionsTester {
		public static class LinearEquals {
			[Fact]
			public static void returns_false_when_compared_to_different_length_array() => new byte[] {1, 2}.LinearEquals(new byte[] {1}).ShouldBeFalse();

			[Fact]
			public static void returns_false_when_compared_to_different_values() => new byte[] {1, 2}.LinearEquals(new byte[] {3, 4}).ShouldBeFalse();

			[Fact]
			public static void returns_false_when_compared_to_null() => new byte[] {1}.LinearEquals(null).ShouldBeFalse();

			[Fact]
			public static void returns_true_when_compared_to_different_instance_with_same_values() => new byte[] {1}.LinearEquals(new byte[] {1}).ShouldBeTrue();

			[Fact]
			public static void returns_true_when_compared_to_same_instance() {
				var x = new byte[] {1};
				x.LinearEquals(x).ShouldBeTrue();
			}

			[Fact]
			public static void throws_on_null_array() => Should.Throw<ArgumentNullException>(() => ByteArrayExtensions.LinearEquals(null, new byte[] {1}));
		}

		public static class ToHash {
			private static readonly HashAlgorithm HashAlgorithm = HashAlgorithm.Create("MD5")!;

			[Fact]
			public static void returns_correct_value() => "test".ToUtfBytes().ToHash(HashAlgorithm).ShouldBe(TestValues.TestMd5Hash);

			[Fact]
			public static void throws_on_empty_bytes() => Should.Throw<ArgumentException>(() => TestValues.EmptyByteArray.ToHash(HashAlgorithm));

			[Fact]
			public static void throws_on_null_bytes() => Should.Throw<ArgumentNullException>(() => TestValues.NullByteArray.ToHash(HashAlgorithm));
		}

		public static class ToHashText {
			private static readonly HashAlgorithm HashAlgorithm = HashAlgorithm.Create("MD5")!;

			[Fact]
			public static void returns_correct_value() => "test".ToUtfBytes().ToHashText(HashAlgorithm).ShouldBe(TestValues.TestMd5HashHex);

			[Fact]
			public static void throws_on_empty_bytes() => Should.Throw<ArgumentException>(() => TestValues.EmptyByteArray.ToHashText(HashAlgorithm));

			[Fact]
			public static void throws_on_null_bytes() => Should.Throw<ArgumentNullException>(() => TestValues.NullByteArray.ToHashText(HashAlgorithm));
		}
	}
}
