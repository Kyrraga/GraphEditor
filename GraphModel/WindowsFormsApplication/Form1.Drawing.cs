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
				Point point = node.Location;
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

			Graph graph = _graphModel.Graph;
			foreach (NodeModel node in graph) {
				foreach (EdgeModel edge in node.GetOutgoingEdges()) {
					NodeModel node2 = edge.To as NodeModel;
					Color color = convertColor(edge.Color);
					context.DrawArrow(node.Location, node2.Location, color);
				}
			}
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
