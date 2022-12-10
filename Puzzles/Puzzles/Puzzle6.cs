namespace AoC2022.Puzzles;

public class Puzzle6 : PuzzleBase<int, string>
{
    protected override string Filename => "Input/puzzle-input-06";
    protected override string PuzzleTitle => "--- Day 6: Tuning Trouble ---";

    public override int PartOne(string input)
    {
        return CountProcessedBeforeMarker(input, 4);
    }

    public override int PartTwo(string input)
    {
        return CountProcessedBeforeMarker(input, 14);
    }
    
    public override string Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetFirstLine();
    }

    private static int CountProcessedBeforeMarker(string input, int size)
    {
        var index = 0;
        
        while (index < input.Length)
        {
            if (input.Substring(index, size).Distinct().Count() == size) break;
            index++;
        }

        return index + size;
    }
}