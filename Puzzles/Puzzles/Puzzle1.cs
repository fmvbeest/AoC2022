namespace AoC2022.Puzzles;

public class Puzzle1 : PuzzleBase
{
    protected override string Filename => "Input/puzzle-input-01";
    protected override string PuzzleTitle => "--- Day 1: Calorie Counting ---";

    public override int PartOne(IPuzzleInput input)
    {
        var max = 0;
        var current = 0;
          
        foreach (var line in input.GetAllLines())
        {
               
            if (string.IsNullOrEmpty(line))
            {
                max = Math.Max(max, current);
                current = 0;
                continue;
            }
          
            current += int.Parse(line.Trim());
        }
        
        return Math.Max(max, current);
    }

    public override int PartTwo(IPuzzleInput input)
    {
        var values = new List<int>();
        var sum = 0;
          
        foreach (var line in input.GetAllLines())
        {
            if (string.IsNullOrEmpty(line))
            {
                values.Add(sum);
                sum = 0;
                continue;
            }

            sum += int.Parse(line.Trim());
        }
        values.Add(sum);
        values.Sort();
        values.Reverse();
        
        return values[0] + values[1] + values[2];
    }
}