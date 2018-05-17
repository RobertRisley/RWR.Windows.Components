namespace RWR.Common
{
	/// <summary>
	/// Common Constants in alphabetical order.
	/// </summary>
	public class Constants
	{
		/// <summary>
		/// This Web Service root URL.
		/// </summary>
		public const string SERVER_URL = "http://www.RobertRisley.com/2010";
		/// <summary>
		/// Regular Expression Credit Card 
		/// </summary>
		public const string REGEX_CREDIT_CARD = @"^((\d{4}[- ]?){3}\d{4})$";
		/// <summary>
		/// Regular Expression Currency
		/// </summary>
		public const string REGEX_CURRENCY = @"^(-)?\d+(\.\d\d)?$";
		/// <summary>
		/// Regular Expression Date Mm/Dd/Yyyy
		/// </summary>
		public const string REGEX_DATE_MM_DD_YYYY = @"^\d{1,2}\/\d{1,2}\/\d{2,4}$";
		/// <summary>
		/// Regular Expression E-Mail
		/// </summary>
		public const string REGEX_EMAIL = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
		/// <summary>
		/// Regular Expression File Path
		/// Beginning with the drive letter and optionally match a filename with a three-character extension
		///		(no ".." characters signifying to move up the directory hierarchy are allowed,
		///		 nor is a directory name with a "." followed by an extension)
		/// </summary>
		public const string REGEX_FILE_PATH = @"^[a-zA-Z]:[\\/]([_a-zA-Z0-9]+[\\/]?)*([_a-zA-Z0-9]+\.[_a-zA-Z0-9]{0,3})?$";
		/// <summary>
		/// Regular Expression IP Address
		/// </summary>
		public const string REGEX_IP_ADDRESS = @"^([0-2]?[0-5]?[0-5]\.){3}[0-2]?[0-5]?[0-5]$";
		/// <summary>
		/// Regular Expression Name
		/// </summary>
		public const string REGEX_NAME = @"^[a-zA-Z''-'\s]{1,40}$";
		/// <summary>
		/// Regular Expression Non-Negative Currency
		/// </summary>
		public const string REGEX_NON_NEGATIVE_CURRENCY = @"^\d+(\.\d\d)?$";
		/// <summary>
		/// Regular Expression Non-Negative Integer
		/// </summary>
		public const string REGEX_NON_NEGATIVE_INTEGER = @"^\d+$";
		/// <summary>
		/// Regular Expression Password
		/// </summary>
		public const string REGEX_PASSWORD = @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$";
		/// <summary>
		/// Regular Expression Phone Number
		/// </summary>
		public const string REGEX_PHONE_NUMBER = @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";
		/// <summary>
		/// Regular Expression Social Security Number
		/// </summary>
		public const string REGEX_SOCIAL_SECURITY_NUMBER = @"^\d{3}-\d{2}-\d{4}$";
		/// <summary>
		/// Regular Expression Time Hh:Mm AM
		/// </summary>
		public const string REGEX_TIME_HH_MM_AMPM = @"^\d{1,2}:\d{2}\s?([ap]m)?$";
		/// <summary>
		/// Regular Expression URL
		/// </summary>
		public const string REGEX_URL = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
		/// <summary>
		/// Regular Expression Zip Code
		/// </summary>
		public const string REGEX_ZIP_CODE = @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$";
	}
}
