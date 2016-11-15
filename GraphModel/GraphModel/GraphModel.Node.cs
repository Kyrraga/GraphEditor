using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	partial class GraphModel {
		public class Node {
			public Node(GraphModel graph) {
				_graph = graph;
			}

			private GraphModel _graph;
		}
	}
}
