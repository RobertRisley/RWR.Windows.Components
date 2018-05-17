namespace RWR.Windows.Components
{
    partial class FilterEditorUi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.FilterGrid = new System.Windows.Forms.DataGridView();
			this._cboGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this._cboLogic = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this._cboColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this._cboOperator = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this._txtValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this._txtMapping = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnRemoveRow = new System.Windows.Forms.Button();
			this.cboLogic = new System.Windows.Forms.ComboBox();
			this.cboGroup = new System.Windows.Forms.ComboBox();
			this.cboColumn = new System.Windows.Forms.ComboBox();
			this.cboOperator = new System.Windows.Forms.ComboBox();
			this._btnAddRow = new System.Windows.Forms.Button();
			this.txtValue = new System.Windows.Forms.TextBox();
			this._btnOk = new System.Windows.Forms.Button();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this._lblFilter = new System.Windows.Forms.ToolStripLabel();
			this._cboSelect = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this._btnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this._btnNew = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this._btnDelete = new System.Windows.Forms.ToolStripButton();
			this._btnRemoveAll = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.FilterGrid)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// FilterGrid
			// 
			this.FilterGrid.AllowUserToAddRows = false;
			this.FilterGrid.AllowUserToResizeColumns = false;
			this.FilterGrid.AllowUserToResizeRows = false;
			this.FilterGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.FilterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.FilterGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._cboGroup,
            this._cboLogic,
            this._cboColumn,
            this._cboOperator,
            this._txtValue,
            this._txtMapping});
			this.FilterGrid.GridColor = System.Drawing.SystemColors.Control;
			this.FilterGrid.Location = new System.Drawing.Point(11, 74);
			this.FilterGrid.Name = "FilterGrid";
			this.FilterGrid.ReadOnly = true;
			this.FilterGrid.RowHeadersWidth = 39;
			this.FilterGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.FilterGrid.Size = new System.Drawing.Size(657, 217);
			this.FilterGrid.TabIndex = 10;
			this.FilterGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Grid_CellValidating);
			this.FilterGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellEndEdit);
			this.FilterGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Grid_EditingControlShowing);
			this.FilterGrid.CurrentCellChanged += new System.EventHandler(this.Grid_CurrentCellChanged);
			this.FilterGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Grid_RowsRemoved);
			// 
			// _cboGroup
			// 
			this._cboGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this._cboGroup.HeaderText = "Group";
			this._cboGroup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this._cboGroup.MaxDropDownItems = 16;
			this._cboGroup.Name = "_cboGroup";
			this._cboGroup.ReadOnly = true;
			this._cboGroup.Width = 40;
			// 
			// _cboLogic
			// 
			this._cboLogic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this._cboLogic.HeaderText = "Logic";
			this._cboLogic.Items.AddRange(new object[] {
            "AND",
            "OR"});
			this._cboLogic.MaxDropDownItems = 16;
			this._cboLogic.Name = "_cboLogic";
			this._cboLogic.ReadOnly = true;
			this._cboLogic.Width = 50;
			// 
			// _cboColumn
			// 
			this._cboColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this._cboColumn.HeaderText = "Column Name";
			this._cboColumn.MaxDropDownItems = 16;
			this._cboColumn.Name = "_cboColumn";
			this._cboColumn.ReadOnly = true;
			this._cboColumn.Width = 175;
			// 
			// _cboOperator
			// 
			this._cboOperator.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this._cboOperator.HeaderText = "Operator";
			this._cboOperator.Items.AddRange(new object[] {
            "Equals",
            "NOT Equal",
            "Contains",
            "Does NOT Contain",
            "StartsWith",
            "EndsWith",
            "LessThan",
            "LessThan or Equal",
            "GreaterThan",
            "GreaterThan or Equal",
            "is EMPTY",
            "is NOT EMPTY",
            "is NULL",
            "is NOT NULL",
            "InList",
            "NOT InList",
            "is True",
            "is False"});
			this._cboOperator.MaxDropDownItems = 16;
			this._cboOperator.Name = "_cboOperator";
			this._cboOperator.ReadOnly = true;
			this._cboOperator.Width = 140;
			// 
			// _txtValue
			// 
			this._txtValue.HeaderText = "Value";
			this._txtValue.Name = "_txtValue";
			this._txtValue.ReadOnly = true;
			this._txtValue.Width = 175;
			// 
			// _txtMapping
			// 
			this._txtMapping.HeaderText = "Mapping";
			this._txtMapping.Name = "_txtMapping";
			this._txtMapping.ReadOnly = true;
			this._txtMapping.Visible = false;
			// 
			// _btnCancel
			// 
			this._btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnCancel.Location = new System.Drawing.Point(593, 297);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 21;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = false;
			this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
			// 
			// _btnRemoveRow
			// 
			this._btnRemoveRow.AutoSize = true;
			this._btnRemoveRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
			this._btnRemoveRow.Location = new System.Drawing.Point(11, 297);
			this._btnRemoveRow.Name = "_btnRemoveRow";
			this._btnRemoveRow.Size = new System.Drawing.Size(125, 23);
			this._btnRemoveRow.TabIndex = 88;
			this._btnRemoveRow.Text = "Delete selected row(s)";
			this._btnRemoveRow.UseVisualStyleBackColor = false;
			this._btnRemoveRow.Visible = false;
			this._btnRemoveRow.Click += new System.EventHandler(this._btnRemoveRow_Click);
			// 
			// cboLogic
			// 
			this.cboLogic.FormattingEnabled = true;
			this.cboLogic.Items.AddRange(new object[] {
            "AND",
            "OR"});
			this.cboLogic.Location = new System.Drawing.Point(89, 41);
			this.cboLogic.Name = "cboLogic";
			this.cboLogic.Size = new System.Drawing.Size(50, 21);
			this.cboLogic.TabIndex = 1;
			this.cboLogic.Visible = false;
			// 
			// cboGroup
			// 
			this.cboGroup.FormattingEnabled = true;
			this.cboGroup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.cboGroup.Location = new System.Drawing.Point(49, 41);
			this.cboGroup.MaxDropDownItems = 9;
			this.cboGroup.Name = "cboGroup";
			this.cboGroup.Size = new System.Drawing.Size(40, 21);
			this.cboGroup.TabIndex = 0;
			this.cboGroup.Visible = false;
			// 
			// cboColumn
			// 
			this.cboColumn.FormattingEnabled = true;
			this.cboColumn.Location = new System.Drawing.Point(139, 41);
			this.cboColumn.MaxDropDownItems = 16;
			this.cboColumn.Name = "cboColumn";
			this.cboColumn.Size = new System.Drawing.Size(175, 21);
			this.cboColumn.TabIndex = 2;
			this.cboColumn.Visible = false;
			this.cboColumn.SelectedIndexChanged += new System.EventHandler(this.cboColumn_SelectedIndexChanged);
			// 
			// cboOperator
			// 
			this.cboOperator.FormattingEnabled = true;
			this.cboOperator.Location = new System.Drawing.Point(314, 41);
			this.cboOperator.MaxDropDownItems = 16;
			this.cboOperator.Name = "cboOperator";
			this.cboOperator.Size = new System.Drawing.Size(140, 21);
			this.cboOperator.TabIndex = 3;
			this.cboOperator.Visible = false;
			this.cboOperator.SelectedIndexChanged += new System.EventHandler(this.cboOperator_SelectedIndexChanged);
			// 
			// _btnAddRow
			// 
			this._btnAddRow.Location = new System.Drawing.Point(630, 40);
			this._btnAddRow.Name = "_btnAddRow";
			this._btnAddRow.Size = new System.Drawing.Size(38, 23);
			this._btnAddRow.TabIndex = 5;
			this._btnAddRow.Text = "Add";
			this._btnAddRow.UseVisualStyleBackColor = true;
			this._btnAddRow.Visible = false;
			this._btnAddRow.Click += new System.EventHandler(this._btnAddRow_Click);
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(455, 41);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(175, 21);
			this.txtValue.TabIndex = 4;
			this.txtValue.Visible = false;
			// 
			// _btnOk
			// 
			this._btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(512, 297);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 23);
			this._btnOk.TabIndex = 20;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = false;
			this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lblFilter,
            this._cboSelect,
            this.toolStripSeparator1,
            this._btnEdit,
            this.toolStripSeparator2,
            this._btnNew,
            this.toolStripSeparator3,
            this._btnDelete});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(678, 25);
			this.toolStrip1.TabIndex = 99;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// _lblFilter
			// 
			this._lblFilter.Name = "_lblFilter";
			this._lblFilter.Size = new System.Drawing.Size(36, 22);
			this._lblFilter.Text = "Filter:";
			// 
			// _cboSelect
			// 
			this._cboSelect.Name = "_cboSelect";
			this._cboSelect.Size = new System.Drawing.Size(268, 25);
			this._cboSelect.SelectedIndexChanged += new System.EventHandler(this._cboSelect_SelectedIndexChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// _btnEdit
			// 
			this._btnEdit.AutoSize = false;
			this._btnEdit.Image = global::RWR.Windows.Components.Properties.Resources.Entry;
			this._btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnEdit.Name = "_btnEdit";
			this._btnEdit.Size = new System.Drawing.Size(80, 22);
			this._btnEdit.Text = "Edit";
			this._btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._btnEdit.Click += new System.EventHandler(this._btnEdit_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// _btnNew
			// 
			this._btnNew.AutoSize = false;
			this._btnNew.Image = global::RWR.Windows.Components.Properties.Resources.New;
			this._btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnNew.Name = "_btnNew";
			this._btnNew.Size = new System.Drawing.Size(80, 22);
			this._btnNew.Text = "New";
			this._btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._btnNew.Click += new System.EventHandler(this._btnNew_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// _btnDelete
			// 
			this._btnDelete.AutoSize = false;
			this._btnDelete.Image = global::RWR.Windows.Components.Properties.Resources.Delete;
			this._btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnDelete.Name = "_btnDelete";
			this._btnDelete.Size = new System.Drawing.Size(80, 22);
			this._btnDelete.Text = "Delete";
			this._btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
			// 
			// _btnRemoveAll
			// 
			this._btnRemoveAll.AutoSize = true;
			this._btnRemoveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
			this._btnRemoveAll.Location = new System.Drawing.Point(142, 297);
			this._btnRemoveAll.Name = "_btnRemoveAll";
			this._btnRemoveAll.Size = new System.Drawing.Size(125, 23);
			this._btnRemoveAll.TabIndex = 100;
			this._btnRemoveAll.Text = "Delete ALL rows";
			this._btnRemoveAll.UseVisualStyleBackColor = false;
			this._btnRemoveAll.Visible = false;
			this._btnRemoveAll.Click += new System.EventHandler(this._btnRemoveAll_Click);
			// 
			// FilterEditorUi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(678, 336);
			this.Controls.Add(this._btnRemoveAll);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this._btnOk);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this._btnAddRow);
			this.Controls.Add(this.cboOperator);
			this.Controls.Add(this.cboColumn);
			this.Controls.Add(this.cboGroup);
			this.Controls.Add(this.cboLogic);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnRemoveRow);
			this.Controls.Add(this.FilterGrid);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(684, 362);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(684, 362);
			this.Name = "FilterEditorUi";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Filter Editor";
			((System.ComponentModel.ISupportInitialize)(this.FilterGrid)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnRemoveRow;
		private System.Windows.Forms.ComboBox cboLogic;
		private System.Windows.Forms.ComboBox cboGroup;
		private System.Windows.Forms.ComboBox cboColumn;
		private System.Windows.Forms.ComboBox cboOperator;
		private System.Windows.Forms.Button _btnAddRow;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.Button _btnOk;
		/// <summary>
		/// 
		/// </summary>
		public System.Windows.Forms.DataGridView FilterGrid;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel _lblFilter;
		private System.Windows.Forms.ToolStripComboBox _cboSelect;
		private System.Windows.Forms.ToolStripButton _btnEdit;
		private System.Windows.Forms.ToolStripButton _btnNew;
		private System.Windows.Forms.ToolStripButton _btnDelete;
		private System.Windows.Forms.DataGridViewComboBoxColumn _cboGroup;
		private System.Windows.Forms.DataGridViewComboBoxColumn _cboLogic;
		private System.Windows.Forms.DataGridViewComboBoxColumn _cboColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn _cboOperator;
		private System.Windows.Forms.DataGridViewTextBoxColumn _txtValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn _txtMapping;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Button _btnRemoveAll;

    }
}