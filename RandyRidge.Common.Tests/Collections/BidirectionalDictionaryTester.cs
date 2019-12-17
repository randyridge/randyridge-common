using Shouldly;
using Xunit;

namespace RandyRidge.Common.Collections {
    public abstract class BidirectionalDictionaryTester {
        private readonly BidirectionalDictionary<int, string> bidirectional;

        protected BidirectionalDictionaryTester() {
            bidirectional = new BidirectionalDictionary<int, string>();
        }

        public class Add : BidirectionalDictionaryTester {
            [Fact]
            public void adds_pair() {
                bidirectional.Add(1, "one");
                bidirectional.Count.ShouldBe(1);
            }
        }

        public sealed class Constructor : BidirectionalDictionaryTester {
            [Fact]
            public void sets_left() => bidirectional.Left.ShouldNotBeNull();

            [Fact]
            public void sets_right() => bidirectional.Right.ShouldNotBeNull();
        }

        public class Indexer : BidirectionalDictionaryTester {
            [Fact]
            public void can_access_left() {
                bidirectional.Add(1, "one");
                bidirectional.Left[1].ShouldBe("one");
            }

            [Fact]
            public void can_access_right() {
                bidirectional.Add(1, "one");
                bidirectional.Right["one"].ShouldBe(1);
            }
        }
    }
}
