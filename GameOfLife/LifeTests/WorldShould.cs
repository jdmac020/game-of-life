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
		_rng.Setup(x => x.GetRandomInt()).Returns(new Random().Next(4,4));
		
		var world = new World(_rng.Object, 3, 3);
		
		var result = world.Cells.Count(c => c.Alive);
		
		result.ShouldBe(5);
	}
	
	[Fact]
	public void HaveAtLeastTwoLiveCells()
	{
		// all dead cells based on RNG
		_rng.Setup(x => x.GetRandomInt()).Returns(new Random().Next(1,1));
		_rng.SetupSequence(x => x.GetRandomInt(It.IsAny<int>(), It.IsAny<int>()))
			.Returns(5)
			.Returns(2);
		
		var world = new World(_rng.Object, 3, 3);
		
		var result = world.Cells.Count(cell => cell.Alive);
		
		result.ShouldBe(2);
	}
	
	[Fact]
	public void HaveFirstCellAtNegative1Negative1()
	{
		var world = new World(_rng.Object, 3, 3);

		world.Cells.First().Coordinate.X.ShouldBe(-1);
		world.Cells.First().Coordinate.Y.ShouldBe(-1);
		world.Cells.Last().Coordinate.X.ShouldBe(1);
		world.Cells.Last().Coordinate.Y.ShouldBe(1);
	}
}