using LifeSupport;
using Moq;
using Shouldly;

namespace LifeSupportTests;

public class CoordinateShould
{
	[Fact]
	public void BeThreeByThree()
	{
		var expectedNeighbors = new List<Coordinate>
		{
			new (-1,0), // 1 left
			new (1,0), // 1 right
			new (0,-1), // 1 down
			new (0, 1), // 1 up
			new (1,-1), // 1 right and down
			new (-1,-1), // 1 left and down
			new (1, 1), // 1 right and up
			new (-1,1), // 1 left and up
		};
		var coordinate = new Coordinate(0, 0);
		
		var result = coordinate.GetNeighbors();
		
		result.ShouldBeEquivalentTo(expectedNeighbors);
	}
}