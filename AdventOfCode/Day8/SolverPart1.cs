namespace Day8;

public class SolverPart1
{
    private readonly HeightMap _map;

    public SolverPart1(HeightMap map)
    {
        _map = map;
    }
    
    public int CountVisibleTrees()
    {
        var visibleTreeCount = 0;
        
        for (int y = 0; y < this._map.GetRowCount(); y++)
        {
            for (int x = 0; x < this._map.GetRow(y).Count; x++)
            {
                if (IsTreeVisible(new Position(x, y)))
                {
                    visibleTreeCount++;
                }
            }
        }

        return visibleTreeCount;
    }

    private bool IsTreeVisible(Position origin)
    {
        if (origin.X == 0 || origin.X == _map.GetRow(origin.Y).Count - 1 || origin.Y == 0 || origin.Y == _map.GetRowCount() - 1)
        {
            return true;
        }
        
        var directions = new[] { Direction.Left, Direction.Right, Direction.Down, Direction.Top };

        return directions.Any(direction => this.IsVisibleFrom(origin, direction));
    }

    private bool IsVisibleFrom(Position origin, Direction direction)
    {
        var originTreeHeight = this._map.GetTree(origin);
        var allTreeHeightsToConsider = new List<int>();
        for (int distance = 1; distance <= this._map.GetDistanceToEdgeOfMap(origin, direction); distance++)
        {
            var positionOfTree = origin.Move(direction, distance);
            var treeHeight = this._map.GetTree(positionOfTree);
            allTreeHeightsToConsider.Add(treeHeight);
        }

        return allTreeHeightsToConsider.Max() < originTreeHeight;
    }
}