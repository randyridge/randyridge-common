using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public abstract class ObjectExtensionsTester {
        public sealed class HasValue : ObjectExtensionsTester {
            [Fact]
            public void returns_false_on_null() => CommonTestValues.NullObject.HasValue().ShouldBeFalse();

            [Fact]
            public void returns_true_on_non_null() => CommonTestValues.TestObject.HasValue().ShouldBeTrue();
        }

        public sealed class IsNull : ObjectExtensionsTester {
            [Fact]
            public void returns_false_on_non_null() => CommonTestValues.TestObject.IsNull().ShouldBeFalse();

            [Fact]
            public void returns_true_on_null() => CommonTestValues.NullObject.IsNull().ShouldBeTrue();
        }
    }
}
