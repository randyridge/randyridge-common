using Shouldly;
using Xunit;

namespace RandyRidge.Common {
	public static class ByteExtensionsTester {
		public static class ToHex {
			[Fact]
			public static void returns_correct_value_for_max() => ((byte) 255).ToHex().ShouldBe("ff");

			[Fact]
			public static void returns_correct_value_for_mid() => ((byte) 128).ToHex().ShouldBe("80");

			[Fact]
			public static void returns_correct_value_for_min() => ((byte) 0).ToHex().ShouldBe("00");
		}
	}
}
