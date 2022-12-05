namespace AoC2022.Puzzles;

public class Puzzle2 : PuzzleBase<int>
{
    protected override string Filename => "Input/puzzle-input-02";
    protected override string PuzzleTitle => "--- Day 2: Rock Paper Scissors ---";
    
    public override int PartOne(IPuzzleInput input)
    {
        return Preprocess(input).Sum(GameRules.GetPoints);
    }

    public override int PartTwo(IPuzzleInput input)
    {
        return Preprocess(input).Sum(game => GameRules.GetPoints(GameRules.FixGame(game)));
    }

    private static IEnumerable<Game> Preprocess(IPuzzleInput input)
    {
        return input.GetAllLines().Select(line => new Game()
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

    private class Game
    {
        public GameRules.Move TheirMove { get; init; }
        public GameRules.Move OurMove { get; set; }
        public GameRules.Result ExpectedOutcome { get; init; }
    }
    
    private static class GameRules
    {
        public enum Move
        {
            Rock = 1, Paper = 2, Scissor = 3
        }

        public enum Result
        {
            Loss = 0, Draw = 3, Win = 6
        }

        public static int GetPoints(Game game)
        {
            return (int)GetResult(game) + (int)game.OurMove;
        }

        public static Game FixGame(Game game)
        {
            game.OurMove = SuggestedMoves[(game.TheirMove, game.ExpectedOutcome)];
            return game;
        }

        private static Result GetResult(Game game)
        {
            return Outcome[(game.OurMove, game.TheirMove)];
        }

        private static readonly Dictionary<(Move, Move), Result> Outcome = new()
        {
            { (Move.Rock, Move.Scissor), Result.Win },
            { (Move.Scissor, Move.Paper), Result.Win },
            { (Move.Paper, Move.Rock), Result.Win },
            { (Move.Scissor, Move.Rock), Result.Loss },
            { (Move.Paper, Move.Scissor), Result.Loss },
            { (Move.Rock, Move.Paper), Result.Loss },
            { (Move.Rock, Move.Rock), Result.Draw },
            { (Move.Paper, Move.Paper), Result.Draw },
            { (Move.Scissor, Move.Scissor), Result.Draw }
        };

        private static readonly Dictionary<(Move, Result), Move> SuggestedMoves = new()
        {
            { (Move.Rock, Result.Win), Move.Paper },
            { (Move.Rock, Result.Loss), Move.Scissor },
            { (Move.Rock, Result.Draw), Move.Rock },
            { (Move.Scissor, Result.Win), Move.Rock },
            { (Move.Scissor, Result.Loss), Move.Paper },
            { (Move.Scissor, Result.Draw), Move.Scissor },
            { (Move.Paper, Result.Win), Move.Scissor },
            { (Move.Paper, Result.Loss), Move.Rock },
            { (Move.Paper, Result.Draw), Move.Paper }
        };
    }
}