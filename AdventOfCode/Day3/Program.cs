using Day3;

var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt");

var sumOfPriorities = 0;

foreach (var line in input)
{
    var firstBag = line.Substring(0, line.Length / 2);
    var secondBag = line.Substring(line.Length / 2);
    var allCharsInFirstBag = new HashSet<char>(firstBag);
    var matchingItem = secondBag.First(x => allCharsInFirstBag.Contains(x));

    sumOfPriorities += PriorityHelper.GetPriority(matchingItem);
}

Console.WriteLine($"Answer 1: {sumOfPriorities}");

//////////////////////////////////////////////

sumOfPriorities = 0;

for (int i = 0; i < input.Length; i += 3)
{
    var team = input.Skip(i).Take(3).ToArray();
    var matchingItem = ComparisonHelper.FindMatchingItemInBags(team);
    sumOfPriorities += PriorityHelper.GetPriority(matchingItem);
}

Console.WriteLine($"Answer 2: {sumOfPriorities}");