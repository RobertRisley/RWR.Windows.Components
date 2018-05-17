namespace RWR.Windows.Components
{
    partial class ColumnsEditorUi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnsEditorUi));
            this._clbColumns = new System.Windows.Forms.CheckedListBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._lblColumns = new System.Windows.Forms.Label();
            this._ilColumnsEditor = new System.Windows.Forms.ImageList(this.components);
            this._btnMoveUp = new System.Windows.Forms.Button();
            this._btnMoveDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _clbColumns
            // 
            this._clbColumns.FormattingEnabled = true;
            this._clbColumns.Location = new System.Drawing.Point(17, 29);
            this._clbColumns.Name = "_clbColumns";
            this._clbColumns.Size = new System.Drawing.Size(222, 260);
            this._clbColumns.TabIndex = 1;
            this._clbColumns.SelectedIndexChanged += new System.EventHandler(this._clbColumns_SelectedIndexChanged);
            this._clbColumns.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._clbColumns_ItemCheck);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(164, 295);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 2;
            this._btnOK.Text = "Done";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _lblColumns
            // 
            this._lblColumns.Location = new System.Drawing.Point(17, 11);
            this._lblColumns.Name = "_lblColumns";
            this._lblColumns.Size = new System.Drawing.Size(64, 15);
            this._lblColumns.TabIndex = 3;
            this._lblColumns.Text = "Columns:";
            // 
            // _ilColumnsEditor
            // 
            this._ilColumnsEditor.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_ilColumnsEditor.ImageStream")));
            this._ilColumnsEditor.TransparentColor = System.Drawing.Color.Magenta;
            this._ilColumnsEditor.Images.SetKeyName(0, "MoveUp.bmp");
            this._ilColumnsEditor.Images.SetKeyName(1, "MoveDown.bmp");
            // 
            // _btnMoveUp
            // 
            this._btnMoveUp.ImageKey = "MoveUp.bmp";
            this._btnMoveUp.ImageList = this._ilColumnsEditor;
            this._btnMoveUp.Location = new System.Drawing.Point(247, 29);
            this._btnMoveUp.Name = "_btnMoveUp";
            this._btnMoveUp.Size = new System.Drawing.Size(35, 30);
            this._btnMoveUp.TabIndex = 2;
            this._btnMoveUp.UseVisualStyleBackColor = true;
            this._btnMoveUp.Click += new System.EventHandler(this._btnMoveUp_Click);
            // 
            // _btnMoveDown
            // 
            this._btnMoveDown.ImageKey = "MoveDown.bmp";
            this._btnMoveDown.ImageList = this._ilColumnsEditor;
            this._btnMoveDown.Location = new System.Drawing.Point(247, 61);
            this._btnMoveDown.Name = "_btnMoveDown";
            this._btnMoveDown.Size = new System.Drawing.Size(35, 30);
            this._btnMoveDown.TabIndex = 2;
            this._btnMoveDown.UseVisualStyleBackColor = true;
            this._btnMoveDown.Click += new System.EventHandler(this._btnMoveDown_Click);
            // 
            // ColumnsEditorUi
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnOK;
            this.ClientSize = new System.Drawing.Size(292, 327);
            this.Controls.Add(this._lblColumns);
            this.Controls.Add(this._btnMoveUp);
            this.Controls.Add(this._btnMoveDown);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._clbColumns);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Name = "ColumnsEditorUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Columns Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox _clbColumns;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Label _lblColumns;
        private System.Windows.Forms.Button _btnMoveDown;
        private System.Windows.Forms.Button _btnMoveUp;
        private System.Windows.Forms.ImageList _ilColumnsEditor;

    }
}