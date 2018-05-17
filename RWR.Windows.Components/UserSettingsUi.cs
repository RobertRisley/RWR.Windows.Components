using System;
using System.Drawing;
using System.Windows.Forms;
using RWR.Common;
using RWR.Windows.Components.DSBO;

namespace RWR.Windows.Components
{
	/// <summary>
	/// The User Settings UI.
	/// </summary>
	public partial class UserSettingsUi : Form
	{
		#region Private Members
		private readonly UserSettingsCD _userSettings = new UserSettingsCD();
		#endregion

		/// <summary>
		/// A Window that allows the Editing of UserSettings
		/// </summary>
		public UserSettingsUi()
		{
			InitializeComponent();

			_cboAltColor1.LoadColors(ColorSet.Web);
			_cboAltColor2.LoadColors(ColorSet.Web);

			_userSettings.ClientGetUserSettingsCompleted += _userSettings_ClientGetUserSettingsCompleted;
			_userSettings.ClientGetUserSettings(_userSettings.UserName, true);
		}

		private void _userSettings_ClientGetUserSettingsCompleted(object sender, EventArgs e)
		{
			var altColor1 = _userSettings.GetValue("AltColor1");
			if (altColor1 != null)
				_cboAltColor1.SelectedColor = Color.FromName(altColor1);

			var altColor2 = _userSettings.GetValue("AltColor2");
			if (altColor2 != null)
				_cboAltColor2.SelectedColor = Color.FromName(altColor2);
		}

		/// <summary>
		/// A Window that allows the Editing of UserSettings
		/// </summary>
		public UserSettingsUi(UserSettingsCD userSettings)
		{
			InitializeComponent();

			_cboAltColor1.LoadColors(ColorSet.Web);
			_cboAltColor2.LoadColors(ColorSet.Web);

			if (userSettings != null)
				_userSettings = userSettings;

			var altColor1 = _userSettings.GetValue("AltColor1");
			if (altColor1 != null)
				_cboAltColor1.SelectedColor = Color.FromName(altColor1);

			var altColor2 = _userSettings.GetValue("AltColor2");
			if (altColor2 != null)
				_cboAltColor2.SelectedColor = Color.FromName(altColor2);
		}

		private void _btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				_userSettings.SetValue("AltColor1", _cboAltColor1.SelectedColor.Name);
				_userSettings.SetValue("AltColor2", _cboAltColor2.SelectedColor.Name);

				_userSettings.ClientUpdateUserSettings(false);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch { }
		}
		private void _btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}