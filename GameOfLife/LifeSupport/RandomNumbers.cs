namespace LifeSupport;

public interface IRandomNumbers
{
	int GetRandomInt();
	int GetRandomInt(int floor, int ceiling);
}

public class RandomNumbers : IRandomNumbers
{
	private readonly Random _rng;
	private int _floor;
	private int _ceiling;
	
	public RandomNumbers(int floor, int ceiling)
	{
		_floor = floor;
		_ceiling = ceiling;
		_rng = new Random();
	}
	
	public int GetRandomInt()
	{
		return _rng.Next(_floor, _ceiling);
	}
	
	public int GetRandomInt(int floor, int ceiling)
	{
		return _rng.Next(floor, ceiling);
	}
}
