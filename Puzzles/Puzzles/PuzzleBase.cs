namespace AoC2022.Puzzles;

public abstract class PuzzleBase<T, U> : IPuzzle
{
    protected abstract string Filename { get; }
    protected abstract string PuzzleTitle { get; }

    public abstract T PartOne(U input);

    public abstract T PartTwo(U input);

    public abstract U Preprocess(IPuzzleInput input, int part = 1);

    public virtual void Run()
    {
        var input = new PuzzleInput(Filename);
        Console.WriteLine(PuzzleTitle);
        
        Console.Write("Solution Part One: ");
        Console.WriteLine(PartOne(Preprocess(input)));
        
        Console.Write("Solution Part Two: ");
        Console.WriteLine(PartTwo(Preprocess(input, 2)));
    }
}