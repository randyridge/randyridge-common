using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RandyRidge.Common {
    /// <summary>
    ///     Provides common guard clauses.
    /// </summary>
    public static class Guard {
        /// <summary>
        ///     Throws an exception if the given argument is null.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of object, must be a class.
        /// </typeparam>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="argument" /> is null.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ArgumentNotNull<T>(T? argument, string argumentName) where T : class => argument ?? throw new ArgumentNullException(argumentName);

        /// <summary>
        ///     Throws an exception if the given argument is null.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of object, must be a struct.
        /// </typeparam>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="argument" /> is null.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ArgumentNotNull<T>(T? argument, string argumentName) where T : struct => argument ?? throw new ArgumentNullException(argumentName);

        /// <summary>
        ///     Throws an exception if the tested string argument is null or an empty string.
        /// </summary>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="argument" /> is an empty string.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="argument" /> is null.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ArgumentNotNullOrEmpty(string? argument, string argumentName) {
            if(argument == null) {
                throw new ArgumentNullException(argumentName);
            }

            if(argument.Length == 0) {
                throw new ArgumentException($"'{argumentName}' must not be empty.", argumentName);
            }

            return argument;
        }

        /// <summary>
        ///     Throws an exception if the tested string argument is null, an empty string, or only contains whitespace characters.
        /// </summary>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="argument" /> is an empty string or only contains whitespace characters.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="argument" /> is null.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ArgumentNotNullOrWhiteSpace(string? argument, string argumentName) {
            if(argument == null) {
                throw new ArgumentNullException(argumentName);
            }

            if(argument.IsNullOrWhiteSpace()) {
                throw new ArgumentException($"'{argumentName}' must not be an empty string or contain only whitespace characters.", argumentName);
            }

            return argument;
        }
    }
}
