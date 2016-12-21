using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GraphModelLibrary {
	public class Graph2 : IEnumerable<Node2> {
		public Graph2() {
			_list = new List<Node2>();
		}

		public int Count {
			get {
				return _list.Count;
			}
		}

		public void Add(Node2 node) {
			_list.Add(node);
		}
		[Obsolete]
		public Node2 AddNode() {
			Node2 node = new Node2();
			_list.Add(node);
			return node;
		}

		public void Clear() {
			_list.Clear();
		}

		public bool Contains(Node2 node) {
			return _list.Contains(node);
		}

		public IEnumerator<Node2> GetEnumerator() {
			return _list.GetEnumerator();
		}

		public bool Remove(Node2 node) {
			return _list.Remove(node);
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return _list.GetEnumerator();
		}

		List<Node2> _list;
	}
}
