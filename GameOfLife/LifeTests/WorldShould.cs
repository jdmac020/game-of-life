using Life;
using Shouldly;

namespace LifeTests;

public class WorldShould
{
    [Fact]
    public void BeThreeByThree()
    {
      var world = new World();

      world.Height.ShouldBe(3);
      world.Width.ShouldBe(3);
    }

    [Fact]
    public void HaveNineCells()
    {
        var world = new World();

        world.Cells.Count.ShouldBe(9);
    }
}