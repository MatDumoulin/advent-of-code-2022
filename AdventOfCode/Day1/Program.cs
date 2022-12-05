var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt");
var elvesInventory = new List<int>();
var current = 0;

foreach (var line in input)
{
    if (line == string.Empty)
    {
        elvesInventory.Add(current);
        current = 0;
    }
    else
    {
        current += Int32.Parse(line);
    }
}
        
elvesInventory.Sort((a,b) => b.CompareTo(a));
var maxOfTop3 = elvesInventory.Take(3).Sum();
        
Console.WriteLine($"Answer: {maxOfTop3}");