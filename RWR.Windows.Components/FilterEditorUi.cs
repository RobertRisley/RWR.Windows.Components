using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RWR.Windows.Components
{
	/// <summary>
	/// The BaseGrid Filter Editor.
	/// </summary>
    public partial class FilterEditorUi : Form
	{
		#region Private Members

		private DataGridView _dgvBaseGrid = new DataGridView();
		private DataSet _dsOriginal = new DataSet();

		// TODO InList, NOT InList
		private readonly object[] _operatorsBool = new object[] { "is True", "is False", "is NULL", "is NOT NULL" };
		private readonly object[] _operatorsString = new object[] { "Equals", "NOT Equal", "Contains", "Does NOT Contain", "StartsWith", "EndsWith", "LessThan", "LessThan or Equal", "GreaterThan", "GreaterThan or Equal", "is EMPTY", "is NOT EMPTY", "is NULL", "is NOT NULL" };
		private readonly object[] _operatorsNumeric = new object[] { "Equals", "NOT Equal", "LessThan", "LessThan or Equal", "GreaterThan", "GreaterThan or Equal", "is NULL", "is NOT NULL" };
		private readonly object[] _operatorsDateTime = new object[] { "Equals", "NOT Equal", "LessThan", "LessThan or Equal", "GreaterThan", "GreaterThan or Equal", "is NULL", "is NOT NULL" };

		private readonly ArrayList _operatorsWithNoValue = new ArrayList(new[] { "is True", "is False", "is NULL", "is NOT NULL", "is EMPTY", "is NOT EMPTY" });

		private bool _eventSet;
		private int _saveCol;

		#endregion

		#region Properties

		/// <summary>
		/// The Filter string for the BindingSource to use.
		/// </summary>
		public string Filter;

		#endregion

		/// <summary>
		/// The BaseGrid Filter Editor.
		/// </summary>
		public FilterEditorUi()
		{
			InitializeComponent();
			_btnEdit_Click(this, null);
		}

		/// <summary>
		/// Sets the DataGridView member of the Filter Editor 
		/// </summary>
		/// <param name="dataGridView"></param>
		public void SetBaseDataGridView(DataGridView dataGridView)
		{
			if (dataGridView == null) return;

			_dgvBaseGrid = dataGridView;

			foreach (DataGridViewColumn column in _dgvBaseGrid.Columns)
				if (!string.IsNullOrEmpty(column.DataPropertyName.Trim()))
				{
					cboColumn.Items.Add(column.HeaderText.Trim());
					((DataGridViewComboBoxColumn)FilterGrid.Columns[2]).Items.Add(column.HeaderText.Trim());
				}

			cboGroup.Text = "1";
			cboColumn.Text = ((DataGridViewComboBoxColumn)FilterGrid.Columns[2]).Items[0].ToString();
			cboColumn.SelectedIndex = cboColumn.FindStringExact(cboColumn.Text);
		}

		/// <summary>
		/// Sets the DataGridView member for the Filter Editor to bind to.
		/// </summary>
		/// <param name="dataSet">The GridSettings DataSet to use.</param>
		public void SetFilterDataGridView(DataSet dataSet)
		{
			if (dataSet == null || !dataSet.Tables.Contains("GridFilters") || dataSet.Tables["GridFilters"].Rows.Count <= 0)
				return;
			
			_dsOriginal = dataSet.Copy(); // save for Cancel button restore
			FilterGrid.Rows.Clear();
			for (var i = 0; i < dataSet.Tables["GridFilters"].Rows.Count; i++)
			{
				var dr = dataSet.Tables["GridFilters"].Rows[i];
				var newRow = new DataGridViewRow();
				newRow.CreateCells(FilterGrid);
				var row = FilterGrid.Rows.Add(newRow);
				FilterGrid[0, row].Value = dr[0];
				FilterGrid[1, row].Value = dr[1];
				FilterGrid[2, row].Value = dr[2];
				FilterGrid[3, row].Value = dr[3];
				FilterGrid[4, row].Value = dr[4];
				if (_operatorsWithNoValue.Contains(dr[3]))
					FilterGrid[4, row].ReadOnly = true;
				FilterGrid[5, row].Value = dr[5];
			}

			ComposeFilter();
		}

		private void CheckDataGridView()
		{
			// Checks that the DataGridView has been set. If NOT, the Filter Editor window is closed.
			if (_dgvBaseGrid != null) return;

			MessageBox.Show("SetBaseDataGridView has NOT been called", "FilterEditorUi Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Close();
		}

		private void _cboSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void _btnEdit_Click(object sender, EventArgs e)
		{
			// Enable/Disable filter grid editing.
			if (!_btnEdit.Checked)
			{
				_btnEdit.Checked = true;
				cboGroup.Visible = true;
				cboLogic.Visible = true;
				cboColumn.Visible = true;
				cboOperator.Visible = true;
				txtValue.Visible = true;
				_btnAddRow.Visible = true;
				_btnRemoveRow.Visible = true;
				_btnRemoveAll.Visible = true;
				FilterGrid.ReadOnly = false;
				_btnAddRow.Focus();
			}
			else
			{
				_btnEdit.Checked = false;
				cboGroup.Visible = false;
				cboLogic.Visible = false;
				cboColumn.Visible = false;
				cboOperator.Visible = false;
				txtValue.Visible = false;
				_btnAddRow.Visible = false;
				_btnRemoveRow.Visible = false;
				_btnRemoveAll.Visible = false;
				FilterGrid.ReadOnly = true;
				_btnOk.Focus();
			}
		}
		private void _btnNew_Click(object sender, EventArgs e)
		{
		}
		private void _btnDelete_Click(object sender, EventArgs e)
		{
		}

		private void _btnRemoveRow_Click(object sender, EventArgs e)
		{
			CheckDataGridView();

			var selectedRows = FilterGrid.SelectedRows;

			if (selectedRows.Count == 0)
				return;

			for (var i = 0; i < selectedRows.Count; i++)
				FilterGrid.Rows.Remove(selectedRows[i]);
		}
		private void _btnRemoveAll_Click(object sender, EventArgs e)
		{
			FilterGrid.Rows.Clear();
		}

		private void cboColumn_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboColumn.SelectedIndex < 0) return;

			cboOperator.Items.Clear();

			switch (_dgvBaseGrid.Columns[cboColumn.SelectedIndex].ValueType.ToString())
			{
				case "System.Boolean":
					cboOperator.Items.AddRange(_operatorsBool);
					cboOperator.Text = "is True";
					txtValue.ReadOnly = true;
					txtValue.Text = string.Empty;
					break;
				case "System.DateTime":
					cboOperator.Items.AddRange(_operatorsDateTime);
					cboOperator.Text = "Equals";
					txtValue.ReadOnly = false;
					txtValue.Text = DateTime.Now.ToShortDateString();
					break;
				case "System.Decimal":
				case "System.Double":
				case "System.Single":
				case "System.Int16":
				case "System.Int32":
				case "System.Int64":
				case "System.UInt16":
				case "System.UInt32":
				case "System.UInt64":
				case "System.Byte":
				case "System.SByte":
					cboOperator.Items.AddRange(_operatorsNumeric);
					cboOperator.Text = "Equals";
					txtValue.ReadOnly = false;
					txtValue.Text = "0";
					break;
				default: //Char, String
					cboOperator.Items.AddRange(_operatorsString);
					cboOperator.Text = "Equals";
					txtValue.ReadOnly = false;
					txtValue.Text = string.Empty;
					break;
			}
		}
		private void cboOperator_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtValue.ReadOnly = _operatorsWithNoValue.Contains(cboOperator.Text);
		}

		private void _btnAddRow_Click(object sender, EventArgs e)
		{
			CheckDataGridView();

			if (string.IsNullOrEmpty(cboLogic.Text) && FilterGrid.Rows.Count > 0)
			{
				MessageBox.Show("Please select 'AND' or 'OR' Logic.", "Logic missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cboLogic.Focus();
				return;
			}

			var errorText = CheckValue(cboColumn.SelectedIndex, txtValue.Text);

			if (!string.IsNullOrEmpty(errorText))
			{
				MessageBox.Show("Please enter a valid Value.", "Value missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtValue.Focus();
			}
			else
			{
				var newRow = new DataGridViewRow();
				newRow.CreateCells(FilterGrid);
				var row = FilterGrid.Rows.Add(newRow);

				FilterGrid[0, row].Value = cboGroup.Text;
				FilterGrid[1, row].Value = cboLogic.Text;
				FilterGrid[2, row].Value = cboColumn.Text;
				FilterGrid[3, row].Value = cboOperator.Text;
				FilterGrid[4, row].Value = txtValue.Text;

				if (_operatorsWithNoValue.Contains(cboOperator.Text))
					FilterGrid[4, row].ReadOnly = true;

				foreach (DataGridViewColumn column in _dgvBaseGrid.Columns)
					if (column.HeaderText == cboColumn.Text)
					{
						FilterGrid[5, row].Value = column.DataPropertyName;
						break;
					}
			}
		}

		private string CheckValue(int index, string value)
		{
			// Validates the value in the Value TextBox using the Type from the filtered DataGridView
			var errorText = string.Empty;

			if (index >= 0)
			{
				switch (_dgvBaseGrid.Columns[index].ValueType.ToString())
				{
					case "System.Boolean":
						if (!cboOperator.Text.Contains("is"))
						{
							bool boolResult;
							if (!bool.TryParse(value, out boolResult))
								errorText = "Value must be True or False.";
						}
						break;
					case "System.DateTime":
						if (!string.IsNullOrEmpty(value))
						{
							DateTime dateResult;
							if (!DateTime.TryParse(value, out dateResult))
								errorText = "Value must be a Date.";
						}
						else
							errorText = "Date Value cannot be blank.";
						break;
					case "System.Decimal":
					case "System.Double":
					case "System.Single":
					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.UInt16":
					case "System.UInt32":
					case "System.UInt64":
					case "System.Byte":
					case "System.SByte":
						if (!cboOperator.Text.Contains("is"))
						{
							if (!string.IsNullOrEmpty(value))
							{
								decimal decimalResult;
								if (!decimal.TryParse(value, out decimalResult))
									errorText = "Value must be a Number.";
							}
							else
								errorText = "Number Value cannot be blank.";
						}
						break;
					default: //Char, String
						if (!cboOperator.Text.Contains("is"))
						{
							if (string.IsNullOrEmpty(value))
								errorText = "String Value cannot be blank.";
						}
						break;
				}
			}
			else
				errorText = "Invalid Index.";

			return errorText;
		}

		private void Grid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (FilterGrid.Rows.Count != 1) return;

			var comboBoxCellGroup = (DataGridViewComboBoxCell)FilterGrid[0, 0];
			comboBoxCellGroup.Value = "1";
			var comboBoxCellLogic = (DataGridViewComboBoxCell)FilterGrid[1, 0];
			comboBoxCellLogic.Value = "";
		}
		private void Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			CheckDataGridView();

			if (FilterGrid.CurrentCell.ColumnIndex == 2 && _eventSet == false)
			{
				((ComboBox)e.Control).SelectionChangeCommitted += _cboColumn_SelectedIndexChanged;
				_eventSet = true;
			}

			if (FilterGrid.CurrentCell.ColumnIndex == 2 || !_eventSet || typeof (ComboBox) != e.Control.GetType()) return;

			((ComboBox)e.Control).SelectionChangeCommitted -= _cboColumn_SelectedIndexChanged;
			_eventSet = false;
		}
		private void Grid_CurrentCellChanged(object sender, EventArgs e)
		{
			// Save the SelectedIndex of a ComboBox when entering the cell.
			if (FilterGrid.CurrentCell == null) return;

			var row = FilterGrid.CurrentCell.RowIndex;
			var col = FilterGrid.CurrentCell.ColumnIndex;

			switch (col)
			{
				case 1:
					var comboBoxCellLogic = (DataGridViewComboBoxCell)FilterGrid[col, row];
					if (comboBoxCellLogic.Value != null)
						comboBoxCellLogic.Items.IndexOf(comboBoxCellLogic.Value);
					break;
				case 2:
					var comboBoxCellColumn = (DataGridViewComboBoxCell)FilterGrid[col, row];
					if (comboBoxCellColumn.Value != null)
						_saveCol = cboColumn.Items.IndexOf(comboBoxCellColumn.Value);
					else
						_saveCol = -1;
					break;
				case 3:
					var comboBoxCellOperator = (DataGridViewComboBoxCell)FilterGrid[col, row];
					if (comboBoxCellOperator.Value != null)
						comboBoxCellOperator.Items.IndexOf(comboBoxCellOperator.Value);
					break;
				default:
					break;
			}
		}
		private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			// In the CellEndEdit event handler, set the ErrorText property on the row to the empty string.
			// The CellEndEdit event occurs only when the cell exits edit mode, which it cannot do if it fails validation.
			var grid = (DataGridView)sender;

			// Clear the row error in case the user presses ESC.   
			grid.Rows[e.RowIndex].ErrorText = string.Empty;
			grid.CurrentCell.ErrorText = string.Empty;
		}
		private void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			CheckDataGridView();

			var grid = (DataGridView)sender;
			try
			{
				if (grid.Columns[e.ColumnIndex].Name == "_txtValue")
				{
					var comboBoxCellOperator = (DataGridViewComboBoxCell)FilterGrid["_cboOperator", e.RowIndex];
					if (!_operatorsWithNoValue.Contains(comboBoxCellOperator.Value))
					{
						grid.CurrentCell.ErrorText = "";
						grid.Rows[e.RowIndex].ErrorText = "";

						var value = (string)e.FormattedValue;
						var index = -1;
						var comboBoxCellColumn = (DataGridViewComboBoxCell)FilterGrid["_cboColumn", e.RowIndex];
						if (comboBoxCellColumn.Value != null)
							index = comboBoxCellColumn.Items.IndexOf(comboBoxCellColumn.Value);

						var errorText = CheckValue(index, value);
						if (!string.IsNullOrEmpty(errorText))
						{
							errorText = "     " + errorText;  // add 5 spaces for visibility
							grid.CurrentCell.ErrorText = errorText;
							grid.Rows[e.RowIndex].ErrorText = errorText;
							e.Cancel = true;
						}
					}
				}
			}
			catch
			{
				grid.CurrentCell.ErrorText = "Something is wrong!";
				e.Cancel = true;
			}
		}

		private void _cboColumn_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (((ComboBox) sender).SelectedIndex < 0) return;

			var row = FilterGrid.CurrentCell.RowIndex;
			var col = FilterGrid.CurrentCell.ColumnIndex;
			var idx = ((ComboBox)sender).SelectedIndex;

			if (col != 2 || idx == _saveCol) return;

			_saveCol = idx;

			#region set Operator.Items based on the DataGridView.Column.ValueType
			var oper = (DataGridViewComboBoxCell)FilterGrid["_cboOperator", row];
			var val = (DataGridViewTextBoxCell)FilterGrid["_txtValue", row];
			oper.Items.Clear();

			switch (_dgvBaseGrid.Columns[idx].ValueType.ToString())
			{
				case "System.Boolean":
					oper.Items.AddRange(_operatorsBool);
					oper.Value = "is True";
					val.ReadOnly = true;
					val.Value = string.Empty;
					break;
				case "System.DateTime":
					oper.Items.AddRange(_operatorsDateTime);
					oper.Value = "Equals";
					val.ReadOnly = false;
					val.Value = DateTime.Now.ToShortDateString();
					break;
				case "System.Decimal":
				case "System.Double":
				case "System.Single":
				case "System.Int16":
				case "System.Int32":
				case "System.Int64":
				case "System.UInt16":
				case "System.UInt32":
				case "System.UInt64":
				case "System.Byte":
				case "System.SByte":
					oper.Items.AddRange(_operatorsNumeric);
					oper.Value = "Equals";
					val.ReadOnly = false;
					val.Value = "0";
					break;
				default: //Char, String
					oper.Items.AddRange(_operatorsString);
					oper.Value = "Equals";
					val.ReadOnly = false;
					val.Value = string.Empty;
					break;
			}
			#endregion
		}

		private void _btnOk_Click(object sender, EventArgs e)
		{
			ComposeFilter();
			DialogResult = DialogResult.OK;
			Close();
		}
		private void _btnCancel_Click(object sender, EventArgs e)
		{
			SetFilterDataGridView(_dsOriginal);
		}

		/// <summary>
		/// Composes the Filter string from the FilterGrid.Rows.
		/// </summary>
		public void ComposeFilter()
		{
			Filter = string.Empty;
			foreach (DataGridViewRow row in FilterGrid.Rows)
			{
				Filter += " " + row.Cells["_cboLogic"].Value + " ";

				var col = row.Cells["_txtMapping"].Value.ToString();
				Filter += "[" + col + "]";

				var oper = TranslateOperator(row.Cells["_cboOperator"].Value.ToString());
				Filter += oper;

				var value = row.Cells["_txtValue"].Value.ToString();
				// ReSharper disable PossibleNullReferenceException
				switch (_dgvBaseGrid.Columns[col].ValueType.ToString())
				// ReSharper restore PossibleNullReferenceException
				{
					case "System.Boolean":
						break;
					case "System.Decimal":
					case "System.Double":
					case "System.Single":
					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.UInt16":
					case "System.UInt32":
					case "System.UInt64":
					case "System.Byte":
					case "System.SByte":
						Filter += value;
						break;
					default: //Char, String, DateTime
						switch (row.Cells["_cboOperator"].Value.ToString())
						{
							case "Equals":
							case "NOT Equal":
							case "LessThan":
							case "LessThan or Equal":
							case "GreaterThan":
							case "GreaterThan or Equal":
								Filter += "'" + value + "'";
								break;

							case "Contains":
							case "Does NOT Contain":
								Filter += "'%" + value + "%'";
								break;

							case "StartsWith":
								Filter += "'" + value + "%'";
								break;
							case "EndsWith":
								Filter += "'%" + value + "'";
								break;

							// TODO code InList
							case "InList":
							case "NOT InList":
								break;

							default:
								break;
						}
						break;
				}
			}
		}

		private static string TranslateOperator(string text)
		{
			var ret = string.Empty;
			switch(text)
			{
				case "is True": ret = " = True "; break;
				case "is False": ret = " = False "; break;

				case "is NULL": ret = " IS NULL "; break;
				case "is NOT NULL": ret = " IS NOT NULL "; break;

				case "is EMPTY": ret = " = '' "; break;
				case "is NOT EMPTY": ret = " <> '' "; break;

				case "Equals": ret = " = "; break;
				case "NOT Equal": ret = " <> "; break;

				case "Contains": ret = " LIKE "; break;
				case "Does NOT Contain": ret = " NOT LIKE "; break;

				case "InList": ret = " IN "; break;
				case "NOT InList": ret = " NOT IN "; break;

				case "StartsWith":
				case "EndsWith": ret = " LIKE "; break;

				case "LessThan": ret = " < "; break;
				case "LessThan or Equal": ret = " <= "; break;

				case "GreaterThan": ret = " > "; break;
				case "GreaterThan or Equal": ret = " >= "; break;

				default: break;
			}
			return ret;
		}
	}
}