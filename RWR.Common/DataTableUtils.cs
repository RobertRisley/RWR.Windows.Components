using System.Data;

namespace RWR.Common
{
	/// <summary>
	/// Common DataTable Utilities (static)
	/// </summary>
	public class DataTableUtils
	{
		/// <summary>
		/// Sets the Caption text for a given Target DataColumnCollection to
		/// the Caption text of a Reference DataColumnCollection only if it exists
		/// in the Target.
		/// </summary>
		/// <param name="tgtColumns">Target DataTable.DataColumnCollection</param>
		/// <param name="refColumns">Reference DataTable.DataColumnCollection</param>
		public static void SetCaptions(DataColumnCollection tgtColumns, DataColumnCollection refColumns)
		{
			foreach (DataColumn refCol in refColumns)
			{
				if (tgtColumns[refCol.ColumnName] != null && !string.IsNullOrEmpty(refCol.Caption))
				{
					tgtColumns[refCol.ColumnName].Caption = refCol.Caption;
				}
			}
		}
	}
}
