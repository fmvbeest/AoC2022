namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle4
{
    private readonly IPuzzleInput _testInput = new PuzzleInput("Input/test-input-04");
    private readonly IPuzzleInput _puzzleInput = new PuzzleInput("Input/puzzle-input-04");
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(2, new Puzzle4(_testInput).PartOne());
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(494, new Puzzle4(_puzzleInput).PartOne());
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(4, new Puzzle4(_testInput).PartTwo());
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(833, new Puzzle4(_puzzleInput).PartTwo());
    }
}