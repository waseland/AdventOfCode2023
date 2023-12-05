// Trebuchet
var trebuchetLines = File.ReadAllLines("trebuchetInput.txt");
Console.WriteLine($"Day 1 - Trebuchet: {Trebuchet.Solve(trebuchetLines)}");

// Code Conundrum
var codeConundrumLines = File.ReadAllLines("codeConundrumInput.txt");
Console.WriteLine($"Day 2 - Code Conundrum: {CodeConundrum.Solve(codeConundrumLines)}");

// Gear Ratios
var gearRatiosLines = File.ReadAllLines("gearRatiosInput.txt");
Console.WriteLine($"Day 3 - Gear Ratios: {GearRatios.Solve(gearRatiosLines)}");

Console.ReadLine();