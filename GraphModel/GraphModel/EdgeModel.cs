using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public class EdgeModel : Edge {
		public EdgeModel(Node from, Node to) : base(from, to) { }

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
