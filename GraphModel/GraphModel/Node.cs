using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	interface INode {
		NodeColor Color { get; set; }
		IEnumerable<IEdge> GetIncomingEdges();
		IEnumerable<IEdge> GetOutgoingEdges();
		IEnumerable<IEdge> GetEdges();
		IEnumerable<INode> GetAdjacentNodes(INode node);
		void Delete();
	}

	class Node : INode {
		public IGraph Graph {
			get {
				return _graph;
			} 
		}
		public NodeColor Color { get; set; }

		public Node(IGraph graph) {
			this._graph = graph;
		}

		public static INode Create(IGraph graph) {
			return graph.AddNode();
		}

		public IEnumerable<IEdge> GetIncomingEdges() {
			return Graph.GetIncomingEdges(this);
		}
		public IEnumerable<IEdge> GetOutgoingEdges() {
			return Graph.GetOutgoingEdges(this);
		}
		public IEnumerable<IEdge> GetEdges() {
			return Graph.GetEdges(this);
		}
		public IEnumerable<INode> GetAdjacentNodes(INode node) {
			return Graph.GetAdjacentNodes(this);
		}
		public void Delete() {
			Graph.Remove(this);
		}

		private readonly IGraph _graph;
	}
}
