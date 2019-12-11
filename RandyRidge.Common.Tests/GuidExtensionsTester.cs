using System;
using System.Globalization;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
    public abstract class GuidExtensionsTester {
        public sealed class ToStringWithDigitsOnly {
            [Fact]
            public void formats_correctly() {
                var guid = Guid.NewGuid();
                guid.ToStringWithDigitsOnly().ShouldBe(guid.ToString("N", CultureInfo.InvariantCulture));
            }
        }
    }
}
