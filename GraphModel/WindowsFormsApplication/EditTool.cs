using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GraphModelLibrary;

namespace WindowsFormsApplication {
	class EditTool {

		public EditTool(GroupBox groupBox) {
			_drawingTarget = groupBox;
		}

		public void Draw(Graphics g) {

		}

		public void SetGraph(GraphModel graphModel) {
			_graph = graphModel.Graph;
			//TODO: set tool state to default
		}

		public void LeftMouseButtonDown(Point location) {
			
		}

		public void LeftMouseButtonUp(Point location) {

		}

		private GroupBox _drawingTarget;
		private IGraph _graph = null;

		private EditToolState _state = new DefaultEditToolState();
	}
}
