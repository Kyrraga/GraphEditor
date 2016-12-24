using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace UILogicLibrary {
	public class DefaultState : EditToolState {
		public DefaultState(EditTool tool) : base(tool) { }

		public override void LeftMouseButtonDown(Point location) {
			CurrentState = new SelectionState(EditTool, location);
		}
	}
}
