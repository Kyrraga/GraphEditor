using System;
using System.Linq;

namespace ExtensionMethods {
	public static class ArrayExtension {

		/// <summary>
		/// Заполняет массив заданным значением.
		/// </summary>
		/// <typeparam name="T">Тип данных в массиве.</typeparam>
		/// <param name="array">Исходный массив.</param>
		/// <param name="value">Значение для заполнения массива.</param>
		public static void Fill<T>(this T[] array, T value) {
			for (int i = 0; i < array.Length; ++i) {
				array[i] = value;
			}
		}

		/// <summary>
		/// Заполняет двумерный массив заданным значением.
		/// </summary>
		/// <typeparam name="T">Тип данных в массиве.</typeparam>
		/// <param name="array">Исходный массив.</param>
		/// <param name="value">Значение для заполнения массива.</param>
		public static void Fill<T>(this T[,] array, T value) {
			for (int i = 0; i < array.GetLength(0); ++i) {
				for (int j = 0; j < array.GetLength(1); ++j) {
					array[i, j] = value;
				}
			}
		}

		/// <summary>
		/// Применяет функцию ко всем элементам массива.
		/// </summary>
		/// <typeparam name="T">Тип данных в исходном массиве.</typeparam>
		/// <typeparam name="TReturn">Тип данных в возвращаемом массиве.</typeparam>
		/// <param name="array">Исходный массив.</param>
		/// <param name="function">Функция, применяемая к массиву.</param>
		/// <returns></returns>
		public static TReturn[] Map<T, TReturn>(this T[] array, Func<T, TReturn> function) {
			return array.Select(function).ToArray();
		}
	}
}
