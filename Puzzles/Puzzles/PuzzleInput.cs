namespace AoC2022.Puzzles;

public class PuzzleInput : IPuzzleInput
{
    private readonly string[] _allLines;

    public PuzzleInput(string filename)
    {
        _allLines = File.ReadAllLines(filename);
    }

    public PuzzleInput(IEnumerable<string> input)
    {
        _allLines = input.ToArray();
    }

    public IEnumerable<string> GetInput()
    {
        return _allLines;
    }

    public string GetFirstLine()
    {
        return _allLines[0];
    }
}