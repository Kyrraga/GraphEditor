using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public class Edge2 : IEdge2 {
		public Edge2(Node2 from, Node2 to) {
			this._from = from;
			this._to = to;

			_from.AddOutgoingEdge(this);
			_to.AddIncomingEdge(this);
		}

		public INode2 From {
			get {
				return _from;
			}
		}
		public INode2 To {
			get {
				return _to;
			}
		}

		public void Delete() {
			_from.RemoveOutgoingEdge(this);
			_to.RemoveIncomingEdge(this);
		}

		readonly Node2 _from;
		readonly Node2 _to;
	}
}
