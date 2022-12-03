namespace AoC2022.Puzzles;

public class Puzzle1 : IPuzzle
{
    private const string Filename = "Input/puzzle-input-01";
    private const string PuzzleTitle = "--- Day 1: Calorie Counting ---";
    public int PartOne(IPuzzleInput input)
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

    public int PartTwo(IPuzzleInput input)
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

    public void Run()
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
}