using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public class Edge2Model : Edge2 {
		public Edge2Model(Node2 from, Node2 to) : base(from, to) { }

		public NodeColor Color {
			get {
				return _color;
			}
			set {
				_color = value;
			}
		}
		public string Value {
			get {
				return _value;
			}
			set {
				_value = value;
			}
		}

		NodeColor _color = new NodeColor();
		string _value = "";
	}
}
