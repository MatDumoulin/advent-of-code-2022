// See https://aka.ms/new-console-template for more information

using Day8;

var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt");

var heightMap = new HeightMap(input);
var solver1 = new SolverPart1(heightMap);
var result = solver1.CountVisibleTrees();

Console.WriteLine($"Day 8.1: {result}");

//////////////////////////////////////////////

var solver2 = new SolverPart2Dynamic(heightMap);
result = solver2.GetHighestScenicScore();

Console.WriteLine($"Day 8.2: {result}");