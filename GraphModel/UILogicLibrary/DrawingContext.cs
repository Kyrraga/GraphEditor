using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace UILogicLibrary {
	public abstract class DrawingContext {
		public abstract void DrawRectangle(Rectangle rect);
		public abstract void DrawLine(Point a, Point b);
		public abstract Size ScreenSize { get; }
		public abstract Point MousePosition { get; }

		public void SetGraphics(Graphics g) {
			graphics = g;
		}

		protected Graphics graphics;
	}
}
