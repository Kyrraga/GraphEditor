using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public class Node2Model : Node2 {
		public Node2Model(NodeColor color = new NodeColor(), Point location = new Point()) : base() {
			this.Color = color;
			this.Location = location;
		}

		public NodeColor Color {
			get; set;
		}
		public Point Location {
			get; set;
		}
	}
}
