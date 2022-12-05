namespace Day3;

public class ComparisonHelper
{
    public static char FindMatchingItemInBags(params string[] bags)
    {
        var allUniqueItemsOfBag = bags.Select(x => x.Distinct());
        var itemOccurenceInBags = new Dictionary<char, int>();

        foreach (var uniqueItemOfBag in allUniqueItemsOfBag)
        {
            foreach (var item in uniqueItemOfBag)
            {
                if (itemOccurenceInBags.TryGetValue(item, out var currentCount))
                {
                    var newCount = currentCount + 1;
                    if (newCount == bags.Length)
                    {
                        return item;
                    }
                    
                    itemOccurenceInBags[item] = newCount;
                }
                else
                {
                    itemOccurenceInBags.Add(item, 1);
                }
            }
        }

        throw new Exception("No badges found for team");
    }
}