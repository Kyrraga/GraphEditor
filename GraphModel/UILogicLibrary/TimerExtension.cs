using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ExtensionMethods {
	public static class TimerExtension {
		public static void Start(this Timer timer, double interval) {
			timer.Interval = interval;
			timer.Start();
		}
	}
}
