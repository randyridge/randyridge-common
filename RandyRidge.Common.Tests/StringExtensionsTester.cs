using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public abstract class StringExtensionsTester {
        public sealed class IsNullOrEmpty : StringExtensionsTester {
            [Fact]
            public void returns_false_on_value() => CommonTestValues.TestString.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public void returns_false_on_whitespace() => CommonTestValues.WhitespaceString.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public void returns_true_on_empty() => CommonTestValues.EmptyString.IsNullOrEmpty().ShouldBeTrue();

            [Fact]
            public void returns_true_on_null() => CommonTestValues.NullString.IsNullOrEmpty().ShouldBeTrue();
        }

        public sealed class IsNullOrWhiteSpace : StringExtensionsTester {
            [Fact]
            public void returns_false_on_value() => CommonTestValues.TestString.IsNullOrWhiteSpace().ShouldBeFalse();

            [Fact]
            public void returns_true_on_empty() => CommonTestValues.EmptyString.IsNullOrWhiteSpace().ShouldBeTrue();

            [Fact]
            public void returns_true_on_null() => CommonTestValues.NullString.IsNullOrWhiteSpace().ShouldBeTrue();

            [Fact]
            public void returns_true_on_whitespace() => CommonTestValues.WhitespaceString.IsNullOrWhiteSpace().ShouldBeTrue();
        }
    }
}
