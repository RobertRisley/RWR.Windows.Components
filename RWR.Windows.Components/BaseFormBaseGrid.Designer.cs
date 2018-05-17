namespace RWR.Windows.Components
{
	partial class BaseFormBaseGrid
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
			this.StatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this._statusStrip = new System.Windows.Forms.StatusStrip();
			((System.ComponentModel.ISupportInitialize)(this.FormSettings)).BeginInit();
			this._statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// Grid
			// 
			this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Grid.GridName = "_dgvBaseGrid";
			this.Grid.Location = new System.Drawing.Point(0, 0);
			this.Grid.Name = "Grid";
			this.Grid.Size = new System.Drawing.Size(857, 639);
			this.Grid.TabIndex = 1;
			// 
			// StatusMessage
			// 
			this.StatusMessage.Name = "StatusMessage";
			this.StatusMessage.Size = new System.Drawing.Size(211, 17);
			this.StatusMessage.Spring = true;
			this.StatusMessage.Text = "OK";
			this.StatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _statusStrip
			// 
			this._statusStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusMessage});
			this._statusStrip.Location = new System.Drawing.Point(0, 639);
			this._statusStrip.Name = "_statusStrip";
			this._statusStrip.Size = new System.Drawing.Size(857, 22);
			this._statusStrip.TabIndex = 2;
			this._statusStrip.Text = "statusStrip1";
			// 
			// BaseFormBaseGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(857, 661);
			this.Controls.Add(this.Grid);
			this.Controls.Add(this._statusStrip);
			this.Name = "BaseFormBaseGrid";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseFormBaseGrid_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.FormSettings)).EndInit();
			this._statusStrip.ResumeLayout(false);
			this._statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		/// <summary>
		/// This BaseGrid.
		/// </summary>
		public BaseGrid Grid;
		private System.Windows.Forms.StatusStrip _statusStrip;
		/// <summary>
		/// This StatusMessage.
		/// </summary>
		public System.Windows.Forms.ToolStripStatusLabel StatusMessage;

	}
}
