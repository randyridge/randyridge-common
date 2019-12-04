using System;

namespace RandyRidge.Common {
    public static class CommonTestValues {
        public const string? TestString = "test";
        public const string? WhitespaceString = "   ";
        public static readonly string[]? EmptyArray = Array.Empty<string>();
        public static readonly string? EmptyString = string.Empty;
        public static readonly string[]? NullArray = null;
        public static readonly int? NullNullableInt = null;
        public static readonly string? NullString = null;
        public static readonly string[]? TestArray = {"test"};
        public static readonly int? TestNullableInt = 42;
    }
}
