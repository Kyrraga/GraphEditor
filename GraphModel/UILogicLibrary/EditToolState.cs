using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	public abstract class EditToolState {
		public virtual EditToolState LeftMouseButtonDown(Point location) { return this; }
		public virtual EditToolState LeftMouseButtonUp(Point location) { return this; }
		public virtual EditToolState RightMouseButtonDown(Point location) { return this; }
		public virtual EditToolState RightMouseButtonUp(Point location) { return this; }
		public virtual EditToolState MouseMoved(Point location) { return this; }
		public virtual void Draw(DrawingContext context) { }
	}


	public class EmptyState : EditToolState { }
}
