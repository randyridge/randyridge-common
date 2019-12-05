using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class ICollectionExtensionsTester {
        public static class HasValue {
            [Fact]
            public static void returns_false_on_empty() => CommonTestValues.EmptyCollection.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_false_on_null() => CommonTestValues.NullCollection.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_populated_collection() => CommonTestValues.TestCollection.HasValue().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_populated_collection_with_only_null_entry() => CommonTestValues.TestCollection.HasValue().ShouldBeTrue();
        }

        public static class IsNullOrEmpty {
            [Fact]
            public static void returns_false_on_populated_collection() => CommonTestValues.TestCollection.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_empty() => CommonTestValues.EmptyCollection.IsNullOrEmpty().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_null() => CommonTestValues.NullCollection.IsNullOrEmpty().ShouldBeTrue();
        }
    }
}
