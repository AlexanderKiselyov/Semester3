using System.Collections.Generic;

namespace GraphicEditor
{
	/// <summary>
	/// Concrete line command.
	/// </summary>
	public class ConcreteCommand : Command
	{
		private string commandName;
		private Line line;

		public ConcreteCommand(Line newLine, string name)
		{
			line = newLine;
			commandName = name;
		}

		public override void UnExecute(List<Line> lines)
		{
			if (commandName != "Add")
			{
				lines.Add(line);
			}
			else
			{
				lines.Remove(line);
			}
		}

		public override void Execute(List<Line> lines)
		{
			if (commandName == "Add")
			{
				lines.Add(line);
			}
			else
			{
				lines.Remove(line);
			}
		}
	}
}
