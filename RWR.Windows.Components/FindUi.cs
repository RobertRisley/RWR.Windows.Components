using System;
using System.Windows.Forms;

namespace RWR.Windows.Components
{
	/// <summary>
	/// The Find window for the BaseGrid.
	/// </summary>
    public partial class FindUi : Form
    {
        private DataGridView _dataGridView = new DataGridView();

		/// <summary>
		/// The Find window for the BaseGrid.
        /// </summary>
        public FindUi()
        {
            InitializeComponent();

			_cboSearch.SelectedIndex = 0;
		}

		/// <summary>
		/// Sets the DataGridView to use for the Find.
		/// </summary>
		/// <param name="dataGridView">The DataGridView to use for the Find.</param>
		public void SetBaseDataGridView(DataGridView dataGridView)
		{
			if (dataGridView == null)
				DialogResult = DialogResult.Abort;
			else
				_dataGridView = dataGridView;
		}

		/// <summary>
		/// Enables the Find Next button if text is entered.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _txtFind_TextChanged(object sender, EventArgs e)
		{
			_btnFindNext.Enabled = _txtFind.Text.Length > 0;
		}

		private void _btnFind_Click(object sender, EventArgs e)
        {
			if (_dataGridView == null)
			{
				MessageBox.Show("SetBaseDataGridView has not been called", "FindUi Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
			}
			
			Cursor = Cursors.WaitCursor;
			try
			{
				var found = _cboSearch.Text == "Down" ? SearchDown() : SearchUp();

				if (!found)
					MessageBox.Show("The text [" + _txtFind.Text + "] was not found.", "Find Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { Cursor = Cursors.Default; }
		}
		private void _btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Search for the find value in the downward direction starting from the current cell
		/// </summary>
		/// <returns>True if conditionally found</returns>
		private bool SearchDown()
		{
			var currRow = _dataGridView.CurrentCell.RowIndex;
			var currCol = 0;
			if (_dataGridView.CurrentCell.ColumnIndex < _dataGridView.ColumnCount - 1)
				currCol = _dataGridView.CurrentCell.ColumnIndex + 1;
			else
				if (currRow < _dataGridView.RowCount - 1)
					currRow++;

			for (var row = currRow; row < _dataGridView.RowCount; row++)
			{
				for (var col = currCol; col < _dataGridView.ColumnCount; col++)
				{
					if (_dataGridView.Columns[col].Visible == false)
						continue;

					var cellValue = _dataGridView.Rows[row].Cells[col].FormattedValue;
					if (cellValue == null || !IsFindValueFound(cellValue.ToString())) continue;

					_dataGridView.CurrentCell = _dataGridView[col, row];
					return true;
				}
				currCol = 0;
			}
			return false;
		}
		/// <summary>
		/// Search for the find value in the upward direction starting from the current cell
		/// </summary>
		/// <returns>True if conditionally found</returns>
		private bool SearchUp()
		{
			var currRow = _dataGridView.CurrentCell.RowIndex;
			var currCol = _dataGridView.ColumnCount - 1;
			if (_dataGridView.CurrentCell.ColumnIndex > 0)
				currCol = _dataGridView.CurrentCell.ColumnIndex - 1;
			else
				if (currRow > 0)
					currRow--;

			for (var row = currRow; row >= 0; row--)
			{
				for (var col = currCol; col >= 0; col--)
				{
					if (_dataGridView.Columns[col].Visible == false)
						continue;

					var cellValue = _dataGridView.Rows[row].Cells[col].Value;
					if (cellValue == null || !IsFindValueFound(cellValue.ToString())) continue;

					_dataGridView.CurrentCell = _dataGridView[col, row];
					return true;
				}
				currCol = _dataGridView.ColumnCount - 1;
			}
			return false;
		}

		/// <summary>
		/// Determine if find value is in the cell
		/// </summary>
		/// <param name="cellValue">string representation of the cell value</param>
		/// <returns>True if conditionally found</returns>
		private bool IsFindValueFound(string cellValue)
        {
			var findValue = _txtFind.Text;
            var cellValueNoCase = cellValue.ToLower();
            var findValueNoCase = findValue.ToLower();

			// No case or whole word
            if (_chkMatchCase.Checked == false && _chkMatchWholeWord.Checked == false)
            {
            	return cellValueNoCase.IndexOf(findValueNoCase) != -1;
            }

            // Match whole word No case
			if (_chkMatchCase.Checked == false && _chkMatchWholeWord.Checked)
				return cellValueNoCase.Equals(findValueNoCase);

			// Match case No whole word
			if (_chkMatchCase.Checked && _chkMatchWholeWord.Checked == false)
			{
				return cellValue.IndexOf(_txtFind.Text) != -1;
			}

				// Match case and whole word
			if (_chkMatchCase.Checked && _chkMatchWholeWord.Checked)
				return cellValue.Equals(findValue);

			return false;
		}
	}
}