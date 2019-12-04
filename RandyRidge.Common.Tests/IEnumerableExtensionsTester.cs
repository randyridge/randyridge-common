using System;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public abstract class IEnumerableExtensionsTester {
        public sealed class ForEach : IEnumerableExtensionsTester {
            [Fact]
            public static void executes_supplied_action() {
                var total = 0;
                CommonTestValues.TestEnumerable.ForEach(x => total += x);
                total.ShouldBe(6);
            }

            [Fact]
            public static void throws_on_null_action() => Should.Throw<ArgumentNullException>(() => CommonTestValues.TestEnumerable.ForEach(null));

            [Fact]
            public static void throws_on_null_enumerable() => Should.Throw<ArgumentNullException>(() => CommonTestValues.NullEnumerable.ForEach(x => {
            }));
        }

        public sealed class HasValue : IEnumerableExtensionsTester {
            [Fact]
            public static void returns_false_on_empty() => CommonTestValues.EmptyEnumerable.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_false_on_null() => CommonTestValues.NullEnumerable.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_populated_collection() => CommonTestValues.TestEnumerable.HasValue().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_populated_collection_with_only_null_entry() => CommonTestValues.TestEnumerable.HasValue().ShouldBeTrue();
        }

        public sealed class IsNullOrEmpty : IEnumerableExtensionsTester {
            [Fact]
            public static void returns_false_on_populated_collection() => CommonTestValues.TestEnumerable.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_empty() => CommonTestValues.EmptyEnumerable.IsNullOrEmpty().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_null() => CommonTestValues.NullEnumerable.IsNullOrEmpty().ShouldBeTrue();
        }
    }
}
