using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary
{
	public class EditTool {

		public EditTool(Mouse mouse, Keyboard keyboard) {
			this._state = new EmptyState(this);
			this._selectedNodes = new HashSet<Node>();

			mouse.LeftClick += (p => MouseLeftClick(p));
			mouse.RightClick += (p => MouseRightClick(p));
			mouse.LeftPressed += (p => MouseLeftPressed(p));
			mouse.LeftDepressed += (p => MouseLeftDepressed(p));
			mouse.Moved += (p => State.MouseMoved(p));
			this._mouse = mouse;

			keyboard.KeyPressed += KeyPressed;
			this._keyboard = keyboard;
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
		public Keyboard Keyboard {
			get {
				return _keyboard;
			}
		}

		public void Draw(DrawingContext context) {
			State.Draw(context);
			DrawSelected(context);
		}

		public void AddSelected(ICollection<Node> collection) {
			foreach (Node node in collection) {
				_selectedNodes.Add(node);
			}
		}
		public void AddSelected(params Node[] nodes) {
			foreach (Node node in nodes) {
				_selectedNodes.Add(node);
			}
		}
		public void AddSelected(Rectangle rect) {
			var list = new List<Node>();
			foreach (NodeModel node in GraphView.Graph) {
				if (rect.Contains(node.Location)) {
					list.Add(node);
				}
			}
			AddSelected(list);
		}
		public void ClearSelected() {
			_selectedNodes.Clear();
		}
		public void DeleteSelected() {
			foreach (Node node in _selectedNodes) {
				GraphView.Graph.Remove(node);
				node.Delete();
			}
			_selectedNodes.Clear();
		}
        public void SetSelected(ICollection<Node> collection) {
			ClearSelected();
			AddSelected(collection);
		}
		public void SetSelected(params Node[] nodes) {
			ClearSelected();
			AddSelected(nodes);
		}
		public void SetSelected(Rectangle rect) {
			ClearSelected();
			AddSelected(rect);
		}

		readonly Mouse _mouse;
		readonly Keyboard _keyboard;
		readonly HashSet<Node> _selectedNodes;
		GraphView _graph = null;
		EditToolState _state;

		void MouseLeftClick(Point p) {
			Object o = GraphView?.FindClicked(p);

			NodeModel node = o as NodeModel;
			if (node != null) {
				State.MouseLeftClick(node);
				return;
			}

			State.MouseLeftClick(p);
		}
		void MouseRightClick(Point p) {
			Object o = GraphView?.FindClicked(p);

			NodeModel node = o as NodeModel;
			if (node != null) {
				State.MouseRightClick(node);
				return;
			}

			State.MouseRightClick(p);
		}
		void MouseLeftPressed(Point p) {
			Object o = GraphView?.FindClicked(p);

			NodeModel node = o as NodeModel;
			if (node != null) {
				State.MouseLeftPressed(node);
				return;
			}

			State.MouseLeftPressed(p);
		}
		void MouseLeftDepressed(Point p) {
			Object o = GraphView?.FindClicked(p);

			NodeModel node = o as NodeModel;
			if (node != null) {
				State.MouseLeftDepressed(node);
				return;
			}

			State.MouseLeftDepressed(p);
		}
		void KeyPressed(Keyboard.Key key) {
			State.KeyPressed(key);
		}

		void DrawSelected(DrawingContext context) {
			Pen pen = new Pen(Color.DarkBlue, 1);
			foreach (NodeModel node in _selectedNodes) {
				context.DrawCircle(node.Location, GraphView.NodeRadius + 1, pen);
			}
		}
	}
}
