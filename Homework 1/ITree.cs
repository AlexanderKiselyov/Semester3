using System;
using System.Collections.Generic;

namespace Homework_1
{
	///Interface for a binary tree. Can add elements, delete them and search for them.
	public interface IBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
	{
		/// <summary>
		/// Adds a value to the binary tree.
		/// </summary>
		/// <param name="value">
		/// Adding element.
		/// </param>
		void AddElement(T value);

		/// <summary>
		/// Deletes a value from the tree.
		/// </summary>
		/// <param name="value">
		/// Deleting element.
		/// </param>
		void DeleteElement(T value);

		/// <summary>
		/// Searches for a value in the tree.
		/// </summary>
		/// <param name="value">
		/// Searching element.
		///</param>
		bool SearchElement(T value);
	}
}
