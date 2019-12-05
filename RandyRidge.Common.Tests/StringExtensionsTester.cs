using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class StringExtensionsTester {
        public static class IsNullOrEmpty {
            [Fact]
            public static void returns_false_on_value() => CommonTestValues.TestString.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public static void returns_false_on_whitespace() => CommonTestValues.WhitespaceString.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_empty() => CommonTestValues.EmptyString.IsNullOrEmpty().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_null() => CommonTestValues.NullString.IsNullOrEmpty().ShouldBeTrue();
        }

        public static class IsNullOrWhiteSpace {
            [Fact]
            public static void returns_false_on_value() => CommonTestValues.TestString.IsNullOrWhiteSpace().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_empty() => CommonTestValues.EmptyString.IsNullOrWhiteSpace().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_null() => CommonTestValues.NullString.IsNullOrWhiteSpace().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_whitespace() => CommonTestValues.WhitespaceString.IsNullOrWhiteSpace().ShouldBeTrue();
        }

        public static class ToUtf8Bytes {
            [Fact]
            public static void returns_correct_value() => "test".ToUtfBytes();
        }
    }
}
