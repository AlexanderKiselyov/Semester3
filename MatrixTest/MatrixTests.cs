using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework_3
{
	[TestClass]
	public class MatrixTests
	{
		[TestMethod]
		public void MatrixTest1()
		{
			bool[,] matrix = new bool[4, 4] { { true, true, true, false }, { true, true, false, true }, { true, false, true, true }, { false, true, true, true } };
			bool[] robotPosition = new bool[4] { true, true, true, true };
			Graph graph = new Graph(matrix, robotPosition.Length);
			Robots robots = new Robots(graph, robotPosition);
			Assert.AreEqual(true, robots.FinalDecision());
		}

		[TestMethod]
		public void MatrixTest2()
		{
			bool[,] matrix = new bool[3, 3] { { true, true, false }, { true, true, true }, { false, true, true } };
			bool[] robotPosition = new bool[3] { true, true, true };
			Graph graph = new Graph(matrix, robotPosition.Length);
			Robots robots = new Robots(graph, robotPosition);
			Assert.AreEqual(false, robots.FinalDecision());
		}
	}
}
