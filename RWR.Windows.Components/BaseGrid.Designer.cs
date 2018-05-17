namespace RWR.Windows.Components
{
    partial class BaseGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this._sep1 = new System.Windows.Forms.ToolStripSeparator();
			this._sep2 = new System.Windows.Forms.ToolStripSeparator();
			this._sep3 = new System.Windows.Forms.ToolStripSeparator();
			this._sep4 = new System.Windows.Forms.ToolStripSeparator();
			this._sep5 = new System.Windows.Forms.ToolStripSeparator();
			this.TopToolStrip = new System.Windows.Forms.ToolStrip();
			this._btnSort = new System.Windows.Forms.ToolStripButton();
			this._btnFilter = new System.Windows.Forms.ToolStripButton();
			this._btnFind = new System.Windows.Forms.ToolStripButton();
			this._btnRetrieveData = new System.Windows.Forms.ToolStripButton();
			this._btnColumns = new System.Windows.Forms.ToolStripButton();
			this._btnFormSettings = new System.Windows.Forms.ToolStripButton();
			this._tsSort = new System.Windows.Forms.ToolStrip();
			this._cboSortCol1 = new System.Windows.Forms.ToolStripComboBox();
			this._cboSortSrt1 = new System.Windows.Forms.ToolStripComboBox();
			this._sepSort1 = new System.Windows.Forms.ToolStripSeparator();
			this._cboSortCol2 = new System.Windows.Forms.ToolStripComboBox();
			this._cboSortSrt2 = new System.Windows.Forms.ToolStripComboBox();
			this._sepSort2 = new System.Windows.Forms.ToolStripSeparator();
			this._cboSortCol3 = new System.Windows.Forms.ToolStripComboBox();
			this._cboSortSrt3 = new System.Windows.Forms.ToolStripComboBox();
			this._btnSortRemove = new System.Windows.Forms.ToolStripButton();
			this._btnSortApply = new System.Windows.Forms.ToolStripButton();
			this._tsFilter = new System.Windows.Forms.ToolStrip();
			this._txtFilter = new System.Windows.Forms.ToolStripTextBox();
			this._btnFilterRemove = new System.Windows.Forms.ToolStripButton();
			this._btnFilterApply = new System.Windows.Forms.ToolStripButton();
			this._btnFilterEditor = new System.Windows.Forms.ToolStripButton();
			this.DataGridView = new System.Windows.Forms.DataGridView();
			this.Banner = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
			this.TopToolStrip.SuspendLayout();
			this._tsSort.SuspendLayout();
			this._tsFilter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(RWR.Windows.Components.DSBO.GridSettingsCD);
			this.BindingSource.Position = 0;
			// 
			// _sep1
			// 
			this._sep1.Name = "_sep1";
			this._sep1.Size = new System.Drawing.Size(6, 25);
			// 
			// _sep2
			// 
			this._sep2.Name = "_sep2";
			this._sep2.Size = new System.Drawing.Size(6, 25);
			// 
			// _sep3
			// 
			this._sep3.Name = "_sep3";
			this._sep3.Size = new System.Drawing.Size(6, 25);
			// 
			// _sep4
			// 
			this._sep4.Name = "_sep4";
			this._sep4.Size = new System.Drawing.Size(6, 25);
			// 
			// _sep5
			// 
			this._sep5.Name = "_sep5";
			this._sep5.Size = new System.Drawing.Size(6, 25);
			// 
			// TopToolStrip
			// 
			this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnSort,
            this._sep1,
            this._btnFilter,
            this._sep2,
            this._btnFind,
            this._sep3,
            this._btnRetrieveData,
            this._sep4,
            this._btnColumns,
            this._sep5,
            this._btnFormSettings});
			this.TopToolStrip.Location = new System.Drawing.Point(0, 19);
			this.TopToolStrip.Name = "TopToolStrip";
			this.TopToolStrip.Size = new System.Drawing.Size(751, 25);
			this.TopToolStrip.TabIndex = 24;
			this.TopToolStrip.Text = "toolStrip1";
			// 
			// _btnSort
			// 
			this._btnSort.Image = global::RWR.Windows.Components.Properties.Resources.Sort;
			this._btnSort.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnSort.Name = "_btnSort";
			this._btnSort.Size = new System.Drawing.Size(47, 22);
			this._btnSort.Text = "Sort";
			this._btnSort.ToolTipText = "Show Sort Control";
			this._btnSort.Click += new System.EventHandler(this._btnSort_Click);
			// 
			// _btnFilter
			// 
			this._btnFilter.Image = global::RWR.Windows.Components.Properties.Resources.Filter;
			this._btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnFilter.Name = "_btnFilter";
			this._btnFilter.Size = new System.Drawing.Size(51, 22);
			this._btnFilter.Text = "Filter";
			this._btnFilter.ToolTipText = "Show Filter Control";
			this._btnFilter.Click += new System.EventHandler(this._btnFilter_Click);
			// 
			// _btnFind
			// 
			this._btnFind.Image = global::RWR.Windows.Components.Properties.Resources.Find;
			this._btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnFind.Name = "_btnFind";
			this._btnFind.Size = new System.Drawing.Size(47, 22);
			this._btnFind.Text = "Find";
			this._btnFind.ToolTipText = "Open the Find window to search for a value in the Grid";
			this._btnFind.Click += new System.EventHandler(this._btnFind_Click);
			// 
			// _btnRetrieveData
			// 
			this._btnRetrieveData.Image = global::RWR.Windows.Components.Properties.Resources.RetrieveData;
			this._btnRetrieveData.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnRetrieveData.Name = "_btnRetrieveData";
			this._btnRetrieveData.Size = new System.Drawing.Size(94, 22);
			this._btnRetrieveData.Text = "Retrieve Data";
			this._btnRetrieveData.ToolTipText = "Refresh the Data in the Grid";
			this._btnRetrieveData.Click += new System.EventHandler(this._btnRetrieveData_Click);
			// 
			// _btnColumns
			// 
			this._btnColumns.Image = global::RWR.Windows.Components.Properties.Resources.Properties;
			this._btnColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnColumns.Name = "_btnColumns";
			this._btnColumns.Size = new System.Drawing.Size(79, 22);
			this._btnColumns.Text = "Columns...";
			this._btnColumns.ToolTipText = "Open the Columns Editor window";
			this._btnColumns.Click += new System.EventHandler(this._btnColumns_Click);
			// 
			// _btnFormSettings
			// 
			this._btnFormSettings.Image = global::RWR.Windows.Components.Properties.Resources.Tools;
			this._btnFormSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnFormSettings.Name = "_btnFormSettings";
			this._btnFormSettings.Size = new System.Drawing.Size(93, 22);
			this._btnFormSettings.Text = "Form Settings";
			this._btnFormSettings.ToolTipText = "Open the Form Settings window";
			this._btnFormSettings.Click += new System.EventHandler(this._btnFormSettings_Click);
			// 
			// _tsSort
			// 
			this._tsSort.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._tsSort.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._cboSortCol1,
            this._cboSortSrt1,
            this._sepSort1,
            this._cboSortCol2,
            this._cboSortSrt2,
            this._sepSort2,
            this._cboSortCol3,
            this._cboSortSrt3,
            this._btnSortRemove,
            this._btnSortApply});
			this._tsSort.Location = new System.Drawing.Point(0, 44);
			this._tsSort.Name = "_tsSort";
			this._tsSort.Size = new System.Drawing.Size(751, 25);
			this._tsSort.TabIndex = 34;
			this._tsSort.Text = "toolStrip1";
			this._tsSort.Visible = false;
			// 
			// _cboSortCol1
			// 
			this._cboSortCol1.AutoSize = false;
			this._cboSortCol1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboSortCol1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._cboSortCol1.Name = "_cboSortCol1";
			this._cboSortCol1.Size = new System.Drawing.Size(135, 19);
			this._cboSortCol1.SelectedIndexChanged += new System.EventHandler(this._cboSortCol1_SelectedIndexChanged);
			// 
			// _cboSortSrt1
			// 
			this._cboSortSrt1.AutoSize = false;
			this._cboSortSrt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboSortSrt1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._cboSortSrt1.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
			this._cboSortSrt1.Name = "_cboSortSrt1";
			this._cboSortSrt1.Size = new System.Drawing.Size(48, 19);
			// 
			// _sepSort1
			// 
			this._sepSort1.AutoSize = false;
			this._sepSort1.Name = "_sepSort1";
			this._sepSort1.Size = new System.Drawing.Size(20, 25);
			// 
			// _cboSortCol2
			// 
			this._cboSortCol2.AutoSize = false;
			this._cboSortCol2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboSortCol2.Enabled = false;
			this._cboSortCol2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._cboSortCol2.Name = "_cboSortCol2";
			this._cboSortCol2.Size = new System.Drawing.Size(135, 19);
			this._cboSortCol2.SelectedIndexChanged += new System.EventHandler(this._cboSortCol2_SelectedIndexChanged);
			// 
			// _cboSortSrt2
			// 
			this._cboSortSrt2.AutoSize = false;
			this._cboSortSrt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboSortSrt2.Enabled = false;
			this._cboSortSrt2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._cboSortSrt2.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
			this._cboSortSrt2.Name = "_cboSortSrt2";
			this._cboSortSrt2.Size = new System.Drawing.Size(48, 19);
			// 
			// _sepSort2
			// 
			this._sepSort2.AutoSize = false;
			this._sepSort2.Name = "_sepSort2";
			this._sepSort2.Size = new System.Drawing.Size(20, 25);
			// 
			// _cboSortCol3
			// 
			this._cboSortCol3.AutoSize = false;
			this._cboSortCol3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboSortCol3.Enabled = false;
			this._cboSortCol3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._cboSortCol3.Name = "_cboSortCol3";
			this._cboSortCol3.Size = new System.Drawing.Size(135, 19);
			// 
			// _cboSortSrt3
			// 
			this._cboSortSrt3.AutoSize = false;
			this._cboSortSrt3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboSortSrt3.Enabled = false;
			this._cboSortSrt3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._cboSortSrt3.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
			this._cboSortSrt3.Name = "_cboSortSrt3";
			this._cboSortSrt3.Size = new System.Drawing.Size(48, 19);
			// 
			// _btnSortRemove
			// 
			this._btnSortRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this._btnSortRemove.Enabled = false;
			this._btnSortRemove.Image = global::RWR.Windows.Components.Properties.Resources.Delete;
			this._btnSortRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnSortRemove.Name = "_btnSortRemove";
			this._btnSortRemove.Size = new System.Drawing.Size(60, 22);
			this._btnSortRemove.Text = "&Remove";
			this._btnSortRemove.ToolTipText = "Remove Sort";
			this._btnSortRemove.Click += new System.EventHandler(this._btnSortRemove_Click);
			// 
			// _btnSortApply
			// 
			this._btnSortApply.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this._btnSortApply.Image = global::RWR.Windows.Components.Properties.Resources.OK;
			this._btnSortApply.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnSortApply.Name = "_btnSortApply";
			this._btnSortApply.Size = new System.Drawing.Size(50, 22);
			this._btnSortApply.Text = "&Apply";
			this._btnSortApply.ToolTipText = "Apply Sort";
			this._btnSortApply.Click += new System.EventHandler(this._btnSortApply_Click);
			// 
			// _tsFilter
			// 
			this._tsFilter.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._tsFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._txtFilter,
            this._btnFilterRemove,
            this._btnFilterApply,
            this._btnFilterEditor});
			this._tsFilter.Location = new System.Drawing.Point(0, 44);
			this._tsFilter.Name = "_tsFilter";
			this._tsFilter.Size = new System.Drawing.Size(751, 25);
			this._tsFilter.TabIndex = 35;
			this._tsFilter.Text = "toolStrip1";
			this._tsFilter.Visible = false;
			// 
			// _txtFilter
			// 
			this._txtFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this._txtFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this._txtFilter.Name = "_txtFilter";
			this._txtFilter.ReadOnly = true;
			this._txtFilter.Size = new System.Drawing.Size(550, 25);
			// 
			// _btnFilterRemove
			// 
			this._btnFilterRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this._btnFilterRemove.Enabled = false;
			this._btnFilterRemove.Image = global::RWR.Windows.Components.Properties.Resources.Delete;
			this._btnFilterRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnFilterRemove.Name = "_btnFilterRemove";
			this._btnFilterRemove.Size = new System.Drawing.Size(60, 22);
			this._btnFilterRemove.Text = "&Remove";
			this._btnFilterRemove.ToolTipText = "Remove Filter";
			this._btnFilterRemove.Click += new System.EventHandler(this._btnFilterRemove_Click);
			// 
			// _btnFilterApply
			// 
			this._btnFilterApply.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this._btnFilterApply.Image = global::RWR.Windows.Components.Properties.Resources.OK;
			this._btnFilterApply.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnFilterApply.Name = "_btnFilterApply";
			this._btnFilterApply.Size = new System.Drawing.Size(50, 22);
			this._btnFilterApply.Text = "&Apply";
			this._btnFilterApply.ToolTipText = "Apply Filter";
			this._btnFilterApply.Click += new System.EventHandler(this._btnFilterApply_Click);
			// 
			// _btnFilterEditor
			// 
			this._btnFilterEditor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this._btnFilterEditor.Image = global::RWR.Windows.Components.Properties.Resources.Filter;
			this._btnFilterEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnFilterEditor.Name = "_btnFilterEditor";
			this._btnFilterEditor.Size = new System.Drawing.Size(49, 22);
			this._btnFilterEditor.Text = "Editor";
			this._btnFilterEditor.Click += new System.EventHandler(this._btnFilterEditor_Click);
			// 
			// DataGridView
			// 
			this.DataGridView.AllowUserToAddRows = false;
			this.DataGridView.AllowUserToDeleteRows = false;
			this.DataGridView.AllowUserToOrderColumns = true;
			this.DataGridView.AutoGenerateColumns = false;
			this.DataGridView.DataSource = this.BindingSource;
			this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataGridView.Location = new System.Drawing.Point(0, 44);
			this.DataGridView.Name = "DataGridView";
			this.DataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.DataGridView.Size = new System.Drawing.Size(751, 497);
			this.DataGridView.TabIndex = 17;
			this.DataGridView.Text = "dgv1";
			this.DataGridView.DoubleClick += new System.EventHandler(this._dgvGrid_DoubleClick);
			this.DataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this._dgvGrid_MouseUp);
			// 
			// Banner
			// 
			this.Banner.BackColor = System.Drawing.SystemColors.Control;
			this.Banner.Dock = System.Windows.Forms.DockStyle.Top;
			this.Banner.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Banner.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Banner.Location = new System.Drawing.Point(0, 0);
			this.Banner.Name = "Banner";
			this.Banner.Size = new System.Drawing.Size(751, 19);
			this.Banner.TabIndex = 37;
			this.Banner.Text = "Banner Text";
			this.Banner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BaseGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.DataGridView);
			this.Controls.Add(this._tsSort);
			this.Controls.Add(this._tsFilter);
			this.Controls.Add(this.TopToolStrip);
			this.Controls.Add(this.Banner);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "BaseGrid";
			this.Size = new System.Drawing.Size(751, 541);
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
			this.TopToolStrip.ResumeLayout(false);
			this.TopToolStrip.PerformLayout();
			this._tsSort.ResumeLayout(false);
			this._tsSort.PerformLayout();
			this._tsFilter.ResumeLayout(false);
			this._tsFilter.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ToolStripButton _btnSort;
		private System.Windows.Forms.ToolStripSeparator _sep1;
		private System.Windows.Forms.ToolStripButton _btnFilter;
		private System.Windows.Forms.ToolStripSeparator _sep2;
		private System.Windows.Forms.ToolStripButton _btnFind;
		private System.Windows.Forms.ToolStripSeparator _sep3;
		private System.Windows.Forms.ToolStripButton _btnRetrieveData;
		private System.Windows.Forms.ToolStripSeparator _sep4;
		private System.Windows.Forms.ToolStripButton _btnColumns;
		private System.Windows.Forms.ToolStripSeparator _sep5;
		private System.Windows.Forms.ToolStripButton _btnFormSettings;
		private System.Windows.Forms.ToolStripComboBox _cboSortCol1;
		private System.Windows.Forms.ToolStripComboBox _cboSortSrt1;
		private System.Windows.Forms.ToolStripSeparator _sepSort1;
		private System.Windows.Forms.ToolStripComboBox _cboSortCol2;
		private System.Windows.Forms.ToolStripComboBox _cboSortSrt2;
		private System.Windows.Forms.ToolStripSeparator _sepSort2;
		private System.Windows.Forms.ToolStripComboBox _cboSortCol3;
		private System.Windows.Forms.ToolStripComboBox _cboSortSrt3;
		private System.Windows.Forms.ToolStripButton _btnSortRemove;
		private System.Windows.Forms.ToolStripButton _btnSortApply;
		private System.Windows.Forms.ToolStripTextBox _txtFilter;
		private System.Windows.Forms.ToolStripButton _btnFilterRemove;
		private System.Windows.Forms.ToolStripButton _btnFilterApply;
		private System.Windows.Forms.ToolStripButton _btnFilterEditor;
		/// <summary>
		/// 
		/// </summary>
		public System.Windows.Forms.ToolStrip TopToolStrip;
		/// <summary>
		/// 
		/// </summary>
		public System.Windows.Forms.DataGridView DataGridView;
		/// <summary>
		/// 
		/// </summary>
		public System.Windows.Forms.Label Banner;
		private System.Windows.Forms.ToolStrip _tsSort;
		private System.Windows.Forms.ToolStrip _tsFilter;
		/// <summary>
		/// 
		/// </summary>
		public System.Windows.Forms.BindingSource BindingSource;
    }
}
