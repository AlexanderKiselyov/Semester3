namespace Homework_2
{
	/// <summary>
	/// Linux OS.
	/// </summary>
	public class Linux : OperatingSystem
	{
		public Linux(int probability = 40)
		{
			InfectionProbability = probability;
			OSName = "Linux";
		}
	}
}
