namespace AoC2022.Puzzles;

public abstract class PuzzleBase : IPuzzle
{
    protected abstract string Filename { get; }
    protected abstract string PuzzleTitle { get; }

    public abstract int PartOne(IPuzzleInput input);

    public abstract int PartTwo(IPuzzleInput input);

    public virtual void Run()
    {
        IPuzzleInput input = new PuzzleInput(Filename);
        Console.WriteLine(PuzzleTitle);
        
        var res = PartOne(input);
        Console.Write("Solution Part One: ");
        Console.WriteLine(res);
        
        res = PartTwo(input);
        Console.Write("Solution Part Two: ");
        Console.WriteLine(res);
    }
}