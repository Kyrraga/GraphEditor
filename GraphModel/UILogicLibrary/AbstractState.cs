using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using GraphModelLibrary;

namespace UILogicLibrary {
	public abstract class AbstractState {
		public AbstractState(EditTool editTool, IHolderState holder) {
			this._editTool = editTool;
            this._holder = holder;
		}

		public virtual void MouseLeftClick(Point location) { }
		public virtual void MouseLeftClick(NodeModel node) { }
		public virtual void MouseLeftPressed(Point location) { }
		public virtual void MouseLeftPressed(NodeModel node) { }
		public virtual void MouseLeftDepressed(Point location) { }
		public virtual void MouseLeftDepressed(NodeModel node) { }
		public virtual void MouseRightClick(Point location) { }
		public virtual void MouseRightClick(NodeModel node) { }
		public virtual void MouseMoved(Point location) { }
		public virtual void KeyPressed(Keyboard.Key key) { }
		public virtual void Draw(DrawingContext context) { }

		protected AbstractState CurrentState {
			get {
				return _editTool.State;
			}
			set {
				_editTool.State = value;
			}
		}
		protected EditTool EditTool {
			get {
				return _editTool;
			}
		}
        protected IHolderState Holder
        {
            get {
                return _holder;
            }
        }

        private Timer _timer;
		private EditTool _editTool;
        private IHolderState _holder;
	}


	public class EmptyState : AbstractState {
		public EmptyState(EditTool tool, IHolderState holder) : base(tool, holder) { }
	}
}
