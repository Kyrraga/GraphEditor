using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	public class DefaultState : EditToolState {
		public DefaultState(EditTool tool) : base(tool) { }

		public override void MouseLeftPressed(Point location) {
			CurrentState = new SelectionState(EditTool, location);
		}

		public override void MouseLeftPressed(NodeModel node) {
			CurrentState = new DragState(EditTool, node);
		}

		public override void MouseLeftClick(Point location) {
			NodeModel node = new NodeModel(location);
			EditTool.GraphView.Graph.Add(node);
		}

		public override void MouseLeftClick(NodeModel node) {
			CurrentState = new DrawEdgeState(EditTool, node);

			//if (EditTool.Keyboard.IsKeyDown(Keyboard.Key.Shift)) {
			//	EditTool.AddSelected(node);
			//}
			//else {
			//	EditTool.SetSelected(node);
			//}
		}

		public override void MouseRightClick(Point location) {
			EditTool.Selection.Clear();
		}

		public override void KeyPressed(Keyboard.Key key) {
			if (key == Keyboard.Key.Delete) {
				EditTool.Selection.Delete();
			}
		}
	}
}
