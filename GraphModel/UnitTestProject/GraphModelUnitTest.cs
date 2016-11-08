using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphModel;
using System.IO;

namespace UnitTestProject {
	[TestClass]
	public class GraphModelUnitTest {
		[TestMethod]
		public void Loading1() {
			string path = "test_file.txt";
			string contents = 
@"5
0 1 0 1 1
1 0 0 1 1
1 0 0 0 1
1 0 1 0 1
1 1 1 1 0";
			File.WriteAllText(path, contents);

			try {
				GraphModel.GraphModel model = GraphModel.GraphModel.Load(path);
			}
			finally {
				File.Delete(path);
			}
		}

		[TestMethod]
		public void Loading2() {
			string path = "test_file.txt";
			string contents =
@"3
0 2 3
-1 0 0
5 42 0
Node colors:
1 0 3
Text:
Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
Morbi elementum lorem et libero bibendum, ac egestas urna accumsan.";
			File.WriteAllText(path, contents);

			try {
				GraphModel.GraphModel model = GraphModel.GraphModel.Load(path);
			}
			finally {
				File.Delete(path);
			}
		}

		[TestMethod]
		public void Loading3() {
			string path = "test_file.txt";
			string contents =
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
			File.WriteAllText(path, contents);

			try {
				GraphModel.GraphModel model = GraphModel.GraphModel.Load(path);
			}
			finally {
				File.Delete(path);
			}
		}
	}
}
