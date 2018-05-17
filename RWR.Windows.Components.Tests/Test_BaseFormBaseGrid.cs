using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RWR.Common;
using RWR.Windows.Components.DSBO;

namespace RWR.Windows.Components.Tests
{
	public partial class Test_BaseFormBaseGrid : BaseFormBaseGrid
	{
		#region Private Members

		private readonly GridSettingsCD _gridSettingsCD = new GridSettingsCD();
		private Form_GetDataCompletedCallBack _form_GetDataCompletedCallBack;
		private Form_UpdateCompletedCallBack _form_UpdateCompletedCallBack;

		#endregion

		public Test_BaseFormBaseGrid()
		{
			InitializeComponent();
		}

		private void Test_BaseFormBaseGrid_Load(object sender, System.EventArgs e)
		{
			// set Grid Banner properties - Visible,Text
			Grid.BannerName = "GridSettings List";
			Grid.Banner.Visible = true;
			Grid.SetBannerText();

			Form_EventHandlers_Set(); // i.e., GetDataCompleted
			Form_RetrieveData(); // only RetrieveData after Form_EventHandlers_Set has run

			Grid_ToolStrip_Customize();
		}
		private void Test_BaseFormBaseGrid_FormClosing(object sender, FormClosingEventArgs e)
		{
			Grid.GridSettings_Save();
		}

		private void Form_EventHandlers_Set()
		{
			// if the user clicks Retrieve Data button on BaseGrid
			Grid.RetrieveData += Form_RetrieveData;
			Grid.FilterApply += Form_FilterSetStatusMessage;

			_gridSettingsCD.ClientGetGridSettingsCompleted += Form_GetDataCompleted;
			//_gridSettingsCD.ClientUpdateGridSettingsCompleted += Async_UpdateCompleted;

			_form_GetDataCompletedCallBack = Form_GetDataCompleted;
			_form_UpdateCompletedCallBack = Async_UpdateCompleted;

			// TODO add custom FORM event handlers
		}
		private void Form_RetrieveData()
		{
			StatusMessage.Text = "Retrieving Data...";
			Grid.DisableRetrieveDataButton();

			DataSource_EventHandlers_Remove();

			_gridSettingsCD.UseWcfService = false;
			_gridSettingsCD.UseAsmxService = false;
			_gridSettingsCD.UseClientServer = true;


			_gridSettingsCD.ClientGetGridSettings(SystemInformation.UserName, "GridSettingsTest", false);
			// generate test data if it dos not exist
			if (_gridSettingsCD.Tables[0].Rows.Count == 0)
			{
				GridSettingsCD.GridSettingsRow gridSettingsRow;
				var displayIndex = 0;
				foreach (DataColumn column in _gridSettingsCD.Tables[0].Columns)
				{
					gridSettingsRow = _gridSettingsCD.GridSettings.NewGridSettingsRow();
					gridSettingsRow.SetDefaultValues();
					gridSettingsRow.UserName = SystemInformation.UserName;
					gridSettingsRow.GridName = "GridSettingsTest";
					gridSettingsRow.ColumnName = column.ColumnName;
					gridSettingsRow.Visible = true;
					gridSettingsRow.DisplayIndex = displayIndex;
					gridSettingsRow.Width = 100 + displayIndex;
					_gridSettingsCD.GridSettings.AddGridSettingsRow(gridSettingsRow);

					displayIndex++;
				}
				_gridSettingsCD.ClientUpdateGridSettings(false);
				_gridSettingsCD.ClientGetGridSettings(SystemInformation.UserName, "GridSettingsTest", false);
			}
			Form_GetDataCompleted(this, new EventArgs());
		}
		private void Form_GetDataCompleted(object sender, EventArgs e)
		{
			try
			{
				// IMPORTANT! regarding WCF async calls.
				//		This control's System.Windows.Forms.Control.Handle was created on
				//		a different thread than the WCF calling thread (Cross-thread).
				//		If so, you must make calls to the control through an invoke method.
				if (InvokeRequired)
				{
					Invoke(_form_GetDataCompletedCallBack, new object[] { sender, e });
					return;
				}
				else
				{
					_gridSettingsCD.ClientSetCaptions();

					Grid.GetDataCompleted(_gridSettingsCD.GridSettings);  // populate the Grid DataSource

					Grid.GridName = "GridSettings"; // set the GridName for GridSettings retrieval
					if (FormatGrid)
					{
						Grid.FormSettings_Set(FormSettings);
						Grid.GridSettings_Apply();
					}

					Grid_GridSettings_Customize();
					Grid_EventHandlers_Add();  // i.e., CellValidating, CellEndEdit
					DataSource_EventHandlers_Add();  // i.e., TableNewRow, RowChanged, RowDeleted
					Form_FilterSetStatusMessage();

					Grid.EnableRetrieveDataButton();
				}
			}
			catch (Exception ex)
			{
				StatusMessage.Text = String.Format("ERROR Retrieving Data...{0}", ex.Message);
			}
		}
		private delegate void Form_GetDataCompletedCallBack(object sender, EventArgs e);
		private void Form_FilterSetStatusMessage()
		{
			StatusMessage.Text = ((DataTable)Grid.BindingSource.DataSource).Rows.Count + " row(s) retrieved. " + Grid.DataGridView.Rows.Count + " row(s) displayed.";
		}

