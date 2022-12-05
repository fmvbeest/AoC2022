namespace AoC2022.Puzzles;

public class Puzzle3 : PuzzleBase<int, IEnumerable<string[]>>
{
    protected override string Filename => "Input/puzzle-input-03";
    protected override string PuzzleTitle => "--- Day 3: Rucksack Reorganization ---";
    
    private const int UppercaseOffset = 27;
    private const int LowercaseOffset = 1;
    
    public Puzzle3() : base() { }
    public Puzzle3(IPuzzleInput input) : base(input) { }
    
    public override int PartOne()
    {
        return PreparedInput.Select(s => s[0].Intersect(s[1]).First()).Select(GetPriority).Sum();
    }

    public override int PartTwo()
    {
        return PreparedInput.Select(s => s[0].Intersect(s[1]).Intersect(s[2]).First()).Select(GetPriority).Sum();
    }
    
    public override void Run()
    {
        Console.WriteLine(PuzzleTitle);
        
        Console.Write("Solution Part One: ");
        Console.WriteLine(PartOne());

        Preprocess(new PuzzleInput(Filename), 2);
        Console.Write("Solution Part Two: ");
        Console.WriteLine(PartTwo());
    }

    public override void Preprocess(IPuzzleInput input, int part = 1)
    {
        PreparedInput = part == 2 ? PreprocessPartTwo(input) : PreprocessPartOne(input);
    }

    private static IEnumerable<string[]> PreprocessPartOne(IPuzzleInput input)
    {
        return input.GetAllLines().Select(s => new[] { s[..(s.Length / 2)], s[(s.Length / 2)..] }).ToArray();
    }
    
    private static IEnumerable<string[]> PreprocessPartTwo(IPuzzleInput input)
    {
        return input.GetAllLines().Chunk(3);
    }

    private static int GetPriority(char c)
    {
        return char.IsLower(c) ? c - 'a' + LowercaseOffset : c - 'A' + UppercaseOffset;
    }
}