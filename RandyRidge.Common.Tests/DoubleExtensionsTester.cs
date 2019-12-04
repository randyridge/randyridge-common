using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public abstract class DoubleExtensionsTester {
        public sealed class IsAboutEqualTo : DoubleExtensionsTester {
            [Fact]
            public void returns_false_on_different_values() => 1.0.IsAboutEqualTo(2.0).ShouldBeFalse();

            [Fact]
            public void returns_false_on_outside_epsilon() => 1.0.IsAboutEqualTo(1.0 + 1E-14).ShouldBeFalse();

            [Fact]
            public void returns_true_on_same_values() => 1.0.IsAboutEqualTo(1.0).ShouldBeTrue();

            [Fact]
            public void returns_true_on_within_epsilon() => 1.0.IsAboutEqualTo(1.0 + 1E-16).ShouldBeTrue();
        }
    }
}
