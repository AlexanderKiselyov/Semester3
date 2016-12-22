using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicEditor
{
	/// <summary>
	/// Reperesents a simple graphic editor that can draw lines, delete them, change their location.
	/// </summary>
	public partial class GraphicEditor : Form
	{
		private UndoRedo undoredo = new UndoRedo();
		private List<Line> lines = new List<Line>();
		private Point redrowingLineEnd;
		private Point lastClickedPointCoordinates;
		private Point currentMousePosition;
		private bool ifPaintLine = false;
		private bool ifStartCoordinate = false;
		private bool ifManipulationAvailable = false;
		private bool ifRedrawLineHasEnd = false;

		public GraphicEditor()
		{
			InitializeComponent();
			CancellationButton.Enabled = false;
			ReturnButton.Enabled = false;
		}

		private void Draw(object sender, PaintEventArgs e)
		{
			RedrawAllLines(e);
			if (ifPaintLine && ifStartCoordinate)
			{
				e.Graphics.DrawLine(new Pen(Color.Black, 1), lastClickedPointCoordinates, currentMousePosition);
			}
			else if (ifManipulationAvailable && ifRedrawLineHasEnd)
			{
				e.Graphics.DrawLine(new Pen(Color.Black, 1), redrowingLineEnd, currentMousePosition);
			}
		}

		private void MoveMouse(object sender, MouseEventArgs e)
		{
			currentMousePosition.X = e.X;
			currentMousePosition.Y = e.Y;
			if (ifPaintLine && ifStartCoordinate || (ifManipulationAvailable && ifRedrawLineHasEnd))
			{
				Picture.Invalidate();
			}
		}

		private void Mouse_Click(object sender, MouseEventArgs e)
		{
			var beforeClic = lastClickedPointCoordinates;
			lastClickedPointCoordinates.X = e.X;
			lastClickedPointCoordinates.Y = e.Y;
			if (ifPaintLine && ifStartCoordinate)
			{
				lines.Add(new Line(beforeClic, lastClickedPointCoordinates));
				undoredo.AddCommand(new ConcreteCommand(lines[lines.Count - 1], "Add"), true);
				CheckUndoRedo();
				ifPaintLine = false;
				ifStartCoordinate = false;
			}
			else if (!ifPaintLine && !ifStartCoordinate)
			{
				ifPaintLine = true;
				ifStartCoordinate = true;
			}
			else if (ifManipulationAvailable && !ifRedrawLineHasEnd)
			{
				RedrawLine(lastClickedPointCoordinates);
			}
			else if (ifManipulationAvailable && ifRedrawLineHasEnd)
			{
				ifManipulationAvailable = false;
				ifRedrawLineHasEnd = false;
				ifStartCoordinate = false;
				lines.Add(new Line(redrowingLineEnd, lastClickedPointCoordinates));
				undoredo.AddCommand(new ConcreteCommand(lines[lines.Count - 1], "Add"), true);
				CheckUndoRedo();
			}
		}

		private void RedrawLine(Point lastClick)
		{
			var temp = new Line(lastClick, lastClick);
			foreach (var line in lines)
			{
				if (line.Distance(line.StartPosition, lastClick) <= 10)
				{
					redrowingLineEnd = line.EndPosition;
					temp = line;
				}
				else if (line.Distance(line.EndPosition, lastClick) <= 10)
				{
					redrowingLineEnd = line.StartPosition;
					temp = line;
				}
			}

			if (!redrowingLineEnd.IsEmpty)
			{
				undoredo.AddCommand(new ConcreteCommand(temp, "Remove"), true);
				lines.Remove(temp);
				ifRedrawLineHasEnd = true;
			}
		}

		private void RedrawAllLines(PaintEventArgs e)
		{
			foreach (var line in lines)
			{
				line.Draw(e);
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (lines.Count != 0)
			{
				undoredo.AddCommand(new ConcreteCommand(lines[lines.Count - 1], "Remove"), true);
				CheckUndoRedo();
				lines.RemoveAt(lines.Count - 1);
			}
			Picture.Invalidate();
		}

		private void RelocateButton_Click(object sender, EventArgs e)
		{
			ifManipulationAvailable = true;
			ifPaintLine = false;
			ifStartCoordinate = true;
		}

		private void CancellationButton_Click(object sender, EventArgs e)
		{
			undoredo.Undo(lines);
			CheckUndoRedo();
			Picture.Invalidate();
		}

		private void ReturnButton_Click(object sender, EventArgs e)
		{
			undoredo.Redo(lines);
			CheckUndoRedo();
			Picture.Invalidate();
		}

		private void CheckUndoRedo()
		{
			CancellationButton.Enabled = !undoredo.UndoStackIsEmpty();
			ReturnButton.Enabled = !undoredo.RedoStackIsEmpty();
		}
	}
}