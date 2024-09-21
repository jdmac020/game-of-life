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
Console.WriteLine($"Cell1: {world.Cells.First().Coordinate.X},{world.Cells.First().Coordinate.Y}");
Console.WriteLine($"Cell9: {world.Cells.Last().Coordinate.X},{world.Cells.Last().Coordinate.Y}");
Console.Write(" ");

for (var i = 0; i < worldWidth; i++)
{
	Console.Write("-");
}

Console.WriteLine();
Console.Write("|");

for (var i = 0; i < world.Cells.Count; i++)
{
	if (i != 0 && i % worldWidth == 0)
	{
		Console.WriteLine("|");
		Console.Write("|");
	}
	var display = world.Cells[i].Alive ? "o" : "x";
	Console.Write(display);
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