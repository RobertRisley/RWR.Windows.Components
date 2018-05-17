using System;
using System.Data;

namespace RWR.Common
{
	/// <summary>
	/// Common DataRow Utilities (static)
	/// </summary>
	public class DataRowUtils
	{
		/// <summary>
		/// If the ColumnName from Collection exists in DataRow, and a DefaultValue exists in the
		/// Collection Column, and if the DataRow ColumnValue is DBNull, set to DefaultValue.
		/// </summary>
		/// <param name="row">The DataRow that contains the data.</param>
		/// <param name="columns">The DataColumnCollection to get each DefaultValue from.</param>
		public static void SetDefaultValues(DataRow row, DataColumnCollection columns)
		{
			foreach (DataColumn col in columns)
			{
				if (row.Table.Columns[col.ColumnName] != null &&
					col.DefaultValue != DBNull.Value &&
					Convert.IsDBNull(row[col.ColumnName]))
				{
					row[col.ColumnName] = col.DefaultValue;
				}
			}
		}
	}
}
