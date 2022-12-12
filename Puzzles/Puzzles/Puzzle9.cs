using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle9 : PuzzleBase<IEnumerable<(char, int)>, int, int>
{
    protected override string Filename => "Input/puzzle-input-09";
    protected override string PuzzleTitle => "--- Day 9: Rope Bridge ---";

    public override int PartOne(IEnumerable<(char, int)> input)
    {
        return SimulateRope(2, input);
    }

    public override int PartTwo(IEnumerable<(char, int)> input)
    {
        return SimulateRope(10, input);
    }
    
    public override IEnumerable<(char, int)> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(line => line.Split(' ')).Select(s => (s[0][0], int.Parse(s[1]))).ToList();
    }

    private static int SimulateRope(int length, IEnumerable<(char, int)> input)
    {
        var rope = new Rope(new Coordinate(0, 0), length);

        foreach (var (direction, count) in input)
        {
            rope.SimulateStep(direction, count);
        }
        
        return rope.GetVisited().Distinct().Count();
    }

    private class Rope
    {
        private readonly List<Coordinate> _rope;
        private readonly List<Coordinate> _visited;
        
        private Coordinate Head
        {
            get => _rope[0];
            set => _rope[0] = value;
        }
        
        public Rope(Coordinate start, int length)
        {
            _visited = new List<Coordinate>();
            _rope = new List<Coordinate>();
            for (var i = 0; i < length; i++)
            {
                _rope.Add(start);
            }
            _visited.Add(start);
        }

        public void SimulateStep(char direction, int count)
        {
            for (var i = 0; i < count; i++)
            {
                Head += direction switch
                {
                    'R' => (1, 0),
                    'U' => (0, 1),
                    'L' => (-1, 0),
                    'D' => (0, -1),
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                };
                PropagateStep();
            }
        }

        private void PropagateStep()
        {
            for (var i = 1; i < _rope.Count; i++)
            {
                var diff = _rope[i - 1] - _rope[i]; 
                if (diff.Equals((0,0)) || _rope[i-1].IsAdjacentTo(_rope[i]))
                {
                    return;
                }
                
                _rope[i] += (diff) switch
                {
                    (2, 0) => (1, 0),
                    (0, -2) => (0, -1),
                    (-2, 0) => (-1, 0),
                    (0, 2) => (0, 1),
                    (1, 2) or (2, 1) or (2, 2) => (1, 1),
                    (1, -2) or (2, -1) or (2, -2) => (1, -1),
                    (-1, 2) or (-2, 1) or (-2, 2) => (-1, 1),
                    (-1, -2) or (-2, -1) or (-2, -2) => (-1, -1),
                    _ => throw new ArgumentOutOfRangeException("diff", diff, null)
                };

                if (i == _rope.Count - 1)
                {
                    _visited.Add(_rope[i]);
                }
            }
        }

        public IEnumerable<Coordinate> GetVisited()
        {
            return _visited;
        }
        
        public override string ToString()
        {
            return _rope.Aggregate(string.Empty, (current, knot) => current + knot);
        }
    }
}