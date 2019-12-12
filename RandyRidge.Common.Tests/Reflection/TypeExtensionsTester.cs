using System;
using Shouldly;
using Xunit;

namespace RandyRidge.Common.Reflection {
    public static class TypeExtensionsTester {
        private static readonly Type Type = typeof(StubsForReflection);

        public sealed class GetPublicStaticProperty {
            [Fact]
            public void returns_null_on_miss() => Type.GetPublicStaticProperty("blah").ShouldBeNull();

            [Fact]
            public void returns_property_info() => Type.GetPublicStaticProperty("Property").ShouldNotBeNull();

            [Fact]
            public void throws_on_empty_name() => Should.Throw<ArgumentException>(() => Type.GetPublicStaticProperty(string.Empty));

            [Fact]
            public void throws_on_null_name() => Should.Throw<ArgumentNullException>(() => Type.GetPublicStaticProperty(null!));

            [Fact]
            public void throws_on_null_type() => Should.Throw<ArgumentNullException>(() => TypeExtensions.GetPublicStaticProperty(null!, "name"));

            [Fact]
            public void throws_on_whitespace_name() => Should.Throw<ArgumentException>(() => Type.GetPublicStaticProperty("  "));
        }
    }
}
