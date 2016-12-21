using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphModelLibrary;

namespace WindowsFormsApplication {
	partial class Form1 {
		private void graphBox_Paint(object sender, PaintEventArgs e) {
			Graphics g = e.Graphics;
			g.FillRegion(Brushes.Beige, g.Clip);
			if (_graphModel != null) {
				drawEdges(g);
				drawNodes(g);
			}
		}

		private void drawNodes(Graphics g) {
			if (_graphModel == null) {
				throw new InvalidOperationException("Can't draw nodes without a graph");
			}

			RectangleF bounds = g.VisibleClipBounds;
			PointF middle = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);

			Node2Model[] nodes = _graphModel.Graph.ToArray() as Node2Model[];
			for (int i = 0; i < nodes.Length; ++i) {
				PointF point = indexToPoint(middle, nodes.Length, i, 50);
				drawCircle(g, point, nodes[i].Color);
			}
		}

		private void drawEdges(Graphics g) {
			if (_graphModel == null) {
				throw new InvalidOperationException("Can't draw edges without a graph");
			}

			RectangleF bounds = g.VisibleClipBounds;
			PointF middle = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);

			Node2Model[] nodes = _graphModel.Graph.ToArray() as Node2Model[];
			int radius = 50;
			for (int i = 0; i < nodes.Length; ++i) {
				PointF point1 = indexToPoint(middle, nodes.Length, i, radius);
				foreach (Edge2Model edge in nodes[i].GetOutgoingEdges()) {
					INode2 node2 = edge.To;
					int j = 0;
					for (j = 0; j < nodes.Length; ++j) {
						if (nodes[j] == node2) {
							break;
						}
					}
					PointF point2 = indexToPoint(middle, nodes.Length, j, radius);
					drawArrow(g, point1, point2, edge.Color);
				}
			}
		}

		/// <summary>
		/// Вычисляет координаты точки на окружности.
		/// </summary>
		/// <param name="middle">Центр окружности.</param>
		/// <param name="n">Количество точек.</param>
		/// <param name="i">Номер точки.</param>
		/// <param name="radius">Радиус окружности.</param>
		/// <returns></returns>
		private PointF indexToPoint(PointF middle, int n, int i, int radius) {
			double angle = Math.PI * 2 * i / n;
			float x = middle.X + (float)Math.Cos(angle) * radius;
			float y = middle.Y + (float)Math.Sin(angle) * radius;
			return new PointF(x, y);
		}

		private void drawCircle(Graphics g, PointF point, NodeColor color) {
			Brush brush = new SolidBrush(convertColor(color));
			int radius = 10;
			RectangleF rect = new RectangleF(point.X - radius, point.Y - radius, radius * 2, radius * 2);
			g.FillEllipse(brush, rect);
		}

		private void drawArrow(Graphics g, PointF point1, PointF point2, NodeColor color) {
			Pen pen = new Pen(convertColor(color));
			g.DrawLine(pen, point1, point2);
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
