using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Diagnostics;
using ExtensionMethods;

namespace UILogicLibrary {
	public class Mouse {
		public Mouse() {
			_timer = new Timer();
			_timer.Elapsed += OnTimerElapsed;
		}

		public void LeftButtonDown(Point point) {
			_startPoint = point;
			_timer.Start(_delay);
		}
		public void LeftButtonUp(Point point) {
			if (_timer.Enabled) {
				_timer.Stop();
				LeftClick(point);
			}
			else {
				LeftDepressed(point);
			}
		}
		public void RightButtonDown(Point point) {

		}
		public void RightButtonUp(Point point) {
			RightClick(point);
		}
		public void MouseMoved(Point point) {
			if (point == _lastPoint) {
				return;
			}
			_lastPoint = point;

			if (_timer.Enabled) {
				_timer.Stop();
				LeftPressed(_startPoint);
			}
			Moved(point);
		}

		public event MouseEventDelegate LeftClick;
		public event MouseEventDelegate RightClick;
		public event MouseEventDelegate LeftPressed;
		public event MouseEventDelegate LeftDepressed;
		//public event MouseEventDelegate RightPressed;
		//public event MouseEventDelegate RightDepressed;
		public event MouseEventDelegate Moved;

		Timer _timer;
		double _delay = 300;
		Point _startPoint;
		Point _lastPoint = new Point(-1000, -1000);

		void OnTimerElapsed(object sender, ElapsedEventArgs e) {
			LeftPressed(_startPoint);
		}
	}

	public delegate void MouseEventDelegate(Point point);	
}