// See https://aka.ms/new-console-template for more information
using Life;
using LifeSupport;

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("In the beginning there was...a World:");
Console.WriteLine();

const int worldWidth = 3;
const int worldHeight = 3;
const int rngFloor = 6;
const int rngCeiling = 66;

var rng = new RandomNumbers(rngFloor, rngCeiling);
var world = new World(rng, worldHeight, worldWidth);
Console.Write(" ");

for (var i = 0; i < worldWidth; i++)
{
	Console.Write("-");
}

Console.WriteLine();
Console.Write("|");

foreach (var biome in world.Biomes)
{
	for (var i = 0; i < biome.Cells.Count; i++)
	{
		if (i != 0 && i % worldWidth == 0)
		{
			Console.WriteLine("|");
			Console.Write("|");
		}
		var display = biome.Cells[i].Alive ? "o" : "x";
		Console.Write(display);
	}	
}

Console.Write("|");
Console.WriteLine();
Console.Write(" ");

for (var i = 0; i < worldWidth; i++)
{
	Console.Write("-");
}

Console.WriteLine();
Console.WriteLine();