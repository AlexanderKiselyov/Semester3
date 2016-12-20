namespace Homework_2
{
	/// <summary>
	/// Abstract class for different operating systems.
	/// </summary>
	public abstract class OperatingSystem
	{
		/// <summary>
		/// Operating system name.
		/// </summary>
		public string OSName { get; set; }

		/// <summary>
		/// Probability of operating system infection.
		/// </summary>
		public int InfectionProbability { get; set; }
	}
}