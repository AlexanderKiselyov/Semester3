﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_1
{
	/// <summary>
	/// Class that represents binary tree with functions: addElement, deleteElement, searchElement. Has an enumerator.
	/// </summary>
	/// <typeparam name="T">
	/// Type of tree elements.
	/// </typeparam>
	public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
	{
		private class TreeElement
		{
			/// <summary>
			/// Value of tree element.
			/// </summary>
			public T Value { get; set; }
			
			/// <summary>
			/// Left child of the current element.
			/// </summary>
			public TreeElement LeftChild { get; set; }
			
			/// <summary>
			/// Right child of the current element.
			/// </summary>
			public TreeElement RightChild { get; set; }
			
			/// <summary>
			/// Parent of the current element.
			/// </summary>
			public TreeElement Parent { get; set; }

			public TreeElement(T value)
			{
				Value = value;
				Parent = null;
				LeftChild = null;
				RightChild = null;
			}
		}

		private TreeElement head = null;

		public void AddElement(T value)
		{
			if (head == null)
			{
				head = new TreeElement(value);
				head.Parent = head;
				return;
			}
			var newElement = new TreeElement(value);
			var temp = head;
			while (temp != null)
			{
				if (newElement.Value.CompareTo(temp.Value) > 0)
				{
					if (temp.RightChild == null)
					{
						temp.RightChild = newElement;
						temp.RightChild.Parent = temp;
						return;
					}
					temp = temp.RightChild;
				}
				else if (newElement.Value.CompareTo(temp.Value) < 0)
				{
					if (temp.LeftChild == null)
					{
						temp.LeftChild = newElement;
						temp.LeftChild.Parent = temp;
						return;
					}
					temp = temp.LeftChild;
				}
				else
				{
					return;
				}
			}
			if (newElement.Value.CompareTo(head.Value) <= 0)
			{
				head.LeftChild = newElement;
			}
			else
			{
				head.RightChild = newElement;
			}
		}

		public void DeleteElement(T value)
		{
			if (SearchElement(value))
			{
				var temp = head;
				var parent = temp;
				while (temp.Value.CompareTo(value) != 0)
				{
					if (value.CompareTo(temp.Value) > 0)
					{
						parent = temp;
						temp = temp.RightChild;
					}
					else if (value.CompareTo(temp.Value) < 0)
					{
						parent = temp;
						temp = temp.LeftChild;
					}
				}
				Delete(temp, parent);
			}
		}

		private void Delete(TreeElement node, TreeElement parent)
		{
			if ((node.LeftChild == null) && (node.RightChild == null))
			{
				if (parent.LeftChild.Value.CompareTo(node.Value) == 0)
				{
					parent.LeftChild = null;
				}
				else
				{
					parent.RightChild = null;
				}
			}
			else if ((node.LeftChild != null) && (node.RightChild == null))
			{
				if (parent.LeftChild.Value.CompareTo(node.Value) == 0)
				{
					parent.LeftChild = node.LeftChild;
					node.LeftChild.Parent = parent;
				}
				else
				{
					parent.RightChild = node.LeftChild;
					node.LeftChild.Parent = parent;
				}
			}
			else if ((node.RightChild != null) && (node.LeftChild == null))
			{
				if (parent.LeftChild.Value.CompareTo(node.Value) == 0)
				{
					parent.LeftChild = node.RightChild;
					node.RightChild.Parent = parent;
				}
				else
				{
					parent.RightChild = node.RightChild;
					node.RightChild.Parent = parent;
				}
			}
			else
			{
				var delElement = node.RightChild;
				if (delElement.LeftChild != null)
				{
					while (delElement.LeftChild.LeftChild != null)
					{
						delElement = delElement.LeftChild;
					}
					node.Value = delElement.LeftChild.Value;
					if (delElement.LeftChild.RightChild != null)
					{
						delElement.LeftChild.Value = delElement.LeftChild.RightChild.Value;
						delElement.LeftChild.RightChild = null;
					}
					else
					{
						delElement.LeftChild = null;
					}
				}
				else
				{
					node.LeftChild.Parent = node.RightChild;
					node.RightChild.LeftChild = node.LeftChild;
				}
			}
		}

		public bool SearchElement(T value)
		{
			if (head == null)
			{
				return false;
			}
			else
			{
				var temp = head;
				while (temp != null)
				{
					if (value.CompareTo(temp.Value) > 0)
					{
						temp = temp.RightChild;
					}
					else if (value.CompareTo(temp.Value) < 0)
					{
						temp = temp.LeftChild;
					}
					else
					{
						return true;
					}
				}
				return false;
			}
		}
		
		/// <summary>
		/// Returns enumerator for tree elements.
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private class Enumerator : IEnumerator<T>
		{
			private List<T> treeList;
			private int position;

			public Enumerator(BinaryTree<T> tree)
			{
				treeList = new List<T>();
				position = -1;
				MakeTreeList(tree.head);
			}

			/// <summary>
			/// Creates a list with tree elements.
			/// </summary>
			/// <param name="element">
			/// Adding to tree list element. 
			/// </param>
			private void MakeTreeList(TreeElement element)
			{
				if (element != null)
				{
					if (element.RightChild != null)
					{
						MakeTreeList(element.RightChild);
					}
					if (element.LeftChild != null)
					{
						MakeTreeList(element.LeftChild);
					}
					treeList.Add(element.Value);
				}
			}
			
			/// <summary>
			/// Returns current element.
			/// </summary>
			public object Current
			{
				get
				{
					return Current;
				}
			}

			T IEnumerator<T>.Current
			{
				get
				{
					return treeList[position];
				}
			}

			public void Dispose()
			{
			}
			
			/// <summary>
			/// Moves to the next tree element.
			/// </summary>
			/// <returns></returns>
			public bool MoveNext()
			{
				if (position < treeList.Count - 1)
				{
					position++;
					return true;
				}
				return false;
			}
			
			/// <summary>
			/// Returns to the first tree element.
			/// </summary>
			public void Reset()
			{
				position = -1;
			}
		}
	}
}
