using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	public interface IGraphView {
		int NodeRadius { get; set; }
	}

	public class GraphView : IGraphView {
		public GraphView(Graph graph) {
			this._graph = graph;
		}

		public int NodeRadius {
			get {
				return _nodeRadius;
			}
			set {
				_nodeRadius = value;
			}
		}
		public int EdgeWidth {
			get {
				return _edgeWidth;
			}
			set {
				_edgeWidth = value;
			}
		}

		public Graph Graph {
			get {
				return _graph;
			}
		}

		public Object FindClicked(Point p) {
			foreach (NodeModel node in Graph) {
				if (distance(node.Location, p) < NodeRadius) {
					return node;
				}
			}
			return null;
		}
		

		Graph _graph;
		int _nodeRadius = 15;
		int _edgeWidth = 1;

		double distance(Point a, Point b) {
			int dx = a.X - b.X;
			int dy = a.Y - b.Y;
			return Math.Sqrt(dx * dx + dy * dy);
		}
	}
}
