// See https://aka.ms/new-console-template for more information

using Day9;

var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt");
var parsedInput = input.Select(InputParser.Parse).ToList();

var rope = new Rope(new Position(0, 0));
var visitedPositionsOfTail = new HashSet<Position>();

foreach (var (direction, distance) in parsedInput)
{
    var visited = rope.MoveHead(direction, distance);
    visitedPositionsOfTail.UnionWith(visited);
}

Console.WriteLine($"Day 9.1: {visitedPositionsOfTail.Count}");


//////////////////////////////////////
var longerRope = new LongerRope(new Position(0, 0), 10);
visitedPositionsOfTail = new HashSet<Position>();

foreach (var (direction, distance) in parsedInput)
{
    var visited = longerRope.MoveHead(direction, distance);
    visitedPositionsOfTail.UnionWith(visited);
}

Console.WriteLine($"Day 9.2: {visitedPositionsOfTail.Count}");