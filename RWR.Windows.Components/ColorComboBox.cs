using System;
using System.Drawing;
using System.Windows.Forms;
using RWR.Common;

namespace RWR.Windows.Components
{
	/// <summary>
	/// Represents a Windows combo box Color Selector control.
	/// </summary>
	public class ColorComboBox : ComboBox
	{
		#region Private Members

		private readonly bool _hideText;
		private readonly SolidBrush _blackBrush = new SolidBrush(Color.Black);
		private readonly SolidBrush _whiteBrush = new SolidBrush(Color.White);

		#endregion

		#region Properties

		/// <summary>
		/// Get or Sets the current selected color
		/// </summary>
		public Color SelectedColor
		{
			get	{ return BackColor; }
			set
			{
				try { SelectedIndex = FindStringExact(value.Name, 0); }
				catch { SelectedIndex = 0; }
			}
		}

		#endregion

		/// <summary>
		/// A ComboBox Color Selector
		/// </summary>
		public ColorComboBox()
		{
			DrawMode = DrawMode.OwnerDrawFixed;
			DrawItem += ColorComboBox_DrawItem;
			SelectedIndexChanged += ColorComboBox_SelectedIndexChanged;
			DropDown += ColorComboBox_DropDown;
		}

		/// <summary>
		/// Overload with HideText
		/// </summary>
		/// <param name="hideText">boolean to not display the Color's text</param>
		public ColorComboBox(bool hideText)
			: this()
		{
			_hideText = hideText;
		}

		/// <summary>
		/// Load the color palette specified in the ColorSet
		/// </summary>
		/// <param name="colorSet">the palette in the ColorSet</param>
		public void LoadColors(ColorSet colorSet)
		{
			Items.Clear();

			switch (colorSet)
			{
				case ColorSet.All:
					Items.AddRange(Enum.GetNames(typeof(KnownColor)));
					Items.Remove("Transparent");
					break;
				case ColorSet.System:
					AddSystemColors();
					break;
				case ColorSet.Web:
					Items.AddRange(Enum.GetNames(typeof(KnownColor)));
					Items.Remove("Transparent");
					RemoveSystemColors();
					break;
			}


			SelectedIndex = 0;
		}

		private void RemoveSystemColors()
		{
			Items.Remove("ActiveBorder");
			Items.Remove("ActiveCaption");
			Items.Remove("ActiveCaptionText");
			Items.Remove("AppWorkspace");
			Items.Remove("Control");
			Items.Remove("ControlDark");
			Items.Remove("ControlDarkDark");
			Items.Remove("ControlLight");
			Items.Remove("ControlLightLight");
			Items.Remove("ControlText");
			Items.Remove("Desktop");
			Items.Remove("GrayText");
			Items.Remove("Highlight");
			Items.Remove("HighlightText");
			Items.Remove("HotTrack");
			Items.Remove("InactiveBorder");
			Items.Remove("InactiveCaption");
			Items.Remove("InactiveCaptionText");
			Items.Remove("Info");
			Items.Remove("InfoText");
			Items.Remove("Menu");
			Items.Remove("MenuText");
			Items.Remove("ScrollBar");
			Items.Remove("Window");
			Items.Remove("WindowFrame");
			Items.Remove("WindowText");
			Items.Remove("ButtonFace");
			Items.Remove("ButtonHighlight");
			Items.Remove("ButtonShadow");
			Items.Remove("GradientActiveCaption");
			Items.Remove("GradientInactiveCaption");
			Items.Remove("MenuBar");
			Items.Remove("MenuHighlight");
		}
		private void AddSystemColors()
		{
			Items.Add("ActiveBorder");
			Items.Add("ActiveCaption");
			Items.Add("ActiveCaptionText");
			Items.Add("AppWorkspace");
			Items.Add("Control");
			Items.Add("ControlDark");
			Items.Add("ControlDarkDark");
			Items.Add("ControlLight");
			Items.Add("ControlLightLight");
			Items.Add("ControlText");
			Items.Add("Desktop");
			Items.Add("GrayText");
			Items.Add("Highlight");
			Items.Add("HighlightText");
			Items.Add("HotTrack");
			Items.Add("InactiveBorder");
			Items.Add("InactiveCaption");
			Items.Add("InactiveCaptionText");
			Items.Add("Info");
			Items.Add("InfoText");
			Items.Add("Menu");
			Items.Add("MenuText");
			Items.Add("ScrollBar");
			Items.Add("Window");
			Items.Add("WindowFrame");
			Items.Add("WindowsText");
			Items.Add("ButtonFace");
			Items.Add("ButtonHighlight");
			Items.Add("ButtonShadow");
			Items.Add("GradientActiveCaption");
			Items.Add("GradientInactiveCaption");
			Items.Add("MenuBar");
			Items.Add("MenuHighlight");
		}

		private void ColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			var grfx = e.Graphics;
			var colorName = Items[e.Index].ToString();
			var color = Color.FromName(colorName);
			var solidBrush = new SolidBrush(color);

			grfx.FillRectangle( solidBrush, e.Bounds );

			if( _hideText == false )
			{
				if( color == Color.Black || color == Color.MidnightBlue
					|| color == Color.DarkBlue || color == Color.Indigo 
					|| color == Color.MediumBlue || color == Color.Maroon 
					|| color == Color.Navy || color == Color.Purple )
				{
					grfx.DrawString(colorName, e.Font, _whiteBrush, e.Bounds);
				}
				else
				{
					grfx.DrawString(colorName, e.Font, _blackBrush, e.Bounds);
				}

				SelectionStart = 0;
				SelectionLength = 0;
			}
			else 
			{
				grfx.DrawString(colorName, e.Font, solidBrush, e.Bounds);
			}
		}
		private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
		// Prevents the hightlighted text being shown when dropped down.

			BackColor = Color.FromName(SelectedItem.ToString());

			if (!_hideText) return;

			ForeColor = BackColor;
			SelectionStart = 0;
			SelectionLength = 0;
		}
		private void ColorComboBox_DropDown(object sender, EventArgs e)
		{
			ColorComboBox_SelectedIndexChanged(sender, e);
		}
	}
}
