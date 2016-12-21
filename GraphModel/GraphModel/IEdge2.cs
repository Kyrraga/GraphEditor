using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public interface IEdge2 {
		INode2 From { get; }
		INode2 To { get; }
	}
}
