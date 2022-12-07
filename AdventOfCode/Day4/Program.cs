using Day4;

var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt");

// Parsing all pairs to array of sections
var pairs = input.Select(
    pair => pair.Split(',').Select(
        section => new Section(section)).ToArray())
    .ToArray();

var totalSubsetFound = 0;

foreach (var pair in pairs)
{
    if (pair[0].Contains(pair[1]) || pair[1].Contains(pair[0]))
    {
        ++totalSubsetFound;
    }
}

Console.WriteLine($"Answer 1: {totalSubsetFound}");

//////////////////////////////////////////////

var totalOverlapFound = 0;

foreach (var pair in pairs)
{
    if (pair[0].Overlaps(pair[1]))
    {
        ++totalOverlapFound;
    }
}

Console.WriteLine($"Answer 2: {totalOverlapFound}");