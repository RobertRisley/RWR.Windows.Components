using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RWR.Common;
using RWR.Windows.Components.DSBO;

namespace RWR.Windows.Components
{
    /// <summary>
    /// A base general purpose DataGridView with Sort, Filter, Find, RetrieveData, and ColumnsEditing.
    /// </summary>
    public partial class BaseGrid : UserControl
	{
		#region Private Members

		private FormSettingsCD _formSettings = new FormSettingsCD();
		private readonly ArrayList _dataPropertyNames = new ArrayList();
		private readonly GridSettingsCD _gridSettings = new GridSettingsCD();
		private readonly FilterEditorUi _filterEditor = new FilterEditorUi();
		private DataGridView.HitTestInfo _hti;
		private DataGridViewHitTestType _htt;

		#endregion

		#region Properties
		
		/// <summary>
		/// The name of the DataGridView.
		/// </summary>
		public string GridName
		{
			get { return DataGridView.Name; }
			set { DataGridView.Name = value; }
		}

		/// <summary>
		/// The Name to display on the DataGridView Banner.
		/// </summary>
		public string BannerName;

		#endregion

		#region Delegate Public members
		
		/// <summary>
		/// Delegate for parent Form to handle a double-click on the grid.
		/// </summary>
		public event GridDoubleClickEventHandler GridDoubleClick;

		/// <summary>
		/// Delegate for parent Form to retrieve data.
		/// </summary>
		public event RetrieveDataEventHandler RetrieveData;

		/// <summary>
		/// Delegate for parent Form to handle a filter apply.
		/// </summary>
		public event FilterApplyEventHandler FilterApply;

		#endregion

		/// <summary>
		/// A base general purpose DataGridView with Sort, Filter, Find, RetrieveData, and ColumnsEditing.
		/// </summary>
		public BaseGrid()
        {
            InitializeComponent();
			try
			{
				DataGridView.AutoGenerateColumns = true;
				DataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
				//_dgvBaseGrid.RowHeadersWidth = _dgvBaseGrid.ColumnHeadersHeight;
			}
			catch { }
		}

		/// <summary>
		/// Set the Grid DataSource, load Sort Columns, and load Filter DataGridView
		/// </summary>
		/// <param name="dataSource">the dataset to set the BindingSource.DataSource to</param>
		public void GetDataCompleted(DataTable dataSource)
        {
			try
			{
				DataGridView.AutoGenerateColumns = true;
				BindingSource.DataSource = dataSource;
			}
			catch { }
		}

    	/// <summary>
		/// Format the Grid's AlternatingRowsBackColor
		/// </summary>
		public void FormSettings_Set(FormSettingsCD formSettings)
		{
			try
			{
				if (formSettings != null)
					_formSettings = formSettings;
			}
			catch { }
		}

