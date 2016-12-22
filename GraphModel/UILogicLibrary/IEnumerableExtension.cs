using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods {
	public static class IEnumerableExtension {

		/// <summary>
		/// Заменяет объекты в перечислителе на пары из индекса и исходного объекта. 
		/// </summary>
		/// <typeparam name="T">Переменный тип перечислителя.</typeparam>
		/// <param name="enumerable">Перечислитель.</param>
		/// <returns></returns>
		public static IEnumerable<KeyValuePair<long, T>> Indexed<T>(this IEnumerable<T> enumerable) {
			long index = 0;
			foreach (T val in enumerable) {
				yield return new KeyValuePair<long, T>(index, val);
			}
		}
	}
}
