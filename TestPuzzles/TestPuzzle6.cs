namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle6
{
    private readonly PuzzleInput _testInput = new("Input/test-input-06");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-06");
    private readonly Puzzle6 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(7, _puzzle.PartOne(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[0]}))));
        Assert.Equal(5, _puzzle.PartOne(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[1]}))));
        Assert.Equal(6, _puzzle.PartOne(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[2]}))));
        Assert.Equal(10, _puzzle.PartOne(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[3]}))));
        Assert.Equal(11, _puzzle.PartOne(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[4]}))));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(1034, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(19, _puzzle.PartTwo(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[0]}))));
        Assert.Equal(23, _puzzle.PartTwo(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[1]}))));
        Assert.Equal(23, _puzzle.PartTwo(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[2]}))));
        Assert.Equal(29, _puzzle.PartTwo(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[3]}))));
        Assert.Equal(26, _puzzle.PartTwo(_puzzle.Preprocess(new PuzzleInput(new []{_testInput.GetAllLines().ToArray()[4]}))));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(2472, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}