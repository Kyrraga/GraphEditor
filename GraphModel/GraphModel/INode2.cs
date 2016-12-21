using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public interface INode2 {
		IEnumerable<IEdge2> GetIncomingEdges();
		IEnumerable<IEdge2> GetOutgoingEdges();
		IEnumerable<INode2> GetIncomingNodes();
		IEnumerable<INode2> GetOutgoingNodes();
	}
}
