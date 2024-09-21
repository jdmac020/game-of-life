using LifeSupport;

namespace Life;

public class World
{
	public int Height { get; set; }
	public int Width { get; set; }
	public List<Cell> Cells { get; set; } = [];
	private readonly IRandomNumbers _rng;

	public World(IRandomNumbers rng, int height, int width)
	{
		Height = height;
		Width = width;
		_rng = rng;
		
		AddCells(Height, Width);
	}

	private void AddCells(int height, int width)
	{
		for (var i = 0; i < height * width; i++)
		{
			var liveCells = Cells.Count(cell => cell.Alive);
			var isAlive = _rng.GetRandomInt() % 6 == 0 && liveCells < 5;
			Cells.Add(new Cell(isAlive));
		}
	}
}