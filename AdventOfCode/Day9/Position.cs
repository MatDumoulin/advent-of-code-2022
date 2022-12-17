namespace Day9;

public record Position(int X, int Y)
{
    public Position Move(Direction direction)
    {
        return new Position(this.X + direction.X, this.Y + direction.Y);
    }

    public bool IsNextTo(Position other)
    {
        return Math.Abs(this.X - other.X) <= 1 && Math.Abs(this.Y - other.Y) <= 1;
    }
    
    public static Direction operator -(Position original, Position other)
    {
        return new Direction(original.X - other.X, original.Y - other.Y);
    }
}
