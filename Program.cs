using AdventOfCode2022;
Console.WriteLine("Advent of Code 2022");
Console.WriteLine();

// Day one
Console.WriteLine("Day 1");
var calorieCount = ElfCalories.TopCaloriesOfElves(1);
Console.WriteLine($"The elf with the most calories is carrying {calorieCount} calories");
calorieCount = ElfCalories.TopCaloriesOfElves(3);
Console.WriteLine($"The top 3 elves with the most calories are carrying {calorieCount} calories in total");
Console.WriteLine();

// Day two
Console.WriteLine("Day 2");
Console.WriteLine();