﻿using System;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class GuardTester {
        private const string Arg = "arg";

        public static class ArgumentNotNullOrEmpty {
            [Fact]
            public static void returns_the_argument() => Guard.ArgumentNotNullOrEmpty(TestValues.TestString, Arg).ShouldBe(TestValues.TestString);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNullOrEmpty(TestValues.TestString, Arg));

            [Fact]
            public static void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(TestValues.EmptyString, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(TestValues.NullString, Arg));
        }

        public static class ArgumentNotNullOrEmptyWithCollection {
            [Fact]
            public static void returns_the_argument() => Guard.ArgumentNotNullOrEmpty(TestValues.TestArray, Arg).ShouldBe(TestValues.TestArray);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNullOrEmpty(TestValues.TestArray, Arg));

            [Fact]
            public static void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(TestValues.EmptyArray, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(TestValues.NullArray, Arg));
        }

        public static class ArgumentNotNullOrWhiteSpace {
            [Fact]
            public static void returns_the_argument() => Guard.ArgumentNotNullOrWhiteSpace(TestValues.TestString, Arg).ShouldBe(TestValues.TestString);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNullOrWhiteSpace(TestValues.TestString, Arg));

            [Fact]
            public static void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(TestValues.EmptyString, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNullOrWhiteSpace(TestValues.NullString, Arg));

            [Fact]
            public static void should_throw_on_whitespace() => Should.Throw<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(TestValues.WhitespaceString, Arg));
        }

        public static class ArgumentNotNullWithClass {
            [Fact]
            public static void returns_the_argument() => Guard.ArgumentNotNull(TestValues.TestString, Arg).ShouldBe(TestValues.TestString);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNull(TestValues.TestString, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNull(TestValues.NullString, Arg));
        }

        public static class ArgumentNotNullWithStruct {
            [Fact]
            // ReSharper disable once PossibleInvalidOperationException
            public static void returns_the_argument() => Guard.ArgumentNotNull(TestValues.TestNullableInt, Arg).ShouldBe(TestValues.TestNullableInt!.Value);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.ArgumentNotNull(TestValues.TestNullableInt, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.ArgumentNotNull(TestValues.NullNullableInt, Arg));
        }

        public static class MinimumExclusiveDouble {
            [Fact]
            public static void returns_the_argument() => Guard.MinimumExclusive(1.0, 0.0, Arg).ShouldBe(1.0);

            [Fact]
            public static void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.MinimumExclusive(1.0, 0.0, Arg));

            [Fact]
            public static void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumExclusive(0.0, 1.0, Arg));

            [Fact]
            public static void should_throw_on_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumExclusive(0.0, 0.0, Arg));
        }

        public static class MinimumExclusiveInt {
            [Fact]
            public static void returns_the_argument() => Guard.MinimumExclusive(1, 0, Arg).ShouldBe(1);

            [Fact]
            public static void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.MinimumExclusive(1, 0, Arg));

            [Fact]
            public static void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumExclusive(0, 1, Arg));

            [Fact]
            public static void should_throw_on_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumExclusive(0, 0, Arg));
        }

        public sealed class MinimumInclusiveDouble {
            [Fact]
            public static void returns_the_argument() => Guard.MinimumInclusive(1.0, 0.0, Arg).ShouldBe(1.0);

            [Fact]
            public static void should_not_throw_on_minimum() => Should.NotThrow(() => Guard.MinimumInclusive(0.0, 0.0, Arg));

            [Fact]
            public static void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.MinimumInclusive(1.0, 0.0, Arg));

            [Fact]
            public static void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumInclusive(0.0, 1.0, Arg));
        }

        public static class MinimumInclusiveInt {
            [Fact]
            public static void returns_the_argument() => Guard.MinimumInclusive(1, 0, Arg).ShouldBe(1);

            [Fact]
            public static void should_not_throw_on_minimum() => Should.NotThrow(() => Guard.MinimumInclusive(0, 0, Arg));

            [Fact]
            public static void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.MinimumInclusive(1, 0, Arg));

            [Fact]
            public static void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.MinimumInclusive(0, 1, Arg));
        }

        public static class RangeInclusiveDouble {
            [Fact]
            public static void returns_the_argument() => Guard.RangeInclusive(1.0, 0.0, 42.0, Arg).ShouldBe(1.0);

            [Fact]
            public static void should_not_throw_on_maximum() => Should.NotThrow(() => Guard.RangeInclusive(42.0, 0.0, 42.0, Arg));

            [Fact]
            public static void should_not_throw_on_minimum() => Should.NotThrow(() => Guard.RangeInclusive(0.0, 0.0, 42.0, Arg));

            [Fact]
            public static void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.RangeInclusive(1.0, 0.0, 42.0, Arg));

            [Fact]
            public static void should_throw_on_greater_than_maximum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.RangeInclusive(100.0, 1.0, 42.0, Arg));

            [Fact]
            public static void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.RangeInclusive(0.0, 1.0, 42.0, Arg));
        }

        public static class RangeInclusiveInt {
            [Fact]
            public static void returns_the_argument() => Guard.RangeInclusive(1, 0, 42, Arg).ShouldBe(1);

            [Fact]
            public static void should_not_throw_on_maximum() => Should.NotThrow(() => Guard.RangeInclusive(42, 0, 42, Arg));

            [Fact]
            public static void should_not_throw_on_minimum() => Should.NotThrow(() => Guard.RangeInclusive(0, 0, 42, Arg));

            [Fact]
            public static void should_not_throw_on_valid_range() => Should.NotThrow(() => Guard.RangeInclusive(1, 0, 42, Arg));

            [Fact]
            public static void should_throw_on_greater_than_maximum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.RangeInclusive(100, 1, 42, Arg));

            [Fact]
            public static void should_throw_on_less_than_minimum() => Should.Throw<ArgumentOutOfRangeException>(() => Guard.RangeInclusive(0, 1, 42, Arg));
        }
    }
}
