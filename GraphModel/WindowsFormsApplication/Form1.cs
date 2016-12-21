using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
				GraphView = new GraphView(_graphModel.Graph);
				graphBox.Invalidate();
			}
		}
		public GraphView GraphView {
			get {
				return _graphView;
			}
			private set {
				_graphView = value;
				_editTool.GraphView = _graphView;
			}
		}


		private GraphModel _graphModel = null;
		private GraphView _graphView = null;
		private EditTool _editTool = null;

		private void Form1_Load(object sender, EventArgs e) {
			graphBox.MouseDown += graphBox_MouseDown;
			graphBox.MouseMove += graphBox_MouseMove;
			graphBox.MouseUp   += graphBox_MouseUp;
			graphBox.Paint += graphBox_Draw;
			_editTool = new EditTool(new ConcreteDrawingContext(graphBox));
		}

		// buttons
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
			string path = @"..\..\..\..\Examples\Graph files\exampleA1-4.txt";
			GraphModel = GraphModel.Load(path);
		}
		
		// graphBox events
		private void graphBox_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				_editTool.LeftMouseButtonDown(e.Location);
			}
		}
		private void graphBox_MouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				_editTool.LeftMouseButtonUp(e.Location);
			}
		}
		private void graphBox_MouseMove(object sender, MouseEventArgs e) {
			graphBox.Invalidate();
		}
		private void graphBox_Draw(object sender, PaintEventArgs e) {
			Graphics g = e.Graphics;
			drawGraph(g);
			_editTool.Draw(g);
			debugLabel.Text = _editTool.State.ToString();
		}
	}
}
