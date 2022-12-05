namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle4
{
    [Fact]
    public void TestPartOneSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-04");
        var puzzle = new Puzzle4(input);
        var res = puzzle.PartOne();
        
        Assert.Equal(2, res);
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-04");
        var puzzle = new Puzzle4(input);
        var res = puzzle.PartOne();
        
        Assert.Equal(494, res);
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-04");
        var puzzle = new Puzzle4(input);
        var res = puzzle.PartTwo();
        
        Assert.Equal(4, res);
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-04");
        var puzzle = new Puzzle4(input);
        var res = puzzle.PartTwo();
        
        Assert.Equal(833, res);
    }
}