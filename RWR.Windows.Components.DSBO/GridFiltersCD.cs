using System;
using System.Data;
using System.Transactions;
using RWR.Common;
using RWR.Windows.Components.DSBO.SettingsServiceASMX;
using ASMX = RWR.Windows.Components.DSBO.SettingsServiceASMX;
using WCF = RWR.Windows.Components.DSBO.SettingsServiceWCF;

namespace RWR.Windows.Components.DSBO
{
	/// <summary>
	/// A GridFilters Client DataSet
	/// </summary>
	partial class GridFiltersCD
	{
		#region Service Code

		/// <summary>
		/// Service callable code to get GridFilters
		/// </summary>
		/// <returns>A GridFiltersCD object with a GridFilters DataTable</returns>
		public static GridFiltersCD GetGridFilters(string userName, string gridName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ds = new GridFiltersCD();
				var ta = new GridFiltersCDTableAdapters.GridFiltersTableAdapter();
				ta.Fill(ds.GridFilters, userName, gridName);
				return ds;
			}
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update Grid Filters
		/// </summary>
		/// <param name="ds">A DataSet of type GridFiltersCD</param>
		/// <returns>A GridFiltersCD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static GridFiltersCD UpdateGridFilters(DataSet ds)
		{
			if (ds == null || ds.Tables["GridFilters"] == null)
				throw new Exception("The DataSet and/or DataTable is null.");

			var clientDataSet = new GridFiltersCD();
			clientDataSet.Merge(ds, false, MissingSchemaAction.Ignore);

			#region Update GridFilters

			if (clientDataSet.GridFilters.Select("", "", DataViewRowState.Added).Length > 0)
			{
				var gridFiltersTD = new GridFiltersTD();
				gridFiltersTD.GridFilters.BeginLoadData();
				gridFiltersTD.GridFilters.Merge(clientDataSet.GridFilters, false, MissingSchemaAction.Ignore);

				using (var ts = new TransactionScope(TransactionScopeOption.Required))
				{
					GridFiltersTD.UpdateGridFilters(gridFiltersTD);
					ts.Complete();
				}
			}
			#endregion

			return clientDataSet;
		}

		#endregion

		#region Client Code

		#region Try-to-Use Service Types
		/// <summary>
		/// Use Win Services.
		/// </summary>
		public bool UseWcfService = true;
		/// <summary>
		/// Use Web Services.
		/// </summary>
		public bool UseAsmxService = true;
		/// <summary>
		/// Use Client/Server (last resort).
		/// </summary>
		public bool UseClientServer = true;
		#endregion

