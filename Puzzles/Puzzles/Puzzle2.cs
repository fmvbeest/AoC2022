using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle2 : PuzzleBase<int, IEnumerable<Game>>
{
    protected override string Filename => "Input/puzzle-input-02";
    protected override string PuzzleTitle => "--- Day 2: Rock Paper Scissors ---";

    public Puzzle2() : base() { }
    public Puzzle2(IPuzzleInput input) : base(input) { }
    
    public override int PartOne()
    {
        return PreparedInput.Sum(GameRules.GetPoints);
    }

    public override int PartTwo()
    {
        return PreparedInput.Sum(game => GameRules.GetPoints(GameRules.FixGame(game)));
    }

    public override void Preprocess(IPuzzleInput input, int part = 1)
    {
        PreparedInput = input.GetAllLines().Select(line => new Game()
        {
            TheirMove = ParseMove(line[0]), 
            OurMove = ParseMove(line[2]), 
            ExpectedOutcome = ParseOutcome(line[2])
        }).ToList();
    }

    private static GameRules.Move ParseMove(char move) => move switch
    {
        'A' => GameRules.Move.Rock,
        'B' => GameRules.Move.Paper,
        'C' => GameRules.Move.Scissor,
        'X' => GameRules.Move.Rock,
        'Y' => GameRules.Move.Paper,
        'Z' => GameRules.Move.Scissor,
        _ => throw new ArgumentOutOfRangeException(nameof(move), move, "Unexpected move")
    };
        
    private static GameRules.Result ParseOutcome(char move) => move switch
    {
        'X' => GameRules.Result.Loss,
        'Y' => GameRules.Result.Draw,
        'Z' => GameRules.Result.Win,
        _ => throw new ArgumentOutOfRangeException(nameof(move), move, "Unexpected outcome")
    };
}