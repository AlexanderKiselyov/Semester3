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
			var localComputers = new List<LocalComputer>
			{
				new LocalComputer(new Linux(), false),
				new LocalComputer(new Macintosh(), false),
				new LocalComputer(new Windows(), true)
			};
			var localNetwork = new LocalNetwork(localComputers, linkMatrix);
			localNetwork.StepOfVirusInfection();
			Assert.IsFalse(localNetwork.IfAllComputersAreInfected());
		}

		[TestMethod]
		public void InfectionTest()
		{
			bool[,] linkMatrix = new bool[3, 3] { { true, true, true }, { true, true, false }, { true, false, true } };
			var localComputers = new List<LocalComputer>
			{
				new LocalComputer(new Linux(), false),
				new LocalComputer(new Macintosh(), false),
				new LocalComputer(new Windows(), true)
			};
			var localNetwork = new LocalNetwork(localComputers, linkMatrix);
			localNetwork.Infection();
			Assert.IsTrue(localNetwork.IfAllComputersAreInfected());
		}

		[TestMethod]
		public void SimulationTest()
		{
			bool[,] linkMatrix = new bool[3, 3] { { true, true, false }, { true, true, true }, { true, true, true } };
			var localComputers = new List<LocalComputer>
			{
				new LocalComputer(new Linux(), false),
				new LocalComputer(new Macintosh(), false),
				new LocalComputer(new Windows(), true)
			};
			var localNetwork = new LocalNetwork(localComputers, linkMatrix);
			localNetwork.Infection();
			Assert.IsTrue(localNetwork.IfAllComputersAreInfected());
		}
	}
}
