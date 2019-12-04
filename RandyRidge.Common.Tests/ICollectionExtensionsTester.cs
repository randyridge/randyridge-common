using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public abstract class ICollectionExtensionsTester {
        public sealed class HasValue : ICollectionExtensionsTester {
            [Fact]
            public static void returns_false_on_empty() => CommonTestValues.EmptyArray.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_false_on_null() => CommonTestValues.NullArray.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_populated_collection() => CommonTestValues.TestArray.HasValue().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_populated_collection_with_only_null_entry() => CommonTestValues.TestArray.HasValue().ShouldBeTrue();
        }

        public sealed class IsNullOrEmpty : ICollectionExtensionsTester {
            [Fact]
            public static void returns_false_on_populated_collection() => CommonTestValues.TestArray.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_empty() => CommonTestValues.EmptyArray.IsNullOrEmpty().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_null() => CommonTestValues.NullArray.IsNullOrEmpty().ShouldBeTrue();
        }
    }
}
