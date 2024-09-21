using LifeSupport;

namespace Life;

public class Biome
{
	public List<Cell> Cells { get; set; } = [];
	private readonly IRandomNumbers _rng;
	private const int TotalCells = 9;

	public Biome(IRandomNumbers rng)
	{
		_rng = rng;
		LetThereBeLight();
	}

	public void LetThereBeLight()
	{
		var liveCells = 0;
		var xCoord = -1;
		var yCoord = -1;
		var xCycle = 0;
		
		// intial seeding...
		for (var i = 0; i < TotalCells; i++)
		{
			xCycle++;
			// first cell -1,-1
			var isAlive = _rng.GetRandomInt() % 4 == 0 && liveCells < 5;
			Cells.Add(new Cell(isAlive, xCoord, yCoord));
			liveCells = Cells.Count(cell => cell.Alive);
			
			if (xCycle % 3 == 0)
			{
				xCoord++;
				yCoord = -1;
			}
			else 
			{
				yCoord ++;
			}
		}
		
		// ensure at least 2 are alive
		while (liveCells < 2)
		{
			var cell = _rng.GetRandomInt(0, Cells.Count - 1);
			Cells[cell].Alive = true;
			
			liveCells = Cells.Count(cell => cell.Alive);
		}
	}

	// I don't think this is going to work out long term -- if each 3x3 biome
	// updates independently of each other, we'll never actually see the whole
	// world working together and just see the same "frozen" states across the
	// world of multiple biomes
	public void DoLifeCycle()
	{
		foreach (var cell in Cells)
		{
			cell.DoSurvive(Cells);
		}
	}
}