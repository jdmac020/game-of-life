using LifeSupport;

namespace Life;

public class Cell(bool isAlive, int x, int y)
{
	public bool Alive { get; set; } = isAlive;
	public Coordinate Coordinate { get; set; } = new Coordinate(x, y);

	public void DoSurvive(List<Cell> biomeCells)
	{
		var liveNeighbors = new List<Cell>();
		var neighbors = Coordinate.GetNeighbors();
		foreach (var coord in neighbors)
		{
			var neighborCell = biomeCells.FirstOrDefault(x => x.Coordinate.Equals(coord));
			if (neighborCell is not null && neighborCell.Alive)
			{
				liveNeighbors.Add(neighborCell);
			}
		}
		
		if (Alive)
		{
			if (liveNeighbors.Count == 2 || liveNeighbors.Count == 3)
			{
				Alive = true;
			}
			else
			{
				Alive = false;
			}
		}
		else
		{
			if (liveNeighbors.Count == 3)
			{
				Alive = true;
			}
		}
		
	}
}
