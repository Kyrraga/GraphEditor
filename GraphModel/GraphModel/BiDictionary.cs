using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomDataStructures {
	public interface IBiDictionary<TFirst, TSecond> : IDictionary<TFirst, TSecond> {
		IBiDictionary<TSecond, TFirst> Mirror { get; }
	}

	public partial class BiDictionary<TFirst, TSecond> : IDictionary<TFirst, TSecond>, IBiDictionary<TFirst, TSecond> {
		public BiDictionary() {
			this._dictionary = new Dictionary<TFirst, TSecond>();
			this._mirror = new BiDictionary<TSecond, TFirst>(this);
		}
		public BiDictionary(BiDictionary<TSecond, TFirst> mirror) {
			this._dictionary = new Dictionary<TFirst, TSecond>();
			this._mirror = mirror;
		}

		public IBiDictionary<TSecond, TFirst> Mirror {
			get {
				return _mirror;
			}
		}
		public ICollection<TFirst> Keys {
			get {
				return _dictionary.Keys;
			}
		}
		public ICollection<TSecond> Values {
			get {
				return _dictionary.Values;
			}
		}
		public int Count {
			get {
				return _dictionary.Count;
			}
		}
		public bool IsReadOnly {
			get {
				return ((IDictionary<TFirst, TSecond>)_dictionary).IsReadOnly;
			}
		}

		public TSecond this[TFirst key] {
			get {
				return _dictionary[key];
			}
			set {
				_mirror._dictionary[value] = key;
				_dictionary[key] = value;
			}
		}

		public bool ContainsKey(TFirst key) {
			return _dictionary.ContainsKey(key);
		}
		public void Add(TFirst key, TSecond value) {
			_mirror._dictionary.Add(value, key);
			_dictionary.Add(key, value);
		}
		public bool Remove(TFirst key) {
			_mirror._dictionary.Remove(this[key]);
			return _dictionary.Remove(key);
		}
		public bool TryGetValue(TFirst key, out TSecond value) {
			return _dictionary.TryGetValue(key, out value);
		}
		public void Add(KeyValuePair<TFirst, TSecond> item) {
			var mirrored = new KeyValuePair<TSecond, TFirst>(item.Value, item.Key);
			((IDictionary<TFirst, TSecond>)_mirror._dictionary).Add(item);
			((IDictionary<TFirst, TSecond>)_dictionary).Add(item);
		}
		public void Clear() {
			_mirror._dictionary.Clear();
			_dictionary.Clear();
		}
		public bool Contains(KeyValuePair<TFirst, TSecond> item) {
			return _dictionary.Contains(item);
		}
		public void CopyTo(KeyValuePair<TFirst, TSecond>[] array, int arrayIndex) {
			((IDictionary<TFirst, TSecond>)_dictionary).CopyTo(array, arrayIndex);
		}
		public bool Remove(KeyValuePair<TFirst, TSecond> item) {
			_mirror._dictionary.Remove(item.Value);
			return _dictionary.Remove(item.Key);
		}
		public IEnumerator<KeyValuePair<TFirst, TSecond>> GetEnumerator() {
			return _dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return _dictionary.GetEnumerator();
		}
		
		Dictionary<TFirst, TSecond> _dictionary;
		BiDictionary<TSecond, TFirst> _mirror;
	}
}
