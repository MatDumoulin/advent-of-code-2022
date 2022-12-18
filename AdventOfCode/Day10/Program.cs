using Day10;
using Day10.Commands;

var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt");
var commands = input.Select(CommandParser.Parse).ToList();
var cpu = new Cpu();

foreach (var command in commands)
{
    cpu.Apply(command);
}

var sampleAtCpuCycles = new[]
{
    20,
    60,
    100,
    140,
    180,
    220
};

var sumOfSignalStrengthSamples = sampleAtCpuCycles.Select(cycle => cpu.GetSignalStrength(cycle)).Sum();

Console.WriteLine($"Day10.1: {sumOfSignalStrengthSamples}");

////////////////////////////////////

var crt = new Crt();
crt.BuildFinalScreen(cpu);

Console.WriteLine($"Day10.2:");
crt.Display();