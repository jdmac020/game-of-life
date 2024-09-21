// See https://aka.ms/new-console-template for more information
using Life;

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("It is...a World:");
Console.WriteLine();

const int worldWidth = 3;

var world = new World();

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