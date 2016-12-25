using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary
{
	public class EditTool {

		public EditTool(Mouse mouse) {
			this._state = new EmptyState(this);

			mouse.LeftClick += (p => State.MouseLeftClick(p));
			mouse.RightClick += (p => State.MouseRightClick(p));
			mouse.LeftPressed += (p => State.MouseLeftPressed(p));
			mouse.LeftDepressed += (p => State.MouseLeftDepressed(p));
			mouse.Moved += (p => State.MouseMoved(p));
			this._mouse = mouse;
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

		public void Draw(DrawingContext context) {
			State.Draw(context);
		}


		EditToolState _state;
		GraphView _graph = null;
		Mouse _mouse;
	}
}
