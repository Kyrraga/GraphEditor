using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsFormsApplication {
	class ConcreteKeyboard : UILogicLibrary.Keyboard {
		public ConcreteKeyboard(Control control) {
			control.KeyDown += KeyDown;
		}

		public override bool IsKeyDown(Key key) {
			System.Windows.Input.Key windowsKey = System.Windows.Input.Key.None;
			switch (key) {
				case Key.Delete:
					windowsKey = System.Windows.Input.Key.Delete;
					break;
				case Key.Shift:
					windowsKey = System.Windows.Input.Key.LeftShift;
					break;
				default:
					throw new ArgumentException(string.Format("{0} is not a valid argument.", key));
			}
			return Keyboard.IsKeyDown(windowsKey);
        }

		void KeyDown(object sender, System.Windows.Forms.KeyEventArgs handler) {
			switch (handler.KeyCode) {
				case System.Windows.Forms.Keys.Delete:
					CallKeyPressed(Key.Delete);
					break;
				case System.Windows.Forms.Keys.ShiftKey:
					CallKeyPressed(Key.Shift);
					break;
			}
		}
	}
}
