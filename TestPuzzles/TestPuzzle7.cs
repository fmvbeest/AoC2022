namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle7
{
    private readonly PuzzleInput _testInput = new("Input/test-input-07");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-07");
    private readonly Puzzle7 _puzzle = new();
    
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
        Assert.Equal(0, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(0, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}