namespace Day8;

public class HeightMap
{
    private readonly List<List<int>> _map;

    public HeightMap(string[] input)
    {
        _map = this.ParseInput(input);
    }

    public List<int> GetRow(int y)
    {
        return _map[y];
    }
    
    public int GetTree(Position pos)
    {
        return _map[pos.Y][pos.X];
    }

    public int GetRowCount()
    {
        return this._map.Count;
    }
    
    public int GetDistanceToEdgeOfMap(Position from, Direction direction)
    {
        if (direction.X > 0)
        {
            return _map[from.Y].Count - from.X - 1;
        }

        if (direction.X < 0)
        {
            return from.X;
        }

        if (direction.Y > 0)
        {
            return _map.Count - from.Y - 1;
        }

        return from.Y; // direction.Y < 0
    }

    private List<List<int>> ParseInput(string[] input)
    {
        var map = new List<List<int>>();

        foreach (var line in input)
        {
            map.Add(new List<int>());

            foreach (var tree in line)
            {
                map.Last().Add(int.Parse(tree.ToString()));
            }
        }

        return map;
    }
}

public record Position(int X, int Y)
{
    public Position Move(Direction dir, int distance)
    {
        var vector = dir * distance;
        return new Position(this.X + vector.X, this.Y + vector.Y);
    }
}

public record Direction(int X, int Y)
{
    public static readonly Direction Left = new (-1, 0);
    public static readonly Direction Right = new (1, 0);
    public static readonly Direction Top = new (0, -1);
    public static readonly Direction Down = new (0, 1);
    
    public static Direction operator *(Direction original, int distance)
    {
        return new Direction(original.X * distance, original.Y * distance);
    }
}