		/// <summary>
		/// Client callable code to get GridFilters.
		/// </summary>
		/// <returns>True if get is successful</returns>
		public bool ClientGetGridFilters(string userName, string gridName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			if (UseWcfService)
			{
				try
				{
					var svWCF = new WCF.SettingsContractClient();
					var rqWCF = new WCF.GetGridFiltersRequest {UserName = userName, GridName = gridName};

					WCF.GetGridFiltersResponse rsWCF = svWCF.GetGridFilters(rqWCF);
					Merge(rsWCF.GridFiltersCD, false, MissingSchemaAction.Ignore);
					return true;
				}
				catch { UseWcfService = false; } // ignore if not responding
			}
			if (UseAsmxService)
			{
				try
				{
					var svASMX = new ASMX.SettingsServiceASMX();
// ReSharper disable RedundantNameQualifier
					var rqASMX = new ASMX.GetGridFiltersRequest {UserName = userName, GridName = gridName};
// ReSharper restore RedundantNameQualifier

					ASMX.GetGridFiltersResponse rsASMX = svASMX.GetGridFilters(rqASMX);
					Merge(rsASMX.GridFiltersCD, false, MissingSchemaAction.Ignore);
					return true;
				}
				catch { UseAsmxService = false; } // ignore if not responding
			}
			if (UseClientServer)
			{
				try
				{
					Merge(GetGridFilters(userName, gridName));
					return true;
				}
				catch { UseClientServer = false; } // ignore if not responding
			}

			return false;
		}
		#region public void ClientGetGridFiltersAsync(string userName, string gridName)
		/// <summary>
		/// Event fired when GetAsyncCompleted
		/// </summary>
		public event EventHandler ClientGetGridFiltersCompleted;
		/// <summary>
		///  Client callable code to get all GridFilters async
		/// </summary>
		public void ClientGetGridFiltersAsync(string userName, string gridName)
		{
			if (UseWcfService)
			{
				try
				{
					var svWCF = new WCF.SettingsContractClient();
					svWCF.Ping();		

					var rqWCF = new WCF.GetGridFiltersRequest {UserName = userName, GridName = gridName};

					svWCF.BeginGetGridFilters(rqWCF, wcf_ClientGetGridFiltersCompleted, svWCF);
				}
				catch { UseWcfService = false; } // ignore if not responding
			}
			if (UseAsmxService)
			{
				try
				{
					var svASMX = new ASMX.SettingsServiceASMX();

// ReSharper disable RedundantNameQualifier
					var rqASMX = new ASMX.GetGridFiltersRequest {UserName = userName, GridName = gridName};
// ReSharper restore RedundantNameQualifier

					svASMX.GetGridFiltersCompleted += asmx_ClientGetGridFiltersCompleted;
					svASMX.GetGridFiltersAsync(rqASMX);
				}
				catch { UseAsmxService = false; } // ignore if not responding
			}
			if (UseClientServer)
			{
				try
				{
					DataSet result = GetGridFilters(userName, gridName);
// ReSharper disable RedundantNameQualifier
					var rs = new ASMX.GetGridFiltersResponse {GridFiltersCD = new ASMX.GridFiltersCD()};
// ReSharper restore RedundantNameQualifier
					rs.GridFiltersCD.Merge(result, false, MissingSchemaAction.Ignore);
// ReSharper disable RedundantNameQualifier
					var e = new ASMX.GetGridFiltersCompletedEventArgs(new object[] { rs }, null, false, null);
// ReSharper restore RedundantNameQualifier
					asmx_ClientGetGridFiltersCompleted(this, e);
				}
				catch { UseClientServer = false; } // ignore if not responding
			}
		}
		private void wcf_ClientGetGridFiltersCompleted(IAsyncResult ar)
		{
			try
			{
				WCF.GetGridFiltersResponse rsWCF = ((WCF.SettingsContractClient)ar.AsyncState).EndGetGridFilters(ar);
				Merge(rsWCF.GridFiltersCD, false, MissingSchemaAction.Ignore);
				ClientGetGridFiltersCompleted(this, new EventArgs());
			}
			catch { }
		}
// ReSharper disable RedundantNameQualifier
		private void asmx_ClientGetGridFiltersCompleted(object sender, ASMX.GetGridFiltersCompletedEventArgs e)
// ReSharper restore RedundantNameQualifier
		{
			try
			{
				ASMX.GetGridFiltersResponse rsASMX = e.Result;
				Merge(rsASMX.GridFiltersCD, false, MissingSchemaAction.Ignore);
				ClientGetGridFiltersCompleted(this, new EventArgs());
			}
			catch { }
		}
		#endregion

