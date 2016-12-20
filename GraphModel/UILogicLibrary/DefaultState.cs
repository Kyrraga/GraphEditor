using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace UILogicLibrary {
	public class DefaultState : EditToolState {
		public DefaultState() { }

		public override EditToolState LeftMouseButtonDown(Point location) {
			return new SelectionState(location);
		}
	}
}
