namespace AoC2022.Puzzles;

public class Puzzle1 : PuzzleBase
{
    protected override string Filename => "Input/puzzle-input-01";
    protected override string PuzzleTitle => "--- Day 1: Calorie Counting ---";

    public override int PartOne(IPuzzleInput input)
    {
        var calories = Preprocess(input);
        
        return calories.Select(x => x.Sum()).Max();
    }

    public override int PartTwo(IPuzzleInput input)
    {
        var calories = Preprocess(input);
        
        return calories.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).Sum();
    }

    private static IEnumerable<IEnumerable<int>> Preprocess(IPuzzleInput input)
    {
        var calories = new List<IEnumerable<int>>();
        var currentElf = new List<int>();
        foreach (var line in input.GetAllLines())
        {
            if (string.IsNullOrEmpty(line))
            {
                calories.Add(currentElf.ToArray());
                currentElf = new List<int>();
                continue;
            }
            currentElf.Add(int.Parse(line));
        }
        calories.Add(currentElf);

        return calories.ToArray();
    }
}