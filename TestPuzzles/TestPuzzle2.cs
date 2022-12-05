namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle2
{
    private readonly PuzzleInput _testInput = new("Input/test-input-02");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-02");
    private readonly Puzzle2 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(15, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(12740, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(12, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(11980, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}