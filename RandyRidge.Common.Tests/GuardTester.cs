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

        public sealed class ArgumentNotNullOrEmptyWithCollection : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.ArgumentNotNullOrEmpty(CommonTestValues.TestArray, Arg).ShouldBe(CommonTestValues.TestArray);

            [Fact]
            public void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNullOrEmpty(CommonTestValues.TestArray, Arg));

            [Fact]
            public void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(CommonTestValues.EmptyArray, Arg));

            [Fact]
            public void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(CommonTestValues.NullArray, Arg));
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

        public sealed class MinimumExclusiveDouble : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.MinimumExclusive(1.0, 0.0, Arg).ShouldBe(1.0);

            [Fact]
            public void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.MinimumExclusive(1.0, 0.0, Arg));

            [Fact]
            public void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumExclusive(0.0, 1.0, Arg));

            [Fact]
            public void should_throw_on_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumExclusive(0.0, 0.0, Arg));
        }

        public sealed class MinimumExclusiveInt : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.MinimumExclusive(1, 0, Arg).ShouldBe(1);

            [Fact]
            public void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.MinimumExclusive(1, 0, Arg));

            [Fact]
            public void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumExclusive(0, 1, Arg));

            [Fact]
            public void should_throw_on_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumExclusive(0, 0, Arg));
        }

        public sealed class MinimumInclusiveDouble : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.MinimumInclusive(1.0, 0.0, Arg).ShouldBe(1.0);

            [Fact]
            public void should_not_throw_on_minimum() => Should.NotThrow(() => Guard.MinimumInclusive(0.0, 0.0, Arg));

            [Fact]
            public void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.MinimumInclusive(1.0, 0.0, Arg));

            [Fact]
            public void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumInclusive(0.0, 1.0, Arg));
        }

        public sealed class MinimumInclusiveInt : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.MinimumInclusive(1, 0, Arg).ShouldBe(1);

            [Fact]
            public void should_not_throw_on_minimum() => Should.NotThrow(() => Guard.MinimumInclusive(0, 0, Arg));

            [Fact]
            public void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.MinimumInclusive(1, 0, Arg));

            [Fact]
            public void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumInclusive(0, 1, Arg));
        }

        public sealed class RangeInclusiveDouble : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.RangeInclusive(1.0, 0.0, 42.0, Arg).ShouldBe(1.0);

            [Fact]
            public void should_not_throw_on_maximum() => Should.NotThrow(() => Guard.RangeInclusive(42.0, 0.0, 42.0, Arg));

            [Fact]
            public void should_not_throw_on_minimum() => Should.NotThrow(() => Guard.RangeInclusive(0.0, 0.0, 42.0, Arg));

            [Fact]
            public void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.RangeInclusive(1.0, 0.0, 42.0, Arg));

            [Fact]
            public void should_throw_on_greater_than_maximum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.RangeInclusive(100.0, 1.0, 42.0, Arg));

            [Fact]
            public void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.RangeInclusive(0.0, 1.0, 42.0, Arg));
        }

        public sealed class RangeInclusiveInt : GuardTester {
            [Fact]
            public void returns_the_argument() => Guard.RangeInclusive(1, 0, 42, Arg).ShouldBe(1);

            [Fact]
            public void should_not_throw_on_maximum() => Should.NotThrow(() => Guard.RangeInclusive(42, 0, 42, Arg));

            [Fact]
            public void should_not_throw_on_minimum() => Should.NotThrow(() => Guard.RangeInclusive(0, 0, 42, Arg));

            [Fact]
            public void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.RangeInclusive(1, 0, 42, Arg));

            [Fact]
            public void should_throw_on_greater_than_maximum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.RangeInclusive(100, 1, 42, Arg));

            [Fact]
            public void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.RangeInclusive(0, 1, 42, Arg));
        }
    }
}
