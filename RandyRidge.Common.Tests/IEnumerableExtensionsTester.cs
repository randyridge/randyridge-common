using System;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class IEnumerableExtensionsTester {
        public static class ForEach {
            [Fact]
            public static void executes_supplied_action() {
                var total = 0;
                TestValues.TestEnumerable.ForEach(x => total += x);
                total.ShouldBe(6);
            }

            [Fact]
            public static void throws_on_null_action() => Should.Throw<ArgumentNullException>(() => TestValues.TestEnumerable.ForEach(null!));

            [Fact]
            public static void throws_on_null_enumerable() => Should.Throw<ArgumentNullException>(() => TestValues.NullEnumerable.ForEach(x => {
                var _ = x;
            }));
        }

        public static class HasValue {
            [Fact]
            public static void returns_false_on_empty() => TestValues.EmptyEnumerable.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_false_on_null() => TestValues.NullEnumerable.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_populated_collection() => TestValues.TestEnumerable.HasValue().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_populated_collection_with_only_null_entry() => TestValues.TestEnumerable.HasValue().ShouldBeTrue();
        }

        public static class IsNullOrEmpty {
            [Fact]
            public static void returns_false_on_populated_collection() => TestValues.TestEnumerable.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_empty() => TestValues.EmptyEnumerable.IsNullOrEmpty().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_null() => TestValues.NullEnumerable.IsNullOrEmpty().ShouldBeTrue();
        }

        public static class ToHex {
            [Fact]
            public static void returns_correct_value() => TestValues.TestByteArray.ToHex().ShouldBe("00ff80");

            [Fact]
            public static void throws_on_null_bytes() => Should.Throw<ArgumentNullException>(() => TestValues.NullByteArray.ForEach(null!));
        }
    }
}
