namespace RWR.Common
{
	/// <summary>
	/// Static Values
	/// </summary>
	public class Static
	{
		private static RunConfiguration _runConfiguration;
		/// <summary>
		/// 
		/// </summary>
		public static RunConfiguration RunConfiguration
		{
			get { _runConfiguration = RunConfiguration.WebService; return _runConfiguration; }
		}
	}
}
