using System;
using System.Data;
using System.Transactions;
using System.Windows.Forms;
using RWR.Common;
using ASMX = RWR.Windows.Components.DSBO.SettingsServiceASMX;
using WCF = RWR.Windows.Components.DSBO.SettingsServiceWCF;

namespace RWR.Windows.Components.DSBO
{
	/// <summary>
	/// The GridSettings DBO
	/// </summary>
	partial class GridSettingsCD
	{
		#region Service Code

		/// <summary>
		/// Service callable code to get GridSettings
		/// </summary>
		/// <returns>A GridSettingsCD object with a GridSettings DataTable</returns>
		public static GridSettingsCD GetGridSettings(string userName, string gridName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ds = new GridSettingsCD();
				var ta = new GridSettingsCDTableAdapters.GridSettingsTableAdapter();
				ta.Fill(ds.GridSettings, userName, gridName);
				return ds;
			}
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update Grid Settings
		/// </summary>
		/// <param name="ds">A DataSet of type GridSettingsCD</param>
		/// <returns>A GridSettingsCD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static GridSettingsCD UpdateGridSettings(DataSet ds)
		{
			if (ds == null || ds.Tables["GridSettings"] == null)
				throw new Exception("The DataSet and/or DataTable is null.");

			var clientDataSet = new GridSettingsCD();
			clientDataSet.Merge(ds, false, MissingSchemaAction.Ignore);

			#region Update GridSettings
			var tblDataSet = new GridSettingsTD.GridSettingsDataTable();

			if (clientDataSet.GridSettings.Select("", "", DataViewRowState.Deleted).Length > 0 ||
				clientDataSet.GridSettings.Select("", "", DataViewRowState.Added).Length > 0 ||
				clientDataSet.GridSettings.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
			{
				if (clientDataSet.GridSettings.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
				{
					var modifiedGridSetting = new GridSettingsDataTable();

					foreach (GridSettingsRow modifiedRow in clientDataSet.GridSettings.Select("", "", DataViewRowState.ModifiedCurrent))
					{
						modifiedGridSetting.Clear();
						modifiedGridSetting.ImportRow(modifiedRow);

						tblDataSet.Merge(GridSettingsTD.GetGridSetting(modifiedRow.GridName, modifiedRow.GridName, modifiedRow.ColumnName));
						tblDataSet.Merge(modifiedGridSetting, false, MissingSchemaAction.Ignore);
					}
				}

				var gridSettingsTD = new GridSettingsTD();
				gridSettingsTD.GridSettings.BeginLoadData();
				gridSettingsTD.GridSettings.Merge(clientDataSet.GridSettings, false, MissingSchemaAction.Ignore);
				gridSettingsTD.GridSettings.Merge(tblDataSet, false, MissingSchemaAction.Ignore);


				using (var ts = new TransactionScope(TransactionScopeOption.Required))
				{
					GridSettingsTD.UpdateGridSettings(gridSettingsTD);
					ts.Complete();
				}
			}
			#endregion

			return clientDataSet;
		}

		/// <summary>
		/// Service callable code to delete GridSettings by UserName GridName
		/// </summary>
		public static bool ReplaceGridSettings(DataSet ds)
		{
			if (ds == null || ds.Tables["GridSettings"] == null)
				throw new Exception("The DataSet and/or DataTable is null.");

			var clientDataSet = new GridSettingsCD();
			clientDataSet.Merge(ds, false, MissingSchemaAction.Ignore);

			if (clientDataSet.GridSettings.Rows.Count > 0)
			{
				var userName = clientDataSet.GridSettings[0]["UserName"] as string;
				var gridName = clientDataSet.GridSettings[0]["GridName"] as string;

				var gridSettingsTD = new GridSettingsTD();
				gridSettingsTD.GridSettings.BeginLoadData();
				gridSettingsTD.GridSettings.Merge(clientDataSet.GridSettings, false, MissingSchemaAction.Ignore);

				using (var ts = new TransactionScope(TransactionScopeOption.Required))
				{
					GridSettingsTD.DeleteGridSettingsByUserNameGridName(userName, gridName);
					GridSettingsTD.UpdateGridSettings(gridSettingsTD);
					ts.Complete();
					return true;
				}
			}

			return false;
		}

		#endregion

		#region Client Code

		#region Private Members

		private string _userName = string.Empty;
		private string _gridName = string.Empty;

		#endregion

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			get { return _userName; } set { _userName = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string GridName
		{
			get { return _gridName; }
			set { _gridName = value; }
		}

		#endregion

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
		/// Client callable code to get GridSettings.
		/// </summary>
		/// <param name="userName">The User name</param>
		/// <param name="gridName">The Grid name</param>
		/// <param name="async">Do the update async</param>
		/// <returns>True if get successful.</returns>
		public bool ClientGetGridSettings(string userName, string gridName, bool async)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			_userName = userName;
			_gridName = gridName;

			if (UseWcfService)
			{
				try
				{
					var svWCF = new WCF.SettingsContractClient();
					var rqWCF = new WCF.GetGridSettingsRequest {UserName = userName, GridName = gridName};

					if (async)
					{
						if (String.IsNullOrEmpty(svWCF.Ping()))
							throw new Exception("WCF is offline.");

						svWCF.BeginGetGridSettings(rqWCF, wcf_ClientGetGridSettingsCompleted, svWCF);
						return true;
					}

					WCF.GetGridSettingsResponse rsWCF = svWCF.GetGridSettings(rqWCF);
					Merge(rsWCF.GridSettingsCD, false, MissingSchemaAction.Ignore);
					PrepareDataAfterGet();
					return true;
				}
				catch { UseWcfService = false; } // ignore if not responding
			}
			if (UseAsmxService)
			{
				try
				{
					var svASMX = new ASMX.SettingsServiceASMX();
					var rqASMX = new ASMX.GetGridSettingsRequest {UserName = userName, GridName = gridName};

					if (async)
					{
						svASMX.GetGridSettingsCompleted += asmx_ClientGetGridSettingsCompleted;
						svASMX.GetGridSettingsAsync(rqASMX);
						return true;
					}

					ASMX.GetGridSettingsResponse rsASMX = svASMX.GetGridSettings(rqASMX);
					Merge(rsASMX.GridSettingsCD, false, MissingSchemaAction.Ignore);
					PrepareDataAfterGet();
					return true;
				}
				catch { UseAsmxService = false; } // ignore if not responding
			}
			if (UseClientServer)
			{
				try
				{
					Merge(GetGridSettings(userName, gridName), false, MissingSchemaAction.Ignore);
					PrepareDataAfterGet();
					return true;
				}
				catch { UseClientServer = false; } // ignore if not responding
			}

			return false;
		}
		/// <summary>
		/// Event fired when GetAsyncCompleted
		/// </summary>
		public event EventHandler ClientGetGridSettingsCompleted;
		private void wcf_ClientGetGridSettingsCompleted(IAsyncResult ar)
		{
			try
			{
				WCF.GetGridSettingsResponse rsWCF = ((WCF.SettingsContractClient)ar.AsyncState).EndGetGridSettings(ar);
				Merge(rsWCF.GridSettingsCD, false, MissingSchemaAction.Ignore);
				PrepareDataAfterGet();
				ClientGetGridSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}
		private void asmx_ClientGetGridSettingsCompleted(object sender, ASMX.GetGridSettingsCompletedEventArgs e)
		{
			try
			{
				ASMX.GetGridSettingsResponse rsASMX = e.Result;
				Merge(rsASMX.GridSettingsCD, false, MissingSchemaAction.Ignore);
				PrepareDataAfterGet();
				ClientGetGridSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}

		/// <summary>
		/// Client callable code to update GridSettings.
		/// </summary>
		/// <param name="async">Do the update async.</param>
		/// <returns>True if update is successful. If False, check for RowErrors.</returns>
		public bool ClientUpdateGridSettings(bool async)
		{
			if (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			PrepareDataBeforeUpdate();

			if (GridSettings.Select("", "", DataViewRowState.Deleted).Length > 0 ||
				GridSettings.Select("", "", DataViewRowState.Added).Length > 0 ||
				GridSettings.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
			{
				var ds = new GridSettingsCD();
				foreach (GridSettingsRow deletedRow in GridSettings.Select("", "", DataViewRowState.Deleted))
					ds.GridSettings.ImportRow(deletedRow);
				foreach (GridSettingsRow addedRow in GridSettings.Select("", "", DataViewRowState.Added))
					ds.GridSettings.ImportRow(addedRow);
				foreach (GridSettingsRow modifiedCurrentRow in GridSettings.Select("", "", DataViewRowState.ModifiedCurrent))
					ds.GridSettings.ImportRow(modifiedCurrentRow);

				if (UseWcfService)
				{
					try
					{
						var svWCF = new WCF.SettingsContractClient();
						var rqWCF = new WCF.UpdateGridSettingsRequest {GridSettingsCD = new WCF.GridSettingsCD()};
						rqWCF.GridSettingsCD.Merge(ds, false, MissingSchemaAction.Ignore);

						if (async)
						{
							if (String.IsNullOrEmpty(svWCF.Ping()))
								throw new Exception("WCF is offline.");

							svWCF.BeginUpdateGridSettings(rqWCF, wcf_ClientUpdateGridSettingsCompleted, svWCF);
							return true;
						}

						WCF.UpdateGridSettingsResponse rsWCF = svWCF.UpdateGridSettings(rqWCF);
						Merge(rsWCF.GridSettingsCD, false, MissingSchemaAction.Ignore);
						PrepareDataAfterUpdate();
						return true;
					}
					catch { UseWcfService = false; } // ignore if not responding
				}
				if (UseAsmxService)
				{
					try
					{
						var svASMX = new ASMX.SettingsServiceASMX();
						var rqASMX = new ASMX.UpdateGridSettingsRequest {GridSettingsCD = new ASMX.GridSettingsCD()};
						rqASMX.GridSettingsCD.Merge(ds, false, MissingSchemaAction.Ignore);

						if (async)
						{
							svASMX.UpdateGridSettingsCompleted += asmx_ClientUpdateGridSettingsCompleted;
							svASMX.UpdateGridSettingsAsync(rqASMX);
							return true;
						}

						ASMX.UpdateGridSettingsResponse rsASMX = svASMX.UpdateGridSettings(rqASMX);
						Merge(rsASMX.GridSettingsCD, false, MissingSchemaAction.Ignore);
						PrepareDataAfterUpdate();
						return true;
					}
					catch { UseAsmxService = false; } // ignore if not responding
				}
				if (UseClientServer)
				{
					try
					{
						Merge(UpdateGridSettings(ds), false, MissingSchemaAction.Ignore);
						PrepareDataAfterUpdate();
						return true;
					}
					catch { UseClientServer = false; } // ignore if not responding
				}
			}
			return false;
		}
		/// <summary>
		/// Event fired when UpdateAsyncCompleted
		/// </summary>
		public event EventHandler ClientUpdateGridSettingsCompleted;
		private void wcf_ClientUpdateGridSettingsCompleted(IAsyncResult ar)
		{
			try
			{
				WCF.UpdateGridSettingsResponse rsWCF = ((WCF.SettingsContractClient)ar.AsyncState).EndUpdateGridSettings(ar);
				Merge(rsWCF.GridSettingsCD, false, MissingSchemaAction.Ignore);
				PrepareDataAfterUpdate();
				ClientUpdateGridSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}
		private void asmx_ClientUpdateGridSettingsCompleted(object sender, ASMX.UpdateGridSettingsCompletedEventArgs e)
		{
			try
			{
				var rsASMX = new ASMX.UpdateGridSettingsResponse();
				Merge(rsASMX.GridSettingsCD, false, MissingSchemaAction.Ignore);
				PrepareDataAfterUpdate();
				ClientUpdateGridSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}

		/// <summary>
		/// Prepare any Data after Get is completed.
		/// </summary>
		private void PrepareDataAfterGet()
		{
		}

		/// <summary>
		/// Prepare any Data before Update is started.
		/// </summary>
		private void PrepareDataBeforeUpdate()
		{
		}

		/// <summary>
		/// Prepare any Data after Update is completed.
		/// </summary>
		private void PrepareDataAfterUpdate()
		{
		}

		/// <summary>
		/// Sets the Caption text for the DataColumnCollection in the DataTable
		/// </summary>
		public void ClientSetCaptions()
		{
			DataTableUtils.SetCaptions(GridSettings.Columns, new GridSettingsTD.GridSettingsDataTable().Columns);
		}

		/// <summary>
		/// Save the Grid Settings to the database from a DataGridView
		/// </summary>
		/// <param name="dataGridView">The DataGridView to derive the GridSettings from</param>
		/// <param name="async">Do the update async</param>
		/// <returns>true if replaced</returns>
		public bool ClientUpdateGridSettingsFromDataGridView(DataGridView dataGridView, bool async)
		{
			if (dataGridView == null || dataGridView.Columns.Count == 0)
				throw new Exception("The DataGridView is null or empty.");

			if (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_gridName))
				throw new Exception("The UserName and/or GridName is null or empty.");

			var ds = new GridSettingsCD();
			GridSettingsRow gridSettingsRow;
			for (int i = 0; i < dataGridView.Columns.Count; i++)
			{
				gridSettingsRow = ds.GridSettings.NewGridSettingsRow();
				gridSettingsRow.SetDefaultValues();
				gridSettingsRow.UserName = SystemInformation.UserName;
				gridSettingsRow.GridName = _gridName;
				gridSettingsRow.ColumnName = dataGridView.Columns[i].Name;
				gridSettingsRow.Visible = dataGridView.Columns[i].Visible;
				gridSettingsRow.DisplayIndex = dataGridView.Columns[i].DisplayIndex;
				gridSettingsRow.Width = dataGridView.Columns[i].Width;
				ds.GridSettings.AddGridSettingsRow(gridSettingsRow);
			}

			if (UseWcfService)
			{
				try
				{
					var svWCF = new WCF.SettingsContractClient();
					var rqWCF = new WCF.ReplaceGridSettingsRequest {GridSettingsCD = new WCF.GridSettingsCD()};
					rqWCF.GridSettingsCD.Merge(ds, false, MissingSchemaAction.Ignore);

					if (async)
					{
						svWCF.Ping();
						svWCF.BeginReplaceGridSettings(rqWCF, wcf_ClientReplaceGridSettingsCompleted, svWCF);
						return true;
					}

					WCF.ReplaceGridSettingsResponse rsWCF = svWCF.ReplaceGridSettings(rqWCF);
					return rsWCF.ReplaceSuccessful;
				}
				catch { UseWcfService = false; } // ignore if not responding
			}
			if (UseAsmxService)
			{
				try
				{
					var svASMX = new ASMX.SettingsServiceASMX();
					var rqASMX = new ASMX.ReplaceGridSettingsRequest {GridSettingsCD = new ASMX.GridSettingsCD()};
					rqASMX.GridSettingsCD.Merge(ds, false, MissingSchemaAction.Ignore);

					if (async)
					{
						svASMX.ReplaceGridSettingsCompleted += asmx_ClientReplaceGridSettingsCompleted;
						svASMX.ReplaceGridSettingsAsync(rqASMX);
						return true;
					}

					ASMX.ReplaceGridSettingsResponse rsASMX = svASMX.ReplaceGridSettings(rqASMX);
					return rsASMX.ReplaceSuccessful;
				}
				catch { UseAsmxService = false; } // ignore if not responding
			}
			if (UseClientServer)
			{
				try
				{
					return ReplaceGridSettings(ds);
				}
				catch { UseClientServer = false; } // ignore if not responding
			}

			return false;
		}
		/// <summary>
		/// Event fired when ReplaceAsyncCompleted
		/// </summary>
		public event EventHandler ClientReplaceGridSettingsCompleted;
		private void wcf_ClientReplaceGridSettingsCompleted(IAsyncResult ar)
		{
			try
			{
				WCF.ReplaceGridSettingsResponse rsWCF = ((WCF.SettingsContractClient)ar.AsyncState).EndReplaceGridSettings(ar);
#pragma warning disable 168
				var success = rsWCF.ReplaceSuccessful;
#pragma warning restore 168
				ClientReplaceGridSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}
		private void asmx_ClientReplaceGridSettingsCompleted(object sender, ASMX.ReplaceGridSettingsCompletedEventArgs e)
		{
			try
			{
				var rsASMX = new ASMX.ReplaceGridSettingsResponse();
#pragma warning disable 168
				var success = rsASMX.ReplaceSuccessful;
#pragma warning restore 168
				ClientReplaceGridSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}

		#endregion

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
				DataRowUtils.SetDefaultValues(this, new GridSettingsTD.GridSettingsDataTable().Columns);
			}

			/// <summary>
			/// Validates the current GridSettingsRow.
			///   This ClientRow only validates the columns it uses from each different TableRow
			/// </summary>
			/// <returns>The row is valid</returns>
			public bool IsValidRow()
			{
				//this.RowError += GridSettingsTD.CheckSomeColumn(SomeColumn.ToString());
				return !HasErrors;
			}
		}
	}
}
