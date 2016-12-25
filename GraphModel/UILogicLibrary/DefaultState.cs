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

		public override void MouseLeftClick(Point location) {
			NodeModel node = new NodeModel(location);
			EditTool.GraphView.Graph.Add(node);
		}
	}
}
