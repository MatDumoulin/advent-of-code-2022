namespace Day5;

public class InputParser
{
    private static readonly int[] IndexOfPackages =
    {
        1,
        5,
        9,
        13,
        17,
        21,
        25,
        29,
        33
    };

    public static ParsedInput Parse(IReadOnlyCollection<string> lines)
    {
        var stacksInput = lines.TakeWhile(x => x != string.Empty).ToArray();
        var actionsInput = lines.Skip(stacksInput.Length + 1).ToArray();

        var stacks = ParsePiles(stacksInput);
        var actions = ParseActions(actionsInput);

        return new ParsedInput(stacks, actions);
    }

    private static List<Pile> ParsePiles(string[] stacksInput)
    {
        var piles = Enumerable.Range(0, IndexOfPackages.Length).Select(x => new Pile()).ToList();

        // Skipping row with only column number as it's not important.
        for (int i = stacksInput.Length - 2; i >= 0; i--)
        {
            for (var x = 0; x < IndexOfPackages.Length; ++x)
            {
                var package = stacksInput[i][IndexOfPackages[x]];
                if (package != ' ')
                {
                    piles[x].Add(package);
                }
            }
        }

        return piles;
    }

    private static List<Action> ParseActions(string[] actionsInput)
    {
        return actionsInput.Select(input =>
            {
                var splitted = input.Split(' ');
                var quantity = Int32.Parse(splitted[1]);
                var from = Int32.Parse(splitted[3]);
                var to = Int32.Parse(splitted[5]);

                return new Action(quantity, from, to);
            })
            .ToList();
    }
}

public record ParsedInput(List<Pile> Piles, List<Action> Actions);