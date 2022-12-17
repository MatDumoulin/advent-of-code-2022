namespace Day9;

public record Direction(int X, int Y)
{
    public static readonly Direction Left = new (-1, 0);
    public static readonly Direction Right = new (1, 0);
    public static readonly Direction Up = new (0, -1);
    public static readonly Direction Down = new (0, 1);
    
    public static Direction operator *(Direction original, int distance)
    {
        return new Direction(original.X * distance, original.Y * distance);
    }

    public Direction ToUnit()
    {
        // Math.Max --> Prevents division by 0
        // Math.Abs --> Keep sign of original value while dividing
        var xDividend = Math.Max(Math.Abs(this.X), 1);
        var yDividend = Math.Max(Math.Abs(this.Y), 1);
        return new Direction(this.X / xDividend, this.Y / yDividend);
    }
}