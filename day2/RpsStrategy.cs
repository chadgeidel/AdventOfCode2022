namespace AdventOfCode2022
{
    // Rock Paper Scissors gameplay mechanic
    internal record struct RpsGame
    {
        public string P1Play { get; init; }
        public string P2Play { get; init; }

        private int P2PlayScore => P2Play switch
        {
            "X" or "x" => 1, // rock
            "Y" or "y" => 2, // paper
            "Z" or "z" => 3, // scissors
            _ => 0,
        };
            
        // this calculates the score for the second player
        private int GameResult => (P1Play + P2Play).ToLower() switch
        {
            "ax" => 3, // rock, rock - tie
            "ay" => 6, // rock, paper - P2 wins
            "az" => 0, // rock, scissors - P1 wins
            "bx" => 0, // paper, rock - P1 wins
            "by" => 3, // paper, paper - tie
            "bz" => 6, // paper, scissors - P2 wins
            "cx" => 6, // scissors, rock - P2 wins
            "cy" => 0, // scissors, paper - P1 wins
            "cz" => 3, // scissors, scissors - tie
            _ => 0,
        };

        public int GameScore => GameResult + P2PlayScore;
    }

    internal class RpsStrategy
    {
        // read the input file and create a list of gameplays
        private static List<RpsGame> ReadFile(string fileName)
        {
            var allGames = new List<RpsGame>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                var line = sr.ReadLine();
                while(line != null)
                {
                    // assume all these records are of the format "A X"
                    string[] splitline = line.Split(' ');
                    var game = new RpsGame() { P1Play = splitline[0], P2Play = splitline[1] };
                    allGames.Add(game);
                    line = sr.ReadLine();
                }
            }
            return allGames;
        }

        // get expected score of sample game
         public static int RpsScore()
        {
            var game = ReadFile("day2//rps-strat.txt");

            return game.Sum(x => x.GameScore);
       }
    }
}