namespace RWR.Windows.Components.Tests
{
	partial class Test_BaseGrid
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
			this.Grid = new RWR.Windows.Components.BaseGrid();
			this._statusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this._statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// Grid
			// 
			this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Grid.GridName = "_dgvBaseGrid";
			this.Grid.Location = new System.Drawing.Point(0, 0);
			this.Grid.Name = "Grid";
			this.Grid.Size = new System.Drawing.Size(765, 556);
			this.Grid.TabIndex = 0;
			// 
			// _statusStrip
			// 
			this._statusStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusMessage});
			this._statusStrip.Location = new System.Drawing.Point(0, 534);
			this._statusStrip.Name = "_statusStrip";
			this._statusStrip.Size = new System.Drawing.Size(765, 22);
			this._statusStrip.TabIndex = 1;
			this._statusStrip.Text = "statusStrip1";
			// 
			// StatusMessage
			// 
			this.StatusMessage.Name = "StatusMessage";
			this.StatusMessage.Size = new System.Drawing.Size(750, 17);
			this.StatusMessage.Spring = true;
			this.StatusMessage.Text = "OK";
			this.StatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Test_BaseGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(765, 556);
			this.Controls.Add(this._statusStrip);
			this.Controls.Add(this.Grid);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Test_BaseGrid";
			this.Text = "Test of the BaseGrid";
			this.Load += new System.EventHandler(this.Test_BaseGrid_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Test_BaseGrid_FormClosing);
			this._statusStrip.ResumeLayout(false);
			this._statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private BaseGrid Grid;
		private System.Windows.Forms.StatusStrip _statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel StatusMessage;
	}
}