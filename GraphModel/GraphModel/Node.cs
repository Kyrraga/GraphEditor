using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public class Node : INode {
		public Node() {
			this._incomingEdges = new HashSet<Edge>();
			this._outgoingEdges = new HashSet<Edge>();
		}

		public void AddIncomingEdge(Edge edge) {
			if (edge.To != this) {
				throw new InvalidOperationException();
			}

			_incomingEdges.Add(edge);
		}
		public void AddOutgoingEdge(Edge edge) {
			if (edge.From != this) {
				throw new InvalidOperationException();
			}

			_outgoingEdges.Add(edge);
		}
		public void RemoveIncomingEdge(Edge edge) {
			if (edge.To != this) {
				throw new InvalidOperationException();
			}

			bool success = _incomingEdges.Remove(edge);
			if (!success) {
				throw new InvalidOperationException();
			}
		}
		public void RemoveOutgoingEdge(Edge edge) {
			if (edge.From != this) {
				throw new InvalidOperationException();
			}

			bool success = _outgoingEdges.Remove(edge);
			if (!success) {
				throw new InvalidOperationException();
			}
		}

		public IEnumerable<IEdge> GetIncomingEdges() {
			return _incomingEdges as IEnumerable<IEdge>;
		}
		public IEnumerable<INode> GetIncomingNodes() {
			return _incomingEdges.Select((edge) => (edge.From));
		}
		public IEnumerable<IEdge> GetOutgoingEdges() {
			return _outgoingEdges as IEnumerable<IEdge>;
		}
		public IEnumerable<INode> GetOutgoingNodes() {
			return _outgoingEdges.Select((edge) => (edge.To));
		}

		public void Delete() {
			while (_incomingEdges.Count > 0) {
				_incomingEdges.First().Delete();
			}
			while (_outgoingEdges.Count > 0) {
				_outgoingEdges.First().Delete();
			}
		}

		readonly HashSet<Edge> _incomingEdges;
		readonly HashSet<Edge> _outgoingEdges;
	}
}
