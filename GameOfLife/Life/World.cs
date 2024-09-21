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
		var liveCells = 0;
		
		// intial seeding...
		for (var i = 0; i < height * width; i++)
		{
			var isAlive = _rng.GetRandomInt() % 6 == 0 && liveCells < 5;
			Cells.Add(new Cell(isAlive));
			liveCells = Cells.Count(cell => cell.Alive);
		}
		
		// ensure at least 2 are alive
		while (liveCells < 2)
		{
			// get random number 0-8
			var cell = _rng.GetRandomInt(0, Cells.Count - 1);
			Cells[cell].Alive = true;
			
			liveCells = Cells.Count(cell => cell.Alive);
		}
	}
}