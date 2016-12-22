namespace Homework_2
{
	/// <summary>
	/// Class for each local computer.
	/// </summary>
	public class LocalComputer
	{
		private OperatingSystem operatingSystem;

		public LocalComputer(OperatingSystem concreteOperatingSystem, bool ifInfected)
		{
			operatingSystem = concreteOperatingSystem;
			Infected = ifInfected;
		}

		/// <summary>
		/// If computer infected.
		/// </summary>
		public bool Infected { get; set; }

		/// <summary>
		/// Returns infection probability of the concrete operating system on each computer.
		/// </summary>
		/// <returns></returns>
		public int InfectionProbability()
		{
			return operatingSystem.InfectionProbability;
		}

		/// <summary>
		/// Returns operating system name.
		/// </summary>
		/// <returns></returns>
		public string OSName()
		{
			return operatingSystem.OSName;
		}
	}
}
