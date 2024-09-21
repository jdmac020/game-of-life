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
		world.Biomes.Count.ShouldBe(1);
	}
}