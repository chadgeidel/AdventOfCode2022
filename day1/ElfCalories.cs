using System;
using System.IO;
namespace AdventOfCode2022
{
    internal class ElfCalories
    {
        /// read file and get the calories in the elf 
        ///  with the most calories in their backpack
         public static int TopCaloriesOfElves(int numElves)
        {
            // assuming one elf doesn't have 2 billion calories in his bag
            var elfCalorieBags = new Dictionary<int, int>();
            var elfNumber = 1;
            var currentCalorieBag = 0;

            using (StreamReader sr = new StreamReader("day1\\elf-calories.txt"))
            {
                var line = sr.ReadLine();
                while(line != null)
                {
                    var currentSnack = 0;
                    // assuming lines are either a number or an empty string
                    if (Int32.TryParse(line, out currentSnack))
                    {
                        currentCalorieBag += currentSnack;
                    }
                    else
                    {
                        // empty line, new elf
                        elfCalorieBags.Add(elfNumber, currentCalorieBag);
                        elfNumber++;

                        // reset calorie bag
                        currentCalorieBag = 0;
                    }

                    // reset snack
                    currentSnack = 0;

                    line = sr.ReadLine();
                }
            }

            // return the calories of the top N elves
            return elfCalorieBags.OrderByDescending(v => v.Value)
                                .Take(numElves)
                                .Sum(v => v.Value);
        }
    }
}