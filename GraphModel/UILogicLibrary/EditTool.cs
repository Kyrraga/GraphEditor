using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary
{
	public class EditTool {

		public EditTool(DrawingContext context) {
			this._drawingContext = context;
		}

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
		public void Draw(Graphics g) {
			_drawingContext.SetGraphics(g);
			_state.Draw(_drawingContext);
		}

		private EditToolState _state = new EmptyState();
		private DrawingContext _drawingContext = null;
		private GraphView _graph = null;
	}
}
