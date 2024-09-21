using LifeSupport;

namespace Life;

public class Cell(bool isAlive, int x, int y)
{
    public bool Alive { get; set; } = isAlive;
    public Coordinate Coordinate { get; set; } = new Coordinate(x, y);
}
