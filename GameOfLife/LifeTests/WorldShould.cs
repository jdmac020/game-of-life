using Life;
using LifeSupport;
using Moq;
using Shouldly;

namespace LifeTests;

public class WorldShould
{
	private Mock<IRandomNumbers> _rng = new Mock<IRandomNumbers>();
	[Fact]
	public void BeThreeByThree()
	{
	  	var world = new World(_rng.Object, 3, 3);

		world.Height.ShouldBe(3);
	  	world.Width.ShouldBe(3);
	}

	[Fact]
	public void HaveNineCells()
	{
		var world = new World(_rng.Object, 3, 3);

		world.Cells.Count.ShouldBe(9);
	}
	
	[Fact]
	public void HaveNoMoreThanFiveLiveCells()
	{
		// all cells will be live based on RNG
		_rng.Setup(x => x.GetRandomInt()).Returns(new Random().Next(6,6));
		
		var world = new World(_rng.Object, 3, 3);
		
		var result = world.Cells.Count(c => c.Alive);
		
		result.ShouldBe(5);
	}
}