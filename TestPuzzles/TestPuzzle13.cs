namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle13
{
    private readonly PuzzleInput _testInput = new("Input/test-input-13");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-13");
    private readonly Puzzle13 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(0, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(0, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(0, _puzzle.PartTwo(_puzzle.Preprocess(_testInput, 2)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(0, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput, 2)));
    }
}