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
	
	[Fact]
	public void SurviveWithTwoAliveNeighbors()
	{
		var biomeCells = new List<Cell>
		{
			new (true, -1,-1),
			new (false, -1,0),
			new (false, -1,1),
			new (true, 1,1),
			new (false,1,0),
			new (false,1,-1),
			new (false,0,-1),
			new (false,0,1)
		};
		var subject = new Cell(true, 0,0);
		
		subject.DoSurvive(biomeCells);
		
		subject.Alive.ShouldBe(true);
	}
}