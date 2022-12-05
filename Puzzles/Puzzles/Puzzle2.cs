using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle2 : PuzzleBase<int, IEnumerable<Game>>
{
    protected override string Filename => "Input/puzzle-input-02";
    protected override string PuzzleTitle => "--- Day 2: Rock Paper Scissors ---";

    public override int PartOne(IEnumerable<Game> input)
    {
        return input.Sum(GameRules.GetPoints);
    }

    public override int PartTwo(IEnumerable<Game> input)
    {
        return input.Sum(game => GameRules.GetPoints(GameRules.FixGame(game)));
    }

    public override IEnumerable<Game> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetInput().Select(line => new Game()
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