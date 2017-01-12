using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods {
	public static class IKeyValueCollectionExtension {
		public static Dictionary<TValue, TKey> Mirror<TKey, TValue>(this ICollection<KeyValuePair<TKey, TValue>> dict) {
			var newDict = new Dictionary<TValue, TKey>(dict.Count);
			foreach (var item in dict) {
				if (newDict.ContainsKey(item.Value)) {
					throw new ArgumentException("Values should be unique");
				}
				newDict[item.Value] = item.Key;
			}
			return newDict;
		}
	}
}
