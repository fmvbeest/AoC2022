namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle9
{
    private readonly PuzzleInput _testInput = new("Input/test-input-09");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-09");
    private readonly Puzzle9 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(13, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(5779, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(1, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(2331, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}