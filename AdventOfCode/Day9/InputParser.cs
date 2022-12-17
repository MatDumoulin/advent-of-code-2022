namespace Day9;

public class InputParser
{
    public static (Direction Direction, int Distance) Parse(string line)
    {
        var split = line.Split(' ');

        var direction = split[0] switch
        {
            "U" => Direction.Up,
            "D" => Direction.Down,
            "L" => Direction.Left,
            "R" => Direction.Right,
            _ => throw new Exception($"Couldn't parse input {line}")
        };

        var distance = int.Parse(split[1]);

        return (direction, distance);
    }
}