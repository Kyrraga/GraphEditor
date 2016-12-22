using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphModelLibrary;
using UILogicLibrary;
using ExtensionMethods;

namespace WindowsFormsApplication {
	partial class Form1 {
		private void drawGraph(DrawingContext context) {
			if (_graphModel != null) {
				drawEdges(context);
				drawNodes(context);
			}
		}

		private void drawNodes(DrawingContext context) {
			if (_graphModel == null) {
				throw new InvalidOperationException("Can't draw nodes without a graph");
			}

			RectangleF bounds = context.Graphics.VisibleClipBounds;
			PointF middle = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);

			Graph graph = _graphModel.Graph;
			foreach (var pair in graph.Indexed()) {
				int index = (int)pair.Key;
				NodeModel node = (NodeModel)pair.Value;
				Point point = indexToPoint(middle, graph.Count, index, 50);
				Color color = convertColor(node.Color);
				context.FillCircle(point, 10, new SolidBrush(color));
			}
		}

		private void drawEdges(DrawingContext context) {
			if (_graphModel == null) {
				throw new InvalidOperationException("Can't draw edges without a graph");
			}

			RectangleF bounds = context.Graphics.VisibleClipBounds;
			PointF middle = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);

			Node[] nodes = _graphModel.Graph.ToArray();
			int radius = 50;
			for (int i = 0; i < nodes.Length; ++i) {
				Point point1 = indexToPoint(middle, nodes.Length, i, radius);
				foreach (EdgeModel edge in nodes[i].GetOutgoingEdges()) {
					Node node2 = edge.To as Node;
					int j = 0;
					for (j = 0; j < nodes.Length; ++j) {
						if (nodes[j] == node2) {
							break;
						}
					}
					Point point2 = indexToPoint(middle, nodes.Length, j, radius);
					Color color = convertColor(edge.Color);
					context.DrawArrow(point1, point2, color);
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
		private Point indexToPoint(PointF middle, int n, int i, int radius) {
			double angle = Math.PI * 2 * i / n;
			float x = middle.X + (float)Math.Cos(angle) * radius;
			float y = middle.Y + (float)Math.Sin(angle) * radius;
			return Point.Round(new PointF(x, y));
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
