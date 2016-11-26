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

namespace WindowsFormsApplication {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		GraphModel graphModel = null;

		private void loadGraphButton_Click(object sender, EventArgs e) {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK) {
				string path = openFileDialog.FileName;
				graphModel = GraphModel.Load(path);
			}
		}

		private void drawButon_Click(object sender, EventArgs e) {
			graphBox.Invalidate();
		}

		private void graphBox_Paint(object sender, PaintEventArgs e) {
			if (graphModel != null) {
				RectangleF bounds = e.Graphics.VisibleClipBounds;
				PointF middle = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
				int radius = 50;

				INode[] nodes = graphModel.Graph.Nodes.ToArray();
				for (int i = 0; i < nodes.Length; ++i) {
					double angle = Math.PI * 2 * i / nodes.Length;
					float x = middle.X + (float)Math.Cos(angle) * radius;
					float y = middle.Y + (float)Math.Sin(angle) * radius;

					drawCircle(e.Graphics, new PointF(x, y), nodes[i].Color);
				}
			}
		}

		private void drawCircle(Graphics g, PointF point, NodeColor color) {
			Brush brush = new SolidBrush(convertColor(color));
			int radius = 10;
			RectangleF rect = new RectangleF(point.X - radius, point.Y - radius, radius * 2, radius * 2);
			g.FillEllipse(brush, rect);
        }

		private Color convertColor(NodeColor color) {
			switch (color) {
				case NodeColor.Black:
					return Color.Black;
				case NodeColor.Blue:
					return Color.Blue;
				case NodeColor.Brown:
					return Color.Brown;
				case NodeColor.Darkblue:
					return Color.DarkBlue;
				case NodeColor.Green:
					return Color.Green;
				case NodeColor.Grey:
					return Color.Gray;
				case NodeColor.Magenta:
					return Color.Magenta;
				case NodeColor.Orange:
					return Color.Orange;
				case NodeColor.Pink:
					return Color.Pink;
				case NodeColor.Purple:
					return Color.Purple;
				case NodeColor.Red:
					return Color.Red;
				case NodeColor.Teal:
					return Color.Teal;
				case NodeColor.Turquoise:
					return Color.Turquoise;
				case NodeColor.Violet:
					return Color.Violet;
				case NodeColor.White:
					return Color.White;
				case NodeColor.Yellow:
					return Color.Yellow;
				default:
					throw new ArgumentException("Unknown color");
			}
		}
	}
}
