using System;
using System.Windows.Forms;

namespace RWR.Windows.Components
{
    /// <summary>
    /// A general purpose Columns Selector and Sequencer.
    /// </summary>
    public partial class ColumnsEditorUi : Form
	{
		#region Private Members

		private readonly DataGridView _dataGridView = new DataGridView();

		#endregion

		/// <summary>
		/// A general purpose Columns Selector and Sequencer.
        /// </summary>
        /// <param name="dataGridView"></param>
        public ColumnsEditorUi(DataGridView dataGridView)
        {
            InitializeComponent();

            _btnMoveUp.Enabled = false;

			if (dataGridView == null) return;

			_dataGridView = dataGridView;
			int columnIndex;
			for (columnIndex = 0; columnIndex < _dataGridView.Columns.Count; columnIndex++)
				_clbColumns.Items.Add("placeholder");

			for (columnIndex = 0; columnIndex < _dataGridView.Columns.Count; columnIndex++)
			{
				var displayIndex = _dataGridView.Columns[columnIndex].DisplayIndex;
				_clbColumns.Items[displayIndex] = _dataGridView.Columns[columnIndex].HeaderText;
				if (_dataGridView.Columns[columnIndex].Visible)
					_clbColumns.SetItemCheckState(displayIndex, CheckState.Checked);
				else
					_clbColumns.SetItemCheckState(displayIndex, CheckState.Unchecked);
			}

			if (_dataGridView.Columns.Count > 0)
				_clbColumns.SelectedIndex = 0;
        }

        private void _clbColumns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index < 0)
                return;

            var columnIndex = GetGridColumnIndex(e.Index);
        	if (columnIndex >= _dataGridView.Columns.Count) return;

        	_dataGridView.Columns[columnIndex].Visible = e.NewValue == CheckState.Checked;
        }
        private void _clbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
        	_btnMoveUp.Enabled = _clbColumns.SelectedIndex != 0;
        	_btnMoveDown.Enabled = _clbColumns.SelectedIndex != _clbColumns.Items.Count - 1;
        }

    	private void _btnMoveUp_Click(object sender, EventArgs e)
        {
            var selectedIndex = _clbColumns.SelectedIndex;
    		if (selectedIndex < 0 || selectedIndex > _clbColumns.Items.Count - 1) return;

    		var columnIndex = GetGridColumnIndex(selectedIndex);
    		_dataGridView.Columns[columnIndex].DisplayIndex = _clbColumns.SelectedIndex - 1;

    		var upIndex = selectedIndex - 1;
    		var downIndex = selectedIndex;
    		SwitchItems(upIndex, downIndex);

    		_clbColumns.SelectedIndex = upIndex;
    		_clbColumns_SelectedIndexChanged(null, null);
        }
        private void _btnMoveDown_Click(object sender, EventArgs e)
        {
            var selectedIndex = _clbColumns.SelectedIndex;
        	if (selectedIndex < 0 || selectedIndex > _clbColumns.Items.Count - 1) return;

        	var columnIndex = GetGridColumnIndex(selectedIndex);
        	_dataGridView.Columns[columnIndex].DisplayIndex = _clbColumns.SelectedIndex + 1;

        	var upIndex = selectedIndex;
        	var downIndex = selectedIndex + 1;
        	SwitchItems(upIndex, downIndex);

        	_clbColumns.SelectedIndex = downIndex;
        	_clbColumns_SelectedIndexChanged(null, null);
        }

        private void SwitchItems(int upIndex, int downIndex)
        {
            var upValue = _clbColumns.Items[downIndex].ToString();
            var upChecked = _clbColumns.GetItemCheckState(downIndex);

            var downValue = _clbColumns.Items[upIndex].ToString();
            var downChecked = _clbColumns.GetItemCheckState(upIndex);

            _clbColumns.Items[downIndex] = downValue;
            _clbColumns.Items[upIndex] = upValue;

            if (downChecked == CheckState.Checked)
                _clbColumns.SetItemChecked(downIndex, true);
            else
                _clbColumns.SetItemChecked(downIndex, false);

            if (upChecked == CheckState.Checked)
                _clbColumns.SetItemChecked(upIndex, true);
            else
                _clbColumns.SetItemChecked(upIndex, false);
        }

        private int GetGridColumnIndex(int selectedIndex)
        {
            int columnIndex;
            for (columnIndex = 0; columnIndex < _dataGridView.Columns.Count; columnIndex++)
                if (_dataGridView.Columns[columnIndex].DisplayIndex == selectedIndex)
                    break;
            return columnIndex;
        }
    }
}
