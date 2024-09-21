using Life;
using LifeSupport;
using Moq;
using Shouldly;

namespace LifeTests;

public class BiomeShould
{
	private Mock<IRandomNumbers> _rng = new Mock<IRandomNumbers>();
	[Fact]
	public void HaveNineCells()
	{
		var biome = new Biome(_rng.Object);

		biome.Cells.Count.ShouldBe(9);
	}
	
	[Fact]
	public void HaveNoMoreThanFiveLiveCells()
	{
		// all cells will be live based on RNG
		_rng.Setup(x => x.GetRandomInt()).Returns(new Random().Next(4,4));
		
		var biome = new Biome(_rng.Object);
		
		var result = biome.Cells.Count(c => c.Alive);
		
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
		
		var biome = new Biome(_rng.Object);
		
		var result = biome.Cells.Count(cell => cell.Alive);
		
		result.ShouldBe(2);
	}
	
	[Fact]
	public void HaveFirstCellAtNegative1Negative1()
	{
		var biome = new Biome(_rng.Object);

		biome.Cells.First().Coordinate.X.ShouldBe(-1);
		biome.Cells.First().Coordinate.Y.ShouldBe(-1);
		biome.Cells.Last().Coordinate.X.ShouldBe(1);
		biome.Cells.Last().Coordinate.Y.ShouldBe(1);
	}
	
	[Fact]
	public void UpdateCellStatus()
	{
		var biome = new Biome(_rng.Object);
		var firstRoundCells = biome.Cells.Where(cell => cell.Alive).Count();
		
		biome.DoLifeCycle();
		
		var postUpdateCells = biome.Cells.Where(cell => cell.Alive).Count();
		postUpdateCells.Equals(firstRoundCells).ShouldBeFalse();
	}
}