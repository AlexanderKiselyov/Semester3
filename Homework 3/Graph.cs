namespace Homework_3
{
	public class Graph
	{
		private int numberOfVertices;
		private bool[,] graph;
		
		/// <summary>
		/// Graph that represents an adjacency matrix with robots in some verteces.
		/// </summary>
		/// <param name="matrix">
		/// Adjecency matrix.
		/// </param>
		/// <param name="countVerteces">
		/// Number of vertices in graph.
		/// </param>
		public Graph(bool[,] matrix, int countVerteces)
		{
			graph = matrix;
			numberOfVertices = countVerteces;
		}

		/// <summary>
		/// Checks if there is a way between two verteces.
		/// </summary>
		public bool IfHasWay(int i, int j)
		{
			return graph[i, j];
		}

		/// <summary>
		/// Returns number of verteces.
		/// </summary>
		public int Number()
		{
			return numberOfVertices;
		}
	}
}
