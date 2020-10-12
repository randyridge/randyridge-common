using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RandyRidge.Common.Reflection {
	/// <summary>
	///   Provides <see cref="Type" /> extensions.
	/// </summary>
	public static class TypeExtensions {
		private const BindingFlags PublicStatic = BindingFlags.Public | BindingFlags.Static;

		/// <summary>
		///   Searches for public, static properties.
		/// </summary>
		/// <param name="type">
		///   The type to search.
		/// </param>
		/// <returns>
		///   An array representing the public, static properties.
		/// </returns>
		public static PropertyInfo[] GetPublicStaticProperties(this Type type) {
			type = Guard.NotNull(type, nameof(type));
			return type.GetProperties(PublicStatic);
		}

		/// <summary>
		///   Searches for public, static properties with the specified predicate.
		/// </summary>
		/// <param name="type">
		///   The type to search.
		/// </param>
		/// <param name="predicate">
		///   The predicate to search with.
		/// </param>
		/// <returns>
		///   An array representing the public, static properties.
		/// </returns>
		public static PropertyInfo[] GetPublicStaticProperties(this Type type, Func<PropertyInfo, bool> predicate) {
			type = Guard.NotNull(type, nameof(type));
			predicate = Guard.NotNull(predicate, nameof(predicate));
			return type.GetPublicStaticProperties().Where(predicate).ToArray();
		}

		/// <summary>
		///   Searches for the public, static property with the specified name.
		/// </summary>
		/// <param name="type">
		///   The type to search.
		/// </param>
		/// <param name="name">
		///   The string containing the name of the property to get.
		/// </param>
		/// <returns>
		///   An object representing the public, static property with the specified name, if found; otherwise, null.
		/// </returns>
		public static PropertyInfo? GetPublicStaticProperty(this Type type, string name) {
			type = Guard.NotNull(type, nameof(type));
			name = Guard.NotNullOrWhiteSpace(name, nameof(name));
			return type.GetProperty(name, PublicStatic);
		}

		/// <summary>
		///   Determines whether the current type is a closed generic type.
		/// </summary>
		/// <param name="type">
		///   The type to evaluate.
		/// </param>
		/// <returns>
		///   <c>true</c> if the type is an closed generic type; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsClosedGenericType(this Type type) {
			type = Guard.NotNull(type, nameof(type));
			return type.IsGenericType && !type.ContainsGenericParameters;
		}

		/// <summary>
		///   Determines whether the current type is a closed form of the specified open generic.
		/// </summary>
		/// <param name="type">
		///   The type to evaluate.
		/// </param>
		/// <param name="openGenericType">
		///   The open generic to search for.
		/// </param>
		/// <returns>
		///   <c>true</c> if the type is a closed form of the specified open generic; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsClosedTypeOf(this Type type, Type openGenericType) {
			type = Guard.NotNull(type, nameof(type));
			openGenericType = Guard.NotNull(openGenericType, nameof(openGenericType));
			if(!openGenericType.IsOpenGenericType()) {
				throw new ArgumentException($"{openGenericType} must be an open generic type.", nameof(openGenericType));
			}

			return type.TypesAssignableFrom().Any(t => t.IsClosedGenericType() && t.GetGenericTypeDefinition() == openGenericType);
		}

		/// <summary>
		///   Determines whether the current type is an open generic type.
		/// </summary>
		/// <param name="type">
		///   The type to evaluate.
		/// </param>
		/// <returns>
		///   <c>true</c> if the type is an open generic type; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsOpenGenericType(this Type type) {
			type = Guard.NotNull(type, nameof(type));
			return type.IsGenericType && type.ContainsGenericParameters;
		}

		/// <summary>
		///   Gets the types assignable from the specified type.
		/// </summary>
		/// <param name="type">
		///   The type to traverse for assignable types.
		/// </param>
		/// <returns>
		///   All available assignable types.
		/// </returns>
		public static IEnumerable<Type> TypesAssignableFrom(this Type type) {
			type = Guard.NotNull(type, nameof(type));
			return type.GetInterfaces().Concat(Traverse.Across(type, t => t?.BaseType));
		}
	}
}
