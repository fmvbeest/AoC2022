namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle4
{
    private readonly PuzzleInput _testInput = new("Input/test-input-04");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-04");
    private readonly Puzzle4 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(2, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(494, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(4, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(833, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}