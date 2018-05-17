namespace RWR.Windows.Components
{
	partial class FormSettingsUi
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
			this._tabctl = new System.Windows.Forms.TabControl();
			this._tpGridSettings = new System.Windows.Forms.TabPage();
			this._cboAltColor1 = new RWR.Windows.Components.ColorComboBox();
			this._lblAltColor1 = new System.Windows.Forms.Label();
			this._btnOK = new System.Windows.Forms.Button();
			this._btnCancel = new System.Windows.Forms.Button();
			this._tabctl.SuspendLayout();
			this._tpGridSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// _tabctl
			// 
			this._tabctl.Controls.Add(this._tpGridSettings);
			this._tabctl.Location = new System.Drawing.Point(0, 0);
			this._tabctl.Name = "_tabctl";
			this._tabctl.SelectedIndex = 0;
			this._tabctl.Size = new System.Drawing.Size(378, 205);
			this._tabctl.TabIndex = 18;
			this._tabctl.TabStop = false;
			// 
			// _tpGridSettings
			// 
			this._tpGridSettings.Controls.Add(this._cboAltColor1);
			this._tpGridSettings.Controls.Add(this._lblAltColor1);
			this._tpGridSettings.Location = new System.Drawing.Point(4, 22);
			this._tpGridSettings.Name = "_tpGridSettings";
			this._tpGridSettings.Size = new System.Drawing.Size(370, 179);
			this._tpGridSettings.TabIndex = 1;
			this._tpGridSettings.Text = "Grid Settings";
			this._tpGridSettings.UseVisualStyleBackColor = true;
			// 
			// _cboAltColor1
			// 
			this._cboAltColor1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this._cboAltColor1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this._cboAltColor1.BackColor = System.Drawing.SystemColors.Window;
			this._cboAltColor1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this._cboAltColor1.FormattingEnabled = true;
			this._cboAltColor1.Location = new System.Drawing.Point(154, 23);
			this._cboAltColor1.Name = "_cboAltColor1";
			this._cboAltColor1.SelectedColor = System.Drawing.SystemColors.Window;
			this._cboAltColor1.Size = new System.Drawing.Size(154, 22);
			this._cboAltColor1.TabIndex = 17;
			// 
			// _lblAltColor1
			// 
			this._lblAltColor1.Location = new System.Drawing.Point(16, 16);
			this._lblAltColor1.Name = "_lblAltColor1";
			this._lblAltColor1.Size = new System.Drawing.Size(132, 24);
			this._lblAltColor1.TabIndex = 12;
			this._lblAltColor1.Text = "Alternating Rows Color:";
			this._lblAltColor1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// _btnOK
			// 
			this._btnOK.Location = new System.Drawing.Point(213, 215);
			this._btnOK.Name = "_btnOK";
			this._btnOK.Size = new System.Drawing.Size(75, 23);
			this._btnOK.TabIndex = 19;
			this._btnOK.Text = "OK";
			this._btnOK.UseVisualStyleBackColor = true;
			this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(294, 215);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 20;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
			// 
			// FormSettingsUi
			// 
			this.AcceptButton = this._btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(378, 249);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._tabctl);
			this.Controls.Add(this._btnOK);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormSettingsUi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Form Settings";
			this._tabctl.ResumeLayout(false);
			this._tpGridSettings.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl _tabctl;
		private System.Windows.Forms.TabPage _tpGridSettings;
		private RWR.Windows.Components.ColorComboBox _cboAltColor1;
		private System.Windows.Forms.Label _lblAltColor1;
		private System.Windows.Forms.Button _btnOK;
		private System.Windows.Forms.Button _btnCancel;
	}
}