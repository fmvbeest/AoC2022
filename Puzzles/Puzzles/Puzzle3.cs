namespace AoC2022.Puzzles;

public class Puzzle3 : PuzzleBase
{
    protected override string Filename => "Input/puzzle-input-03";
    protected override string PuzzleTitle => "--- Day 3: Rucksack Reorganization ---";
    
    private const int UppercaseOffset = -38;
    private const int LowercaseOffset = -96;
    
    public override int PartOne(IPuzzleInput input)
    {
        return PreprocessPartOne(input).Select(s => s[0].Intersect(s[1]).First()).Select(GetPriority).Sum();
    }

    public override int PartTwo(IPuzzleInput input)
    {
        return PreprocessPartTwo(input).Select(s => s[0].Intersect(s[1]).Intersect(s[2]).First()).Select(GetPriority).Sum();
    }
    
    private static IEnumerable<string[]> PreprocessPartOne(IPuzzleInput input)
    {
        return input.GetAllLines().Select(s => new[] { s[..(s.Length / 2)], s[(s.Length / 2)..] }).ToArray();
    }
    
    private static IEnumerable<string[]> PreprocessPartTwo(IPuzzleInput input)
    {
        var res = new List<string[]>();

        var s = input.GetAllLines();
        for (var index = 0; index < s.Length; index += 3)
        {
            res.Add(new []{ s[index], s[index+1], s[index+2]});
        }

        return res.ToArray();
    }

    private static int GetPriority(char c)
    {
        var priority = (int)c;
        if (char.IsUpper(c))
        {
            return priority + UppercaseOffset;
        } 
        
        if (char.IsLower(c))
        {
            return priority + LowercaseOffset;
        }

        return priority;
    }
}