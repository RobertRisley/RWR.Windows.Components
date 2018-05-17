using System;
using System.Data;
using System.Transactions;
using System.Windows.Forms;
using RWR.Common;

namespace RWR.Windows.Components.DSBO
{
	/// <summary>
	/// The FormSettings DataSet.
	/// </summary>
	partial class FormSettingsTD
	{
		/// <summary>
		/// Get all FormSettings
		/// </summary>
		/// <returns>A FormSettingsTD</returns>
		public static DataSet GetFormSettings()
		{
			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ds = new FormSettingsTD();
				var ta = new FormSettingsTDTableAdapters.FormSettingsTableAdapter();
				ta.Fill(ds.FormSettings);
				return ds;
			}
		}

		/// <summary>
		/// Get FormSetting row by UserName/FormName
		/// </summary>
		/// <returns>A FormSettingsDataTable with one row if UserName/FormName exists</returns>
		public static DataTable GetFormSetting(string userName, string formName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(formName))
				throw new Exception("The UserName and/or FormName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ta = new FormSettingsTDTableAdapters.FormSettingsTableAdapter();
				return ta.GetDataByUserNameFormName(userName, formName);
			}
		}

		/// <summary>
		/// Returns true or false if a FormSettings exists
		/// </summary>
		/// <param name="userName">The UserName to check existance</param>
		/// <param name="formName">The FormName to check existance</param>
		/// <returns>true if FormSettings exists, false if not</returns>
		public static bool IsExistingFormSettings(string userName, string formName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(formName))
				throw new Exception("The UserName and/or FormName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ta = new FormSettingsTDTableAdapters.FormSettingsTableAdapter();
				return (ta.IsExistingFormSettings(userName, formName) == 0 ? false : true);
			}
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update FormSettings
		/// </summary>
		/// <returns>A FormSettingsTD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static DataSet UpdateFormSettings(DataSet formSettingsDataSet)
		{
			if (formSettingsDataSet == null || formSettingsDataSet.Tables["FormSettings"] == null || formSettingsDataSet.Tables["FormSettings"].Rows.Count == 0)
				throw new Exception("The DataSet and/or DataTable is null or empty.");

			var dtFormSettings = new FormSettingsDataTable();
			dtFormSettings.BeginLoadData();
			dtFormSettings.Merge(formSettingsDataSet.Tables["FormSettings"], false, MissingSchemaAction.Error);

			using (var ts = new TransactionScope(TransactionScopeOption.Required))
			{
				var taFormSettings = new FormSettingsTDTableAdapters.FormSettingsTableAdapter();

				#region do deletes
				foreach (FormSettingsRow deletedRow in dtFormSettings.Select("", "", DataViewRowState.Deleted))
				{
					// get the primary key value(s) from the Original version (for child deletes)
					var userName = (string)deletedRow["UserName", DataRowVersion.Original];
					var formName = (string)deletedRow["FormName", DataRowVersion.Original];

					// do child deletes (if any exist)
					//SettingsChildrenDataSet tasksChildrenDataSet = new SettingsChildrenDataSet();
					// fill the DataSet with some udpates
					//SettingsChildrenDataSet.UpdateSettingsChildren(tasksChildrenDataSet, ref sqlTrans);

					// delete the row
					taFormSettings.Delete(userName, formName);
				}
				#endregion

				#region do inserts
				foreach (FormSettingsRow insertedRow in dtFormSettings.Select("", "", DataViewRowState.Added))
				{
					insertedRow.SetDefaultValues();

					if (insertedRow.IsValidRow())
						taFormSettings.Update(insertedRow);
					else
						throw new Exception("A row to be inserted contains invalid data. Entire transaction cancelled.");
				}
				#endregion

				#region do updates
				foreach (FormSettingsRow modifiedRow in dtFormSettings.Select("", "", DataViewRowState.ModifiedCurrent))
				{
					// get the primary key value(s) from the Original version
					var userName = (string)modifiedRow["UserName", DataRowVersion.Original];
					var formName = (string)modifiedRow["FormName", DataRowVersion.Original];

					// do not allow key changes
					var userNameCurr = (string)modifiedRow["UserName", DataRowVersion.Current];
					var formNameCurr = (string)modifiedRow["FormName", DataRowVersion.Current];
					if (userName != userNameCurr || formName != formNameCurr)
						throw new Exception("Change of primary key(s) is not permitted. Entire transaction cancelled.");

					if (modifiedRow.IsValidRow())
						taFormSettings.Update(modifiedRow);
					else
						throw new Exception("A row to be modified contains invalid data. Entire transaction cancelled.");
				}
				#endregion

				ts.Complete();
			}
			dtFormSettings.AcceptChanges();
			formSettingsDataSet.Tables["FormSettings"].Merge(dtFormSettings, false, MissingSchemaAction.Ignore);

			return formSettingsDataSet;
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
		/// A FormSettings row.
		/// </summary>
		public partial class FormSettingsRow
		{
			/// <summary>
			/// Set value for columns == DBNull to their DefaultValue  (if DefaultValue specified in XSD)
			/// </summary>
			public void SetDefaultValues()
			{
				DataRowUtils.SetDefaultValues(this, Table.Columns);
			}

			/// <summary>
			/// Validates the current FormSettingsRow
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
