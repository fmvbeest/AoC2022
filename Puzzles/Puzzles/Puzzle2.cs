namespace AoC2022.Puzzles;

public class Puzzle2 : PuzzleBase
{
    protected override string Filename => "Input/puzzle-input-02";
    protected override string PuzzleTitle => "--- Day 2: Rock Paper Scissors ---";

    public override int PartOne(IPuzzleInput input)
    {
        var total = 0;
        
        foreach (var line in input.GetAllLines())
        {
            var x = ShapeMap[line[0]];
            var y = ShapeMap[line[2]];
            var r = Result[(y, x)];

            total += GetPoints(r, y);
        }

        return total;
    }

    public override int PartTwo(IPuzzleInput input)
    {
        var total = 0;
        
        foreach (var line in input.GetAllLines())
        {
            var x = ShapeMap[line[0]];
            var y = ExpectedResult[line[2]];
            var m = SuggestedMoves[(x, y)];
            var r = Result[(m, x)];

            total += GetPoints(r, m);
        }
        
        return total;
    }

    private static int GetPoints(char result, char shape)
    {
        return PointsResult[result] + PointsShape[shape];
    }

    private static readonly Dictionary<char, int> PointsResult = new()
    {
        { 'L', 0 },
        { 'D', 3 },
        { 'W', 6 }
    };
    
    private static readonly Dictionary<char, int> PointsShape = new()
    {
        { 'R', 1 },
        { 'P', 2 },
        { 'S', 3 }
    };

    private static readonly Dictionary<char, char> ShapeMap = new()
    {
        { 'A', 'R' },
        { 'B', 'P' },
        { 'C', 'S' },
        { 'X', 'R' },
        { 'Y', 'P' },
        { 'Z', 'S' }
    };

    private static readonly Dictionary<(char, char), char> Result = new()
    {
        { ('R', 'S'), 'W' },
        { ('S', 'P'), 'W' },
        { ('P', 'R'), 'W' },
        { ('S', 'R'), 'L' },
        { ('P', 'S'), 'L' },
        { ('R', 'P'), 'L' },
        { ('R', 'R'), 'D' },
        { ('P', 'P'), 'D' },
        { ('S', 'S'), 'D' }
    };
    
    private static readonly Dictionary<char, char> ExpectedResult = new()
    {
        { 'X', 'L' },
        { 'Y', 'D' },
        { 'Z', 'W' }
    };
    
    private static readonly Dictionary<(char, char), char> SuggestedMoves = new()
    {
        { ('R', 'W'), 'P' },
        { ('R', 'L'), 'S' },
        { ('R', 'D'), 'R' },
        { ('S', 'W'), 'R' },
        { ('S', 'L'), 'P' },
        { ('S', 'D'), 'S' },
        { ('P', 'W'), 'S' },
        { ('P', 'L'), 'R' },
        { ('P', 'D'), 'P' }
    };
}