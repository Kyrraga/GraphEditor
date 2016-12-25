using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public Graph Graph {
			get {
				return _graph;
			}
		}
		

		Graph _graph;
		int _nodeRadius = 15;
	}
}
