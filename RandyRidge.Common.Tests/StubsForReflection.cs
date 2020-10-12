using System.Threading.Tasks;
using RandyRidge.Common.Reflection;

namespace RandyRidge.Common {
	[Test("test")]
	[Test("test1")]
	public sealed class StubsForReflection {
		private static bool isPrivateStaticField;
		private readonly bool isPrivateField;

		public StubsForReflection() {
			isPrivateField = false;
			isPrivateField.ToString();
			isPrivateStaticField = true;
			isPrivateStaticField.ToString();
		}

		public int IntField;

		public int IntProperty { get; set; }

		public async void AsyncVoidMethod() {
			await Task.CompletedTask;
		}

		[Test("test")]
		public void HasAttribute() {
		}

		public void HasNoAttribute() {
		}

		public int Method() => 42;

		private bool PrivateMethod() {
			return true;
		}
	}}
