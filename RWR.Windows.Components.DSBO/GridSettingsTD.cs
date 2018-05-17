using System;
using System.Data;
using System.Transactions;
using System.Windows.Forms;
using RWR.Common;

namespace RWR.Windows.Components.DSBO
{
	/// <summary>
	/// The GridSettings DataSet.
	/// </summary>
	partial class GridSettingsTD
	{
		/// <summary>
		/// Get all GridSettings
		/// </summary>
		/// <returns>A GridSettingsTD</returns>
		public static DataSet GetGridSettings()
		{
			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ds = new GridSettingsTD();
				var ta = new GridSettingsTDTableAdapters.GridSettingsTableAdapter();
				ta.Fill(ds.GridSettings);
				return ds;
			}
		}

		/// <summary>
		/// Get GridSetting row by UserName/GridName
		/// </summary>
		/// <returns>A GridSettingsDataTable with one row if UserName/GridName exists</returns>
		public static DataTable GetGridSetting(string userName, string gridName, string columnName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName) || string.IsNullOrEmpty(columnName))
				throw new Exception("The UserName and/or GridName and/or ColumnName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ta = new GridSettingsTDTableAdapters.GridSettingsTableAdapter();
				return ta.GetDataByUserNameGridNameColumnName(userName, gridName, columnName);
			}
		}

		/// <summary>
		/// Returns true or false if a GridSettings exists
		/// </summary>
		/// <param name="userName">The UserName to check existance</param>
		/// <param name="gridName">The GridName to check existance</param>
		/// <returns>true if GridSettings exists, false if not</returns>
		public static bool IsExistingGridSettings(string userName, string gridName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ta = new GridSettingsTDTableAdapters.GridSettingsTableAdapter();
				return (ta.IsExistingGridSettings(userName, gridName) == 0 ? false : true);
			}
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update GridSettings
		/// </summary>
		/// <returns>A GridSettingsTD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static DataSet UpdateGridSettings(DataSet gridSettingsDataSet)
		{
			if (gridSettingsDataSet == null || gridSettingsDataSet.Tables["GridSettings"] == null)
				throw new Exception("The DataSet and/or DataTable is null.");

			var dtGridSettings = new GridSettingsDataTable();
			dtGridSettings.BeginLoadData();
			dtGridSettings.Merge(gridSettingsDataSet.Tables["GridSettings"], false, MissingSchemaAction.Error);

			using (var ts = new TransactionScope(TransactionScopeOption.Required))
			{
				var taGridSettings = new GridSettingsTDTableAdapters.GridSettingsTableAdapter();

				#region do deletes
				foreach (GridSettingsRow deletedRow in dtGridSettings.Select("", "", DataViewRowState.Deleted))
				{
					// get the primary key value(s) from the Original version (for child deletes)
					var userName = (string)deletedRow["UserName", DataRowVersion.Original];
					var gridName = (string)deletedRow["GridName", DataRowVersion.Original];
					var columnName = (string)deletedRow["ColumnName", DataRowVersion.Original];

					// do child deletes (if any exist)
					//SettingsChildrenDataSet tasksChildrenDataSet = new SettingsChildrenDataSet();
					// fill the DataSet with some udpates
					//SettingsChildrenDataSet.UpdateSettingsChildren(tasksChildrenDataSet, ref sqlTrans);

					// delete the row
					taGridSettings.Delete(userName, gridName, columnName);
				}
				#endregion

				#region do inserts
				foreach (GridSettingsRow insertedRow in dtGridSettings.Select("", "", DataViewRowState.Added))
				{
					insertedRow.SetDefaultValues();

					if (insertedRow.IsValidRow())
					{
						taGridSettings.Update(insertedRow);
					}
					else
					{
						throw new Exception("A row to be inserted contains invalid data. Entire transaction cancelled.");
					}
				}
				#endregion

				#region do updates
				foreach (GridSettingsRow modifiedRow in dtGridSettings.Select("", "", DataViewRowState.ModifiedCurrent))
				{
					// get the primary key value(s) from the Original version
					var userName = (string)modifiedRow["UserName", DataRowVersion.Original];
					var gridName = (string)modifiedRow["GridName", DataRowVersion.Original];
					var columnName = (string)modifiedRow["ColumnName", DataRowVersion.Original];

					// do not allow key changes
					var userNameCurr = (string)modifiedRow["UserName", DataRowVersion.Current];
					var gridNameCurr = (string)modifiedRow["GridName", DataRowVersion.Current];
					var columnNameCurr = (string)modifiedRow["ColumnName", DataRowVersion.Current];
					if (userName != userNameCurr || gridName != gridNameCurr || columnName != columnNameCurr)
						throw new Exception("Change of primary key(s) is not permitted. Entire transaction cancelled.");

					if (modifiedRow.IsValidRow())
					{
						taGridSettings.Update(modifiedRow);
					}
					else
					{
						throw new Exception("A row to be modified contains invalid data. Entire transaction cancelled.");
					}
				}
				#endregion

				ts.Complete();
			}
			dtGridSettings.AcceptChanges();
			gridSettingsDataSet.Tables["GridSettings"].Merge(dtGridSettings, false, MissingSchemaAction.Ignore);

			return gridSettingsDataSet;
		}

		/// <summary>
		/// Service callable code to Delete GridSettings
		/// </summary>
		/// <returns>A GridSettingsTD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static void DeleteGridSettingsByUserNameGridName(string userName, string gridName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			using (var ts = new TransactionScope(TransactionScopeOption.Required))
			{
				var taGridSettings = new GridSettingsTDTableAdapters.GridSettingsTableAdapter();
				taGridSettings.DeleteByUserNameGridName(userName, gridName);

				ts.Complete();
			}
		}


		/// <summary>
		/// <para>Validate all of the column values in a DataRow.</para>
		/// <para>The RowError text is set and HasErrors property is true if exists RowError text.</para>
		/// </summary>
		/// <param name="row">the DataRow to be validated</param>
		/// <param name="cols">the DataColumnCollection to iterate through</param>
		public static void CheckTableRow(DataRow row, DataColumnCollection cols)
		{
			try
			{
				foreach (DataColumn col in cols)
					switch (col.ColumnName)
					{
						// TODO: code case for each column to be validated
						//case "PrioritySequence":
						//    row.RowError += CheckPrioritySequence(row[col].ToString());
						//    break;
						default:
							break;
					}
			}
			catch
			{
				row.RowError = "OOPS! ERROR checking DataRow!";
			}
		}

		/// <summary>
		/// Call this from the DataGridView.CellValidating event
		/// </summary>
		/// <param name="sender">The sender object (DataGridView) from CellValidatingEvent</param>
		/// <param name="e">The e DataGridViewCellValidatingEventArgs from CellValidatingEvent</param>
		public static void CheckGridColumn(object sender, DataGridViewCellValidatingEventArgs e)
		{
			var grid = (DataGridView)sender;

			//grid.CurrentCell.ErrorText = "";
			try
			{

				switch (grid.Columns[e.ColumnIndex].Name)
				{
					//case "PrioritySequence":
					//    grid.Rows[e.RowIndex].ErrorText = CheckPrioritySequence((string)e.FormattedValue);
					//    break;
					default:
						break;
				}

				if (grid.Rows[e.RowIndex].ErrorText != string.Empty)
					e.Cancel = true;
			}
			catch
			{
				grid.CurrentCell.ErrorText = "OOPS! ERROR!";
				e.Cancel = true;
			}
		}


		/// <summary>
		/// A GridSettings row.
		/// </summary>
		public partial class GridSettingsRow
		{
			/// <summary>
			/// Set value for columns == DBNull to their DefaultValue  (if DefaultValue specified in XSD)
			/// </summary>
			public void SetDefaultValues()
			{
				DataRowUtils.SetDefaultValues(this, Table.Columns);
			}

			/// <summary>
			/// Validates the current GridSettingsRow
			/// </summary>
			/// <returns>The row is valid</returns>
			public bool IsValidRow()
			{
				CheckTableRow(this, Table.Columns);
				return !HasErrors;
			}
		}
	}
}
