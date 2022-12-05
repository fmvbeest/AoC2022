namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle1
{
    private readonly IPuzzleInput _testInput = new PuzzleInput("Input/test-input-01");
    private readonly IPuzzleInput _puzzleInput = new PuzzleInput("Input/puzzle-input-01");
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(24000, new Puzzle1(_testInput).PartOne());
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(67658, new Puzzle1(_puzzleInput).PartOne());
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(45000, new Puzzle1(_testInput).PartTwo());
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(200158, new Puzzle1(_puzzleInput).PartTwo());
    }
}