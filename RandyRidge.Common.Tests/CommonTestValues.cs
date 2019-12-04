using System;
using System.Collections.Generic;
using System.Linq;

namespace RandyRidge.Common {
    public static class CommonTestValues {
        public const string? TestString = "test";
        public const string? WhitespaceString = "   ";
        public static readonly string[]? EmptyArray = Array.Empty<string>();
        public static readonly IEnumerable<int> EmptyEnumerable = Array.Empty<int>();
        public static readonly string? EmptyString = string.Empty;
        public static readonly string[]? NullArray = null;
        public static readonly IEnumerable<int> NullEnumerable = null;
        public static readonly int? NullNullableInt = null;
        public static readonly object? NullObject = null;
        public static readonly string? NullString = null;
        public static readonly string[]? TestArray = {"test"};
        public static readonly IEnumerable<int> TestEnumerable = Enumerable.Range(1, 3);
        public static readonly int? TestNullableInt = 42;
        public static readonly object? TestObject = "test";
    }
}
