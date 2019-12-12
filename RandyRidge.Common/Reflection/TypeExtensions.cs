using System;
using System.Linq;
using System.Reflection;

namespace RandyRidge.Common.Reflection {
    /// <summary>
    ///     Provides <see cref="Type" /> extensions.
    /// </summary>
    public static class TypeExtensions {
        private const BindingFlags PublicStatic = BindingFlags.Public | BindingFlags.Static;

        /// <summary>
        ///     Searches for the public, static property with the specified name.
        /// </summary>
        /// <param name="type">
        ///     The type to search.
        /// </param>
        /// <param name="name">
        ///     The string containing the name of the property to get.
        /// </param>
        /// <returns>
        ///     An object representing the public, static property with the specified name, if found; otherwise, null.
        /// </returns>
        public static PropertyInfo? GetPublicStaticProperty(this Type type, string name) {
            Guard.ArgumentNotNull(type, nameof(type));
            Guard.ArgumentNotNullOrWhiteSpace(name, nameof(name));
            return type.GetProperty(name, PublicStatic);
        }

        /// <summary>
        ///     Searches for public, static properties.
        /// </summary>
        /// <param name="type">
        ///     The type to search.
        /// </param>
        /// <returns>
        ///     An array representing the public, static properties.
        /// </returns>
        public static PropertyInfo[] GetPublicStaticProperties(this Type type) {
            Guard.ArgumentNotNull(type, nameof(type));
            return type.GetProperties(PublicStatic);
        }

        /// <summary>
        ///     Searches for public, static properties with the specified predicate.
        /// </summary>
        /// <param name="type">
        ///     The type to search.
        /// </param>
        /// <param name="predicate">
        ///     The predicate to search with.
        /// </param>
        /// <returns>
        ///     An array representing the public, static properties.
        /// </returns>
        public static PropertyInfo[] GetPublicStaticProperties(this Type type, Func<PropertyInfo, bool> predicate) {
            Guard.ArgumentNotNull(type, nameof(type));
            Guard.ArgumentNotNull(predicate, nameof(predicate));
            return type.GetPublicStaticProperties().Where(predicate).ToArray();
        }
    }
}
