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
		for (var i = 0; i < height * width; i++)
		{
			Cells.Add(new Cell(true));
		}
	}
}