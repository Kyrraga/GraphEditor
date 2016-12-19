using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using GraphModelLibrary;
using UILogicLibrary;

namespace WindowsFormsApplication {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		public GraphModel GraphModel {
			get {
				return _graphModel;
			}
			private set {
				_graphModel = value;
				graphBox.Invalidate();
				_editTool.Reset(_graphModel);
			}
		}

		private GraphModel _graphModel = null;
		private EditTool _editTool = null;

		private void Form1_Load(object sender, EventArgs e) {
			this.Paint += form_Paint;
			graphBox.MouseDown += graphBox_MouseDown;
			graphBox.MouseMove += graphBox_MouseMove;
			graphBox.Paint += graphBox_Draw;
			_editTool = new EditTool();
		}

		private void form_Paint(object sender, PaintEventArgs e) {
			debugLabel.Text = _editTool.State.ToString();
		}

		private void graphBox_Draw(object sender, PaintEventArgs e) {
			throw new NotImplementedException();
		}

		private void graphBox_MouseMove(object sender, MouseEventArgs e) {
			graphBox.Invalidate();
		}

		private void loadGraphButton_Click(object sender, EventArgs e) {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK) {
				string path = openFileDialog.FileName;
				GraphModel = GraphModel.Load(path);
			}
		}

		private void drawButton_Click(object sender, EventArgs e) {
			graphBox.Invalidate();
		}

		private void loadExampleButton_Click(object sender, EventArgs e) {
			string path = @"C:\Users\Ruslan\Documents\MAI\Диплом\GraphEditor\Examples\Graph files\exampleA1-4.txt";
			GraphModel = GraphModel.Load(path);
		}

		private void graphBox_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				_editTool.LeftMouseButtonDown(e.Location);
			}
		}
	}
}
