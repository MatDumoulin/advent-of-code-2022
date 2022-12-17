namespace Day9;

public class Rope
{
    private Position _head;
    private Position _tail;

    public Rope(Position start)
    {
        // Cloning start using copy constructor
        _head = start with {};
        _tail = start with {};
    }

    public HashSet<Position> MoveHead(Direction direction, int distance)
    {
        var visitedPositionsOfTail = new HashSet<Position>();
        
        if (distance == 0)
        {
            return visitedPositionsOfTail;
        }

        // Looking at input, distances are only positive numbers
        for (int i = 0; i < distance; i++)
        {
            _head = _head.Move(direction);
            TailFollowsHead(direction);
            visitedPositionsOfTail.Add(_tail);
        }

        return visitedPositionsOfTail;
    }

    private void TailFollowsHead(Direction direction)
    {
        if (!_head.IsNextTo(_tail))
        {
            // The tail always move to the last position of the head when they are appart.
            _tail = _head.Move(direction * -1);
        }
    }
}