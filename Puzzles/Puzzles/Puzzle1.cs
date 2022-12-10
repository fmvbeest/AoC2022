namespace AoC2022.Puzzles;

public class Puzzle1 : PuzzleBase<IEnumerable<IEnumerable<int>>, int, int>
{
    protected override string Filename => "Input/puzzle-input-01";
    protected override string PuzzleTitle => "--- Day 1: Calorie Counting ---";

    public override int PartOne(IEnumerable<IEnumerable<int>> input)
    {
        return input.Select(x => x.Sum()).Max();
    }

    public override int PartTwo(IEnumerable<IEnumerable<int>> input)
    {
        return input.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).Sum();
    }

    public override IEnumerable<IEnumerable<int>> Preprocess(IPuzzleInput input, int part = 1)
    {
        var index = 0;
        return input.GetInput().
            GroupBy(x => !string.IsNullOrEmpty(x) ? index : index++, 
                x => !string.IsNullOrEmpty(x) ? int.Parse(x) : 0);
    }
}