using System;
using System.Data;
using System.Transactions;
using System.Windows.Forms;
using RWR.Common;

namespace RWR.Windows.Components.DSBO
{
	/// <summary>
	/// The GridFilters Table DataSet.
	/// </summary>
	partial class GridFiltersTD
	{
		/// <summary>
		/// Get all GridFilters
		/// </summary>
		/// <returns>A GridFiltersTD</returns>
		public static DataSet GetGridFilters()
		{
			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ds = new GridFiltersTD();
				var ta = new GridFiltersTDTableAdapters.GridFiltersTableAdapter();
				ta.Fill(ds.GridFilters);
				return ds;
			}
		}

		/// <summary>
		/// Get GridSetting row by UserName/GridName
		/// </summary>
		/// <returns>A GridSettingsDataTable with rows if UserName/GridName exists</returns>
		public static DataTable GetGridFilter(string userName, string gridName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ta = new GridSettingsTDTableAdapters.GridSettingsTableAdapter();
				return ta.GetDataByUserNameGridName(userName, gridName);
			}
		}

		/// <summary>
		/// Returns true or false if a GridFilters exists
		/// </summary>
		/// <param name="userName">The UserName to check existance</param>
		/// <param name="gridName">The GridName to check existance</param>
		/// <returns>true if GridFilters exists, false if not</returns>
		public static bool IsExistingGridFilters(string userName, string gridName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ta = new GridFiltersTDTableAdapters.GridFiltersTableAdapter();
				return (ta.IsExistingGridFilters(userName, gridName) == 0 ? false : true);
			}
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update GridFilters
		/// </summary>
		/// <returns>A GridFiltersTD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static DataSet UpdateGridFilters(DataSet gridFiltersDataSet)
		{
			if (gridFiltersDataSet == null || gridFiltersDataSet.Tables["GridFilters"] == null)
				throw new Exception("The DataSet and/or DataTable is null.");

			var dtGridFilters = new GridFiltersDataTable();
			dtGridFilters.BeginLoadData();
			dtGridFilters.Merge(gridFiltersDataSet.Tables["GridFilters"], false, MissingSchemaAction.Error);

			using (var ts = new TransactionScope(TransactionScopeOption.Required))
			{
				var taGridFilters = new GridFiltersTDTableAdapters.GridFiltersTableAdapter();

				// cannot do deletes by row

				#region do inserts (full replace)

				if (dtGridFilters.Select("", "", DataViewRowState.Added).Length > 0)
					DeleteGridFiltersByUserNameGridName(dtGridFilters.Rows[0]["UserName"].ToString(), dtGridFilters.Rows[0]["GridName"].ToString());

				foreach (GridFiltersRow insertedRow in dtGridFilters.Select("", "", DataViewRowState.Added))
				{
					insertedRow.SetDefaultValues();

					if (insertedRow.IsValidRow())
					{
						taGridFilters.Update(insertedRow);
					}
					else
					{
						throw new Exception("A row to be inserted contains invalid data. Entire transaction cancelled.");
					}
				}

				#endregion

				ts.Complete();
			}
			dtGridFilters.AcceptChanges();
			gridFiltersDataSet.Tables["GridFilters"].Merge(dtGridFilters, false, MissingSchemaAction.Ignore);

			return gridFiltersDataSet;
		}

		/// <summary>
		/// Service callable code to Delete GridFilters
		/// </summary>
		/// <returns>A GridFiltersTD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static void DeleteGridFiltersByUserNameGridName(string userName, string gridName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			using (var ts = new TransactionScope(TransactionScopeOption.Required))
			{
				var taGridFilters = new GridFiltersTDTableAdapters.GridFiltersTableAdapter();
				taGridFilters.DeleteByUserNameGridName(userName, gridName);

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
		/// A GridFilters row.
		/// </summary>
		public partial class GridFiltersRow
		{
			/// <summary>
			/// Set value for columns == DBNull to their DefaultValue  (if DefaultValue specified in XSD)
			/// </summary>
			public void SetDefaultValues()
			{
				DataRowUtils.SetDefaultValues(this, Table.Columns);
			}

			/// <summary>
			/// Validates the current GridFiltersRow
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
