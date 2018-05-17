using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RWR.Windows.Components.Tests
{
	public partial class Test_Main : Form
	{
		public Test_Main()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			new Test_BaseForm().ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			new Test_BaseGrid().ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			new Test_BaseFormBaseGrid().ShowDialog();
		}
	}
}
