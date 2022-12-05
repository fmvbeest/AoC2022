using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle2 : PuzzleBase<int, IEnumerable<RPS.Game>>
{
    protected override string Filename => "Input/puzzle-input-02";
    protected override string PuzzleTitle => "--- Day 2: Rock Paper Scissors ---";

    public Puzzle2() : base() { }
    public Puzzle2(IPuzzleInput input) : base(input) { }
    
    public override int PartOne()
    {
        return PreparedInput.Sum(RPS.GameRules.GetPoints);
    }

    public override int PartTwo()
    {
        return PreparedInput.Sum(game => RPS.GameRules.GetPoints(RPS.GameRules.FixGame(game)));
    }

    public override void Preprocess(IPuzzleInput input, int part = 1)
    {
        PreparedInput = input.GetAllLines().Select(line => new RPS.Game()
        {
            TheirMove = ParseMove(line[0]), 
            OurMove = ParseMove(line[2]), 
            ExpectedOutcome = ParseOutcome(line[2])
        }).ToList();
    }

    private static RPS.GameRules.Move ParseMove(char move) => move switch
    {
        'A' => RPS.GameRules.Move.Rock,
        'B' => RPS.GameRules.Move.Paper,
        'C' => RPS.GameRules.Move.Scissor,
        'X' => RPS.GameRules.Move.Rock,
        'Y' => RPS.GameRules.Move.Paper,
        'Z' => RPS.GameRules.Move.Scissor,
        _ => throw new ArgumentOutOfRangeException(nameof(move), move, "Unexpected move")
    };
        
    private static RPS.GameRules.Result ParseOutcome(char move) => move switch
    {
        'X' => RPS.GameRules.Result.Loss,
        'Y' => RPS.GameRules.Result.Draw,
        'Z' => RPS.GameRules.Result.Win,
        _ => throw new ArgumentOutOfRangeException(nameof(move), move, "Unexpected outcome")
    };
}