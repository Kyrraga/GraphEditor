using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace UILogicLibrary {
	public class SelectionState : EditToolState {
		public SelectionState(EditTool tool, Point start) : base(tool) {
			this._start = start;
		}

		public override void Draw(DrawingContext context) {
			Point mouse = context.MousePosition;
			Rectangle rect = new Rectangle();
			rect.Location = _start;
			rect.Size = new Size(mouse.X - _start.X, mouse.Y - _start.Y);
			context.DrawRectangle(rect);
		}

		public override void LeftMouseButtonUp(Point location) {
			CurrentState = new DefaultState(EditTool);
		}

		private Point _start;
	}
}
