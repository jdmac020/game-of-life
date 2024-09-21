namespace Life;

public class World
{
	public int Height { get; set; }
	public int Width { get; set; }
	public List<Cell> Cells { get; set; } = [];

	public World()
	{
		Height = 3;
		Width = 3;
		AddCells(Height, Width);
	}

	private void AddCells(int height, int width)
	{
		var rnd = new Random();
		for (var i = 0; i < height * width; i++)
		{
			var seed = rnd.Next(0, 99);
			Cells.Add(new Cell(seed % 6 == 0));
		}
	}
}