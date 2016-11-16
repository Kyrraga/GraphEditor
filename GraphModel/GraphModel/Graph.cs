using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	interface IGraph {
		ReadOnlyCollection<INode> Nodes { get; }
		IEnumerable<IEdge> Edges { get; }
		IEnumerable<IEdge> GetIncomingEdges(INode node);
		IEnumerable<IEdge> GetOutgoingEdges(INode node);
		IEnumerable<IEdge> GetEdges(INode node);
		IEnumerable<INode> GetAdjacentNodes(INode node);
		INode AddNode();
		IEdge AddEdge(INode nodeFrom, INode nodeTo);
		void Remove(INode node);
		void Remove(IEdge edge);
	}

	class Graph : IGraph {
		public IEnumerable<IEdge> Edges {
			get {
				foreach (var dict in _outgoingEdges.Values) {
					foreach (var pair in dict) {
						yield return pair.Value;
					}
				}
			}
		}
		public ReadOnlyCollection<INode> Nodes {
			get {
				return _nodes.AsReadOnly();
			}
		}

		public Graph() {
			this._nodes = new List<INode>();
			this._outgoingEdges = new Dictionary<INode, IDictionary<INode, IEdge>>();
			this._incomingEdges = new Dictionary<INode, IDictionary<INode, IEdge>>();
		}

		public IEdge AddEdge(INode nodeFrom, INode nodeTo) {
			IEdge edge = new Edge(this, nodeFrom, nodeTo);

			if (!_outgoingEdges.ContainsKey(nodeFrom)) {
				_outgoingEdges[nodeFrom] = new Dictionary<INode, IEdge>();
			}
			_outgoingEdges[nodeFrom][nodeTo] = edge;

			if (!_incomingEdges.ContainsKey(nodeTo)) {
				_incomingEdges[nodeTo] = new Dictionary<INode, IEdge>();
			}
			_incomingEdges[nodeTo][nodeFrom] = edge;

			return edge;
		}
		public INode AddNode() {
			INode node = new Node(this);
			_nodes.Add(node);
			return node;
		}

		public IEnumerable<INode> GetAdjacentNodes(INode node) {
			foreach (var pair in _outgoingEdges[node]) {
				yield return pair.Key;
			}
			foreach (var pair in _incomingEdges[node]) {
				yield return pair.Key;
			}
		}
		public IEnumerable<IEdge> GetEdges(INode node) {
			foreach (var edge in GetOutgoingEdges(node)) {
				yield return edge;
			}
			foreach (var edge in GetIncomingEdges(node)) {
				yield return edge;
			}
		}
		public IEnumerable<IEdge> GetIncomingEdges(INode node) {
			foreach(KeyValuePair<INode, IEdge> pair in _incomingEdges[node]) {
				yield return pair.Value;
			}
		}
		public IEnumerable<IEdge> GetOutgoingEdges(INode node) {
			foreach(KeyValuePair<INode, IEdge> pair in _outgoingEdges[node]) {
				yield return pair.Value;
			}
		}

		public void Remove(IEdge edge) {
			_outgoingEdges[edge.NodeFrom].Remove(edge.NodeTo);
			_incomingEdges[edge.NodeTo].Remove(edge.NodeFrom);
		}
		public void Remove(INode node) {
			foreach (var edge in node.GetEdges()) {
				Remove(edge);
			}
			_nodes.Remove(node);
		}

		private readonly List<INode> _nodes;
		private readonly IDictionary<INode, IDictionary<INode, IEdge>> _outgoingEdges;
		private readonly IDictionary<INode, IDictionary<INode, IEdge>> _incomingEdges;
	}
}
