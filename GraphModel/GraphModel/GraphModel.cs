using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using ExtensionMethods;

namespace GraphModel
{
	// UNUSED
	public class Vertex {
		public string name;
		public string color;
	}

	public enum NodeColor {
		Magenta = 0,
		Blue = 1,
		Red = 2,
		Green = 3,
		Black = 4, 
		White = 5,
		Purple = 6,
		Orange = 7,
		Yellow = 8,
		Pink = 9,
		Turquoise = 10,
		Grey = 11,
		Teal = 12,
		Darkblue = 13,
		Violet = 14,
		Brown = 15
	}

	public class GraphModel {
		/// <summary>
		/// Загружает граф из файла.
		/// </summary>
		/// <param name="path">Путь к файлу в файловой системе.</param>
		/// <returns>Объект графа.</returns>
		public static GraphModel Load(string path) {
			string text = File.ReadAllText(path);
			return GraphModel.Parse(text);
		}

		/// <summary>
		/// Парсит строку, описывающую граф в формате A1 (см. вики).
		/// </summary>
		/// <param name="str">Строка с описанием графа.</param>
		/// <returns>Объект графа.</returns>
		public static GraphModel Parse(string str) {
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
					return new GraphModel(n, adjacencyMatrix);
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
							edgeColors.Fill(DEFAULT_EDGE_COLOR);

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

				return new GraphModel(n, adjacencyMatrix, nodeColors, edgeColors, text);
			}
			catch (Exception e){
				throw new InvalidDataException("Неправильный формат входных данных", e);
			}
		}

		private const NodeColor DEFAULT_NODE_COLOR = NodeColor.Magenta;
		private const NodeColor DEFAULT_EDGE_COLOR = NodeColor.Magenta;

		private readonly int _nodeNumber;
		private readonly int[,] _adjacencyMatrix = null;
		private readonly NodeColor[] _nodeColors = null;
		private readonly NodeColor[,] _edgeColors = null;
		private string _text;

		/// <summary>
		/// Внутренний конструктор модели графа.
		/// Размерности массивов должны совпадать с количеством вершин.
		/// </summary>
		/// <param name="n">Количество вершин.</param>
		/// <param name="matrix">Матрица смежности.</param>
		/// <param name="nodeColors">Цвета вершин.</param>
		/// <param name="edgeColors">Цвета рёбер.</param>
		/// <param name="text">Свободный текст.</param>
		private GraphModel(
					int n,
					int[,] matrix,
					NodeColor[] nodeColors = null,
					NodeColor[,] edgeColors = null,
					string text = null) {

			_nodeNumber = n;

			_adjacencyMatrix = (int[,])matrix.Clone();

			_nodeColors = (NodeColor[])nodeColors?.Clone();
			if (_nodeColors != null) {
				_nodeColors = new NodeColor[n];
				_nodeColors.Fill(DEFAULT_NODE_COLOR);
			}

			_edgeColors = (NodeColor[,])edgeColors?.Clone();
			if (_edgeColors != null) {
				_edgeColors = new NodeColor[n, n];
				_edgeColors.Fill(DEFAULT_EDGE_COLOR);
			}

			_text = text ?? "";
		}

		/// <summary>
		/// Разбивает строку на числа.
		/// </summary>
		/// <param name="str">Строка, содержащая числа, разбитые пробелами.</param>
		/// <returns>Массив чисел.</returns>
		private static int[] StringToIntArray(string str) {
			return str.Split().Map(x => int.Parse(x));
  }
	}
}
