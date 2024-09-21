using Life;
using Shouldly;

namespace LifeTests;

public class CellShould
{
	// I kinda hate these tests but I can't write any in my day job so
	[Fact]
	public void BeAlive()
	{
		
		var cell = new Cell(true, 0, 3);

		cell.Alive.ShouldBe(true);
		cell.Coordinate.X.ShouldBe(0);
		cell.Coordinate.Y.ShouldBe(3);
	}
	
	[Fact]
	public void BeDead()
	{
		var cell = new Cell(false, 2, 0);

		cell.Alive.ShouldBe(false);
		cell.Coordinate.X.ShouldBe(2);
		cell.Coordinate.Y.ShouldBe(0);
	}
}