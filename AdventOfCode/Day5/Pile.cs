namespace Day5;

public class Pile
{
    private Stack<char> _inner;

    public Pile()
    {
        _inner = new();
    }

    public void Add(params char[] packages)
    {
        foreach (var x in packages)
        {
            this._inner.Push(x);
        }
    }

    // Going very dirty. The remove functions should be part of a Crane class if we wanted to make it cleaner
    public char[] RemoveWithOldCrane(int quantity)
    {
        var removed = new List<char>();

        for (int i = 0; i < quantity; i++)
        {
            removed.Add(this._inner.Pop());
        }

        return removed.ToArray();
    }
    
    public char[] RemoveWithNewCrane(int quantity)
    {
        var removed = new List<char>();

        for (int i = 0; i < quantity; i++)
        {
            removed.Add(this._inner.Pop());
        }

        removed.Reverse();

        return removed.ToArray();
    }

    public char Peek()
    {
        return this._inner.Peek();
    }
}