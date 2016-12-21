using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public interface INode {
		IEnumerable<IEdge> GetIncomingEdges();
		IEnumerable<IEdge> GetOutgoingEdges();
		IEnumerable<INode> GetIncomingNodes();
		IEnumerable<INode> GetOutgoingNodes();
	}
}
