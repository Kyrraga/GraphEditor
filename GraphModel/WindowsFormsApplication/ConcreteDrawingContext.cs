using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UILogicLibrary;

namespace WindowsFormsApplication {
	class ConcreteDrawingContext : DrawingContext {
		public ConcreteDrawingContext(Control canvas) {
			this._canvas = canvas;
		}

		public override void DrawRectangle(Rectangle rect) {
			if (rect.Width < 0) {
				rect.X += rect.Width;
				rect.Width *= -1;
			}
			if (rect.Height < 0) {
				rect.Y += rect.Height;
				rect.Height *= -1;
			}
			graphics.DrawRectangle(Pens.Black, rect);
		}
		public override void DrawLine(Point a, Point b) {
			graphics.DrawLine(Pens.Black, a, b);
		}
		public override Size ScreenSize {
			get {
				return _canvas.Size;
			}
		}
		public override Point MousePosition {
			get {
				return _canvas.PointToClient(Control.MousePosition);
			}
		}

		private Control _canvas;
	}
}
