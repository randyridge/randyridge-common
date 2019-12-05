using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class DoubleExtensionsTester {
        public static class IsAboutEqualTo {
            [Fact]
            public static void returns_false_on_different_values() => 1.0.IsAboutEqualTo(2.0).ShouldBeFalse();

            [Fact]
            public static void returns_false_on_outside_epsilon() => 1.0.IsAboutEqualTo(1.0 + 1E-14).ShouldBeFalse();

            [Fact]
            public static void returns_true_on_same_values() => 1.0.IsAboutEqualTo(1.0).ShouldBeTrue();

            [Fact]
            public static void returns_true_on_within_epsilon() => 1.0.IsAboutEqualTo(1.0 + 1E-16).ShouldBeTrue();
        }
    }
}
