namespace AoC2022.Puzzles;

public class Puzzle3 : IPuzzle
{
    private const string Filename = "Input/puzzle-input-03";
    private const string PuzzleTitle = "--- Day 3: Rock Paper Scissors ---";
    
    private const int UppercaseOffset = 38;
    private const int LowercaseOffset = 96;
    public int PartOne(IPuzzleInput input)
    {
        var total = 0;

        foreach (var line in input.GetAllLines())
        {
            var s = line.Trim();
            var x = s[..(s.Length / 2)];
            var y = s.Substring(s.Length / 2, s.Length / 2);

            var intersect = x.Intersect(y).ToArray().First();

            total += GetPriority(intersect);
        }
        return total;
    }

    public int PartTwo(IPuzzleInput input)
    {
        var total = 0;

        var lines = input.GetAllLines();

        var index = 0;
        while (index < lines.Length)
        {
            var bagone = lines[index];
            var bagtwo = lines[index+1];
            var bagthree = lines[index+2];

            var intersect = bagone.Intersect(bagtwo);
            intersect = intersect.Intersect(bagthree);

            var badge = intersect.ToArray().First();

            total += GetPriority(badge);

            index += 3;
        }

        return total;
    }

    private static int GetPriority(char c)
    {
        var priority = (int)c;
        if (char.IsUpper(c))
        {
            priority -= UppercaseOffset;
        } else if (char.IsLower(c))
        {
            priority -= LowercaseOffset;
        }

        return priority;
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
}