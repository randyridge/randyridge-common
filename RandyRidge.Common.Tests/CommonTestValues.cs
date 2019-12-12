using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable ConvertToConstant.Global

namespace RandyRidge.Common {
    public static class TestValues {
        public static readonly string[]? EmptyArray = Array.Empty<string>();
        public static readonly byte[]? EmptyByteArray = Array.Empty<byte>();
        public static readonly ICollection<int>? EmptyCollection = Array.Empty<int>();
        public static readonly IEnumerable<int>? EmptyEnumerable = Array.Empty<int>();
        public static readonly string? EmptyString = string.Empty;
        public static readonly string[]? NullArray = null;
        public static readonly byte[]? NullByteArray = null;
        public static readonly ICollection<int>? NullCollection = null;
        public static readonly IEnumerable<int>? NullEnumerable = null;
        public static readonly int? NullNullableInt = null;
        public static readonly object? NullObject = null;
        public static readonly string? NullString = null;
        public static readonly string[]? TestArray = {"test"};
        public static readonly byte[]? TestByteArray = {0, 255, 128};
        public static readonly ICollection<int>? TestCollection = Enumerable.Range(1, 3).ToArray();
        public static readonly IEnumerable<int>? TestEnumerable = Enumerable.Range(1, 3);
        public static readonly string TestMd5Hash = "098f6bcd4621d373cade4e832627b4f6"; // "test"
        public static readonly int? TestNullableInt = 42;
        public static readonly object? TestObject = "test";
        public static readonly string? TestString = "test";
        public static readonly string? WhitespaceString = "   ";
    }
}
