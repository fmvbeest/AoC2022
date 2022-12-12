namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle11
{
    private readonly PuzzleInput _testInput = new("Input/test-input-11");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-11");
    private readonly Puzzle11 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(10605, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(76728, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(2713310158, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(21553910156, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}