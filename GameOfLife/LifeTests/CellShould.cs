using Life;
using Shouldly;

namespace LifeTests;

public class CellShould
{
	[Fact]
	public void BeAlive()
	{
		var cell = new Cell(true);

		cell.Alive.ShouldBe(true);
	}
	
	[Fact]
    public void BeDead()
    {
    	var cell = new Cell(false);

    	cell.Alive.ShouldBe(false);
    }
}