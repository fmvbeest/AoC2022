namespace AoC2022.Puzzles;

public abstract class PuzzleBase<T> : IPuzzle
{
    protected abstract string Filename { get; }
    protected abstract string PuzzleTitle { get; }

    public abstract T PartOne(IPuzzleInput input);

    public abstract T PartTwo(IPuzzleInput input);

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