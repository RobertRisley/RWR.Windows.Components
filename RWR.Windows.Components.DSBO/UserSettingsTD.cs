using System;
using System.Data;
using System.Transactions;
using System.Windows.Forms;
using RWR.Common;

namespace RWR.Windows.Components.DSBO
{
	/// <summary>
	/// The UserSettings Table DataSet
	/// </summary>
	partial class UserSettingsTD
	{
		/// <summary>
		/// Get all UserSettings
		/// </summary>
		/// <returns>A UserSettingsTD</returns>
		public static DataSet GetUserSettings()
		{
			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ds = new UserSettingsTD();
				var ta = new UserSettingsTDTableAdapters.UserSettingsTableAdapter();
				ta.Fill(ds.UserSettings);
				return ds;
			}
		}

		/// <summary>
		/// Get UserSetting row by UserName
		/// </summary>
		/// <returns>A UserSettingsDataTable with one row if UserName exists</returns>
		public static DataTable GetUserSetting(string userName)
		{
			if (string.IsNullOrEmpty(userName))
				throw new Exception("The UserName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ta = new UserSettingsTDTableAdapters.UserSettingsTableAdapter();
				return ta.GetDataByUserName(userName);
			}
		}

		/// <summary>
		/// Returns true or false if a UserSettings exists
		/// </summary>
		/// <param name="userName">The UserName to check existance</param>
		/// <returns>true if UserSettings exists, false if not</returns>
		public static bool IsExistingUserSettings(string userName)
		{
			if (string.IsNullOrEmpty(userName))
				throw new Exception("The UserName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ta = new UserSettingsTDTableAdapters.UserSettingsTableAdapter();
				return (ta.IsExistingUserSettings(userName) == 0 ? false : true);
			}
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update UserSettings
		/// </summary>
		/// <returns>A UserSettingsTD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static DataSet UpdateUserSettings(DataSet userSettingsDataSet)
		{
			if (userSettingsDataSet == null || userSettingsDataSet.Tables["UserSettings"] == null)
				throw new Exception("The DataSet and/or DataTable is null.");

			var dtUserSettings = new UserSettingsDataTable();
			dtUserSettings.BeginLoadData();
			dtUserSettings.Merge(userSettingsDataSet.Tables["UserSettings"], false, MissingSchemaAction.Error);

			using (var ts = new TransactionScope(TransactionScopeOption.Required))
			{
				var taUserSettings = new UserSettingsTDTableAdapters.UserSettingsTableAdapter();

				#region do deletes
				foreach (UserSettingsRow deletedRow in dtUserSettings.Select("", "", DataViewRowState.Deleted))
				{
					// get the primary key value(s) from the Original version (for child deletes)
					var userName = (string)deletedRow["UserName", DataRowVersion.Original];

					// do child deletes (if any exist)
					//SettingsChildrenDataSet.UpdateSettingsChildren

					// delete the row
					taUserSettings.Delete(userName);
				}
				#endregion

				#region do inserts
				foreach (UserSettingsRow insertedRow in dtUserSettings.Select("", "", DataViewRowState.Added))
				{
					//insertedRow["SubmitDt"] = DBNull.Value;  // for testing SetDefaultValues
					insertedRow.SetDefaultValues();

					if (insertedRow.IsValidRow())
					{
						taUserSettings.Update(insertedRow);
					}
					else
					{
						throw new Exception("A row to be inserted contains invalid data. Entire transaction cancelled.");
					}
				}
				#endregion

				#region do updates
				foreach (UserSettingsRow modifiedRow in dtUserSettings.Select("", "", DataViewRowState.ModifiedCurrent))
				{
					// get the primary key value(s) from the Original version
					var userName = (string)modifiedRow["UserName", DataRowVersion.Original];

					// do not allow key changes
					var userNameCurr = (string)modifiedRow["UserName", DataRowVersion.Current];
					if (userName != userNameCurr)
						throw new Exception("Change of primary key(s) is not permitted. Entire transaction cancelled.");

					if (modifiedRow.IsValidRow())
					{
						taUserSettings.Update(modifiedRow);
					}
					else
					{
						throw new Exception("A row to be modified contains invalid data. Entire transaction cancelled.");
					}
				}
				#endregion

				ts.Complete();
			}
			dtUserSettings.AcceptChanges();
			userSettingsDataSet.Tables["UserSettings"].Merge(dtUserSettings, false, MissingSchemaAction.Ignore);

			return userSettingsDataSet;
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
		/// A UserSettings row.
		/// </summary>
		public partial class UserSettingsRow
		{
			/// <summary>
			/// Set value for columns == DBNull to their DefaultValue  (if DefaultValue specified in XSD)
			/// </summary>
			public void SetDefaultValues()
			{
				DataRowUtils.SetDefaultValues(this, Table.Columns);
			}

			/// <summary>
			/// Validates the current UserSettingsRow
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
