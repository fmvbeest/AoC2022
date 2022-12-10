namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle10
{
    private readonly PuzzleInput _testInput = new("Input/test-input-10");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-10");
    private readonly Puzzle10 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(13140, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(14920, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(2681320, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(2331, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}