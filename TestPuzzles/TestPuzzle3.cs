namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle3
{
    private readonly PuzzleInput _testInput = new("Input/test-input-03");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-03");
    private readonly Puzzle3 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(157, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(8401, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(70, _puzzle.PartTwo(_puzzle.Preprocess(_testInput, 2)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(2641, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput, 2)));
    }
}