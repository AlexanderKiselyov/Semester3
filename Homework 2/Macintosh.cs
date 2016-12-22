namespace Homework_2
{
	/// <summary>
	/// Macintosh OS.
	/// </summary>
	public class Macintosh : OperatingSystem
	{
		public Macintosh(int probability = 20)
		{
			InfectionProbability = probability;
			OSName = "Macintosh";
		}
	}
}
