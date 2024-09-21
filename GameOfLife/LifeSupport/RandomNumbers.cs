namespace LifeSupport;

public interface IRandomNumbers
{
	int GetRandomInt();
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
}
