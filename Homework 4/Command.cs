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
		public abstract void Start(List<Line> shapes);

		/// <summary>
		/// Cancels command.
		/// </summary>
		public abstract void Cancel(List<Line> shapes);
	}
}
