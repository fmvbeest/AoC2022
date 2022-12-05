namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle3
{
    private readonly IPuzzleInput _testInput = new PuzzleInput("Input/test-input-03");
    private readonly IPuzzleInput _puzzleInput = new PuzzleInput("Input/puzzle-input-03");
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(157, new Puzzle3(_testInput).PartOne());
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(8401, new Puzzle3(_puzzleInput).PartOne());
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        var puzzle = new Puzzle3();
        puzzle.Preprocess(_testInput, 2);
        
        Assert.Equal(70, puzzle.PartTwo());
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        var puzzle = new Puzzle3();
        puzzle.Preprocess(_puzzleInput, 2);
        
        Assert.Equal(2641, puzzle.PartTwo());
    }
}