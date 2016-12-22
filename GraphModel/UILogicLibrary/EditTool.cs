using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary
{
	public class EditTool {

		public EditTool() {	}

		public GraphView GraphView {
			get {
				return _graph;
			}
			set {
				_graph = value;
				if (_graph == null) {
					State = new EmptyState();
				}
				else {
					State = new DefaultState();
				}
			}
		}

		public EditToolState State {
			get {
				return _state;
			}
			private set {
				_state = value;
			}
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
		public void Draw(DrawingContext context) {
			_state.Draw(context);
		}

		private EditToolState _state = new EmptyState();
		private GraphView _graph = null;
	}
}
