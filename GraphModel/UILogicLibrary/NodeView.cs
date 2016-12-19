using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	class NodeView : Node {
		public NodeView(IGraph graph) : base(graph) { }

		public Point Location { get; set; }
	}
}
