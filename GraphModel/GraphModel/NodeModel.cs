using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public class NodeModel : Node {
		public NodeModel(NodeColor color = _defaultColor) :base() {
			this.Color = color;
			this.Location = _defaultLocation;
		}
		public NodeModel(Point location, NodeColor color = _defaultColor) : base() {
			this.Color = color;
			this.Location = location;
		}

		public NodeColor Color {
			get; set;
		}
		public Point Location {
			get; set;
		}

		const NodeColor _defaultColor = NodeColor.Magenta;
		readonly Point _defaultLocation = Point.Empty;
	}
}
