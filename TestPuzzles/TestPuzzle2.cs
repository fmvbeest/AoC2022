namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle2
{
    private readonly IPuzzleInput _testInput = new PuzzleInput("Input/test-input-02");
    private readonly IPuzzleInput _puzzleInput = new PuzzleInput("Input/puzzle-input-02");
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(15, new Puzzle2(_testInput).PartOne());
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(12740, new Puzzle2(_puzzleInput).PartOne());
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(12, new Puzzle2(_testInput).PartTwo());
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(11980, new Puzzle2(_puzzleInput).PartTwo());
    }
}