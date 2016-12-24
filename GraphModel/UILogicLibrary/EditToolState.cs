using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using GraphModelLibrary;

namespace UILogicLibrary {
	public abstract class EditToolState {
		public EditToolState(EditTool editTool) {
			this._editTool = editTool;
		}

		public virtual void LeftMouseButtonDown(Point location) { }
		public virtual void LeftMouseButtonUp(Point location) { }
		public virtual void RightMouseButtonDown(Point location) { }
		public virtual void RightMouseButtonUp(Point location) { }
		public virtual void MouseMoved(Point location) { }
		public virtual void Draw(DrawingContext context) { }

		protected EditToolState CurrentState {
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

		protected virtual void TimerElapsed(object sender, ElapsedEventArgs e) {

		}
		protected void StartTimer() {
			_timer = new Timer(500);
			_timer.Elapsed += TimerElapsed;
			_timer.Start();
		}
		protected void StopTimer() {
			_timer.Stop();
		}

		private Timer _timer;
		private EditTool _editTool;
	}


	public class EmptyState : EditToolState {
		public EmptyState(EditTool tool) : base(tool) { }
	}
}
