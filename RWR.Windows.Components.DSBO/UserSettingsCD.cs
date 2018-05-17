using System;
using System.Data;
using System.IO;
using System.Transactions;
using RWR.Common;
using ASMX = RWR.Windows.Components.DSBO.SettingsServiceASMX;
using WCF = RWR.Windows.Components.DSBO.SettingsServiceWCF;

namespace RWR.Windows.Components.DSBO
{
	/// <summary>
	/// A UserSettings Client DataSet
	/// </summary>
	partial class UserSettingsCD
	{
		#region Service Code

		/// <summary>
		/// Service callable code to get UserSettings
		/// </summary>
		/// <returns>A SettingsCD object with a UserSettings DataTable</returns>
		public static UserSettingsCD GetUserSettings(string userName)
		{
			if (string.IsNullOrEmpty(userName))
				throw new Exception("The UserName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var ds = new UserSettingsCD();
				var ta = new UserSettingsCDTableAdapters.UserSettingsTableAdapter();
				ta.Fill(ds.UserSettings, userName);
				return ds;
			}
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update User Settings
		/// </summary>
		/// <param name="ds">A DataSet of type UserSettingsCD</param>
		/// <returns>A UserSettingsCD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static UserSettingsCD UpdateUserSettings(DataSet ds)
		{
			if (ds == null || ds.Tables["UserSettings"] == null)
				throw new Exception("The DataSet and/or DataTable is null.");

			var clientDataSet = new UserSettingsCD();
			clientDataSet.Merge(ds, false, MissingSchemaAction.Ignore);

			if (clientDataSet.UserSettings.Select("", "", DataViewRowState.Deleted).Length > 0 ||
				clientDataSet.UserSettings.Select("", "", DataViewRowState.Added).Length > 0 ||
				clientDataSet.UserSettings.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
			{
				var tblDataSet = new UserSettingsTD.UserSettingsDataTable();

				if (clientDataSet.UserSettings.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
				{
					var modifiedUserSetting = new UserSettingsDataTable();

					foreach (UserSettingsRow modifiedRow in clientDataSet.UserSettings.Select("", "", DataViewRowState.ModifiedCurrent))
					{
						modifiedUserSetting.Clear();
						modifiedUserSetting.ImportRow(modifiedRow);

						tblDataSet.Merge(UserSettingsTD.GetUserSetting(modifiedRow.UserName));
						tblDataSet.Merge(modifiedUserSetting, false, MissingSchemaAction.Ignore);
					}
				}

				var userSettingsTD = new UserSettingsTD();
				userSettingsTD.UserSettings.BeginLoadData();
				userSettingsTD.UserSettings.Merge(clientDataSet.UserSettings, false, MissingSchemaAction.Ignore);
				userSettingsTD.UserSettings.Merge(tblDataSet, false, MissingSchemaAction.Ignore);

				using (var ts = new TransactionScope(TransactionScopeOption.Required))
				{
					UserSettingsTD.UpdateUserSettings(userSettingsTD);
					ts.Complete();
				}
			}

			return clientDataSet;
		}

		#endregion

		#region Client Code

		#region Private Members

		private string _userName = string.Empty;
		private bool _createUserSettings;

		#endregion

		#region Properties

		/// <summary>
		/// The SystemInformation.UserName value.
		/// </summary>
		public string UserName
		{
			get { return System.Windows.Forms.SystemInformation.UserName; }
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
		/// Client callable code to get UserSettings.
		/// </summary>
		/// <param name="userName">The User name</param>
		/// <param name="async">Do the update async</param>
		/// <returns>True if get successful.</returns>
		public bool ClientGetUserSettings(string userName, bool async)
		{
			if (string.IsNullOrEmpty(userName))
				throw new Exception("The UserName is null or empty.");

			_userName = userName;

			if (UseWcfService)
			{
				try
				{
					var svWCF = new WCF.SettingsContractClient();
					var rqWCF = new WCF.GetUserSettingsRequest {UserName = userName};

					if (async)
					{
						if (String.IsNullOrEmpty(svWCF.Ping()))
							throw new Exception("WCF is offline.");

						svWCF.BeginGetUserSettings(rqWCF, wcf_ClientGetUserSettingsCompleted, svWCF);
						return true;
					}
					WCF.GetUserSettingsResponse rsWCF = svWCF.GetUserSettings(rqWCF);
					PrepareDataAfterGet(rsWCF.UserSettingsCD);
					Merge(rsWCF.UserSettingsCD, false, MissingSchemaAction.Ignore);
					return true;
				}
				catch { UseWcfService = false; } // ignore if not responding
			}
			if (UseAsmxService)
			{
				try
				{
					var svASMX = new ASMX.SettingsServiceASMX();
					var rqASMX = new ASMX.GetUserSettingsRequest {UserName = userName};

					if (async)
					{
						svASMX.GetUserSettingsCompleted += asmx_ClientGetUserSettingsCompleted;
						svASMX.GetUserSettingsAsync(rqASMX);
						return true;
					}

					ASMX.GetUserSettingsResponse rsASMX = svASMX.GetUserSettings(rqASMX);
					PrepareDataAfterGet(rsASMX.UserSettingsCD);
					Merge(rsASMX.UserSettingsCD, false, MissingSchemaAction.Ignore);
					return true;
				}
				catch { UseAsmxService = false; } // ignore if not responding
			}
			if (UseClientServer)
			{
				try
				{
					UserSettingsCD userSettings = GetUserSettings(userName);
					PrepareDataAfterGet(userSettings);
					Merge(userSettings, false, MissingSchemaAction.Ignore);
					return true;
				}
				catch { UseClientServer = false; } // ignore if not responding
			}

			return false;
		}
		/// <summary>
		/// Event fired when GetAsyncCompleted
		/// </summary>
		public event EventHandler ClientGetUserSettingsCompleted;
		private void wcf_ClientGetUserSettingsCompleted(IAsyncResult ar)
		{
			try
			{
				WCF.GetUserSettingsResponse rsWCF = ((WCF.SettingsContractClient)ar.AsyncState).EndGetUserSettings(ar);
				PrepareDataAfterGet(rsWCF.UserSettingsCD);
				Merge(rsWCF.UserSettingsCD, false, MissingSchemaAction.Ignore);
				ClientGetUserSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}
		private void asmx_ClientGetUserSettingsCompleted(object sender, ASMX.GetUserSettingsCompletedEventArgs e)
		{
			try
			{
				ASMX.GetUserSettingsResponse rsASMX = e.Result;
				PrepareDataAfterGet(rsASMX.UserSettingsCD);
				Merge(rsASMX.UserSettingsCD, false, MissingSchemaAction.Ignore);
				ClientGetUserSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}

		/// <summary>
		/// Client callable code to update UserSettings.
		/// </summary>
		/// <param name="async">Do the update async.</param>
		/// <returns>True if update is successful. If False, check for RowErrors.</returns>
		public bool ClientUpdateUserSettings(bool async)
		{
			if (string.IsNullOrEmpty(_userName))
				throw new Exception("The UserName and/or FormName is null or empty.");

			PrepareDataBeforeUpdate();

			if (UserSettings.Select("", "", DataViewRowState.Deleted).Length > 0 ||
				UserSettings.Select("", "", DataViewRowState.Added).Length > 0 ||
				UserSettings.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
			{
				var ds = new UserSettingsCD();
				foreach (UserSettingsRow deletedRow in UserSettings.Select("", "", DataViewRowState.Deleted))
					ds.UserSettings.ImportRow(deletedRow);
				foreach (UserSettingsRow addedRow in UserSettings.Select("", "", DataViewRowState.Added))
					ds.UserSettings.ImportRow(addedRow);
				foreach (UserSettingsRow modifiedCurrentRow in UserSettings.Select("", "", DataViewRowState.ModifiedCurrent))
					ds.UserSettings.ImportRow(modifiedCurrentRow);

				if (UseWcfService)
				{
					try
					{
						var svWCF = new WCF.SettingsContractClient();
						var rqWCF = new WCF.UpdateUserSettingsRequest {UserSettingsCD = new WCF.UserSettingsCD()};
						rqWCF.UserSettingsCD.Merge(ds, false, MissingSchemaAction.Ignore);

						if (async)
						{
							if (String.IsNullOrEmpty(svWCF.Ping()))
								throw new Exception("WCF is offline.");

							svWCF.BeginUpdateUserSettings(rqWCF, wcf_ClientUpdateUserSettingsCompleted, svWCF);
							return true;
						}

						WCF.UpdateUserSettingsResponse rsWCF = svWCF.UpdateUserSettings(rqWCF);
						Merge(rsWCF.UserSettingsCD, false, MissingSchemaAction.Ignore);
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
						var rqASMX = new ASMX.UpdateUserSettingsRequest {UserSettingsCD = new ASMX.UserSettingsCD()};
						rqASMX.UserSettingsCD.Merge(ds, false, MissingSchemaAction.Ignore);

						if (async)
						{
							svASMX.UpdateUserSettingsCompleted += asmx_ClientUpdateUserSettingsCompleted;
							svASMX.UpdateUserSettingsAsync(rqASMX);
							return true;
						}

						ASMX.UpdateUserSettingsResponse rsASMX = svASMX.UpdateUserSettings(rqASMX);
						Merge(rsASMX.UserSettingsCD, false, MissingSchemaAction.Ignore);
						PrepareDataAfterUpdate();
						return true;
					}
					catch { UseAsmxService = false; } // ignore if not responding
				}
				if (UseClientServer)
				{
					try
					{
						Merge(UpdateUserSettings(ds), false, MissingSchemaAction.Ignore);
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
		public event EventHandler ClientUpdateUserSettingsCompleted;
		private void wcf_ClientUpdateUserSettingsCompleted(IAsyncResult ar)
		{
			try
			{
				WCF.UpdateUserSettingsResponse rsWCF = ((WCF.SettingsContractClient)ar.AsyncState).EndUpdateUserSettings(ar);
				Merge(rsWCF.UserSettingsCD, false, MissingSchemaAction.Ignore);
				PrepareDataAfterUpdate();
				ClientUpdateUserSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}
		private void asmx_ClientUpdateUserSettingsCompleted(object sender, ASMX.UpdateUserSettingsCompletedEventArgs e)
		{
			try
			{
				var rsASMX = new ASMX.UpdateUserSettingsResponse();
				Merge(rsASMX.UserSettingsCD, false, MissingSchemaAction.Ignore);
				PrepareDataAfterUpdate();
				ClientUpdateUserSettingsCompleted(this, new EventArgs());
			}
			catch { }
		}

		/// <summary>
		/// Prepare any Data after Get is completed.
		/// </summary>
		private void PrepareDataAfterGet(DataSet userSettings)
		{
			// Reads the Settings from UserSettingsXml column.
			if (userSettings.Tables["UserSettings"] != null && userSettings.Tables["UserSettings"].Rows.Count > 0)
			{
				_createUserSettings = false;
				userSettings.Tables["Settings"].ReadXml(
					new StringReader(userSettings.Tables["UserSettings"].Rows[0]["UserSettingsXml"].ToString()));
			}
			else
				_createUserSettings = true;
		}

		/// <summary>
		/// Prepare any Data before Update is started.
		/// </summary>
		private void PrepareDataBeforeUpdate()
		{
			try
			{
				var sw = new StringWriter();
				Settings.WriteXml(sw);

				UserSettingsRow userSettingsRow;
				if (_createUserSettings)
				{
					userSettingsRow = UserSettings.NewUserSettingsRow();
					userSettingsRow.UserName = _userName;
				}
				else
					userSettingsRow = UserSettings.FindByUserName(UserName);

				userSettingsRow.UserSettingsXml = sw.ToString();

				if (_createUserSettings)
					UserSettings.Rows.Add(userSettingsRow);
			}
			catch
			{
				throw new Exception("There was an error with the KeyValuePairs Xml.");
			}
		}

		/// <summary>
		/// Prepare any Data after Update is completed.
		/// </summary>
		private void PrepareDataAfterUpdate()
		{
			if (UserSettings.Rows.Count > 0)
				_createUserSettings = false;
		}

		/// <summary>
		/// Sets the Caption text for the DataColumnCollection in the DataTable
		/// </summary>
		public void ClientSetCaptions()
		{
			DataTableUtils.SetCaptions(UserSettings.Columns, new UserSettingsTD.UserSettingsDataTable().Columns);
		}

		/// <summary>
		/// Gets a UserSetting key/value pair
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string GetValue(string key)
		{
			string value = null;

			UserSettingsCD.SettingsRow settingsRow = Settings.FindByKey(key);
			if (settingsRow != null)
				value = settingsRow.Value;

			return value;
		}

		/// <summary>
		/// Sets a UserSetting key/value pair
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool SetValue(string key, string value)
		{
			try
			{
				UserSettingsCD.SettingsRow settingsRow = Settings.FindByKey(key);
				if (settingsRow != null)
					settingsRow.Value = value;
				else
				{
					settingsRow = Settings.NewSettingsRow();
					settingsRow.Key = key;
					settingsRow.Value = value;
					Settings.Rows.Add(settingsRow);
				}
				return true;
			}
			catch { return false; }
		}

		#endregion

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
				DataRowUtils.SetDefaultValues(this, new UserSettingsTD.UserSettingsDataTable().Columns);
			}

			/// <summary>
			/// Validates the current UserSettingsRow.
			///   This ClientRow only validates the columns it uses from each different TableRow
			/// </summary>
			/// <returns>The row is valid</returns>
			public bool IsValidRow()
			{
				//this.RowError += UserSettingsTD.CheckSomeColumn(SomeColumn.ToString());
				return !HasErrors;
			}
		}
	}
}
