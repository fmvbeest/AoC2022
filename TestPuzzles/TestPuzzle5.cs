namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle5
{
    private readonly PuzzleInput _testInput = new("Input/test-input-05");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-05");
    private readonly Puzzle5 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal("CMZ", _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal("LBLVVTVLP", _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal("MCD", _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal("TPFFBDRJD", _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}