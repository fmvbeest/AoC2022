namespace AoC2022.Puzzles;

public class Puzzle4 : PuzzleBase
{
    protected override string Filename => "Input/puzzle-input-04";
    protected override string PuzzleTitle => "--- Day 4: Camp Cleanup ---";
    
    public override int PartOne(IPuzzleInput input)
    {
        var fullSubRanges = 0;

        foreach (var line in input.GetAllLines())
        {
            var ranges = line.Split(',');
            var indicesx = ranges[0].Split('-'); 
            var indicesy = ranges[1].Split('-');
            var x = (int.Parse(indicesx[0]), int.Parse(indicesx[1]));
            var y = (int.Parse(indicesy[0]), int.Parse(indicesy[1]));

            if (IsSubRange(x, y) || IsSubRange(y, x))
            {
                fullSubRanges += 1;
            }
            
        }
        return fullSubRanges;
    }

    public override int PartTwo(IPuzzleInput input)
    {
        var overlaps = 0;

        foreach (var line in input.GetAllLines())
        {
            var ranges = line.Split(',');
            var indicesx = ranges[0].Split('-'); 
            var indicesy = ranges[1].Split('-');
            var x = (int.Parse(indicesx[0]), int.Parse(indicesx[1]));
            var y = (int.Parse(indicesy[0]), int.Parse(indicesy[1]));

            if (Overlap(x, y))
            {
                overlaps += 1;
            }
            
        }
        return overlaps;
    }

    private static bool IsSubRange((int start, int end) a, (int start,int end) b)
    {
        return a.start >= b.start && a.end <= b.end;
    }

    private static bool Overlap((int start, int end) a, (int start, int end) b)
    {
        return a.start >= b.start && a.start <= b.end || b.start >= a.start && b.start <= a.end;
    }
}