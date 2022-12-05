namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle5
{
    private readonly IPuzzleInput _testInput = new PuzzleInput("Input/test-input-05");
    private readonly IPuzzleInput _puzzleInput = new PuzzleInput("Input/puzzle-input-05");
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal("CMZ", new Puzzle5(_testInput).PartOne());
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal("LBLVVTVLP", new Puzzle5(_puzzleInput).PartOne());
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal("MCD", new Puzzle5(_testInput).PartTwo());
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal("TPFFBDRJD", new Puzzle5(_puzzleInput).PartTwo());
    }
}