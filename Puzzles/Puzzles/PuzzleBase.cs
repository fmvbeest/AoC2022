namespace AoC2022.Puzzles;

public abstract class PuzzleBase<T, U> : IPuzzle
{
    protected abstract string Filename { get; }
    protected abstract string PuzzleTitle { get; }

    protected U PreparedInput;

    protected PuzzleBase() => Preprocess(new PuzzleInput(Filename));
    protected PuzzleBase(IPuzzleInput input) => Preprocess(input);

    public abstract T PartOne();

    public abstract T PartTwo();

    public abstract void Preprocess(IPuzzleInput input, int part = 1);

    public virtual void Run()
    {
        Console.WriteLine(PuzzleTitle);
        
        Console.Write("Solution Part One: ");
        Console.WriteLine(PartOne());
        
        Console.Write("Solution Part Two: ");
        Console.WriteLine(PartTwo());
    }
}