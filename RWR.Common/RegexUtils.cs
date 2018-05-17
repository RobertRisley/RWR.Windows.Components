using System.Text.RegularExpressions;

namespace RWR.Common
{
	/// <summary>
	/// Common Regular Expression Utilities (static).
	/// </summary>
	public class RegexUtils
	{
		/// <summary>
		/// Validates a ZipCode 5 or 5-4.
		/// </summary>
		/// <param name="zipCode">The Zip Code to Regex.Match.</param>
		/// <returns>The ZipCode Regex match.</returns>
		public static Match GetZipCodeMatch(string zipCode)
		{
			return GetMatch(Constants.REGEX_ZIP_CODE, zipCode);
		}

		/// <summary>
		/// Perform a Regex Match function with a pattern and text
		/// </summary>
		/// <param name="pattern">The regular expression pattern.</param>
		/// <param name="text">The string to search for a match.</param>
		/// <returns>The regular expression match object.</returns>
		public static Match GetMatch(string pattern, string text)
		{
			var regex = new Regex(pattern);
			return regex.Match(text);
		}
	}
}
