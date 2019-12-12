using System.IO;
using Shouldly;
using Xunit;

namespace RandyRidge.Common.IO {
    public static class RandomFileTester {
        public static class Constructor {
            [Fact]
            public static void creates_file() {
                using var f = new RandomFile(".txt");
                Exists(f).ShouldBeTrue();
            }

            [Fact]
            public static void sets_extension() {
                using var f = new RandomFile(".txt");
                f.Path.ShouldEndWith(".txt");
            }

            [Fact]
            public static void sets_path() {
                using var f = new RandomFile(".txt");
                f.Path.ShouldNotBeNullOrWhiteSpace();
            }
        }

        public static class Dispose {
            [Fact]
            public static void deletes_file() {
                var f = new RandomFile(".txt");
                Exists(f).ShouldBeTrue();
                f.Dispose();
                Exists(f).ShouldBeFalse();
            }

            [Fact]
            public static void double_dispose_does_not_throw() {
                var f = new RandomFile(".txt");
                Exists(f).ShouldBeTrue();
                f.Dispose();
                f.Dispose();
                Exists(f).ShouldBeFalse();
            }
        }

        private static bool Exists(RandomFile f) => File.Exists(f.Path);
    }
}
