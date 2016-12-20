using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	public interface IGraphView : IGraph {
		int NodeRadius { get; set; }
		INodeView GetNodeFrom(IEdgeView edge);
		INodeView GetNodeTo(IEdgeView edge);
	}

	public class GraphView : IGraphView {
		public GraphView(IGraph graph) {
			this._graph = graph;
		}

		public int NodeRadius {
			get {
				return _nodeRadius;
			}

			set {
				_nodeRadius = value;
			}
		}

		public ReadOnlyCollection<INode> Nodes {
			get {
				return _graph.Nodes
					.Select((node) => (new NodeView(this, node)) as INode)
					.ToList()
					.AsReadOnly();
			}
		}
		public IEnumerable<IEdge> Edges {
			get {
				return _graph.Edges
					.Select((edge) => (new EdgeView(this, edge) as IEdge));
			}
		}

		public IEnumerable<IEdge> GetIncomingEdges(INode node) {
			throw new NotImplementedException();
		}
		public IEnumerable<IEdge> GetOutgoingEdges(INode node) {
			throw new NotImplementedException();
		}
		public IEnumerable<IEdge> GetEdges(INode node) {
			throw new NotImplementedException();
		}
		public IEnumerable<INode> GetAdjacentNodes(INode node) {
			throw new NotImplementedException();
		}

		public INode AddNode() {
			throw new NotImplementedException();
		}
		public IEdge AddEdge(INode nodeFrom, INode nodeTo) {
			throw new NotImplementedException();
		}

		public void Remove(INode node) {
			throw new NotImplementedException();
		}
		public void Remove(IEdge edge) {
			throw new NotImplementedException();
		}

		public INodeView GetNodeFrom(IEdgeView edge) {
			throw new NotImplementedException();
		}

		public INodeView GetNodeTo(IEdgeView edge) {
			throw new NotImplementedException();
		}

		private IGraph _graph;
		private int _nodeRadius = 15;
	}
}
