namespace AoC2022.Puzzles;

public class Puzzle3 : PuzzleBase<int, IEnumerable<string[]>>
{
    protected override string Filename => "Input/puzzle-input-03";
    protected override string PuzzleTitle => "--- Day 3: Rucksack Reorganization ---";
    
    private const int UppercaseOffset = 27;
    private const int LowercaseOffset = 1;
    
    public override int PartOne(IEnumerable<string[]> input)
    {
        return input.Select(s => s[0].Intersect(s[1]).First()).Select(GetPriority).Sum();
    }

    public override int PartTwo(IEnumerable<string[]> input)
    {
        return input.Select(s => s[0].Intersect(s[1]).Intersect(s[2]).First()).Select(GetPriority).Sum();
    }

    public override IEnumerable<string[]> Preprocess(IPuzzleInput input, int part = 1)
    {
        return part == 2 ? PreprocessPartTwo(input) : PreprocessPartOne(input);
    }

    private static IEnumerable<string[]> PreprocessPartOne(IPuzzleInput input)
    {
        return input.GetInput().Select(s => new[] { s[..(s.Length / 2)], s[(s.Length / 2)..] }).ToArray();
    }
    
    private static IEnumerable<string[]> PreprocessPartTwo(IPuzzleInput input)
    {
        return input.GetInput().Chunk(3);
    }

    private static int GetPriority(char c)
    {
        return char.IsLower(c) ? c - 'a' + LowercaseOffset : c - 'A' + UppercaseOffset;
    }
}