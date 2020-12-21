using System;

namespace RandyRidge.Common.Reflection {
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public sealed class TestAttribute : Attribute {
		public TestAttribute(string value) {
			Value = value;
		}

		public string Value { get; set; }
	}
}
