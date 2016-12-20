using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework_1
{
	[TestClass]
	public class TreeTest
	{
		[TestMethod]
		public void AddTreeTests()
		{
			var tree = new BinaryTree<int>();
			int number = 0;
			tree.AddElement(7);
			tree.AddElement(6);
			tree.AddElement(12);
			tree.AddElement(4);
			tree.AddElement(1);
			tree.AddElement(7);
			tree.AddElement(5);
			tree.AddElement(10);
			tree.AddElement(15);
			tree.AddElement(8);
			tree.AddElement(9);
			tree.AddElement(11);
			tree.AddElement(9);
			tree.AddElement(13);
			tree.AddElement(18);
			tree.AddElement(17);
			tree.AddElement(17);
			foreach (var value in tree)
			{
				number++;
			}
			Assert.AreEqual(number, 14);
		}

		[TestMethod]
		public void DeleteTreeTests()
		{
			var tree = new BinaryTree<int>();
			int number = 0;
			tree.AddElement(7);
			tree.AddElement(6);
			tree.AddElement(12);
			tree.AddElement(4);
			tree.AddElement(1);
			tree.AddElement(7);
			tree.AddElement(5);
			tree.AddElement(10);
			tree.AddElement(15);
			tree.AddElement(8);
			tree.AddElement(9);
			tree.AddElement(11);
			tree.AddElement(9);
			tree.AddElement(13);
			tree.AddElement(18);
			tree.AddElement(17);
			tree.AddElement(17);
			tree.DeleteElement(7);
			foreach (var value in tree)
			{
				number++;
			}
			Assert.AreEqual(number, 13);
		}

		[TestMethod]
		public void SearchTreeTests()
		{
			var tree = new BinaryTree<int>();
			tree.AddElement(7);
			tree.AddElement(6);
			tree.AddElement(12);
			tree.AddElement(4);
			tree.AddElement(1);
			tree.AddElement(7);
			tree.AddElement(5);
			tree.AddElement(10);
			tree.AddElement(15);
			tree.AddElement(8);
			tree.AddElement(9);
			tree.AddElement(11);
			tree.AddElement(9);
			tree.AddElement(13);
			tree.AddElement(18);
			tree.AddElement(17);
			tree.AddElement(17);
			Assert.AreEqual(tree.SearchElement(3), false);
			Assert.AreEqual(tree.SearchElement(11), true);
		}
	}
}
