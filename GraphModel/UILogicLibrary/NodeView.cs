using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	public interface INodeView : INode {
		Point Location { get; set; }
	}

	public class NodeView : INodeView {
		public NodeView(IGraphView graphView, INode node) {
			this._graphView = graphView;
			this._node = node;
		}

		public Point Location { get; set; }

		public NodeColor Color {
			get {
				return _node.Color;
			}

			set {
				_node.Color = value;
			}
		}

		public IGraph Graph {
			get {
				return _graphView;
			}
		}

		public IEnumerable<IEdge> GetIncomingEdges() {
			return _graphView.GetIncomingEdges(this);
		}

		public IEnumerable<IEdge> GetOutgoingEdges() {
			return _graphView.GetOutgoingEdges(this);
		}

		public IEnumerable<IEdge> GetEdges() {
			throw new NotImplementedException();
		}

		public IEnumerable<INode> GetAdjacentNodes(INode node) {
			throw new NotImplementedException();
		}

		public void Delete() {
			throw new NotImplementedException();
		}

		private INode _node;
		private IGraphView _graphView;
	}
}
