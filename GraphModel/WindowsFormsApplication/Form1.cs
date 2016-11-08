using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphModel;

namespace WindowsFormsApplication {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private GraphModel.GraphModel graphModel = GraphModel.GraphModel.Load();

		private void loadGraphButton_Click(object sender, EventArgs e) {
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.FileOk += LoadGraph;
			dialog.ShowDialog();
		}

		private void LoadGraph(object sender, CancelEventArgs e) {
			
		}
	}
}
