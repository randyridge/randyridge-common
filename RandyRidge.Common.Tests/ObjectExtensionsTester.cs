using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class ObjectExtensionsTester {
        public static class HasValue {
            [Fact]
            public static void returns_false_on_null() => TestValues.NullObject.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_non_null() => TestValues.TestObject.HasValue().ShouldBeTrue();
        }

        public static class IsNull {
            [Fact]
            public static void returns_false_on_non_null() => TestValues.TestObject.IsNull().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_null() => TestValues.NullObject.IsNull().ShouldBeTrue();
        }
    }
}
