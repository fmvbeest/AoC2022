namespace AoC2022.Puzzles;

public interface IPuzzle
{
    public int PartOne(IPuzzleInput input);

    public int PartTwo(IPuzzleInput input);

    public void Run();
}