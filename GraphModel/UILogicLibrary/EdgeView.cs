using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	public interface IEdgeView : IEdge {

	}

	public class EdgeView : IEdgeView {
		public EdgeView(IGraphView graph, IEdge edge) {
			this._graphView = graph;
			this._edge = edge;
		}


		public NodeColor Color {
			get {
				return _edge.Color;
			}

			set {
				_edge.Color = value;
			}
		}

		public INode NodeFrom {
			get {
				return _graphView.GetNodeFrom(this);
			}
		}

		public INode NodeTo {
			get {
				return _graphView.GetNodeTo(this);
			}
		}

		public void Delete() {
			_graphView.Remove(this);
		}

		private IGraphView _graphView;
		private IEdge _edge;
	}
}
