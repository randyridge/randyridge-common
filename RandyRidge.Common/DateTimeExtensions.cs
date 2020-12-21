using System;

namespace RandyRidge.Common {
	/// <summary>
	///   Provides extension methods for <see cref="DateTime" />.
	/// </summary>
	public static class DateTimeExtensions {
		/// <summary>
		///   Rounds the specified datetime down to day precision.
		/// </summary>
		/// <param name="value">
		///   The datetime to round down.
		/// </param>
		/// <returns>
		///   The datetime with precision down to the hour.
		/// </returns>
		public static DateTime RoundToDay(this DateTime value) => new(value.Year, value.Month, value.Day, 0, 0, 0);

		/// <summary>
		///   Rounds the specified datetime down to hour precision.
		/// </summary>
		/// <param name="value">
		///   The datetime to round down.
		/// </param>
		/// <returns>
		///   The datetime with precision down to the hour.
		/// </returns>
		public static DateTime RoundToHour(this DateTime value) => new(value.Year, value.Month, value.Day, value.Hour, 0, 0);

		/// <summary>
		///   Rounds the specified datetime down to minute precision.
		/// </summary>
		/// <param name="value">
		///   The datetime to round down.
		/// </param>
		/// <returns>
		///   The datetime with precision down to the minute.
		/// </returns>
		public static DateTime RoundToMinute(this DateTime value) => new(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);

		/// <summary>
		///   Rounds the specified datetime down to second precision.
		/// </summary>
		/// <param name="value">
		///   The datetime to round down.
		/// </param>
		/// <returns>
		///   The datetime with precision down to the second.
		/// </returns>
		public static DateTime RoundToSecond(this DateTime value) => new(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
	}
}
