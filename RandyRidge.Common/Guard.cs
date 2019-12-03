using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ArgumentNotNull<T>(T? argument, string argumentName) where T : class {
            if(argument == null) {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }

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
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ArgumentNotNull<T>(T? argument, string argumentName) where T : struct {
            if(argument == null) {
                throw new ArgumentNullException(argumentName);
            }

            return argument.Value;
        }
    }
}
