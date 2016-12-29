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

		private Point currentMousePosition;
		private Point lastClickedPointCoordinates;
		private Point startCoordinate;
		private Point redrowingLineEnd;

		private bool ifDrawingLine = false;
		private bool ifLineHasStartCoordinate = false;
		private bool ifRedrawLineHasEnd = false;

		private bool ifAddingLine = true;
		private bool ifMovingLine = false;
		/*private UndoRedo undoredo = new UndoRedo();
		private Point lastClickedPointCoordinates;
		private Point currentMousePosition;
		private bool ifPaintLine = false;
		private bool ifStartCoordinate = false;
		private bool ifManipulationAvailable = false;
		private bool ifRedrawLineHasEnd = false;*/

		public GraphicEditor()
		{
			InitializeComponent();
			CancellationButton.Enabled = false;
			ReturnButton.Enabled = false;
		}

		private void Draw(object sender, PaintEventArgs e)
		{
			RedrawAllLines(e);
			if (ifAddingLine && ifLineHasStartCoordinate)
			{
				e.Graphics.DrawLine(new Pen(Color.Black, 1), startCoordinate, currentMousePosition);
			}
			else if (ifMovingLine && ifLineHasStartCoordinate)
			{
				e.Graphics.DrawLine(new Pen(Color.Black, 1), redrowingLineEnd, currentMousePosition);
			}
		}

		private void MouseMoved(object sender, MouseEventArgs e)
		{
			currentMousePosition.X = e.X;
			currentMousePosition.Y = e.Y;
			if (ifAddingLine)
			{
				if (ifDrawingLine)
				{
					Picture.Invalidate();
				}
			}
			else if (ifMovingLine)
			{
				if (ifRedrawLineHasEnd)
				{
					Picture.Invalidate();
				}
			}
		}

		private void MouseClicked(object sender, MouseEventArgs e)
		{
			lastClickedPointCoordinates.X = e.X;
			lastClickedPointCoordinates.Y = e.Y;
			if (ifAddingLine)
			{
				if (ifLineHasStartCoordinate)
				{
					lines.Add(new Line(lastClickedPointCoordinates, startCoordinate));
					undoredo.AddCommand(new ConcreteCommand(lines[lines.Count - 1], "Add"));
					CheckUndoRedo();
					ifLineHasStartCoordinate = false;
				}
				else
				{
					startCoordinate = currentMousePosition;
					ifLineHasStartCoordinate = true;
					ifDrawingLine = true;
				}
			}
			else if (ifMovingLine && !ifRedrawLineHasEnd)
			{
				RedrawLine(lastClickedPointCoordinates);
			}
			else if (ifMovingLine && ifRedrawLineHasEnd)
			{
				ifAddingLine = true;
				ifMovingLine = false;
				ifRedrawLineHasEnd = false;
				ifLineHasStartCoordinate = false;
				lines.Add(new Line(redrowingLineEnd, lastClickedPointCoordinates));
				undoredo.AddCommand(new ConcreteCommand(lines[lines.Count - 1], "Add"));
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
				undoredo.AddCommand(new ConcreteCommand(temp, "Remove"));
				CheckUndoRedo();
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

		private void DeleteButtonClick(object sender, EventArgs e)
		{
			if (lines.Count != 0)
			{
				undoredo.AddCommand(new ConcreteCommand(lines[lines.Count - 1], "Remove"));
				CheckUndoRedo();
				lines.RemoveAt(lines.Count - 1);
			}
			Picture.Invalidate();
		}

		private void RelocateButtonClick(object sender, EventArgs e)
		{
			ifMovingLine = true;
			ifAddingLine = false;
			ifLineHasStartCoordinate = true;
		}

		private void CancellationButtonClick(object sender, EventArgs e)
		{
			undoredo.Undo(lines);
			CheckUndoRedo();
			Picture.Invalidate();
		}

		private void ReturnButtonClick(object sender, EventArgs e)
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