using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace RandyRidge.Common {
    /// <summary>
    ///     Provides common guard clauses.
    /// </summary>
    public static class Guard {
        /// <summary>
        ///     Throws an exception if the specified file does not exist.
        /// </summary>
        /// <param name="filePath">
        ///     The file path to test.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="filePath" /> is an empty string or only contains whitespace characters.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="filePath" /> is null.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        ///     Thrown if <paramref name="filePath" /> is null.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FileExists(string? filePath, string argumentName) {
            if(filePath == null) {
                throw new ArgumentNullException(argumentName);
            }

            if(filePath.IsNullOrWhiteSpace()) {
                throw new ArgumentException($"'{argumentName}' must not be an empty string or contain only whitespace characters.", argumentName);
            }

            if(!File.Exists(filePath)) {
                throw new FileNotFoundException(null, filePath);
            }

            return filePath;
        }

        /// <summary>
        ///     Throws an exception if the tested argument is less-than the specified minimum, exclusive.
        /// </summary>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="minimum">
        ///     The minimum value, exclusive.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="argument" /> is less than the specified minimum, exclusive.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MinimumExclusive(double argument, double minimum, string argumentName) {
            if(argument <= minimum) {
                throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} must be greater-than {minimum}, exclusive.");
            }

            return argument;
        }

        /// <summary>
        ///     Throws an exception if the tested argument is less-than the specified minimum, exclusive.
        /// </summary>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="minimum">
        ///     The minimum value, exclusive.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="argument" /> is less than the specified minimum, exclusive.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MinimumExclusive(int argument, int minimum, string argumentName) {
            if(argument <= minimum) {
                throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} must be greater-than {minimum}, exclusive.");
            }

            return argument;
        }

        /// <summary>
        ///     Throws an exception if the tested argument is less-than the specified minimum, inclusive.
        /// </summary>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="minimum">
        ///     The minimum value, inclusive.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="argument" /> is less than the specified minimum, inclusive.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MinimumInclusive(double argument, double minimum, string argumentName) {
            if(argument < minimum) {
                throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} must be greater-than {minimum}, exclusive.");
            }

            return argument;
        }

        /// <summary>
        ///     Throws an exception if the tested argument is less-than the specified minimum, inclusive.
        /// </summary>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="minimum">
        ///     The minimum value, inclusive.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="argument" /> is less than the specified minimum, inclusive.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MinimumInclusive(int argument, int minimum, string argumentName) {
            if(argument < minimum) {
                throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} must be greater-than {minimum}, exclusive.");
            }

            return argument;
        }

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
        public static T NotNull<T>(T? argument, string argumentName) where T : class => argument ?? throw new ArgumentNullException(argumentName);

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
        public static T NotNull<T>(T? argument, string argumentName) where T : struct => argument ?? throw new ArgumentNullException(argumentName);

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
        public static string NotNullOrEmpty(string? argument, string argumentName) {
            if(argument == null) {
                throw new ArgumentNullException(argumentName);
            }

            if(argument.Length == 0) {
                throw new ArgumentException($"'{argumentName}' must not be empty.", argumentName);
            }

            return argument;
        }

        /// <summary>
        ///     Throws an exception if the tested collection argument is null or has no items.
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
        ///     Thrown if <paramref name="argument" /> is an empty collection.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="argument" /> is null.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ICollection<T> NotNullOrEmpty<T>(ICollection<T>? argument, string argumentName) {
            if(argument == null) {
                throw new ArgumentNullException(argumentName);
            }

            return argument.Count == 0 ? throw new ArgumentException($"'{argumentName}' must not be empty.", argumentName) : argument;
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
        public static string NotNullOrWhiteSpace(string? argument, string argumentName) {
            if(argument == null) {
                throw new ArgumentNullException(argumentName);
            }

            if(argument.IsNullOrWhiteSpace()) {
                throw new ArgumentException($"'{argumentName}' must not be an empty string or contain only whitespace characters.", argumentName);
            }

            return argument;
        }

        /// <summary>
        ///     Throws an exception if the tested argument is outside the specified minimum and maximum range, inclusive.
        /// </summary>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="minimum">
        ///     The minimum value, inclusive.
        /// </param>
        /// <param name="maximum">
        ///     The maximum value, inclusive.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="argument" /> is less than the specified minimum, inclusive.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RangeInclusive(double argument, double minimum, double maximum, string argumentName) {
            if(argument < minimum || argument > maximum) {
                throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} must be between {minimum} and {maximum}, inclusive.");
            }

            return argument;
        }

        /// <summary>
        ///     Throws an exception if the tested argument is outside the specified minimum and maximum range, inclusive.
        /// </summary>
        /// <param name="argument">
        ///     The argument to test.
        /// </param>
        /// <param name="minimum">
        ///     The minimum value, inclusive.
        /// </param>
        /// <param name="maximum">
        ///     The maximum value, inclusive.
        /// </param>
        /// <param name="argumentName">
        ///     The name of the argument.
        /// </param>
        /// <returns>
        ///     The argument.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="argument" /> is less than the specified minimum, inclusive.
        /// </exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RangeInclusive(int argument, int minimum, int maximum, string argumentName) {
            if(argument < minimum || argument > maximum) {
                throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} must be between {minimum} and {maximum}, inclusive.");
            }

            return argument;
        }
    }
}
