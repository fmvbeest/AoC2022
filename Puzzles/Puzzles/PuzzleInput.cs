namespace AoC2022.Puzzles;

public class PuzzleInput : IPuzzleInput
{
    private readonly string[] _allLines;
    
    public PuzzleInput(string filename)
    {
        _allLines = File.ReadAllLines(filename);
    }

    public IEnumerable<string> GetInput()
    {
        return _allLines;
    }
}