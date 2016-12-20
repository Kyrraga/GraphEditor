using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public interface IEdge {
		IGraph Graph { get; }
		INode NodeFrom { get; }
		INode NodeTo { get; }
		NodeColor Color { get; set; }
		void Delete();
	}

	public class Edge : IEdge {
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
		public string Value {
			get {
				return _value; }
			set {
				_value = value;
			}
		}
		public NodeColor Color {
			get {
				return _color;
			}
			set {
				_color = value;
			}
		}

		public Edge(IGraph graph, INode from, INode to) {
			this._graph = graph;
			this._from = from;
			this._to = to;
		}

		public ReadOnlyCollection<INode> Nodes {
			get {
				return Array.AsReadOnly(new INode[] { NodeFrom, NodeTo });
			}
		}

		public void Delete() {
			Graph.Remove(this);
		}

		private readonly IGraph _graph;
		private readonly INode _from;
		private readonly INode _to;
		private string _value;
		private NodeColor _color;
	}
}
