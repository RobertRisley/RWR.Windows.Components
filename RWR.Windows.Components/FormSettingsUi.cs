using System.Drawing;
using System.Windows.Forms;
using RWR.Common;
using RWR.Windows.Components.DSBO;

namespace RWR.Windows.Components
{
	/// <summary>
	/// A Window that allows the Editing of FormSettings
	/// </summary>
	public partial class FormSettingsUi : Form
	{
		#region Private Members

		private readonly FormSettingsCD _formSettings = new FormSettingsCD();

		#endregion

		/// <summary>
		/// A Window that allows the Editing of FormSettings
		/// </summary>
		public FormSettingsUi(FormSettingsCD formSettings)
		{
			InitializeComponent();

			_cboAltColor1.LoadColors(ColorSet.Web);

			if (formSettings != null)
				_formSettings = formSettings;

			var altColor1 = _formSettings.GetValue("AltColor1");
			if (altColor1 != null)
				_cboAltColor1.SelectedColor = Color.FromName(altColor1);
		}

		private void _btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				_formSettings.SetValue("AltColor1", _cboAltColor1.SelectedColor.Name);

				DialogResult = DialogResult.OK;
				Close();
			}
			catch { }
		}
		private void _btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}