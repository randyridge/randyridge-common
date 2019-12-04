using System;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public abstract class GuardTester {
        private const string ArgumentName = "arg";
        private const string? ClassWithValue = "test";
        private static readonly string? ClassWithoutValue = null;
        private static readonly int? StructWithoutValue = null;
        private static readonly int? StructWithValue = 42;

        public sealed class ArgumentNotNullWithClass : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.ArgumentNotNull(ClassWithValue, ArgumentName).ShouldBe("test");

            [Fact]
            public void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNull(ClassWithValue, ArgumentName));

            [Fact]
            public void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNull(ClassWithoutValue, ArgumentName));
        }

        public sealed class ArgumentNotNullWithStruct : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.ArgumentNotNull(StructWithValue, ArgumentName).ShouldBe(42);

            [Fact]
            public void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNull(StructWithValue, ArgumentName));

            [Fact]
            public void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNull(StructWithoutValue, ArgumentName));
        }
    }
}
