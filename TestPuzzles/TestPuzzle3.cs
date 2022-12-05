namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle3
{
    [Fact]
    public void TestPartOneSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-03");
        var puzzle = new Puzzle3(input);
        var res = puzzle.PartOne();
        
        Assert.Equal(157, res);
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-03");
        var puzzle = new Puzzle3(input);
        var res = puzzle.PartOne();
        
        Assert.Equal(8401, res);
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        IPuzzleInput input = new PuzzleInput("Input/test-input-03");
        var puzzle = new Puzzle3();
        puzzle.Preprocess(input, 2);
        var res = puzzle.PartTwo();
        
        Assert.Equal(70, res);
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        IPuzzleInput input = new PuzzleInput("Input/puzzle-input-03");
        var puzzle = new Puzzle3();
        puzzle.Preprocess(input, 2);
        var res = puzzle.PartTwo();
        
        Assert.Equal(2641, res);
    }
}