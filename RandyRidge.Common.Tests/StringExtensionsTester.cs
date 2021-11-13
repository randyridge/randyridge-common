using Shouldly;
using Xunit;

namespace RandyRidge.Common;

public static class StringExtensionsTester {
	public static class IsNullOrEmpty {
		[Fact]
		public static void returns_false_on_value() => TestValues.TestString.IsNullOrEmpty().ShouldBeFalse();

		[Fact]
		public static void returns_false_on_whitespace() => TestValues.WhitespaceString.IsNullOrEmpty().ShouldBeFalse();

		[Fact]
		public static void returns_true_on_empty() => TestValues.EmptyString.IsNullOrEmpty().ShouldBeTrue();

		[Fact]
		public static void returns_true_on_null() => TestValues.NullString.IsNullOrEmpty().ShouldBeTrue();
	}

	public static class IsNullOrWhiteSpace {
		[Fact]
		public static void returns_false_on_value() => TestValues.TestString.IsNullOrWhiteSpace().ShouldBeFalse();

		[Fact]
		public static void returns_true_on_empty() => TestValues.EmptyString.IsNullOrWhiteSpace().ShouldBeTrue();

		[Fact]
		public static void returns_true_on_null() => TestValues.NullString.IsNullOrWhiteSpace().ShouldBeTrue();

		[Fact]
		public static void returns_true_on_whitespace() => TestValues.WhitespaceString.IsNullOrWhiteSpace().ShouldBeTrue();
	}

	public static class ReplaceInvariant {
		[Fact]
		public static void returns_correct_value() => "test".ReplaceInvariant("test", "x").ShouldBe("x");
	}

	public static class ToUtf8Bytes {
		[Fact]
		public static void returns_correct_value() => "test".ToUtfBytes();
	}
}
