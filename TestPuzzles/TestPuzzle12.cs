namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle12
{
    private readonly PuzzleInput _testInput = new("Input/test-input-12");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-12");
    private readonly Puzzle12 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(31, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(339, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(29, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(332, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}