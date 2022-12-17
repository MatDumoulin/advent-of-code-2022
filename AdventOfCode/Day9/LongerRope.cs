namespace Day9;

public class LongerRope
{
    private List<Position> _knots;

    public LongerRope(Position start, int length)
    {
        _knots = Enumerable
            .Range(0, length)
            .Select(_ => start with {}) // Cloning start using copy constructor
            .ToList();
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
            this._knots[0] = this._knots[0].Move(direction);
            for (int knotIndex = 1; knotIndex < this._knots.Count; knotIndex++)
            {
                this._knots[knotIndex] = FollowKnot(
                    leader: this._knots[knotIndex - 1], 
                    follower: this._knots[knotIndex]);
            }
            
            visitedPositionsOfTail.Add(this._knots.Last());
        }

        return visitedPositionsOfTail;
    }

    private Position FollowKnot(Position leader, Position follower)
    {
        if (!leader.IsNextTo(follower))
        {
            return follower.Move((leader - follower).ToUnit());
        }

        return follower;
    }
}