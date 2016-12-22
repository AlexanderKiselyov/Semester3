namespace Homework_2
{
	/// <summary>
	/// Windows OS.
	/// </summary>
	public class Windows : OperatingSystem
	{
		public Windows(int probability = 60)
		{
			InfectionProbability = probability;
			OSName = "Windows";
		}
	}
}
