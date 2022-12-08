namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle8
{
    private readonly PuzzleInput _testInput = new("Input/test-input-08");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-08");
    private readonly Puzzle8 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(21, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(1785, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(8, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(345168, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}