using System;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public abstract class GuardTester {
        public sealed class ArgumentNotNullWithClass {
            [Fact]
            public void returns_the_argument() {
                Guard.ArgumentNotNull("hi", "argument").ShouldBe("hi");
            }

            [Fact]
            public void should_not_throw_on_instance() {
                Should.NotThrow(() => Guard.ArgumentNotNull(string.Empty, "argument"));
            }

            [Fact]
            public void should_throw_on_null() {
                Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNull<object>(null, "argument"));
            }
        }

        public sealed class ArgumentNotNullWithStruct {
            [Fact]
            public void returns_the_argument() {
                int? i = 0;
                Guard.ArgumentNotNull(i, "argument").ShouldBe(0);
            }

            [Fact]
            public void should_not_throw_on_instance() {
                int? i = 0;
                Should.NotThrow(() => Guard.ArgumentNotNull(i, "argument"));
            }

            [Fact]
            public void should_throw_on_null() {
                int? i = null;
                Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNull(i, "argument"));
            }
        }
    }
}
