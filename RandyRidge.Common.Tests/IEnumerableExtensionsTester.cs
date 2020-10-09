using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public static class IEnumerableExtensionsTester {
	    private static readonly IEnumerable<string> EmptyEnumerable = new string[0];
        private static readonly IEnumerable<string>? NullEnumerable = null;
        private static readonly IEnumerable<string> PopulatedEnumerable = new[] {"1", "2", "3"};
        private static readonly IEnumerable<string> PopulatedWithSomeNullsEnumerable = new[] {
	        "1", null, "2", null, "3", null
        };

        public static class ForEach {
            [Fact]
            public static void executes_supplied_action() {
                var total = 0;
                TestValues.TestEnumerable.ForEach(x => total += x);
                total.ShouldBe(6);
            }

            [Fact]
            public static void throws_on_null_action() => Should.Throw<ArgumentNullException>(() => TestValues.TestEnumerable.ForEach(null!));

            [Fact]
            public static void throws_on_null_enumerable() => Should.Throw<ArgumentNullException>(() => TestValues.NullEnumerable.ForEach(x => {
                var _ = x;
            }));
        }

        public static class ForEachAsync {
            [Fact]
            public static async Task executes_supplied_action() {
                var list = new List<int>();
                await PopulatedEnumerable.ForEachAsync(3, x => {
                    list.Add(int.Parse(x, CultureInfo.InvariantCulture));
                    return Task.CompletedTask;
                }).ForAwait();
                list.Sum().ShouldBe(6);
            }

            [Fact]
            public static Task throws_on_null_action() {
                return Should.ThrowAsync<ArgumentNullException>(() => PopulatedEnumerable.ForEachAsync(1, null!));
            }

            [Fact]
            public static Task throws_on_null_enumerable() {
                return Should.ThrowAsync<ArgumentNullException>(() => NullEnumerable!.ForEachAsync(3, x => Task.CompletedTask));
            }
        }

        public static class HasValue {
            [Fact]
            public static void returns_false_on_empty() => TestValues.EmptyEnumerable.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_false_on_null() => TestValues.NullEnumerable.HasValue().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_populated_collection() => TestValues.TestEnumerable.HasValue().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_populated_collection_with_only_null_entry() => TestValues.TestEnumerable.HasValue().ShouldBeTrue();
        }

        public static class IsNullOrEmpty {
            [Fact]
            public static void returns_false_on_populated_collection() => TestValues.TestEnumerable.IsNullOrEmpty().ShouldBeFalse();

            [Fact]
            public static void returns_true_on_empty() => TestValues.EmptyEnumerable.IsNullOrEmpty().ShouldBeTrue();

            [Fact]
            public static void returns_true_on_null() => TestValues.NullEnumerable.IsNullOrEmpty().ShouldBeTrue();
        }

        public static class ToHex {
            [Fact]
            public static void returns_correct_value() => TestValues.TestByteArray.ToHex().ShouldBe("00ff80");

            [Fact]
            public static void throws_on_null_bytes() => Should.Throw<ArgumentNullException>(() => TestValues.NullByteArray.ForEach(null!));
        }

        public static class WhereNotNull {
	        [Fact]
	        public static void does_not_filter_populated_items() {
		        PopulatedEnumerable.WhereNotNull().ShouldBe(PopulatedEnumerable);
	        }

	        [Fact]
	        public static void filters_out_null_items() {
		        PopulatedWithSomeNullsEnumerable.WhereNotNull().ShouldBe(PopulatedEnumerable);
	        }

	        [Fact]
	        public static void returns_empty_on_null() {
		        NullEnumerable.WhereNotNull().ShouldBe(EmptyEnumerable);
	        }
        }
    }
}
