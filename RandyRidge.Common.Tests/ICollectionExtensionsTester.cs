using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class ICollectionExtensionsTester {
        public static class HasValue {
            [Fact]
            public static void returns_false_on_empty() => TestValues.EmptyCollection.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_false_on_null() => TestValues.NullCollection.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_populated_collection() => TestValues.TestCollection.HasValue().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_populated_collection_with_only_null_entry() => TestValues.TestCollection.HasValue().ShouldBeTrue();
        }

        public static class IsNullOrEmpty {
            [Fact]
            public static void returns_false_on_populated_collection() => TestValues.TestCollection.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_empty() => TestValues.EmptyCollection.IsNullOrEmpty().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_null() => TestValues.NullCollection.IsNullOrEmpty().ShouldBeTrue();
        }
    }
}
