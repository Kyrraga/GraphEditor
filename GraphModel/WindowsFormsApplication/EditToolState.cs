using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication {
	class EditToolState {
		public virtual EditToolState LeftMouseButtonDown(Point location) { return this; }
		public virtual EditToolState LeftMouseButtonUp(Point location) { return this; }
		public virtual EditToolState RightMouseButtonDown(Point location) { return this; }
		public virtual EditToolState RightMouseButtonUp(Point location) { return this; }
	}

	class DefaultEditToolState : EditToolState {

	}
}
