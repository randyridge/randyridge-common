using System;
using System.Collections.Generic;
using System.Reflection;
using Shouldly;
using Xunit;

namespace RandyRidge.Common.Reflection {
	public abstract class TypeExtensionsTester {
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

		public sealed class IsClosedGenericType : TypeExtensionsTester {
			[Fact]
			public void returns_false_on_non_generic_type() {
				typeof(string).IsClosedGenericType().ShouldBeFalse();
			}

			[Fact]
			public void returns_false_on_open_generic_type() {
				typeof(IEnumerable<>).IsClosedGenericType().ShouldBeFalse();
			}

			[Fact]
			public void returns_true_on_closed_generic_type() {
				typeof(IEnumerable<int>).IsClosedGenericType().ShouldBeTrue();
			}

			[Fact]
			public void throws_on_null_type() {
				Should.Throw<ArgumentNullException>(() => TypeExtensions.IsClosedGenericType(null!));
			}
		}

		public sealed class IsClosedTypeOf {
			[Fact]
			public void returns_false_on_not_being_closed_type_of() {
				typeof(int).IsClosedTypeOf(typeof(IEnumerable<>)).ShouldBeFalse();
			}

			[Fact]
			public void returns_true_on_closed_type_of() {
				typeof(IEnumerable<int>).IsClosedTypeOf(typeof(IEnumerable<>)).ShouldBeTrue();
			}

			[Fact]
			public void throws_on_non_open_generic_type() {
				Should.Throw<ArgumentException>(() => typeof(string).IsClosedTypeOf(typeof(string)));
			}

			[Fact]
			public void throws_on_null_open_generic_type() {
				Should.Throw<ArgumentNullException>(() => typeof(string).IsClosedTypeOf(null!));
			}

			[Fact]
			public void throws_on_null_type() {
				Should.Throw<ArgumentNullException>(() => TypeExtensions.IsClosedTypeOf(null!, null!));
			}
		}

		public sealed class IsOpenGenericType {
			[Fact]
			public void returns_false_on_closed_generic_type() {
				typeof(IEnumerable<int>).IsOpenGenericType().ShouldBeFalse();
			}

			[Fact]
			public void returns_false_on_non_generic_type() {
				typeof(string).IsOpenGenericType().ShouldBeFalse();
			}

			[Fact]
			public void returns_true_on_open_generic_type() {
				typeof(IEnumerable<>).IsOpenGenericType().ShouldBeTrue();
			}

			[Fact]
			public void throws_on_null_type() {
				Should.Throw<ArgumentNullException>(() => TypeExtensions.IsOpenGenericType(null!));
			}
		}

		public sealed class TypesAssignableFrom {
			[Fact]
			public void returns_assignable_types() {
				var result = typeof(StubsForReflection).TypesAssignableFrom().Materialize();
				result.ShouldNotBeNull();
				result.Count.ShouldBe(2);
			}

			[Fact]
			public void throws_on_null_type() {
				Should.Throw<ArgumentNullException>(() => TypeExtensions.TypesAssignableFrom(null!));
			}
		}

		private static bool ReturnsStringPredicate(PropertyInfo propertyInfo) => propertyInfo.PropertyType == typeof(string);
	}
}
