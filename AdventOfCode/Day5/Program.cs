// See https://aka.ms/new-console-template for more information

using Day5;

var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt");

var (piles, actions) = InputParser.Parse(input);

foreach (var action in actions)
{
    var removed = piles[action.From - 1].RemoveWithOldCrane(action.Quantity);
    piles[action.To-1].Add(removed);
}

Console.WriteLine("Day 5.1:");
foreach (var pile in piles)
{
    Console.Write(pile.Peek());
}

/////////////////////////////////////

(piles, actions) = InputParser.Parse(input);

foreach (var action in actions)
{
    var removed = piles[action.From - 1].RemoveWithNewCrane(action.Quantity);
    piles[action.To-1].Add(removed);
}

Console.WriteLine("");
Console.WriteLine("Day 5.2:");
foreach (var pile in piles)
{
    Console.Write(pile.Peek());
}
