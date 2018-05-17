using System.Windows.Forms;

namespace RWR.Windows.Components
{
	/// <summary>
	/// The BaseForm for Forms using BaseGrid.
	/// </summary>
	public partial class BaseFormBaseGrid : BaseForm
	{
		/// <summary>
		/// The grid needs to be formatted.
		/// </summary>
		public bool FormatGrid = true;

		/// <summary>
		/// The BaseForm for Forms using BaseGrid.
		/// </summary>
		public BaseFormBaseGrid()
		{
			InitializeComponent();
		}

		private void BaseFormBaseGrid_FormClosing(object sender, FormClosingEventArgs e)
		{
			Grid.GridSettings_Save();
		}
	}
}

