using System;
using System.Security.Cryptography;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class ByteArrayExtensionsTester {
        public static class LinearEquals {
            [Fact]
            public static void returns_false_when_compared_to_different_length_array() => ByteArrayExtensions.LinearEquals(new byte[] {1, 2}, new byte[] {1}).ShouldBeFalse();

            [Fact]
            public static void returns_false_when_compared_to_different_values() => ByteArrayExtensions.LinearEquals(new byte[] {1, 2}, new byte[] {3, 4}).ShouldBeFalse();

            [Fact]
            public static void returns_false_when_compared_to_null() => ByteArrayExtensions.LinearEquals(new byte[] {1}, null).ShouldBeFalse();

            [Fact]
            public static void returns_true_when_compared_to_different_instance_with_same_values() => ByteArrayExtensions.LinearEquals(new byte[] {1}, new byte[] {1}).ShouldBeTrue();

            [Fact]
            public static void returns_true_when_compared_to_same_instance() {
                var x = new byte[] {1};
                ByteArrayExtensions.LinearEquals(x, x).ShouldBeTrue();
            }

            [Fact]
            public static void throws_on_null_array() => Should.Throw<ArgumentNullException>(() => ByteArrayExtensions.LinearEquals(null, new byte[] {1}));
        }

        public static class ToHex {
            private static readonly HashAlgorithm HashAlgorithm = HashAlgorithm.Create("MD5");

            [Fact]
            public static void returns_correct_value() => ByteArrayExtensions.ToHashText("test".ToUtfBytes(), HashAlgorithm).ShouldBe(TestValues.TestMd5Hash);

            [Fact]
            public static void throws_on_empty_bytes() => Should.Throw<ArgumentException>(() => ByteArrayExtensions.ToHashText(TestValues.EmptyByteArray, HashAlgorithm));

            [Fact]
            public static void throws_on_null_bytes() => Should.Throw<ArgumentNullException>(() => ByteArrayExtensions.ToHashText(TestValues.NullByteArray, HashAlgorithm));
        }
    }
}
