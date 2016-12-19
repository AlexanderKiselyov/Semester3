namespace Homework_3
{
	public class Robots
	{
		private Graph graph;
		private int countVerteces = 0;
		private int countRobots = 0;
		private int countMarkedRobots = 0;
		private bool[] vertexWithRobot;
		private bool[] markedVerteces;

		public Robots(Graph graph, bool[] positionAdd)
		{
			this.graph = graph;
			countVerteces = graph.Number();
			vertexWithRobot = positionAdd;
		}

		/// <summary>
		/// Marks first vertex.
		/// </summary>
		private void InitialMarkVertexes()
		{
			for (int i = 0; i < countVerteces; i++)
			{
				if (vertexWithRobot[i] == true)
				{
					countRobots++;
				}
			}
			markedVerteces = new bool[countVerteces];
			markedVerteces[0] = true;
			for (int i = 1; i < countVerteces; i++)
			{
				markedVerteces[i] = false;
			}
			countMarkedRobots++;
			MarkVertexes(0);
		}

		/// <summary>
		/// Marks each vertex which has adjacent vertex with another marked vertex.
		/// </summary>
		/// <param name="consideringVertex"></param>
		private void MarkVertexes(int consideringVertex)
		{
			for (int i = 0; i < countVerteces; i++)
			{
				if (!markedVerteces[i] && IfWay(consideringVertex, i))
				{
					if (vertexWithRobot[i] == true)
					{
						countMarkedRobots++;
					}
					markedVerteces[i] = true;
					MarkVertexes(i);
				}
			}
		}

		/// <summary>
		/// Checks if there is a way between two vertexes.
		/// </summary>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <returns></returns>
		private bool IfWay(int first, int second)
		{
			for (int i = 0; i < countVerteces; i++)
			{
				if ((i != first) && (i != second) && (graph.IfHasWay(first, i)) && (graph.IfHasWay(second, i)))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Shows if all robots can destroy each other.
		/// </summary>
		/// <returns></returns>
		public bool FinalDecision()
		{
			InitialMarkVertexes();
			if ((countMarkedRobots != 1) && (countRobots - countMarkedRobots != 1))
			{
				return true;
			}
			return false;
		}
	}
}