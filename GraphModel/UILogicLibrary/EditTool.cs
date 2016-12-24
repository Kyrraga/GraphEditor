using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary
{
	public class EditTool {

		public EditTool() {
			this._state = new EmptyState(this);
		}

		public GraphView GraphView {
			get {
				return _graph;
			}
			set {
				_graph = value;
				if (_graph == null) {
					State = new EmptyState(this);
				}
				else {
					State = new DefaultState(this);
				}
			}
		}

		public EditToolState State {
			get {
				return _state;
			}
			set {
				_state = value;
			}
		}

		public void LeftMouseButtonDown(Point location) {
			_state.LeftMouseButtonDown(location);
		}
		public void LeftMouseButtonUp(Point location) {
			_state.LeftMouseButtonUp(location);
		}
		public void RightMouseButtonUp(Point location) {
			_state.RightMouseButtonUp(location);
		}
		public void RightMouseButtonDown(Point location) {
			_state.RightMouseButtonDown(location);
		}
		public void MouseMoved(Point location) {
			_state.MouseMoved(location);
		}
		public void Draw(DrawingContext context) {
			_state.Draw(context);
		}

		private EditToolState _state = null;
		private GraphView _graph = null;
	}
}