		private void Grid_ToolStrip_Customize()
		{
			// disable the ToolStrip here if it's not needed
			//Grid.TopToolStrip.Visible = false;

			// disable the separator and FormSettings button
			//Grid.TopToolStrip.Items[09].Visible = false;
			//Grid.TopToolStrip.Items[10].Visible = false;

			// to add an Image first add the .bmp,.jpg... to the Resources folder, then
			// go to Properties folder, double-click Resources.resx,
			// Add Resource-Add Existing File... then select the Resources folder image

			//ToolStripButton _btnTest = new ToolStripButton();
			//_btnTest.Image = global::RWR.IssueTracker.UI.Properties.Resources.install;
			//_btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
			//_btnTest.Name = "_btnTest";
			//_btnTest.AutoSize = true;
			//_btnTest.Text = "Button Test";
			//_btnTest.ToolTipText = "Testing of Adding a Button from the Form";
			//Grid.TopToolStrip.Items.Add(_btnTest);
			//_btnTest.Click += _btnTest_Click;
		}
		private void Grid_GridSettings_Customize()
		{
			// set all columns to ReadOnly
			foreach (DataGridViewColumn col in Grid.DataGridView.Columns)
				col.ReadOnly = true;

			// set specific columns editable
			Grid.DataGridView.Columns["DisplayIndex"].ReadOnly = false;
			Grid.DataGridView.Columns["Width"].ReadOnly = false;

			// override specific columns default formatting
			Grid.DataGridView.Columns["DisplayIndex"].DefaultCellStyle.Format = "0";
			//Grid.DataGridView.Columns["Width"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			Grid.DataGridView.Columns["Width"].DefaultCellStyle.Format = "0";
		}
		private void Grid_EventHandlers_Add()
		{
			Grid.GridDoubleClick += Grid_DoubleClick;
			Grid.DataGridView.CellValidating += Grid_CellValidating;
			Grid.DataGridView.CellEndEdit += Grid_CellEndEdit;

			// TODO add custom GRID event handlers
		}
		private void Grid_EventHandlers_Remove()
		{
			//try { Grid.GridDoubleClick -= Grid_DoubleClick; }
			//catch { }
			//try { Grid.DataGridView.CellValidating -= Grid_CellValidating; }
			//catch { }
			//try { Grid.DataGridView.CellEndEdit -= Grid_CellEndEdit; }
			//catch { }

			// TODO add custom GRID event handlers
		}
		private void Grid_DoubleClick(object sender, GridDoubleClickEventArgs e)
		{
			//_oneIssueDataTable.Clear();
			//GridSettingsCD.IssuesRow dr = _oneIssueDataTable.NewIssuesRow();
			//dr.ItemArray = e.Row.ItemArray;
			//_oneIssueDataTable.Rows.Add(dr);
			//_bsIssue.DataSource = _oneIssueDataTable;
			//_oneIssueDataTable.AcceptChanges();

			//btnSave.Visible = true;
			//btnCancel.Visible = true;
			//btnNew.Visible = false;
		}
		private static void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			//CheckGridColumn(sender, e);
		}
		private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			// Clear the row error in case the user presses ESC.   
			Grid.DataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
			Grid.DataGridView.CurrentCell.ErrorText = string.Empty;
		}

		private void DataSource_EventHandlers_Add()
		{
			DataTable dataSource = (DataTable)Grid.BindingSource.DataSource;
			dataSource.TableNewRow += DataSource_TableNewRow;
			dataSource.RowChanged += DataSource_RowUpdated;
			dataSource.RowDeleted += DataSource_RowUpdated;

			// TODO add custom DATASOURCE event handlers
		}
		private void DataSource_EventHandlers_Remove()
		{
			if (Grid.BindingSource.DataSource.ToString() == "GridSettings")
			{
				DataTable dataSource = (DataTable)Grid.BindingSource.DataSource;
				dataSource.TableNewRow -= DataSource_TableNewRow;
				dataSource.RowChanged -= DataSource_RowUpdated;
				dataSource.RowDeleted -= DataSource_RowUpdated;
			}

			// TODO add custom GRID event handlers
		}
		private void DataSource_TableNewRow(object sender, DataTableNewRowEventArgs e)
		{
			DataRowChangeEventArgs ea = new DataRowChangeEventArgs(e.Row, DataRowAction.Add);
			DataSource_RowUpdated(sender, ea);
		}
		private void DataSource_RowUpdated(object sender, DataRowChangeEventArgs e)
		{
			// TODO manually code this
			StatusMessage.Text = "Async Update Started";

			// put the e.Row into a DataSet for transport/update
			GridSettingsCD ds = new GridSettingsCD();
			ds.GridSettings.ImportRow(e.Row);

			//synch USE FOR DEBUGGING
			ds.UserName = SystemInformation.UserName;
			ds.GridName = "GridSettings";
			ds.ClientUpdateGridSettings(false);

			//async USE FOR PRODUCTION
			//ds.ClientUpdateGridSettingsCompleted += Async_UpdateCompleted;
			//ds.ClientUpdateGridSettings(true);
		}

		private void Async_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
		{
			// IMPORTANT! regarding WCF async calls.
			//		This control's System.Windows.Forms.Control.Handle was created on
			//		a different thread than the WCF calling thread (Cross-thread).
			//		If so, you must make calls to the control through an invoke method.
			if (InvokeRequired)
			{
				Invoke(_form_UpdateCompletedCallBack, new object[] { sender, e });
				return;
			}
			else
			{
				if (e.Error != null)
					StatusMessage.Text = e.Error.Message;
			}
		}
		private delegate void Form_UpdateCompletedCallBack(object sender, AsyncCompletedEventArgs e);

	}
}