		/// <summary>
		/// Format the Grid's AlternatingRowsBackColor and Column properties (HeaderText, Visible, DisplayIndex, Width, Alignment, Format)
		/// </summary>
		public void GridSettings_Apply()
		{
			try
			{
				if (_formSettings.GetValue("AltColor1") == null)
					_formSettings.SetValue("AltColor1", "AliceBlue");
				Banner.BackColor = Color.FromName(_formSettings.GetValue("AltColor1"));
				DataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromName(_formSettings.GetValue("AltColor1"));

				int i;

				#region Set column properties (Visible, DisplayIndex, Width) from GridSettings
				_gridSettings.ClientGetGridSettings(SystemInformation.UserName, GridName, false);
				var count = _gridSettings.GridSettings.Count;

				for (i = 0; i < count; i++)
				{
					var columnName = _gridSettings.GridSettings[i].ColumnName;
					// ReSharper disable PossibleNullReferenceException
					DataGridView.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
					DataGridView.Columns[columnName].Visible = _gridSettings.GridSettings[i].Visible;
					DataGridView.Columns[columnName].DisplayIndex = _gridSettings.GridSettings[i].DisplayIndex;
					DataGridView.Columns[columnName].Width = _gridSettings.GridSettings[i].Width;
					// ReSharper restore PossibleNullReferenceException
				}
				#endregion

				DataGridView.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
				#region auto Set column properties (Alignment, Format) based on DataType
				var dataSource = (DataTable)BindingSource.DataSource;
				for (i = 0; i < dataSource.Columns.Count; i++)
				{
					DataGridView.Columns[i].HeaderText = dataSource.Columns[i].Caption;

					switch (dataSource.Columns[i].DataType.ToString())
					{
						case "System.Boolean":
							DataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
							break;
						case "System.DateTime":
							DataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
							DataGridView.Columns[i].DefaultCellStyle.Format = "MM/dd/yyyy";
							break;
						case "System.Decimal":
						case "System.Double":
						case "System.Single":
							DataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
							DataGridView.Columns[i].DefaultCellStyle.Format = "#,#.##";
							break;
						case "System.Int16":
						case "System.Int32":
						case "System.Int64":
						case "System.UInt16":
						case "System.UInt32":
						case "System.UInt64":
						case "System.Byte":
						case "System.SByte":
							DataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
							DataGridView.Columns[i].DefaultCellStyle.Format = "#,0";
							break;
						default: //Char, String
							DataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
							break;
					}
				}
				#endregion

				#region Set Sort from Previous
				Sort_LoadColumns();

				var sortCol1 = _formSettings.GetValue("SortCol1");
				var sortSrt1 = _formSettings.GetValue("SortSrt1");
				var sortCol2 = _formSettings.GetValue("SortCol2");
				var sortSrt2 = _formSettings.GetValue("SortSrt2");
				var sortCol3 = _formSettings.GetValue("SortCol3");
				var sortSrt3 = _formSettings.GetValue("SortSrt3");

				_cboSortCol1.SelectedIndex = 0;
				_cboSortSrt1.SelectedIndex = 0;
				_cboSortCol2.SelectedIndex = 0;
				_cboSortSrt2.SelectedIndex = 0;
				_cboSortCol3.SelectedIndex = 0;
				_cboSortSrt3.SelectedIndex = 0;

				if (!string.IsNullOrEmpty(sortCol1) && _cboSortCol1.FindStringExact(sortCol1) > 0)
				{
					_cboSortCol1.Text = sortCol1;
					if (!string.IsNullOrEmpty(sortSrt1))
						if (_cboSortSrt1.FindStringExact(sortSrt1) >= 0)
							_cboSortSrt1.Text = sortSrt1;

					if (!string.IsNullOrEmpty(sortCol2) && _cboSortCol2.FindStringExact(sortCol2) > 0)
					{
						_cboSortCol2.Text = sortCol2;
						if (!string.IsNullOrEmpty(sortSrt2))
							if (_cboSortSrt2.FindStringExact(sortSrt2) >= 0)
								_cboSortSrt2.Text = sortSrt2;

						if (!string.IsNullOrEmpty(sortCol3) && _cboSortCol3.FindStringExact(sortCol3) > 0)
						{
							_cboSortCol3.Text = _formSettings.GetValue("SortCol3");
							if (!string.IsNullOrEmpty(sortSrt3))
								if (_cboSortSrt3.FindStringExact(sortSrt3) >= 0)
									_cboSortSrt3.Text = sortSrt3;
						}
					}
					_btnSortApply_Click(null, null);
				}
				#endregion

				#region Set Filter from Previous
				Filter_LoadSettings();

				if (!string.IsNullOrEmpty(_formSettings.GetValue("FilterDS")))
				{
					var ds = new DataSet("FilterDS");
					ds.ReadXml(new StringReader(_formSettings.GetValue("FilterDS")));
					_filterEditor.SetFilterDataGridView(ds);
					if (_filterEditor.Filter != null)
					{
						_txtFilter.Text = _filterEditor.Filter;
						_btnFilterApply_Click(null, null);
					}
				}
				#endregion
			}
			catch { }
		}

		/// <summary>
		/// Saves the GridSettings (current column Visible/DisplayIndex/Width properties)
		/// </summary>
		public void GridSettings_Save()
		{
			_gridSettings.ClientUpdateGridSettingsFromDataGridView(DataGridView, false);

		}

		/// <summary>
		/// Set the Grid's Banner.Text using the BannerName, Filter, and Sort.
		/// </summary>
		public void SetBannerText()
		{
			Banner.Text = BannerName;

			if (!string.IsNullOrEmpty(BindingSource.Filter))
			{
				Banner.Text += "  -  Filter(" + BindingSource.Filter.Trim() + ")";
			}

			if (!string.IsNullOrEmpty(BindingSource.Sort))
			{
				Banner.Text += "  -  Sort(" + BindingSource.Sort.Trim() + ")";
			}
		}

		/// <summary>
		/// Disable the Retrieve Data Button on the TopToolStrip
		/// </summary>
		public void DisableRetrieveDataButton()
		{
			_btnRetrieveData.Enabled = false;
		}
		/// <summary>
		/// Enable the Retrieve Data Button on the TopToolStrip
		/// </summary>
		public void EnableRetrieveDataButton()
		{
			_btnRetrieveData.Enabled = true;
		}

		#region Sort Methods

