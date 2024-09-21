namespace LifeSupport;

public class Coordinate
{
	public int X { get; }
	public int Y { get; }
	
	public Coordinate(int x, int y)
	{
		X = x;
		Y = y;
	}
	
	public List<Coordinate> GetNeighbors()
	{
		return
        [
            new(X - 1, Y), // left
			new(X + 1, Y), // right
			new(X, Y - 1), // down
			new(X, Y + 1), // up
			new(X + 1, Y - 1), // down right
			new(X - 1, Y - 1), // down left
			new(X + 1, Y + 1), // up right
			new(X - 1, Y + 1) // up left
		];
	}
}