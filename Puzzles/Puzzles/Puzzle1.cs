namespace AoC2022.Puzzles;

public class Puzzle1 : PuzzleBase<int, IEnumerable<IEnumerable<int>>>
{
    protected override string Filename => "Input/puzzle-input-01";
    protected override string PuzzleTitle => "--- Day 1: Calorie Counting ---";

    public Puzzle1() : base() { }
    public Puzzle1(IPuzzleInput input) : base(input) { }

    public override int PartOne()
    {
        return PreparedInput.Select(x => x.Sum()).Max();
    }

    public override int PartTwo()
    {
        return PreparedInput.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).Sum();
    }

    public override void Preprocess(IPuzzleInput input, int part = 1)
    {
        var index = 0;
        PreparedInput = input.GetAllLines().
            GroupBy(x => !string.IsNullOrEmpty(x) ? index : index++, 
                x => !string.IsNullOrEmpty(x) ? int.Parse(x) : 0);
    }
}