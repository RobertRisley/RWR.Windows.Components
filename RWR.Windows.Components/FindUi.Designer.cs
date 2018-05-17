namespace RWR.Windows.Components
{
    partial class FindUi
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
			this.label1 = new System.Windows.Forms.Label();
			this._txtFind = new System.Windows.Forms.TextBox();
			this._btnCancel = new System.Windows.Forms.Button();
			this._chkMatchCase = new System.Windows.Forms.CheckBox();
			this._chkMatchWholeWord = new System.Windows.Forms.CheckBox();
			this._btnFindNext = new System.Windows.Forms.Button();
			this._lblSearchType = new System.Windows.Forms.Label();
			this._cboSearch = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Find what:";
			// 
			// _txtFind
			// 
			this._txtFind.Location = new System.Drawing.Point(73, 6);
			this._txtFind.Name = "_txtFind";
			this._txtFind.Size = new System.Drawing.Size(351, 20);
			this._txtFind.TabIndex = 1;
			this._txtFind.TextChanged += new System.EventHandler(this._txtFind_TextChanged);
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(349, 51);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 5;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			this._btnCancel.Click += new System.EventHandler(this._btnClose_Click);
			// 
			// _chkMatchCase
			// 
			this._chkMatchCase.AutoSize = true;
			this._chkMatchCase.Location = new System.Drawing.Point(12, 38);
			this._chkMatchCase.Name = "_chkMatchCase";
			this._chkMatchCase.Size = new System.Drawing.Size(82, 17);
			this._chkMatchCase.TabIndex = 3;
			this._chkMatchCase.Text = "Match &case";
			this._chkMatchCase.UseVisualStyleBackColor = true;
			// 
			// _chkMatchWholeWord
			// 
			this._chkMatchWholeWord.AutoSize = true;
			this._chkMatchWholeWord.Location = new System.Drawing.Point(12, 55);
			this._chkMatchWholeWord.Name = "_chkMatchWholeWord";
			this._chkMatchWholeWord.Size = new System.Drawing.Size(113, 17);
			this._chkMatchWholeWord.TabIndex = 4;
			this._chkMatchWholeWord.Text = "Match &whole word";
			this._chkMatchWholeWord.UseVisualStyleBackColor = true;
			// 
			// _btnFindNext
			// 
			this._btnFindNext.Enabled = false;
			this._btnFindNext.Location = new System.Drawing.Point(268, 51);
			this._btnFindNext.Name = "_btnFindNext";
			this._btnFindNext.Size = new System.Drawing.Size(75, 23);
			this._btnFindNext.TabIndex = 6;
			this._btnFindNext.Text = "&Find Next";
			this._btnFindNext.UseVisualStyleBackColor = true;
			this._btnFindNext.Click += new System.EventHandler(this._btnFind_Click);
			// 
			// _lblSearchType
			// 
			this._lblSearchType.AutoSize = true;
			this._lblSearchType.Location = new System.Drawing.Point(140, 57);
			this._lblSearchType.Name = "_lblSearchType";
			this._lblSearchType.Size = new System.Drawing.Size(44, 13);
			this._lblSearchType.TabIndex = 7;
			this._lblSearchType.Text = "Search:";
			// 
			// _cboSearch
			// 
			this._cboSearch.FormattingEnabled = true;
			this._cboSearch.Items.AddRange(new object[] {
            "Down",
            "Up"});
			this._cboSearch.Location = new System.Drawing.Point(185, 52);
			this._cboSearch.Name = "_cboSearch";
			this._cboSearch.Size = new System.Drawing.Size(55, 21);
			this._cboSearch.TabIndex = 8;
			// 
			// FindUi
			// 
			this.AcceptButton = this._btnFindNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(438, 83);
			this.Controls.Add(this._cboSearch);
			this.Controls.Add(this._lblSearchType);
			this.Controls.Add(this._btnFindNext);
			this.Controls.Add(this._chkMatchWholeWord);
			this.Controls.Add(this._chkMatchCase);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._txtFind);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FindUi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Find";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _txtFind;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.CheckBox _chkMatchCase;
        private System.Windows.Forms.CheckBox _chkMatchWholeWord;
		private System.Windows.Forms.Button _btnFindNext;
		private System.Windows.Forms.Label _lblSearchType;
		private System.Windows.Forms.ComboBox _cboSearch;
    }
}