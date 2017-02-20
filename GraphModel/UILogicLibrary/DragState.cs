using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	class DragState : AbstractState{
		public DragState(EditTool editTool, IHolderState holder, NodeModel node) : base(editTool, holder) {
			this._node = node;
		}

		public override void MouseMoved(Point location) {
			_node.Location = location;
		}

		public override void MouseLeftDepressed(NodeModel node) {
			Depressed();
		}

		public override void MouseLeftDepressed(Point location) {
			Depressed();
		}

		NodeModel _node;

		void Depressed() {
			CurrentState = new DefaultState(EditTool, Holder);
		}
	}
}
