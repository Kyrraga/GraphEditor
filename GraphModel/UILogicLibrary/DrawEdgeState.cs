using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	class DrawEdgeState : AbstractState {
		public DrawEdgeState(EditTool editTool, IHolderState holder, NodeModel start) : base(editTool, holder) {
			this._start = start;
		}

		public override void Draw(DrawingContext context) {
			context.DrawArrow(_start.Location, context.MousePosition);
		}

		public override void MouseLeftClick(Point location) {
			CurrentState = new DefaultState(EditTool, Holder);
		}

		public override void MouseLeftClick(NodeModel node) {
			EdgeModel edge = new EdgeModel(_start, node);
			_start.AddOutgoingEdge(edge);
			CurrentState = new DefaultState(EditTool, Holder);
		}

		public override void MouseRightClick(Point location) {
			CurrentState = new DefaultState(EditTool, Holder);
		}

		public override void MouseRightClick(NodeModel node) {
			CurrentState = new DefaultState(EditTool, Holder);
		}

		readonly NodeModel _start;
	}
}
