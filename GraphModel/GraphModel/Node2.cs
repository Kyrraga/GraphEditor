using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public class Node2 : INode2 {
		public Node2() {
			this._incomingEdges = new HashSet<Edge2>();
			this._outgoingEdges = new HashSet<Edge2>();
		}

		public void AddIncomingEdge(Edge2 edge) {
			if (edge.To != this) {
				throw new InvalidOperationException();
			}

			_incomingEdges.Add(edge);
		}
		public void AddOutgoingEdge(Edge2 edge) {
			if (edge.From != this) {
				throw new InvalidOperationException();
			}

			_outgoingEdges.Add(edge);
		}
		public void RemoveIncomingEdge(Edge2 edge) {
			if (edge.To != this) {
				throw new InvalidOperationException();
			}

			bool success = _incomingEdges.Remove(edge);
			if (!success) {
				throw new InvalidOperationException();
			}
		}
		public void RemoveOutgoingEdge(Edge2 edge) {
			if (edge.From != this) {
				throw new InvalidOperationException();
			}

			bool success = _outgoingEdges.Remove(edge);
			if (!success) {
				throw new InvalidOperationException();
			}
		}

		public IEnumerable<IEdge2> GetIncomingEdges() {
			return _incomingEdges as IEnumerable<IEdge2>;
		}
		public IEnumerable<INode2> GetIncomingNodes() {
			return _incomingEdges.Select((edge) => (edge.From));
		}
		public IEnumerable<IEdge2> GetOutgoingEdges() {
			return _outgoingEdges as IEnumerable<IEdge2>;
		}
		public IEnumerable<INode2> GetOutgoingNodes() {
			return _outgoingEdges.Select((edge) => (edge.To));
		}

		readonly HashSet<Edge2> _incomingEdges;
		readonly HashSet<Edge2> _outgoingEdges;
	}
}
