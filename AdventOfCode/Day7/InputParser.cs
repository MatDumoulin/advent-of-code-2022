namespace Day7;

public class InputParser
{
    private const string ChangeDirectoryCommand = "$ cd ";
    private const string ListDirectoryCommand = "$ ls";
    private const string DirectoryInfoOutput = "dir ";
    private const string MoveOutOneLevel = "..";
    
    public static Dictionary<string, long> BuildFolderSizes(string[] input)
    {
        var location = new List<string>();
        var directories = new Dictionary<string, long>();

        foreach (var line in input)
        {
            if (line == ListDirectoryCommand)
            {
                continue; // Do nothing
            }
            
            if (TryParseLine(line, ChangeDirectoryCommand, out var locationName))
            {
                if (locationName == MoveOutOneLevel)
                {
                    location.RemoveAt(location.Count - 1);
                }
                else
                {
                    location.Add(locationName);
                    directories.TryAdd(BuildPath(location), 0);
                }
            }
            else if (TryParseLine(line, DirectoryInfoOutput, out var directoryName))
            {
                var path = BuildPath(location.Append(directoryName).ToList());
                directories.TryAdd(path, 0);
            }
            else
            {
                // It's a file
                var file = ParseFile(line);
                for (int i = 1; i <= location.Count; i++)
                {
                    var path = BuildPath(location.Take(i).ToList());
                    if (directories[path] > long.MaxValue - file.Size)
                    {
                        throw new Exception("Long overflow!!!");
                    }
                    
                    directories[path] += file.Size;
                }
            }
        }

        return directories;
    }

    private static bool TryParseLine(string line, string prefixToSearch, out string rest)
    {
        rest = string.Empty;
        
        if (line.StartsWith(prefixToSearch))
        {
            rest = line.Substring(prefixToSearch.Length);
            return true;
        }

        return false;
    }

    private static string BuildPath(List<string> location)
    {
        return string.Join('/', location);
    }

    private static FileDescription ParseFile(string line)
    {
        var split = line.Split(' ');
        return new FileDescription(split[1], long.Parse(split[0]));
    }
}

public record FileDescription(string Name, long Size);