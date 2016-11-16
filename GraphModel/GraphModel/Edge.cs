using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	interface IEdge {
		NodeColor Color { get; set; }
		INode NodeFrom { get; }
		INode NodeTo { get; }
		void Delete();
	}

	class Edge : IEdge {
		public IGraph Graph {
			get {
				return _graph;
			}
		}
		public INode NodeFrom {
			get {
				return _from;
			}
		}
		public INode NodeTo {
			get {
				return _to;
			}
		}
		public string Value { get; set; }
		public NodeColor Color { get; set; }

		public Edge(IGraph graph, INode from, INode to) {
			this._graph = graph;
			this._from = from;
			this._to = to;
		}

		public static IEdge Create(IGraph graph, INode from, INode to) {
			return graph.AddEdge(from, to);
		}

		public ReadOnlyCollection<INode> Nodes {
			get {
				return Array.AsReadOnly(new INode[] { NodeFrom, NodeTo });
			}
		}

		public void Delete() {
			
		}

		private readonly IGraph _graph;
		private readonly INode _from;
		private readonly INode _to;
	}
}
