using System;
using Shouldly;
using Xunit;

namespace RandyRidge.Common {
public abstract class DateTimeExtensionsTester {
        private readonly DateTime testDateTime;

        protected DateTimeExtensionsTester() {
            testDateTime = new DateTime(1978, 1, 19, 1, 2, 3, 4);
        }

        public sealed class RoundToDay : DateTimeExtensionsTester {
            [Fact]
            public void removes_hours_precision() {
                var roundedDatetime = testDateTime.RoundToDay();
                roundedDatetime.Hour.ShouldBe(0);
            }

            [Fact]
            public void removes_milliseconds_precision() {
                var roundedDatetime = testDateTime.RoundToDay();
                roundedDatetime.Minute.ShouldBe(0);
            }

            [Fact]
            public void removes_minutes_precision() {
                var roundedDatetime = testDateTime.RoundToDay();
                roundedDatetime.Millisecond.ShouldBe(0);
            }

            [Fact]
            public void removes_seconds_precision() {
                var roundedDatetime = testDateTime.RoundToDay();
                roundedDatetime.Second.ShouldBe(0);
            }

            [Fact]
            public void retains_precision_greater_or_equal_to_minute() {
                var roundedDatetime = testDateTime.RoundToDay();
                roundedDatetime.Year.ShouldBe(1978);
                roundedDatetime.Month.ShouldBe(1);
                roundedDatetime.Day.ShouldBe(19);
            }
        }

        public sealed class RoundToHour : DateTimeExtensionsTester {
            [Fact]
            public void removes_milliseconds_precision() {
                var roundedDatetime = testDateTime.RoundToHour();
                roundedDatetime.Minute.ShouldBe(0);
            }

            [Fact]
            public void removes_minutes_precision() {
                var roundedDatetime = testDateTime.RoundToHour();
                roundedDatetime.Millisecond.ShouldBe(0);
            }

            [Fact]
            public void removes_seconds_precision() {
                var roundedDatetime = testDateTime.RoundToHour();
                roundedDatetime.Second.ShouldBe(0);
            }

            [Fact]
            public void retains_precision_greater_or_equal_to_minute() {
                var roundedDatetime = testDateTime.RoundToHour();
                roundedDatetime.Year.ShouldBe(1978);
                roundedDatetime.Month.ShouldBe(1);
                roundedDatetime.Day.ShouldBe(19);
                roundedDatetime.Hour.ShouldBe(1);
            }
        }

        public sealed class RoundToMinute : DateTimeExtensionsTester {
            [Fact]
            public void removes_milliseconds_precision() {
                var roundedDatetime = testDateTime.RoundToMinute();
                roundedDatetime.Millisecond.ShouldBe(0);
            }

            [Fact]
            public void removes_seconds_precision() {
                var roundedDatetime = testDateTime.RoundToMinute();
                roundedDatetime.Second.ShouldBe(0);
            }

            [Fact]
            public void retains_precision_greater_or_equal_to_minute() {
                var roundedDatetime = testDateTime.RoundToMinute();
                roundedDatetime.Year.ShouldBe(1978);
                roundedDatetime.Month.ShouldBe(1);
                roundedDatetime.Day.ShouldBe(19);
                roundedDatetime.Hour.ShouldBe(1);
                roundedDatetime.Minute.ShouldBe(2);
            }
        }

        public sealed class RoundToSecond : DateTimeExtensionsTester {
            [Fact]
            public void removes_milliseconds_precision() {
                var roundedDatetime = testDateTime.RoundToSecond();
                roundedDatetime.Millisecond.ShouldBe(0);
            }

            [Fact]
            public void retains_precision_greater_or_equal_to_second() {
                var roundedDatetime = testDateTime.RoundToSecond();
                roundedDatetime.Year.ShouldBe(1978);
                roundedDatetime.Month.ShouldBe(1);
                roundedDatetime.Day.ShouldBe(19);
                roundedDatetime.Hour.ShouldBe(1);
                roundedDatetime.Minute.ShouldBe(2);
                roundedDatetime.Second.ShouldBe(3);
            }
        }
    }}
