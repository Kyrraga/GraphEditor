using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public interface INode {
		IGraph Graph { get; }
		NodeColor Color { get; set; }
		IEnumerable<IEdge> GetIncomingEdges();
		IEnumerable<IEdge> GetOutgoingEdges();
		IEnumerable<IEdge> GetEdges();
		IEnumerable<INode> GetAdjacentNodes(INode node);
		void Delete();
	}

	public class Node : INode {
		public IGraph Graph {
			get {
				return _graph;
			} 
		}
		public NodeColor Color {
			get {
				return _color;
			}
			set {
				_color = value;
			}
		}

		public Node(IGraph graph) {
			this._graph = graph;
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
		private NodeColor _color;
	}
}
