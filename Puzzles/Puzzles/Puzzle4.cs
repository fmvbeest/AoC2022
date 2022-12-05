namespace AoC2022.Puzzles;

public class Puzzle4 : PuzzleBase<int, IEnumerable<(Range a, Range b)>>
{
    protected override string Filename => "Input/puzzle-input-04";
    protected override string PuzzleTitle => "--- Day 4: Camp Cleanup ---";
    
    public Puzzle4() : base() { }
    public Puzzle4(IPuzzleInput input) : base(input) { }
    
    public override int PartOne()
    {
        return PreparedInput.Count(p => IsSubRange(p.a, p.b) || IsSubRange(p.b, p.a));
    }

    public override int PartTwo()
    {
        return PreparedInput.Count(p => Overlap(p.a, p.b));
    }

    private static bool IsSubRange(Range a, Range b)
    {
        return a.Start.Value >= b.Start.Value && a.End.Value <= b.End.Value;
    }

    private static bool Overlap(Range a, Range b)
    {
        return a.Start.Value <= b.End.Value && b.Start.Value <= a.End.Value;
    }

    public override void Preprocess(IPuzzleInput input, int part = 1)
    {
        PreparedInput = (from line in input.GetAllLines() 
            select line.Split(',') into sections 
            let rangex = sections[0].Split('-') 
            let rangey = sections[1].Split('-') 
            let x = new Range(new Index(int.Parse(rangex[0])), new Index(int.Parse(rangex[1]))) 
            let y = new Range(new Index(int.Parse(rangey[0])), new Index(int.Parse(rangey[1]))) 
            select (x, y)).ToList();
    }
}