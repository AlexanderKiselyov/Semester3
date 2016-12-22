using System;
using System.Windows.Forms;
using System.Drawing;

namespace GraphicEditor
{
	/// <summary>
	/// Represents a line with coordinates on the picture box.
	/// </summary>
	public class Line
	{
		/// <summary>
		/// Initial point of the line.
		/// </summary>
		public Point StartPosition { get; set; }

		/// <summary>
		/// Ending point of the line.
		/// </summary>
		public Point EndPosition { get; set; }

		/// <summary>
		/// Constructs a line by 2 given points.
		/// </summary>
		/// <param name="startPos">
		/// Beginning point of the line.
		/// </param>
		/// <param name="endPos">
		/// Ending point of the line.
		/// </param>
		public Line(Point startPos, Point endPos)
		{
			StartPosition = startPos;
			EndPosition = endPos;
		}

		/// <summary>
		/// Draws a line on picture box.
		/// </summary>
		/// <param name="e">
		/// Represents paint arguments.
		/// </param>
		public void Draw(PaintEventArgs e)
		{
			e.Graphics.DrawLine(new Pen(Color.Black, 1), StartPosition, EndPosition);
		}

		/// <summary>
		/// Get distance between two coordinates.
		/// </summary>
		/// <param name="first">
		/// First point with coordinates.
		/// </param>
		/// <param name="second">
		/// Second point with coordinates.
		/// </param>
		/// <returns></returns>
		public double Distance(Point first, Point second)
		{
			return Math.Sqrt((first.X - second.X) * (first.X - second.X) + (first.Y - second.Y) * (first.Y - second.Y));
		}
	}
}
