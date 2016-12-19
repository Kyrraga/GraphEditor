using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary
{
	public class EditTool {

		public EditTool() { }

		public Action<Point, Point> DrawLine;
		public Action<Rectangle> DrawRectangle;

		public EditToolState State {
			get {
				return _state;
			}
		}

		public void Reset() {
			throw new NotImplementedException();
		}

		public void LeftMouseButtonDown(Point location) {
			_state = _state.LeftMouseButtonDown(location);
		}
		public void LeftMouseButtonUp(Point location) {
			_state = _state.LeftMouseButtonUp(location);
		}
		public void RightMouseButtonUp(Point location) {
			_state = _state.RightMouseButtonUp(location);
		}
		public void RightMouseButtonDown(Point location) {
			_state = _state.RightMouseButtonDown(location);
		}
		public void MouseMoved(Point location) {
			_state = _state.MouseMoved(location);
		}

		private EditToolState _state = new EmptyState();
	}
}
