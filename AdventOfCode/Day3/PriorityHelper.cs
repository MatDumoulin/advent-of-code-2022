namespace Day3;

public class PriorityHelper
{
    public static int GetPriority(char item)
    {
        if (char.IsLower(item))
        {
            return item - 'a' + 1;
        }

        return item - 'A' + 27;
    }
}