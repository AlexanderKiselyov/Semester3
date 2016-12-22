using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework_2
{
	/// <summary>
	/// Class that simulates local network.
	/// </summary>
	public class LocalNetwork
	{
		private List<LocalComputer> allComputers;
		private List<LocalComputer> infectedComputers;
		private bool[,] linkedComputers;
		private Random random = new Random();

		public LocalNetwork(List<LocalComputer> localNetwork, bool[,] linkMatrix)
		{
			allComputers = localNetwork;
			linkedComputers = linkMatrix;
		}

		/// <summary>
		/// Represents each step of local network status.
		/// </summary>
		public void StepOfVirusInfection()
		{
			infectedComputers = new List<LocalComputer>();
			for (int i = 0; i < allComputers.Count; i++)
			{
				if (allComputers[i].Infected)
				{
					for (int j = 0; j < allComputers.Count; j++)
					{
						if (i != j && linkedComputers[i, j] && !allComputers[j].Infected && !infectedComputers.Contains(allComputers[j]))
						{
							if (random.Next(0, 100) < allComputers[j].InfectionProbability())
							{
								allComputers[j].Infected = true;
								infectedComputers.Add(allComputers[j]);
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Checks if all computers in local network are infected.
		/// </summary>
		/// <returns></returns>
		public bool IfAllComputersAreInfected()
		{
			int numberOfInfectedComputers = 0;
			foreach (var localComputer in allComputers)
			{
				if (localComputer.Infected)
				{
					numberOfInfectedComputers++;
				}
			}
			return numberOfInfectedComputers == allComputers.Count;
		}

		/// <summary>
		/// Simulates infection of computers in local network.
		/// </summary>
		public void Infection()
		{
			int step = 1;
			while (!IfAllComputersAreInfected())
			{
				StepOfVirusInfection();
				Console.WriteLine("Step {0}:", step);
				foreach (var localComputer in allComputers)
				{
					Console.WriteLine("Operating system name: " + localComputer.OSName() + "; " + "Infected: " + localComputer.Infected);
				}
				Console.WriteLine();
				step++;
				Thread.Sleep(1000);
			}
			Console.WriteLine("All computers are infected!");
		}
	}	
}
