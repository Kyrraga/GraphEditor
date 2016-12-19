using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace UILogicLibrary {
	public class SelectionState : EditToolState {
		public SelectionState(Point start) {
			this._start = start;
		}

		private Point _start;
	}
}