		/// <summary>
		///  callable code to Delete/Insert/Update Issues
		/// </summary>
		/// <param name="ds">A DataSet of type GridFiltersCD</param>
		/// <returns>A GridFiltersCD DataSet. If ALL OK contains updated data, if not contains the RowErrors</returns>
		public DataSet ClientUpdateGridFilters(DataSet ds)
		{
			if (ds.Tables["Issues"].Select("", "", DataViewRowState.Deleted).Length > 0 ||
				ds.Tables["Issues"].Select("", "", DataViewRowState.Added).Length > 0 ||
				ds.Tables["Issues"].Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
			{
				if (UseWcfService)
				{
					try
					{
						var svWCF = new WCF.SettingsContractClient();
						var rqWCF = new WCF.UpdateGridFiltersRequest {GridFiltersCD = new WCF.GridFiltersCD()};
						rqWCF.GridFiltersCD.Merge(ds, false, MissingSchemaAction.Ignore);
						WCF.UpdateGridFiltersResponse rsWCF = svWCF.UpdateGridFilters(rqWCF);
						return rsWCF.GridFiltersCD;
					}
					catch { UseWcfService = false; } // ignore if not responding
				}
				if (UseAsmxService)
				{
					try
					{
						var svASMX = new ASMX.SettingsServiceASMX();
// ReSharper disable RedundantNameQualifier
						var rqASMX = new ASMX.UpdateGridFiltersRequest {GridFiltersCD = new ASMX.GridFiltersCD()};
// ReSharper restore RedundantNameQualifier
						rqASMX.GridFiltersCD.Merge(ds, false, MissingSchemaAction.Ignore);
						ASMX.UpdateGridFiltersResponse rsASMX = svASMX.UpdateGridFilters(rqASMX);
						return rsASMX.GridFiltersCD;
					}
					catch { UseAsmxService = false; } // ignore if not responding
				}
				if (UseClientServer)
				{
					try
					{
						var issuesCD = new GridFiltersCD();
						issuesCD.Merge(ds, false, MissingSchemaAction.Ignore);
						return UpdateGridFilters(issuesCD);
					}
					catch { UseClientServer = false; } // ignore if not responding
				}

				return ds; // returns no changes if errors
			}

			return ds;
		}

		#region public void ClientUpdateGridFiltersAsync(DataSet ds)
		/// <summary>
			/// Event fired when UpdateAsyncCompleted
			/// </summary>
		public event AsyncDataSetCompletedEventHandler ClientUpdateGridFiltersCompleted;
		/// <summary>
		///  callable code to Delete/Insert/Update Issues
		/// </summary>
		/// <param name="ds">A DataSet of type GridFiltersCD</param>
		public void ClientUpdateGridFiltersAsync(DataSet ds)
		{
			if (ds.Tables["Issues"].Select("", "", DataViewRowState.Deleted).Length > 0 ||
				ds.Tables["Issues"].Select("", "", DataViewRowState.Added).Length > 0 ||
				ds.Tables["Issues"].Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
			{
				if (UseWcfService)
				{
					try
					{
						var svWCF = new WCF.SettingsContractClient();
						svWCF.Ping();

						var rqWCF = new WCF.UpdateGridFiltersRequest {GridFiltersCD = new WCF.GridFiltersCD()};
						rqWCF.GridFiltersCD.Merge(ds, false, MissingSchemaAction.Ignore);
						svWCF.BeginUpdateGridFilters(rqWCF, wcf_ClientUpdateGridFiltersCompleted, svWCF);
					}
					catch { UseWcfService = false; } // ignore if not responding
				}
				if (UseAsmxService)
				{
					try
					{
						var svASMX = new ASMX.SettingsServiceASMX();
// ReSharper disable RedundantNameQualifier
						var rqASMX = new ASMX.UpdateGridFiltersRequest {GridFiltersCD = new ASMX.GridFiltersCD()};
// ReSharper restore RedundantNameQualifier
						rqASMX.GridFiltersCD.Merge(ds, false, MissingSchemaAction.Ignore);
						svASMX.UpdateGridFiltersCompleted += asmx_ClientUpdateGridFiltersCompleted;
						svASMX.UpdateGridFiltersAsync(rqASMX);
					}
					catch { UseAsmxService = false; } // ignore if not responding
				}
				if (UseClientServer)
				{
					try
					{
						var issuesCD = new GridFiltersCD();
						issuesCD.Merge(ds, false, MissingSchemaAction.Ignore);
						issuesCD = UpdateGridFilters(issuesCD);

// ReSharper disable RedundantNameQualifier
						var rs = new ASMX.UpdateGridFiltersResponse();
// ReSharper restore RedundantNameQualifier
						rs.GridFiltersCD.Merge(issuesCD, false, MissingSchemaAction.Ignore);
// ReSharper disable RedundantNameQualifier
						var e = new ASMX.UpdateGridFiltersCompletedEventArgs(new object[] { rs }, null, false, null);
// ReSharper restore RedundantNameQualifier
						asmx_ClientUpdateGridFiltersCompleted(null, e);

					}
					catch { UseClientServer = false; } // ignore if not responding
				}
			}
		}
		private void wcf_ClientUpdateGridFiltersCompleted(IAsyncResult ar)
		{
			try
			{
				WCF.UpdateGridFiltersResponse rs = ((WCF.SettingsContractClient)ar.AsyncState).EndUpdateGridFilters(ar);

				var results = new object[1];
				results[0] = rs.GridFiltersCD;
				ClientUpdateGridFiltersCompleted(this, new AsyncDataSetCompletedEventArgs(results, null, false, null));
			}
			catch { }
		}
// ReSharper disable RedundantNameQualifier
		private void asmx_ClientUpdateGridFiltersCompleted(object sender, ASMX.UpdateGridFiltersCompletedEventArgs e)
// ReSharper restore RedundantNameQualifier
		{
			try
			{
				UpdateGridFiltersResponse rs = e.Result;

				var results = new object[1];
				results[0] = rs.GridFiltersCD;
				ClientUpdateGridFiltersCompleted(this, new AsyncDataSetCompletedEventArgs(results, e.Error, e.Cancelled, e.UserState));
			}
			catch { }
		}
		#endregion

		#endregion

		/// <summary>
		/// Sets the Caption text for the DataColumnCollection in the DataTable
		/// </summary>
		public static void ClientSetCaptions(DataTable clientTable)
		{
			DataTableUtils.SetCaptions(clientTable.Columns, new GridFiltersTD.GridFiltersDataTable().Columns);
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
				DataRowUtils.SetDefaultValues(this, new GridFiltersTD.GridFiltersDataTable().Columns);
			}

			/// <summary>
			/// Validates the current GridFiltersRow.
			///   This ClientRow only validates the columns it uses from each different TableRow
			/// </summary>
			/// <returns>The row is valid</returns>
			public bool IsValidRow()
			{
				//this.RowError += GridFiltersTD.CheckSomeColumn(SomeColumn.ToString());
				return !HasErrors;
			}
		}
	}
}
