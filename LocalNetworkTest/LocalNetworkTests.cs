using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework_2
{
	[TestClass]
	public class LocalNetworkTests
	{
		[TestMethod]
		public void StepInfectionTest()
		{
			bool[,] linkMatrix = new bool[3, 3] { { true, true, false }, { true, true, true }, { true, true, true } };
			var localComputers = new List<Computer.LocalComputer>
			{
				new Computer.LocalComputer(new Linux(), false),
				new Computer.LocalComputer(new Macintosh(), false),
				new Computer.LocalComputer(new Windows(), true)
			};
			var localNetwork = new Network.LocalNetwork(localComputers, linkMatrix);
			localNetwork.StepOfVirusInfection();
			Assert.AreEqual(false, localNetwork.IfAllComputersAreInfected());
		}

		[TestMethod]
		public void InfectionTest()
		{
			bool[,] linkMatrix = new bool[3, 3] { { true, true, true }, { true, true, false }, { true, false, true } };
			var localComputers = new List<Computer.LocalComputer>
			{
				new Computer.LocalComputer(new Linux(), false),
				new Computer.LocalComputer(new Macintosh(), false),
				new Computer.LocalComputer(new Windows(), true)
			};
			var localNetwork = new Network.LocalNetwork(localComputers, linkMatrix);
			localNetwork.Infection();
			Assert.AreEqual(true, localNetwork.IfAllComputersAreInfected());
		}

		[TestMethod]
		public void SimulationTest()
		{
			bool[,] linkMatrix = new bool[3, 3] { { true, true, false }, { true, true, true }, { true, true, true } };
			var localComputers = new List<Computer.LocalComputer>
			{
				new Computer.LocalComputer(new Linux(), false),
				new Computer.LocalComputer(new Macintosh(), false),
				new Computer.LocalComputer(new Windows(), true)
			};
			var localNetwork = new Network.LocalNetwork(localComputers, linkMatrix);
			localNetwork.Infection();
			Assert.AreEqual(true, localNetwork.IfAllComputersAreInfected());
		}
	}
}
