namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle2
{
    [Fact]
    public void TestPartOneSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-02");
        var puzzle = new Puzzle2();
        var res = puzzle.PartOne(input);
        
        Assert.Equal(15, res);
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-02");
        var puzzle = new Puzzle2();
        var res = puzzle.PartOne(input);
        
        Assert.Equal(12740, res);
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-02");
        var puzzle = new Puzzle2();
        var res = puzzle.PartTwo(input);
        
        Assert.Equal(12, res);
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-02");
        var puzzle = new Puzzle2();
        var res = puzzle.PartTwo(input);
        
        Assert.Equal(11980, res);
    }
}