namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle1
{
    [Fact]
    public void TestPartOneSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-01");
        var puzzle = new Puzzle1(input);
        var res = puzzle.PartOne();
        
        Assert.Equal(24000, res);
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-01");
        var puzzle = new Puzzle1(input);
        var res = puzzle.PartOne();
        
        Assert.Equal(67658, res);
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-01");
        var puzzle = new Puzzle1(input);
        var res = puzzle.PartTwo();
        
        Assert.Equal(45000, res);
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-01");
        var puzzle = new Puzzle1(input);
        var res = puzzle.PartTwo();
        
        Assert.Equal(200158, res);
    }
}