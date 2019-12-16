using System;
using System.Collections.Generic;
using System.IO;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class GuardTester {
        private const string Arg = "arg";

        public static class ArgumentNotNullOrEmpty {
            [Fact]
            public static void returns_the_argument() => Guard.NotNullOrEmpty(TestValues.TestString, Arg).ShouldBe(TestValues.TestString);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.NotNullOrEmpty(TestValues.TestString, Arg));

            [Fact]
            public static void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.NotNullOrEmpty(TestValues.EmptyString, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.NotNullOrEmpty(TestValues.NullString, Arg));
        }

        public static class ArgumentNotNullOrEmptyWithCollection {
            [Fact]
            public static void returns_the_argument() => Guard.NotNullOrEmpty(TestValues.TestArray as ICollection<string>, Arg).ShouldBe(TestValues.TestArray);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.NotNullOrEmpty(TestValues.TestArray as ICollection<string>, Arg));

            [Fact]
            public static void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.NotNullOrEmpty(TestValues.EmptyArray as ICollection<string>, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.NotNullOrEmpty(TestValues.NullArray as ICollection<string>, Arg));
        }

        public static class ArgumentNotNullOrWhiteSpace {
            [Fact]
            public static void returns_the_argument() => Guard.NotNullOrWhiteSpace(TestValues.TestString, Arg).ShouldBe(TestValues.TestString);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.NotNullOrWhiteSpace(TestValues.TestString, Arg));

            [Fact]
            public static void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.NotNullOrWhiteSpace(TestValues.EmptyString, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.NotNullOrWhiteSpace(TestValues.NullString, Arg));

            [Fact]
            public static void should_throw_on_whitespace() => Should.Throw<ArgumentException>(() => Guard.NotNullOrWhiteSpace(TestValues.WhitespaceString, Arg));
        }

        public static class ArgumentNotNullWithClass {
            [Fact]
            public static void returns_the_argument() => Guard.NotNull(TestValues.TestString, Arg).ShouldBe(TestValues.TestString);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.NotNull(TestValues.TestString, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.NotNull(TestValues.NullString, Arg));
        }

        public static class ArgumentNotNullWithStruct {
            [Fact]
            // ReSharper disable once PossibleInvalidOperationException
            public static void returns_the_argument() => Guard.NotNull(TestValues.TestNullableInt, Arg).ShouldBe(TestValues.TestNullableInt!.Value);

            [Fact]
            public static void should_not_throw_on_instance() => Should.NotThrow(() => Guard.NotNull(TestValues.TestNullableInt, Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.NotNull(TestValues.NullNullableInt, Arg));
        }

        public static class FileExists {
            [Fact]
            public static void returns_the_argument() => Guard.FileExists(TestValues.TestFilePath, Arg).ShouldBe(TestValues.TestFilePath);

            [Fact]
            public static void should_throw_on_empty() => Should.Throw<ArgumentException>(() => Guard.FileExists(TestValues.EmptyString, Arg));

            [Fact]
            public static void should_throw_on_missing_file() => Should.Throw<FileNotFoundException>(() => Guard.FileExists("Missing.txt", Arg));

            [Fact]
            public static void should_throw_on_null() => Should.Throw<ArgumentNullException>(() => Guard.FileExists(TestValues.NullString, Arg));

            [Fact]
            public static void should_throw_on_whitespace() => Should.Throw<ArgumentException>(() => Guard.FileExists(TestValues.WhitespaceString, Arg));
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