		private void Sort_LoadColumns()
		{
		// Clears and Loads the Sort selection ComboBoxs
			_dataPropertyNames.Clear();
			_cboSortCol1.Items.Clear();
			_cboSortCol1.Items.Add("Select 1st Sort Column");
			_cboSortCol2.Items.Clear();
			_cboSortCol2.Items.Add("Select 2nd Sort Column");
			_cboSortCol3.Items.Clear();
			_cboSortCol3.Items.Add("Select 3rd Sort Column");
			foreach (DataGridViewColumn column in DataGridView.Columns)
			{
				if (string.IsNullOrEmpty(column.DataPropertyName.Trim())) continue;

				_dataPropertyNames.Add(column.DataPropertyName.Trim());
				_cboSortCol1.Items.Add(column.HeaderText.Trim());
				_cboSortCol2.Items.Add(column.HeaderText.Trim());
				_cboSortCol3.Items.Add(column.HeaderText.Trim());
			}
		}

		private void _btnSort_Click(object sender, EventArgs e)
		{
			_tsSort.Visible = !_tsSort.Visible;
			_btnSort.ToolTipText = _tsSort.Visible ? "Hide Sort Control" : "Show Sort Control";
		}

    	private void _btnSortApply_Click(object sender, EventArgs e)
		{
			var sort = string.Empty;

			if (_cboSortCol1.Text.Trim() != "Select 1st Sort Column")
			{
				sort = String.Concat("[", _dataPropertyNames[_cboSortCol1.SelectedIndex-1].ToString(), "] ", _cboSortSrt1.Text);
				if (_cboSortCol2.Text.Trim() != "Select 2nd Sort Column")
				{
					sort = String.Concat(sort, ", [", _dataPropertyNames[_cboSortCol2.SelectedIndex-1].ToString(), "] ", _cboSortSrt2.Text);
					if (_cboSortCol3.Text.Trim() != "Select 3rd Sort Column")
						sort = String.Concat(sort, ", [", _dataPropertyNames[_cboSortCol3.SelectedIndex-1].ToString(), "] ", _cboSortSrt3.Text);
				}
			}

			try
			{
				BindingSource.Sort = sort;
				SetBannerText();

				_btnSort.Checked = true;
				_btnSortRemove.Enabled = true;

				_formSettings.SetValue("SortCol1", _cboSortCol1.Text);
				_formSettings.SetValue("SortSrt1", _cboSortSrt1.Text);
				_formSettings.SetValue("SortCol2", _cboSortCol2.Text);
				_formSettings.SetValue("SortSrt2", _cboSortSrt2.Text);
				_formSettings.SetValue("SortCol3", _cboSortCol3.Text);
				_formSettings.SetValue("SortSrt3", _cboSortSrt3.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Sort Error", MessageBoxButtons.OK);
			}
		}
		private void _btnSortRemove_Click(object sender, EventArgs e)
		{
			BindingSource.Sort = string.Empty;
			SetBannerText();
			_btnSortRemove.Enabled = false;
			_btnSort.Checked = false;
		}

		private void _cboSortCol1_SelectedIndexChanged(object sender, EventArgs e)
		{
		// After SelectedIndex changes, sets the enabled property of Sort Combo 2

			if (_cboSortCol1.Text == "Select 1st Sort Column")
			{
				_cboSortCol2.SelectedIndex = -1;
				_cboSortCol2.Text = "Select 2nd Sort Column";
				_cboSortCol2.Enabled = false;

				_cboSortSrt2.SelectedIndex = 0;
				_cboSortSrt2.Enabled = false;
			}
			else
			{
				_cboSortCol2.Enabled = true;
				_cboSortSrt2.Enabled = true;
			}
		}
		private void _cboSortCol2_SelectedIndexChanged(object sender, EventArgs e)
		{
		// After SelectedIndex changes, sets the enabled property of Sort Combo 3

			if (_cboSortCol2.Text == "Select 2nd Sort Column")
			{
				_cboSortCol3.SelectedIndex = -1;
				_cboSortCol3.Text = "Select 3rd Sort Column";
				_cboSortCol3.Enabled = false;

				_cboSortSrt3.SelectedIndex = 0;
				_cboSortSrt3.Enabled = false;
			}
			else
			{
				_cboSortCol3.Enabled = true;
				_cboSortSrt3.Enabled = true;
			}
		}

		#endregion

		#region Filter Methods

		private void Filter_LoadSettings()
		{
			_filterEditor.SetBaseDataGridView(DataGridView);
		}

		private void _btnFilter_Click(object sender, EventArgs e)
		{
			_tsFilter.Visible = !_tsFilter.Visible;
			if (_tsFilter.Visible)
			{
				_btnFilter.ToolTipText = "Hide Filter Control";
				_btnFilterEditor_Click(this, e);
			}
			else
				_btnFilter.ToolTipText = "Show Filter Control";
		}
		private void _btnFilterEditor_Click(object sender, EventArgs e)
		{
			if (_filterEditor.ShowDialog() != DialogResult.OK) return;

			_txtFilter.Text = _filterEditor.Filter;
			_btnFilterApply_Click(this, e);
		}
		private void _btnFilterApply_Click(object sender, EventArgs e)
		{
			try
			{
				BindingSource.Filter = _txtFilter.Text;
				SetBannerText();
				_btnFilter.Checked = true;
				_btnFilterRemove.Enabled = true;
				FilterApply();

				// serialize the FilterSettings DataGridView into DataSet XML
				var dt = new DataTable("GridFilters");
				dt.Columns.Add("cboGroup");
				dt.Columns.Add("cboLogic");
				dt.Columns.Add("cboColumn");
				dt.Columns.Add("cboOperator");
				dt.Columns.Add("txtValue");
				dt.Columns.Add("txtMapping");
				foreach (DataGridViewRow row in _filterEditor.FilterGrid.Rows)
				{
					var dr = dt.NewRow();
					dr[0] = row.Cells[0].Value;
					dr[1] = row.Cells[1].Value;
					dr[2] = row.Cells[2].Value;
					dr[3] = row.Cells[3].Value;
					dr[4] = row.Cells[4].Value;
					dr[5] = row.Cells[5].Value;
					dt.Rows.Add(dr);
				}
				var ds = new DataSet("FilterDS");
				ds.Tables.Add(dt);
				var sw = new StringWriter();
				ds.WriteXml(sw);
				// Save the FilterSettings XML for retrieval at Form_Open
				_formSettings.SetValue("FilterDS", sw.ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Filter Error", MessageBoxButtons.OK);
			}
		}
		private void _btnFilterRemove_Click(object sender, EventArgs e)
		{
			BindingSource.Filter = string.Empty;
			SetBannerText();
			_btnFilterRemove.Enabled = false;
			_btnFilter.Checked = false;
			FilterApply();
		}

		#endregion

		private void _btnFind_Click(object sender, EventArgs e)
		{
			var findUi = new FindUi();
			findUi.SetBaseDataGridView(DataGridView);
			findUi.ShowDialog();
		}
		private void _btnRetrieveData_Click(object sender, EventArgs e)
        {
			RetrieveData();
		}
		private void _btnColumns_Click(object sender, EventArgs e)
        {
            var editor = new ColumnsEditorUi(DataGridView);
            editor.ShowDialog();
		}
		private void _btnFormSettings_Click(object sender, EventArgs e)
		{
			var formSettingsUi = new FormSettingsUi(_formSettings);
			var dr = formSettingsUi.ShowDialog();
			if (dr != DialogResult.OK) return;

			Banner.BackColor = Color.FromName(_formSettings.GetValue("AltColor1"));
			DataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromName(_formSettings.GetValue("AltColor1"));
		}

		private void _dgvGrid_DoubleClick(object sender, EventArgs e)
		{
		// After Double-Click on Grid Cell or RowHeader, fires GridDoubleClick event and passing DataRow.

			try
			{
				if (_htt == DataGridViewHitTestType.Cell || _htt == DataGridViewHitTestType.RowHeader)
				{
					var cur = Cursor.Current;
					Cursor.Current = Cursors.WaitCursor;

					if (DataGridView.CurrentRow != null)
						if (DataGridView.Rows.Count > 0 && DataGridView.CurrentRow.Index + 1 <= DataGridView.Rows.Count)
						{
							var drv = (DataRowView)BindingSource.Current;
							var dgvRow = drv.Row;
							var de = new GridDoubleClickEventArgs {Row = dgvRow};
							GridDoubleClick(this, de);
						}

					Cursor.Current = cur;
				}
			}
			catch {}
		}
		private void _dgvGrid_MouseUp(object sender, MouseEventArgs e)
		{
		// for testing i guess

			try
			{
				if (e.Button == MouseButtons.Left)
				{
					_hti = DataGridView.HitTest(e.X, e.Y);
					_htt = _hti.Type;
					//if (_htt == DataGrid.HitTestType.Cell && _dgvBaseGrid.CurrentCell.ColumnIndex == 0)
					if (_htt == DataGridViewHitTestType.Cell)
					{
						//if (_dg[_dg.CurrentRowIndex, 0].ToString().Length == 0)
						//	_dg[_dg.CurrentRowIndex, 0] = false;
						//else if (_dg[_dg.CurrentRowIndex, 0].ToString() == "True")
						//	_dg[_dg.CurrentRowIndex, 0] = false;
						//else if (_dg[_dg.CurrentRowIndex, 0].ToString() == "False")
						//	_dg[_dg.CurrentRowIndex, 0] = true;
						//_dg.Select(_hti.Row);
					}
					//else if (_htt == DataGrid.HitTestType.Cell && _dg.CurrentCell.ColumnNumber != 0)
					//{
					//	_dg.CurrentCell = new DataGridCell(_hti.Row, _hti.Column);
					//	_dg.Select(_hti.Row);
					//}
				}
			}
			catch {}
		}
	}
}
