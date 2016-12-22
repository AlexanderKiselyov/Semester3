using System.Collections.Generic;

namespace GraphicEditor
{
	/// <summary>
	/// Interface for starting and cancelling commands.
	/// </summary>
	public abstract class Command
	{
		/// <summary>
		/// Starts command.
		/// </summary>
		public abstract void Execute(List<Line> shapes);

		/// <summary>
		/// Cancels command.
		/// </summary>
		public abstract void UnExecute(List<Line> shapes);
	}
}
