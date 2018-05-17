using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RWR.Windows.Components.DSBO;

namespace RWR.Windows.Components
{
	/// <summary>
	/// The BaseForm for ALL RWR.Windows.Components Forms with FormSettings.
	/// </summary>
	public partial class BaseForm : Form
	{
		#region Private Members

		private Color _color1 = Color.LightSteelBlue;
		private Color _color2 = Color.White;
		private float _angle = 90f;

		#endregion

		#region Properties

		/// <summary>
		/// This forms current FormSettings.
		/// </summary>
		public FormSettingsCD FormSettings = new FormSettingsCD();

		/// <summary>
		/// The gradient color 1.
		/// </summary>
		public Color Color1
		{
			get { return _color1; }
			set
			{
				_color1 = value;
				Invalidate(); // Tell the Form to repaint itself
			}
		}

		/// <summary>
		/// The gradient color 2.
		/// </summary>
		public Color Color2
		{
			get { return _color2; }
			set
			{
				_color2 = value;
				Invalidate(); // Tell the Form to repaint itself
			}
		}

		/// <summary>
		/// The gradient angle.
		/// </summary>
		public float Angle
		{
			get { return _angle; }
			set
			{
				_angle = value;
				Invalidate(); // Tell the Form to repaint itself
			}
		}

		#endregion

		/// <summary>
		/// The BaseForm for ALL RWR.Windows.Components Forms with FormSettings.
		/// </summary>
		public BaseForm()
		{
			InitializeComponent();
		}

		private void BaseForm_Load(object sender, EventArgs e)
		{
		// Get and Apply the FormSettings AFTER all child InitializeComponent's have finished.
			try
			{
				// Makes sure the form repaints when it was resized
				SetStyle(ControlStyles.ResizeRedraw, true);
				BaseForm_FormSettings_Apply();  // Height,Width,X,Y,WindowState
			}
			catch { }
		}

		private void BaseForm_FormSettings_Apply()
		{
		// Get Existing/Default FormSettings for this User and apply.
			FormSettings.ClientGetFormSettings(SystemInformation.UserName, Text, false);
			WindowState = FormSettings.WindowState;
			Height = FormSettings.Height;
			Width = FormSettings.Width;
			Location = FormSettings.Location;
		}

		private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			BaseForm_FormSettings_Save();
		}

		private void BaseForm_FormSettings_Save()
		{
			FormSettings.SetValue("WindowState", WindowState.ToString());
			switch (WindowState.ToString())
			{
				case "Normal":
					FormSettings.SetValue("Height", Height.ToString());
					FormSettings.SetValue("Width", Width.ToString());
					FormSettings.SetValue("X", Location.X.ToString());
					FormSettings.SetValue("Y", Location.Y.ToString());
					break;
				default:
					FormSettings.SetValue("Height", RestoreBounds.Height.ToString());
					FormSettings.SetValue("Width", RestoreBounds.Width.ToString());
					FormSettings.SetValue("X", RestoreBounds.X.ToString());
					FormSettings.SetValue("Y", RestoreBounds.Y.ToString());
					break;
			}
			FormSettings.ClientUpdateFormSettings(false);
		}

		/// <summary>
		/// Overrides the OnPaintBackground event to paint the BackgroundGradient
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			// Getting the graphics object
			var g = e.Graphics;

			// Creating the rectangle for the gradient
			var rect = new Rectangle(0, 0, Width, Height);

			// Creating the lineargradient brush
			var brush = new LinearGradientBrush(rect, _color1, _color2, _angle);

			// Draw the gradient onto the form
			g.FillRectangle(brush, rect);

			// Disposing of the resources held by the brush
			brush.Dispose();
		}
	}
}