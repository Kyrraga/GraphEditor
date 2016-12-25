using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public interface IEdge {
		INode From { get; }
		INode To { get; }
	}
}
