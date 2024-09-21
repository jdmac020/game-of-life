using LifeSupport;

namespace Life;

public class World
{
	public int Height { get; set; }
	public int Width { get; set; }
	public List<Biome> Biomes { get; set; } = [];
	private readonly IRandomNumbers _rng;

	public World(IRandomNumbers rng, int height, int width)
	{
		Height = height;
		Width = width;
		_rng = rng;
		
		for (int i = 0; i < height * width / 9; i++)
		{
			Biomes.Add(new Biome(_rng));
		}
	}
	
	public void Update()
	{
		foreach (var biome in Biomes)
			{
			biome.DoLifeCycle();
		}
	}
}