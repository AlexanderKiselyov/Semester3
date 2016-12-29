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

		public override void Start(List<Line> lines)
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

		public override void Cancel(List<Line> lines)
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
	}
}
