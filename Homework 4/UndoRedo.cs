using System.Collections.Generic;

namespace GraphicEditor
{
	/// <summary>
	/// Represents cancellation of operations and can returns them.
	/// </summary>
	public class UndoRedo
	{
		private Stack<Command> undo = new Stack<Command>();
		private Stack<Command> redo = new Stack<Command>();

		/// <summary>
		/// Adds command to the stack.
		/// </summary>
		public void AddCommand(Command command)
		{
			undo.Push(command);
			undo.Push(null);

			/*if (redo.Count != 0)
			{
				redo = new Stack<Command>();
			}*/
		}

		/// <summary>
		/// Cancels last operation.
		/// </summary>
		public void Undo(List<Line> lines)
		{
			if (undo.Count > 0)
			{
				undo.Pop();
				while (undo.Count > 0 && undo.Peek() != null)
				{
					redo.Push(undo.Pop());
					redo.Peek().Cancel(lines);
				}
				redo.Push(null);
			}
		}

		/// <summary>
		/// Activates last operation which was canceled.
		/// </summary>
		public void Redo(List<Line> lines)
		{
			if (redo.Count > 0)
			{
				redo.Pop();
				while (redo.Count > 0 && redo.Peek() != null)
				{
					undo.Push(redo.Pop());
					undo.Peek().Start(lines);
				}
				undo.Push(null);
			}
		}

		/// <summary>
		/// Checks if the undo stack is empty.
		/// </summary>
		/// <returns></returns>
		public bool UndoStackIsEmpty()
		{
			return undo.Count == 0;
		}

		/// <summary>
		/// Checks if the redo stack is empty.
		/// </summary>
		/// <returns></returns>
		public bool RedoStackIsEmpty()
		{
			return redo.Count == 0;
		}
	}
}