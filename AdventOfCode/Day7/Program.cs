// See https://aka.ms/new-console-template for more information

using Day7;

var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt");

var directories = InputParser.BuildFolderSizes(input);
var sizeOfSmallDirectories = directories.Values.Where(x => x <= 100000L);
var result = sizeOfSmallDirectories.Sum();

Console.WriteLine($"Day 7.1: {result}");

//////////////////////////////////////////////

const long fileSystemTotalSpace = 70000000L;
const long desiredUnusedSpace = 30000000L;

var currentlyUsedSize = directories["/"];
var spaceAvailable = fileSystemTotalSpace - currentlyUsedSize;
var spaceToFreeUp = desiredUnusedSpace - spaceAvailable;

var candidates = directories.Values
    .Where(x => x >= spaceToFreeUp)
    .ToList();

candidates.Sort();

Console.WriteLine($"Day 7.2: {candidates.First()}");