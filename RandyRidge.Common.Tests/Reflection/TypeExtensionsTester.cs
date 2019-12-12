using System;
using System.Reflection;
using Shouldly;
using Xunit;

namespace RandyRidge.Common.Reflection {
    public static class TypeExtensionsTester {
        private const string PublicStaticReadonlyPropertyName = "PublicStaticReadonlyProperty1";
        private static readonly Type EmptyStubType = typeof(EmptyStub);
        private static readonly Type ReflectionStubType = typeof(ReflectionStub);

        public sealed class GetPublicStaticProperties {
            [Fact]
            public void returns_empty_on_miss() => EmptyStubType.GetPublicStaticProperties().ShouldBeEmpty();

            [Fact]
            public void returns_property_info() => ReflectionStubType.GetPublicStaticProperties().Length.ShouldBe(2);

            [Fact]
            public void throws_on_null_type() => Should.Throw<ArgumentNullException>(() => TypeExtensions.GetPublicStaticProperties(null!));
        }

        public sealed class GetPublicStaticPropertiesWithPredicate {
            [Fact]
            public void returns_empty_on_miss() => EmptyStubType.GetPublicStaticProperties(ReturnsStringPredicate).ShouldBeEmpty();

            [Fact]
            public void returns_property_info() => ReflectionStubType.GetPublicStaticProperties(ReturnsStringPredicate).Length.ShouldBe(2);

            [Fact]
            public void throws_on_null_type() => Should.Throw<ArgumentNullException>(() => TypeExtensions.GetPublicStaticProperties(null!, ReturnsStringPredicate));
        }

        public sealed class GetPublicStaticProperty {
            [Fact]
            public void returns_null_on_miss() => EmptyStubType.GetPublicStaticProperty(PublicStaticReadonlyPropertyName).ShouldBeNull();

            [Fact]
            public void returns_property_info() => ReflectionStubType.GetPublicStaticProperty(PublicStaticReadonlyPropertyName).ShouldNotBeNull();

            [Fact]
            public void throws_on_empty_name() => Should.Throw<ArgumentException>(() => ReflectionStubType.GetPublicStaticProperty(string.Empty));

            [Fact]
            public void throws_on_null_name() => Should.Throw<ArgumentNullException>(() => ReflectionStubType.GetPublicStaticProperty(null!));

            [Fact]
            public void throws_on_null_type() => Should.Throw<ArgumentNullException>(() => TypeExtensions.GetPublicStaticProperty(null!, "name"));

            [Fact]
            public void throws_on_whitespace_name() => Should.Throw<ArgumentException>(() => ReflectionStubType.GetPublicStaticProperty("  "));
        }

        private static bool ReturnsStringPredicate(PropertyInfo propertyInfo) => propertyInfo.PropertyType == typeof(string);
    }
}
