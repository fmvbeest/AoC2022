namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle5
{
    [Fact]
    public void TestPartOneSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-05");
        var puzzle = new Puzzle5(input);
        var res = puzzle.PartOne();
        
        Assert.Equal("CMZ", res);
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-05");
        var puzzle = new Puzzle5(input);
        var res = puzzle.PartOne();
        
        Assert.Equal("LBLVVTVLP", res);
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-05");
        var puzzle = new Puzzle5(input);
        var res = puzzle.PartTwo();
        
        Assert.Equal("MCD", res);
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-05");
        var puzzle = new Puzzle5(input);
        var res = puzzle.PartTwo();
        
        Assert.Equal("TPFFBDRJD", res);
    }
}