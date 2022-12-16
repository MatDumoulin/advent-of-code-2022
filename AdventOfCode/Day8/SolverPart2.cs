namespace Day8;

public class SolverPart2
{
    private readonly HeightMap _map;

    public SolverPart2(HeightMap map)
    {
        _map = map;
    }
    
    public int GetHighestScenicScore()
    {
        var scenicScores = new List<List<int>>();
        
        for (int y = 0; y < this._map.GetRowCount(); y++)
        {
            scenicScores.Add(new List<int>());
            
            for (int x = 0; x < this._map.GetRow(y).Count; x++)
            {
                scenicScores[y].Add(GetScenicScore(new Position(x, y)));
            }
        }

        return scenicScores.SelectMany(x => x).Max();
    }

    private int GetScenicScore(Position origin)
    {
        var directions = new[] { Direction.Left, Direction.Right, Direction.Down, Direction.Top };
        var scenicScores = directions.Select(direction => this.GetScenicScore(origin, direction));
        
        return scenicScores.Aggregate((acc, x) => acc * x);
    }

    private int GetScenicScore(Position origin, Direction direction)
    {
        var originTreeHeight = this._map.GetTree(origin);
        var distanceToEdgeOfMap = this._map.GetDistanceToEdgeOfMap(origin, direction);
        
        for (int distance = 1; distance <= distanceToEdgeOfMap; distance++)
        {
            var positionOfTree = origin.Move(direction, distance);
            var treeHeight = this._map.GetTree(positionOfTree);

            if (treeHeight >= originTreeHeight)
            {
                return distance;
            }
        }

        return distanceToEdgeOfMap;
    }
}