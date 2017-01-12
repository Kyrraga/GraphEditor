using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomDataStructures;
using System.IO;

namespace UnitTestProject {
	[TestClass]
	public class BiDictionaryUnitTest {
		[TestMethod]
		public void Constructor() {
			var dict = new BiDictionary<string, string>();
		}

		[TestMethod]
		public void Mirror() {
			var dict = new BiDictionary<string, string>();
			var mirror = dict.Mirror;
		}

		[TestMethod]
		public void Set() {
			var dict = new BiDictionary<string, string>();
			var mirror = dict.Mirror;
			string str1 = "hello";
			string str2 = "world";

			dict[str1] = str2;

			Assert.AreEqual(mirror[str2], str1);
		}
	}
}
