using System;
using System.Data;
using System.IO;
using System.Transactions;
using System.Windows.Forms;
using RWR.Common;
using ASMX = RWR.Windows.Components.DSBO.SettingsServiceASMX;
using WCF = RWR.Windows.Components.DSBO.SettingsServiceWCF;

namespace RWR.Windows.Components.DSBO
{
	/// <summary>
	/// The FormSettings Client DataSet BusinessObject.
	/// </summary>
	partial class FormSettingsCD
	{
		#region Service Code

		/// <summary>
		/// Service callable code to get FormSettings
		/// </summary>
		/// <returns>A FormSettingsCD object with a FormSettings DataTable</returns>
		public static FormSettingsCD GetFormSettings(string userName, string formName)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userName))
				throw new Exception("The UserName and/or FormName is null or empty.");

			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				var cd = new FormSettingsCD();
				var ta = new FormSettingsCDTableAdapters.FormSettingsTableAdapter();
				ta.Fill(cd.FormSettings, userName, formName);
				ta.Dispose();
				return cd;
			}
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update FormSettings
		/// </summary>
		/// <param name="cd">A ClientDataSet of type FormSettingsCD</param>
		/// <returns>A FormSettingsCD ClientDataSet. If ALL OK contains updated data, if not contains the RowErrors</returns>
		public static FormSettingsCD UpdateFormSettings(FormSettingsCD cd)
		{
			if (cd == null || cd.Tables["FormSettings"] == null)
				throw new Exception("The DataSet and/or DataTable is null.");

			var tt = new FormSettingsTD.FormSettingsDataTable();
// ReSharper disable RedundantNameQualifier
			var ct = new FormSettingsCD.FormSettingsDataTable();
// ReSharper restore RedundantNameQualifier

			foreach (FormSettingsRow modifiedRow in cd.FormSettings.Select("", "", DataViewRowState.ModifiedCurrent))
			{
				ct.Clear(); // clear for next row to import
				ct.ImportRow(modifiedRow); // import single row into Table for merge

				tt.Merge(FormSettingsTD.GetFormSetting(modifiedRow.UserName, modifiedRow.FormName)); // populate with all current columns
				tt.Merge(ct, false, MissingSchemaAction.Ignore); // overlay with updated columns
			}

			var td = new FormSettingsTD();
			td.FormSettings.BeginLoadData();
			td.FormSettings.Merge(cd.FormSettings, false, MissingSchemaAction.Ignore);
			td.FormSettings.Merge(tt, false, MissingSchemaAction.Ignore);

			using (var ts = new TransactionScope(TransactionScopeOption.Required))
			{
				FormSettingsTD.UpdateFormSettings(td);
				ts.Complete();
			}

			return cd;
		}

		#endregion

		#region Client Code

		#region Private Members
		private string _userName = string.Empty;
		private string _formName = string.Empty;
		private bool _createFormSettings;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the FormWindowState value, defaults to Normal if missing.
		/// </summary>
		public FormWindowState WindowState
		{
			get
			{
				FormWindowState windowState;
				switch (GetValue("WindowState"))
				{
					case "Maximized":
						windowState = FormWindowState.Maximized;
						break;
					case "Minimized":
						windowState = FormWindowState.Minimized;
						break;
					default:
						windowState = FormWindowState.Normal;
						break;
				}
				return windowState;
			}
		}

		/// <summary>
		/// Gets the Form Height value, defaults to 559 if missing.
		/// </summary>
		public int Height
		{
			get
			{
				int height;
				if (false == int.TryParse(GetValue("Height"), out height))
					height = 559;
				return height;
			}
		}

		/// <summary>
		/// Gets the Form Width value, defaults to 800 if missing.
		/// </summary>
		public int Width
		{
			get
			{
				int width;
				if (false == int.TryParse(GetValue("Width"), out width))
					width = 800;
				return width;
			}
		}

		/// <summary>
		/// Gets the X,Y coordinates, defaults to 0,0 if missing.
		/// </summary>
		public System.Drawing.Point Location
		{
			get
			{
				int x;
				int.TryParse(GetValue("X"), out x);

				int y;
				int.TryParse(GetValue("Y"), out y);

				var location = new System.Drawing.Point(x, y);
				return location;
			}
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
		/// Client callable code to get FormSettings.
		/// </summary>
		/// <param name="userName">The User name</param>
		/// <param name="formName">The Form name</param>
		/// <param name="async">Do the update async</param>
		/// <returns>True if get successful.</returns>
		public bool ClientGetFormSettings(string userName, string formName, bool async)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(formName))
			{
				throw new Exception("The UserName and/or FormName is null or empty.");
			}

			_userName = userName;
			_formName = formName;

			if (UseWcfService)
			{
				try
				{
					var svWCF = new WCF.SettingsContractClient();
					var rqWCF = new WCF.GetFormSettingsRequest {UserName = userName, FormName = formName};

					if (async)
					{
						if (String.IsNullOrEmpty(svWCF.Ping()))
							throw new Exception("WCF is offline.");

						svWCF.BeginGetFormSettings(rqWCF, wcf_ClientGetFormSettingsCompleted, svWCF);
						return true;
					}

					WCF.GetFormSettingsResponse rsWCF = svWCF.GetFormSettings(rqWCF);
					Merge(rsWCF.FormSettingsCD, false, MissingSchemaAction.Ignore);
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
					var rqASMX = new ASMX.GetFormSettingsRequest {UserName = userName, FormName = formName};

					if (async)
					{
						svASMX.GetFormSettingsCompleted += asmx_ClientGetFormSettingsCompleted;
						svASMX.GetFormSettingsAsync(rqASMX);
						return true;
					}

					ASMX.GetFormSettingsResponse rsASMX = svASMX.GetFormSettings(rqASMX);
					Merge(rsASMX.FormSettingsCD, false, MissingSchemaAction.Ignore);
					PrepareDataAfterGet();
					return true;
				}
				catch { UseAsmxService = false; } // ignore if not responding
			}
			if (UseClientServer)
			{
				try
				{
					Merge(GetFormSettings(userName, formName), false, MissingSchemaAction.Ignore);
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
		public event EventHandler ClientGetFormSettingsCompleted;
		private void wcf_ClientGetFormSettingsCompleted(IAsyncResult ar)
		{
			WCF.GetFormSettingsResponse rsWCF = ((WCF.SettingsContractClient)ar.AsyncState).EndGetFormSettings(ar);
			Merge(rsWCF.FormSettingsCD, false, MissingSchemaAction.Ignore);
			PrepareDataAfterGet();
			ClientGetFormSettingsCompleted(this, new EventArgs());
		}
		private void asmx_ClientGetFormSettingsCompleted(object sender, ASMX.GetFormSettingsCompletedEventArgs e)
		{
			ASMX.GetFormSettingsResponse rsASMX = e.Result;
			Merge(rsASMX.FormSettingsCD, false, MissingSchemaAction.Ignore);
			PrepareDataAfterGet();
			ClientGetFormSettingsCompleted(this, new EventArgs());
		}

		/// <summary>
		/// Client callable code to update FormSettings.
		/// </summary>
		/// <param name="async">Do the update async.</param>
		/// <returns>True if update is successful. If False, check for RowErrors.</returns>
		public bool ClientUpdateFormSettings(bool async)
		{
			if (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_formName))
				throw new Exception("The UserName and/or FormName is null or empty.");

			PrepareDataBeforeUpdate();

			var updatedFormSettings = new FormSettingsCD();
			updatedFormSettings.Merge(Tables["FormSettings"].Select("", "", DataViewRowState.Deleted), false, MissingSchemaAction.Ignore);
			updatedFormSettings.Merge(Tables["FormSettings"].Select("", "", DataViewRowState.Added), false, MissingSchemaAction.Ignore);
			updatedFormSettings.Merge(Tables["FormSettings"].Select("", "", DataViewRowState.ModifiedCurrent), false, MissingSchemaAction.Ignore);

			if (updatedFormSettings.FormSettings.Rows.Count > 0)
			{
				if (UseWcfService)
				{
					try
					{
						var svWCF = new WCF.SettingsContractClient();
						var rqWCF = new WCF.UpdateFormSettingsRequest {FormSettingsCD = new WCF.FormSettingsCD()};
						rqWCF.FormSettingsCD.Merge(updatedFormSettings, false, MissingSchemaAction.Ignore);

						if (async)
						{
							if (String.IsNullOrEmpty(svWCF.Ping()))
								throw new Exception("WCF is offline.");

							svWCF.BeginUpdateFormSettings(rqWCF, wcf_ClientUpdateFormSettingsCompleted, svWCF);
							return true;
						}

						WCF.UpdateFormSettingsResponse rsWCF = svWCF.UpdateFormSettings(rqWCF);
						Merge(rsWCF.FormSettingsCD, false, MissingSchemaAction.Ignore);
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
						var rqASMX = new ASMX.UpdateFormSettingsRequest {FormSettingsCD = new ASMX.FormSettingsCD()};
						rqASMX.FormSettingsCD.Merge(updatedFormSettings, false, MissingSchemaAction.Ignore);

						if (async)
						{
							svASMX.UpdateFormSettingsCompleted += asmx_ClientUpdateFormSettingsCompleted;
							svASMX.UpdateFormSettingsAsync(rqASMX);
							return true;
						}

						ASMX.UpdateFormSettingsResponse rsASMX = svASMX.UpdateFormSettings(rqASMX);
						Merge(rsASMX.FormSettingsCD, false, MissingSchemaAction.Ignore);
						PrepareDataAfterUpdate();
						return true;
					}
					catch { UseAsmxService = false; } // ignore if not responding
				}
				if (UseClientServer)
				{
					try
					{
						Merge(UpdateFormSettings(updatedFormSettings), false, MissingSchemaAction.Ignore);
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
		public event EventHandler ClientUpdateFormSettingsCompleted;
		private void wcf_ClientUpdateFormSettingsCompleted(IAsyncResult ar)
		{
			WCF.UpdateFormSettingsResponse rsWCF = ((WCF.SettingsContractClient)ar.AsyncState).EndUpdateFormSettings(ar);
			Merge(rsWCF.FormSettingsCD, false, MissingSchemaAction.Ignore);
			PrepareDataAfterUpdate();
			ClientUpdateFormSettingsCompleted(this, new EventArgs());
		}
		private void asmx_ClientUpdateFormSettingsCompleted(object sender, ASMX.UpdateFormSettingsCompletedEventArgs e)
		{
			var rsASMX = new ASMX.UpdateFormSettingsResponse();
			Merge(rsASMX.FormSettingsCD, false, MissingSchemaAction.Ignore);
			PrepareDataAfterUpdate();
			ClientUpdateFormSettingsCompleted(this, new EventArgs());
		}

		/// <summary>
		/// Prepare any Data after Get is completed.
		/// </summary>
		private void PrepareDataAfterGet()
		{
			// Reads the Settings from FormSettingsXml column.
			if (FormSettings.Rows.Count > 0)
			{
				_createFormSettings = false;
				Settings.ReadXml(new StringReader(FormSettings[0].FormSettingsXml));
			}
			else
				_createFormSettings = true;
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

				FormSettingsRow userSettingsRow;
				if (_createFormSettings)
				{
					userSettingsRow = FormSettings.NewFormSettingsRow();
					userSettingsRow.UserName = _userName;
					userSettingsRow.FormName = _formName;
				}
				else
					userSettingsRow = FormSettings.FindByUserNameFormName(_userName, _formName);

				userSettingsRow.FormSettingsXml = sw.ToString();

				if (_createFormSettings)
					FormSettings.Rows.Add(userSettingsRow);
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
			if (FormSettings.Rows.Count > 0)
				_createFormSettings = false;
		}

		/// <summary>
		/// Sets the Caption text for the DataColumnCollection in the DataTable
		/// </summary>
		public void ClientSetCaptions()
		{
			DataTableUtils.SetCaptions(FormSettings.Columns, new FormSettingsTD.FormSettingsDataTable().Columns);
		}

		/// <summary>
		/// Gets a UserSetting key/value pair
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string GetValue(string key)
		{
			string value = null;

			SettingsRow settingsRow = Settings.FindByKey(key);
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
				SettingsRow settingsRow = Settings.FindByKey(key);
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
		/// A FormSettings row.
		/// </summary>
		public partial class FormSettingsRow
		{
			/// <summary>
			/// Set value for columns == DBNull to their DefaultValue  (if DefaultValue specified in XSD)
			/// </summary>
			public void SetDefaultValues()
			{
				DataRowUtils.SetDefaultValues(this, new FormSettingsTD.FormSettingsDataTable().Columns);
			}

			/// <summary>
			/// Validates the current FormSettingsRow.
			///   This ClientRow only validates the columns it uses from each different TableRow
			/// </summary>
			/// <returns>The row is valid</returns>
			public bool IsValidRow()
			{
				//this.RowError += FormSettingsTD.CheckSomeColumn(SomeColumn.ToString());
				return !HasErrors;
			}
		}
	}
}
