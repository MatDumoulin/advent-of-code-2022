// See https://aka.ms/new-console-template for more information

using Day6;

var input = File.ReadAllText(Directory.GetCurrentDirectory() + "/input.txt");

var device = new Device(4);
var result = device.FindSubRoutine(input);

Console.WriteLine($"Day 6.1: {result}");

//////////////////////////////////////////////

device = new Device(14);
result = device.FindSubRoutine(input);

Console.WriteLine($"Day 6.2: {result}");