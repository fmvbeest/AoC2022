namespace TestPuzzles;
using AoC2022.Puzzles;

public class TestPuzzle10
{
    private readonly PuzzleInput _testInput = new("Input/test-input-10");
    private readonly PuzzleInput _puzzleInput = new("Input/puzzle-input-10");
    private readonly Puzzle10 _puzzle = new();
    
    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(13140, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(14920, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }
    
    [Fact]
    public void TestPartTwoSample()
    {
        const string screen = "##..##..##..##..##..##..##..##..##..##..\n" +
                              "###...###...###...###...###...###...###.\n" +
                              "####....####....####....####....####....\n" +
                              "#####.....#####.....#####.....#####.....\n" +
                              "######......######......######......####\n" +
                              "#######.......#######.......#######.....\n";
        Assert.Equal(screen, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }
    
    [Fact]
    public void TestPartTwoActual()
    {
        const string screen = "###..#..#..##...##...##..###..#..#.####.\n" +
                              "#..#.#..#.#..#.#..#.#..#.#..#.#..#....#.\n" +
                              "###..#..#.#....#..#.#....###..#..#...#..\n" +
                              "#..#.#..#.#....####.#....#..#.#..#..#...\n" +
                              "#..#.#..#.#..#.#..#.#..#.#..#.#..#.#....\n" +
                              "###...##...##..#..#..##..###...##..####.\n";
        Assert.Equal(screen, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}