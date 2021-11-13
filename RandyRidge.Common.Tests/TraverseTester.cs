using Shouldly;
using Xunit;

namespace RandyRidge.Common;

public abstract class TraverseTester {
	public sealed class Across : TraverseTester {
		[Fact]
		public void throws_on_null_head() {
			Should.Throw<ArgumentNullException>(() => Traverse.Across((object) null!, null!).Materialize());
		}

		[Fact]
		public void throws_on_null_next() {
			Should.Throw<ArgumentNullException>(() => Traverse.Across(new object(), null!).Materialize());
		}

		[Fact]
		public void traverses_the_object() {
			var type = typeof(StubsForReflection);
			var result = Traverse.Across(type, x => x!.BaseType).ToList();
			result.ShouldNotBeNull();
			result.Count.ShouldBe(2);
			result[0].ShouldBe(typeof(StubsForReflection));
			result[1].ShouldBe(typeof(object));
		}
	}
}
