using System;

namespace RWR.Common
{
	/// <summary>
	/// Day of the Week enumeration.
	/// </summary>
	[Serializable]
	public enum DayOfWeek
	{
		/// <remarks/>
		Sunday = 1,
		/// <remarks/>
		Monday = 2,
		/// <remarks/>
		Tuesday = 3,
		/// <remarks/>
		Wednesday = 4,
		/// <remarks/>
		Thursday = 5,
		/// <remarks/>
		Friday = 6,
		/// <remarks/>
		Saturday = 7,
	}
	/// <summary>
	/// The ColorSet to use enuameration.
	/// </summary>
	[Serializable]
	public enum ColorSet
	{
		/// <summary>
		/// All ColorSets
		/// </summary>
		All,
		/// <summary>
		/// The System ColorSet
		/// </summary>
		System,
		/// <summary>
		/// The Web ColorSet
		/// </summary>
		Web
	}

	/// <summary>
	/// Run Type enumeration
	/// </summary>
	[Serializable]
	public enum RunConfiguration
	{
		/// <summary>
		/// Call Windows Service
		/// </summary>
		WindowsService,
		/// <summary>
		/// Call Web Service
		/// </summary>
		WebService,
		/// <summary>
		/// Client Server
		/// </summary>
		ClientServer
	}
}
