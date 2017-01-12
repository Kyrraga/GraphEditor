using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphModelLibrary;

namespace UILogicLibrary {
	public class Selection : IEnumerable<Node> {
		public Selection(EditTool editTool) {
			this._selectedNodes = new HashSet<Node>();
			this._editTool = editTool;
		}

		public void Add(ICollection<Node> collection) {
			foreach (Node node in collection) {
				_selectedNodes.Add(node);
			}
		}
		public void Add(params Node[] nodes) {
			foreach (Node node in nodes) {
				_selectedNodes.Add(node);
			}
		}
		public void Add(Rectangle rect) {
			var list = new List<Node>();
			foreach (NodeModel node in _editTool.GraphView.Graph) {
				if (rect.Contains(node.Location)) {
					list.Add(node);
				}
			}
			Add(list);
		}
		public void Clear() {
			_selectedNodes.Clear();
		}
		public void Delete() {
			foreach (Node node in _selectedNodes) {
				_editTool.GraphView.Graph.Remove(node);
				node.Delete();
			}
			_selectedNodes.Clear();
		}
		public void Set(ICollection<Node> collection) {
			Clear();
			Add(collection);
		}
		public void Set(params Node[] nodes) {
			Clear();
			Add(nodes);
		}
		public void Set(Rectangle rect) {
			Clear();
			Add(rect);
		}

		public IEnumerator GetEnumerator() {
			return _selectedNodes.GetEnumerator();
		}
		
		
		readonly HashSet<Node> _selectedNodes;
		readonly EditTool _editTool;

		IEnumerator<Node> IEnumerable<Node>.GetEnumerator() {
			return _selectedNodes.GetEnumerator();
		}
	}
}
