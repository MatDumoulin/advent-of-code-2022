namespace Day8;

// Using dynamic programming to solve the second part of the challenge
public class SolverPart2Dynamic
{
    private readonly HeightMap _map;

    public SolverPart2Dynamic(HeightMap map)
    {
        _map = map;
    }

    public int GetHighestScenicScore()
    {
        var scenicScores = new List<List<ScenicScore>>();

        this.ComputeLeftUp(scenicScores);
        this.FillInRightDown(scenicScores);

        return scenicScores.SelectMany(x => x.Select(y => y.GetTotal())).Max();
    }

    private ScenicScore GetScenicScore(List<List<ScenicScore>> allScenicScores, Position pos)
    {
        if (pos.X < 0 || pos.Y < 0 || pos.Y >= this._map.GetRowCount() || pos.X >= this._map.GetRow(pos.Y).Count)
        {
            return new ScenicScore { Left = -1, Right = -1, Up = -1, Down = -1 };
        }

        return allScenicScores[pos.Y][pos.X];
    }
    
    private void ComputeLeftUp(List<List<ScenicScore>> allScenicScores)
    {
        for (int y = 0; y < this._map.GetRowCount(); y++)
        {
            allScenicScores.Add(new List<ScenicScore>());

            for (int x = 0; x < this._map.GetRow(y).Count; x++)
            {
                var origin = new Position(x, y);
                var originTreeHeight = this._map.GetTree(origin);
                var leftPosition = origin.Move(Direction.Left, 1);
                var upPosition = origin.Move(Direction.Top, 1);
                this._map.TryGetTree(leftPosition, out var leftNeighborHeight);
                this._map.TryGetTree(upPosition, out var upNeighborHeight);

                var scenicScore = new ScenicScore
                {
                    Left = leftNeighborHeight < originTreeHeight
                        ? this.GetScenicScore(allScenicScores, leftPosition).Left + 1
                        : 1,
                    Up = upNeighborHeight < originTreeHeight
                        ? this.GetScenicScore(allScenicScores, upPosition).Up + 1
                        : 1
                };

                allScenicScores[y].Add(scenicScore);
            }
        }
    }

    private void FillInRightDown(List<List<ScenicScore>> allScenicScores)
    {
        for (int y = this._map.GetRowCount() - 1; y >= 0 ; y--)
        {
            for (int x = this._map.GetRow(y).Count - 1; x >= 0; x--)
            {
                var origin = new Position(x, y);
                var originTreeHeight = this._map.GetTree(origin);
                var rightPosition = origin.Move(Direction.Right, 1);
                var downPosition = origin.Move(Direction.Down, 1);
                this._map.TryGetTree(rightPosition, out var rightNeighborHeight);
                this._map.TryGetTree(downPosition, out var downNeighborHeight);

                allScenicScores[y][x].Right = rightNeighborHeight < originTreeHeight
                    ? this.GetScenicScore(allScenicScores, rightPosition).Right + 1
                    : 1;

                allScenicScores[y][x].Down = downNeighborHeight < originTreeHeight
                    ? this.GetScenicScore(allScenicScores, downPosition).Down + 1
                    : 1;
            }
        }
    }
}

public class ScenicScore
{
    public int Left { get; set; }

    public int Right { get; set; }

    public int Up { get; set; }

    public int Down { get; set; }

    public int GetTotal()
    {
        return Left * Right * Up * Down;
    }
}