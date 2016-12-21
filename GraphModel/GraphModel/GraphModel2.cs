using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ExtensionMethods;


namespace GraphModelLibrary {
	public class GraphModel2 {

		/// <summary>
		/// Загружает граф из файла.
		/// </summary>
		/// <param name="path">Путь к файлу в файловой системе.</param>
		/// <returns>Объект графа.</returns>
		public static GraphModel2 Load(string path) {
			string text = File.ReadAllText(path);
			return GraphModel2.Parse(text);
		}

		/// <summary>
		/// Парсит строку, описывающую граф в формате A1 (см. вики).
		/// </summary>
		/// <param name="str">Строка с описанием графа.</param>
		/// <returns>Объект графа.</returns>
		public static GraphModel2 Parse(string str) {
			// разобьём на строки и уберём пустые, оставшиеся сложим в очередь
			char[] separators = { '\r', '\n' };
			Queue<string> queue = new Queue<string>(str.Split(separators).Where(s => s != ""));

			try {
				int n = int.Parse(queue.Dequeue());

				int[,] adjacencyMatrix = new int[n, n];
				for (int i = 0; i < n; ++i) {
					string line = queue.Dequeue();
					int[] numbers = StringToIntArray(line);

					for (int j = 0; j < n; ++j) {
						adjacencyMatrix[i, j] = numbers[j];
					}
				}

				if (queue.Count == 0) {
					return new GraphModel2(n, adjacencyMatrix);
				}

				NodeColor[] nodeColors = null;
				NodeColor[,] edgeColors = null;
				string text = null;
				while (queue.Count != 0) {
					string line = queue.Dequeue();

					int[] numbers;
					switch (line) {
						case "Node colors:":
							numbers = StringToIntArray(queue.Dequeue());
							nodeColors = numbers.Map(x => (NodeColor)x);
							break;
						case "Edge colors:":
							edgeColors = new NodeColor[n, n];

							line = queue.Dequeue();
							while (line != "-1") {
								numbers = StringToIntArray(line);
								edgeColors[numbers[0], numbers[1]] = (NodeColor)numbers[2];

								line = queue.Dequeue();
							}
							break;
						case "Text:":
							StringBuilder sb = new StringBuilder();
							while (queue.Count > 0) {
								sb.AppendLine(queue.Dequeue());
							}
							text = sb.ToString();
							break;
					}
				}

				return new GraphModel2(n, adjacencyMatrix, nodeColors, edgeColors, text);
			}
			catch (Exception e) {
				throw new InvalidDataException("Неправильный формат входных данных", e);
			}
		}

		public Graph2 Graph {
			get {
				return _graph;
			}
		}
		public string Text {
			get {
				return _text;
			}
			set {
				_text = value;
			}
		}


		readonly Graph2 _graph;
		string _text;

		/// <summary>
		/// Внутренний конструктор модели графа.
		/// Размерности массивов должны совпадать с количеством вершин.
		/// </summary>
		/// <param name="n">Количество вершин.</param>
		/// <param name="matrix">Матрица смежности.</param>
		/// <param name="nodeColors">Цвета вершин.</param>
		/// <param name="edgeColors">Цвета рёбер.</param>
		/// <param name="text">Свободный текст.</param>
		private GraphModel2(
					int n,
					int[,] matrix,
					NodeColor[] nodeColors = null,
					NodeColor[,] edgeColors = null,
					string text = null) {

			// create graph and nodes
			_graph = new Graph2();
			Node2Model[] nodes = new Node2Model[n];
			for (int i = 0; i < nodes.Length; ++i) {
				nodes[i] = new Node2Model();
				_graph.Add(nodes[i]);
			}

			// create edges
			for (int i = 0; i < matrix.GetLength(0); ++i) {
				for (int j = 0; j < matrix.GetLength(1); ++j) {
					int value = matrix[i, j];
					if (value != 0) {
						//Edge2 edge = _graph.AddEdge(nodes[i], nodes[j]) as Edge2;
						Edge2Model edge = new Edge2Model(nodes[i], nodes[j]);
						edge.Value = value.ToString();
					}
				}
			}

			// add colors to nodes
			if (nodeColors != null) {
				for (int i = 0; i < nodeColors.Length; ++i) {
					nodes[i].Color = nodeColors[i];
				}
			}

			// add colors to edges
			if (edgeColors != null) {
				for (int i = 0; i < nodes.Length; ++i) {
					for (int j = 0; j < nodes.Length; ++j) {
						Edge2Model edge = nodes[i]
							.GetOutgoingEdges()
							.FirstOrDefault((e) => (e.To == nodes[j]))
							as Edge2Model;
						if (edge != null) {
							edge.Color = edgeColors[i, j];
						}
					}
				}
			}

			_text = text ?? "";
		}

		/// <summary>
		/// Разбивает строку на числа.
		/// </summary>
		/// <param name="str">Строка, содержащая числа, разбитые пробелами.</param>
		/// <returns>Массив чисел.</returns>
		static int[] StringToIntArray(string str) {
			return str.Split().Map(x => int.Parse(x));
		}
	}
}
