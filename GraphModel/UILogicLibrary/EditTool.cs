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

			mouse.LeftClick += (p => MouseLeftClick(p));
			mouse.RightClick += (p => MouseRightClick(p));
			mouse.LeftPressed += (p => MouseLeftPressed(p));
			mouse.LeftDepressed += (p => MouseLeftDepressed(p));
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

		void MouseLeftClick(Point p) {
			Object o = GraphView.FindClicked(p);

			NodeModel node = o as NodeModel;
			if (node != null) {
				State.MouseLeftClick(node);
				return;
			}

			State.MouseLeftClick(p);
		}
		void MouseRightClick(Point p) {
			Object o = GraphView.FindClicked(p);

			NodeModel node = o as NodeModel;
			if (node != null) {
				State.MouseRightClick(node);
				return;
			}

			State.MouseRightClick(p);
		}
		void MouseLeftPressed(Point p) {
			Object o = GraphView.FindClicked(p);

			NodeModel node = o as NodeModel;
			if (node != null) {
				State.MouseLeftPressed(node);
				return;
			}

			State.MouseLeftPressed(p);
		}
		void MouseLeftDepressed(Point p) {
			Object o = GraphView.FindClicked(p);

			NodeModel node = o as NodeModel;
			if (node != null) {
				State.MouseLeftDepressed(node);
				return;
			}

			State.MouseLeftDepressed(p);
		}

		EditToolState _state;
		GraphView _graph = null;
		Mouse _mouse;
	}
}
