namespace Day10.Commands;

public class CommandParser
{
    public static CommandBase Parse(string line)
    {
        if (line == "noop")
        {
            return new NoopCommand();
        }
        
        if (line.StartsWith("addx"))
        {
            var split = line.Split(" ");
            return new AddXCommand(int.Parse(split[1]));
        }

        throw new Exception($"Invalid command received. Cannot parse: {line}");
    }
}