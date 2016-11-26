﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphModelLibrary;
using System.IO;

namespace UnitTestProject {
	[TestClass]
	public class GraphModelUnitTest {
		[TestMethod]
		public void Parsing1() {
			string text = 
@"5
0 1 0 1 1
1 0 0 1 1
1 0 0 0 1
1 0 1 0 1
1 1 1 1 0";

			GraphModel model = GraphModel.Parse(text);
		}

		[TestMethod]
		public void Parsing2() {
			string text =
@"3
0 2 3
-1 0 0
5 42 0
Node colors:
1 0 3
Text:
Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
Morbi elementum lorem et libero bibendum, ac egestas urna accumsan.";

			GraphModel model = GraphModel.Parse(text);
		}

		[TestMethod]
		public void Parsing3() {
			string text =
@"4
0 2 3 100
-1 0 0 -1
5 42 0 24
1 1 -10 0
Edge colors:
0 1 5
0 2 3
-1
Node colors:
1 0 3
Text:
Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
Morbi elementum lorem et libero bibendum, ac egestas urna accumsan.";

			GraphModel model = GraphModel.Parse(text);
		}

		[TestMethod]
		public void Loading1() {
			string path = @"C:\Users\Ruslan\Desktop\MAI\Диплом\GraphEditor\Examples\Graph files\exampleA1-1.txt";
			GraphModel model = GraphModel.Load(path);
		}

		[TestMethod]
		public void Loading2() {
			string path = @"C:\Users\Ruslan\Desktop\MAI\Диплом\GraphEditor\Examples\Graph files\exampleA1-2.txt";
			GraphModel model = GraphModel.Load(path);
		}

		[TestMethod]
		public void Loading3() {
			string path = @"C:\Users\Ruslan\Desktop\MAI\Диплом\GraphEditor\Examples\Graph files\exampleA1-3.txt";
			GraphModel model = GraphModel.Load(path);
		}
	}
}
