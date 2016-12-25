using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public class Edge : IEdge {
		public Edge(Node from, Node to) {
			this._from = from;
			this._to = to;

			_from.AddOutgoingEdge(this);
			_to.AddIncomingEdge(this);
		}

		public INode From {
			get {
				return _from;
			}
		}
		public INode To {
			get {
				return _to;
			}
		}

		public void Delete() {
			_from.RemoveOutgoingEdge(this);
			_to.RemoveIncomingEdge(this);
		}

		readonly Node _from;
		readonly Node _to;
	}
}
