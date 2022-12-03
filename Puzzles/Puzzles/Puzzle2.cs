namespace AoC2022.Puzzles;

public class Puzzle2 : IPuzzle
{
    private const string Filename = "Input/puzzle-input-02";
    private const string PuzzleTitle = "--- Day 2: Rock Paper Scissors ---";

    public int PartOne(IPuzzleInput input)
    {
        var total = 0;
        
        foreach (var line in input.GetAllLines())
        {
            var moves = line.Trim().Split(' ');
            var x = ShapeMap[moves[0]];
            var y = ShapeMap[moves[1]];
            var r = Result[(y, x)];
            var pr = PointsResult[r];
            var ps = PointsShape[y];
            var points = pr + ps;

            total += points;
        }

        return total;
    }

    public int PartTwo(IPuzzleInput input)
    {
        var total = 0;
        
        foreach (var line in input.GetAllLines())
        {
            var moves = line.Trim().Split(' ');
            var x = ShapeMap[moves[0]];
            var y = ExpectedResult[moves[1]];
            var m = SuggestedMoves[(x, y)];
            
            var r = Result[(m, x)];
            var pr = PointsResult[r];
            var ps = PointsShape[m];
            var points = pr + ps;
            
            total += points;
        }
        
        return total;
    }

    void IPuzzle.Run()
    {
        IPuzzleInput input = new PuzzleInput(Filename);
        
        Console.WriteLine(PuzzleTitle);
        var res = PartOne(input);
        Console.WriteLine("Part One:");
        Console.WriteLine(res);
        
        res = PartTwo(input);
        Console.WriteLine("Part Two:");
        Console.WriteLine(res);
    }
    
    private static readonly Dictionary<string, int> PointsResult = new()
    {
        { "L", 0 },
        { "D", 3 },
        { "W", 6 }
    };
    
    private static readonly Dictionary<string, int> PointsShape = new()
    {
        { "R", 1 },
        { "P", 2 },
        { "S", 3 }
    };

    private static readonly Dictionary<string, string> ShapeMap = new()
    {
        { "A", "R" },
        { "B", "P" },
        { "C", "S" },
        { "X", "R" },
        { "Y", "P" },
        { "Z", "S" }
    };

    private static readonly Dictionary<(string, string), string> Result = new()
    {
        { ("R", "S"), "W" },
        { ("S", "P"), "W" },
        { ("P", "R"), "W" },
        { ("S", "R"), "L" },
        { ("P", "S"), "L" },
        { ("R", "P"), "L" },
        { ("R", "R"), "D" },
        { ("P", "P"), "D" },
        { ("S", "S"), "D" }
    };
    
    private static readonly Dictionary<string, string> ExpectedResult = new()
    {
        { "X", "L" },
        { "Y", "D" },
        { "Z", "W" }
    };
    
    private static readonly Dictionary<(string, string), string> SuggestedMoves = new()
    {
        { ("R", "W"), "P" },
        { ("R", "L"), "S" },
        { ("R", "D"), "R" },
        { ("S", "W"), "R" },
        { ("S", "L"), "P" },
        { ("S", "D"), "S" },
        { ("P", "W"), "S" },
        { ("P", "L"), "R" },
        { ("P", "D"), "P" }
    };
}