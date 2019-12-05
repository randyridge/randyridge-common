using System;
using System.Security.Cryptography;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class ArrayExtensionsTester {
        public static class HasValue {
            [Fact]
            public static void returns_false_on_empty() => CommonTestValues.EmptyArray.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_false_on_null() => CommonTestValues.NullArray.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_populated_collection() => CommonTestValues.TestArray.HasValue().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_populated_collection_with_only_null_entry() => CommonTestValues.TestArray.HasValue().ShouldBeTrue();
        }

        public static class IsNullOrEmpty {
            [Fact]
            public static void returns_false_on_populated_collection() => CommonTestValues.TestArray.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_empty() => CommonTestValues.EmptyArray.IsNullOrEmpty().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_null() => CommonTestValues.NullArray.IsNullOrEmpty().ShouldBeTrue();
        }

        public static class LinearEquals {
            [Fact]
            public static void returns_false_when_compared_to_different_length_array() => ArrayExtensions.LinearEquals(new byte[] {1, 2}, new byte[] {1}).ShouldBeFalse();

            [Fact]
            public static void returns_false_when_compared_to_different_values() => ArrayExtensions.LinearEquals(new byte[] {1, 2}, new byte[] {3, 4}).ShouldBeFalse();

            [Fact]
            public static void returns_false_when_compared_to_null() => ArrayExtensions.LinearEquals(new byte[] {1}, null).ShouldBeFalse();

            [Fact]
            public static void returns_true_when_compared_to_different_instance_with_same_values() => ArrayExtensions.LinearEquals(new byte[] {1}, new byte[] {1}).ShouldBeTrue();

            [Fact]
            public static void returns_true_when_compared_to_same_instance() {
                var x = new byte[] {1};
                ArrayExtensions.LinearEquals(x, x).ShouldBeTrue();
            }

            [Fact]
            public static void throws_on_null_array() => Should.Throw<ArgumentNullException>(() => ArrayExtensions.LinearEquals(null, new byte[] {1}));
        }

        public static class StructureEquals {
            [Fact]
            public static void returns_false_when_compared_to_different_length_array() => new byte[] {1}.StructureEquals(new byte[] {1, 2}).ShouldBeFalse();

            [Fact]
            public static void returns_false_when_compared_to_different_values() => new byte[] {1}.StructureEquals(new byte[] {2}).ShouldBeFalse();

            [Fact]
            public static void returns_false_when_compared_to_null() => new byte[] {1}.StructureEquals(null).ShouldBeFalse();

            [Fact]
            public static void returns_true_when_compared_to_different_instance_with_same_values() => new byte[] {1}.StructureEquals(new byte[] {1}).ShouldBeTrue();

            [Fact]
            public static void returns_true_when_compared_to_same_instance() {
                var x = new byte[] {1};
                x.StructureEquals(x).ShouldBeTrue();
            }

            [Fact]
            public static void throws_on_null_array() => Should.Throw<ArgumentNullException>(() => ((byte[]?) null).StructureEquals(new byte[] {1}));
        }

        public static class ToHex {
            private static readonly HashAlgorithm HashAlgorithm = HashAlgorithm.Create("MD5");

            [Fact]
            public static void returns_correct_value() => ArrayExtensions.ToHashText("test".ToUtfBytes(), HashAlgorithm).ShouldBe(CommonTestValues.TestMd5Hash);

            [Fact]
            public static void throws_on_empty_bytes() => Should.Throw<ArgumentException>(() => ArrayExtensions.ToHashText(CommonTestValues.EmptyByteArray, HashAlgorithm));

            [Fact]
            public static void throws_on_null_bytes() => Should.Throw<ArgumentNullException>(() => ArrayExtensions.ToHashText(CommonTestValues.NullByteArray, HashAlgorithm));
        }
    }
}
