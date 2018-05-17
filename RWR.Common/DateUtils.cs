using System;

namespace RWR.Common
{
	/// <summary>
	/// Common Date Utilities (static).
	/// </summary>
	public class DateUtils
	{
		/// <summary>
		/// The minimum DateTime value that SQL2005 and before can use.
		/// Coincides with switch to Gregorian calendar because dates earlier than 1753 are different from country to country.
		/// </summary>
		public static DateTime SqlMinDateTime = Convert.ToDateTime("1753-01-01T00:00:00Z").ToUniversalTime();

		/// <summary>
		/// DateTime.UtcNow without the partial milliseconds
		/// </summary>
		public static DateTime SqlUtcNow
		{
			get { return ConvertToSqlDateTime(DateTime.UtcNow); }
		}

		/// <summary>
		/// Converts a DateTime value to the same without partial milliseconds
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static DateTime ConvertToSqlDateTime(DateTime dateTime)
		{
			return new DateTime(
				dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, (dateTime.Millisecond / 10) * 10, dateTime.Kind);
		}
	}
}
