using System;
using System.Reflection;

namespace RandyRidge.Common.Reflection {
    /// <summary>
    ///     Provides <see cref="Type" /> extensions.
    /// </summary>
    public static class TypeExtensions {
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
            return type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
        }
    }
}
