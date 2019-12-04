using System;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public abstract class GuardTester {
        private const string Arg = "arg";

        public sealed class ArgumentNotNullOrEmpty : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.ArgumentNotNullOrEmpty(CommonTestValues.TestString, Arg).ShouldBe(CommonTestValues.TestString);

            [Fact]
            public void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNullOrEmpty(CommonTestValues.TestString, Arg));

            [Fact]
            public void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(CommonTestValues.EmptyString, Arg));

            [Fact]
            public void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(CommonTestValues.NullString, Arg));
        }

        public sealed class ArgumentNotNullOrWhiteSpace : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.ArgumentNotNullOrWhiteSpace(CommonTestValues.TestString, Arg).ShouldBe(CommonTestValues.TestString);

            [Fact]
            public void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNullOrWhiteSpace(CommonTestValues.TestString, Arg));

            [Fact]
            public void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(CommonTestValues.EmptyString, Arg));

            [Fact]
            public void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNullOrWhiteSpace(CommonTestValues.NullString, Arg));

            [Fact]
            public void should_throw_on_whitespace() => Should.Throw<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(CommonTestValues.WhitespaceString, Arg));
        }

        public sealed class ArgumentNotNullWithClass : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.ArgumentNotNull(CommonTestValues.TestString, Arg).ShouldBe(CommonTestValues.TestString);

            [Fact]
            public void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNull(CommonTestValues.TestString, Arg));

            [Fact]
            public void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNull(CommonTestValues.NullString, Arg));
        }

        public sealed class ArgumentNotNullWithStruct : GuardTester {
            [Fact]
            // ReSharper disable once PossibleInvalidOperationException
            public void returns_the_argument() => Guard.ArgumentNotNull(CommonTestValues.TestNullableInt, Arg).ShouldBe(CommonTestValues.TestNullableInt!.Value);

            [Fact]
            public void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNull(CommonTestValues.TestNullableInt, Arg));

            [Fact]
            public void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNull(CommonTestValues.NullNullableInt, Arg));
        }
    }
}
