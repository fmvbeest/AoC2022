namespace AoC2022.Puzzles;

public interface IPuzzleInput
{
    public IEnumerable<string> GetAllLines();

    public string GetFirstLine();

    public string GetText();
}