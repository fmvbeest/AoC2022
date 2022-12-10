using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle9 : PuzzleBase<int, IEnumerable<(char, int)>>
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
        return input.GetInput().Select(line => line.Split(' ')).Select(s => (s[0][0], int.Parse(s[1]))).ToList();
    }

    private static int SimulateRope(int length, IEnumerable<(char, int)> input)
    {
        var rope = new Rope(new Coordinate(0, 0), length);

        foreach (var (direction, count) in input)
        {
            rope.MoveHead(direction, count);
        }
        
        return rope.GetVisited().Distinct().Count();
    }

    private static Coordinate MoveRight(Coordinate pos)
    {
        //return new Coordinate(pos.X, pos.Y) + new Coordinate(1,0);
        return pos + new Coordinate(1,0);
    }
    
    private static Coordinate MoveUp(Coordinate pos)
    {
        return pos + new Coordinate(0,1);
    }
    
    private static Coordinate MoveLeft(Coordinate pos)
    {
        return pos + new Coordinate(-1,0);
    }
    
    private static Coordinate MoveDown(Coordinate pos)
    {
        return pos + new Coordinate(0,-1);
    }

    private class Rope
    {
        private readonly List<Coordinate> _rope;
        private readonly List<Coordinate> _visited;
        
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

        public override string ToString()
        {
            return _rope.Aggregate(string.Empty, (current, knot) => current + knot);
        }

        public void MoveHead(char direction, int count)
        {
            for (var i = 0; i < count; i++)
            {
                _rope[0] = direction switch
                {
                    'R' => MoveRight(_rope[0]),
                    'U' => MoveUp(_rope[0]),
                    'L' => MoveLeft(_rope[0]),
                    'D' => MoveDown(_rope[0]),
                    _ => _rope[0]
                };
                PropagateStep(direction);
            }
        }

        private void PropagateStep(char move)
        {
            for (var i = 1; i < _rope.Count; i++)
            {
                var prev = _rope[i-1];
                var curr = _rope[i];
                if (prev.IsAdjacentTo(curr))
                {
                    return;
                }
                var diff = prev - curr;
                
                if (diff.Equals(new Coordinate(2, 0)))
                {
                    _rope[i] = curr + new Coordinate(1, 0);
                } else 
                if (diff.Equals(new Coordinate(0, -2)))
                {
                    _rope[i] = curr + new Coordinate(0, -1);
                } else if (diff.Equals(new Coordinate(-2, 0)))
                {
                    _rope[i] = curr + new Coordinate(-1, 0);
                } else if (diff.Equals(new Coordinate(0, 2)))
                {
                    _rope[i] = curr + new Coordinate(0, 1);
                } else if (diff.Equals(new Coordinate(1, 2)) || diff.Equals(new Coordinate(2, 1)) || diff.Equals(new Coordinate(2, 2)))
                {
                    _rope[i] = curr + new Coordinate(1, 1);
                } else if (diff.Equals(new Coordinate(1, -2)) || diff.Equals(new Coordinate(2, -1)) || diff.Equals(new Coordinate(2, -2)))
                {
                    _rope[i] = curr + new Coordinate(1, -1);
                } else if (diff.Equals(new Coordinate(-1, -2)) || diff.Equals(new Coordinate(-2, -1)) || diff.Equals(new Coordinate(-2, -2)))
                {
                    _rope[i] = curr + new Coordinate(-1, -1);
                } else if (diff.Equals(new Coordinate(-1, 2)) || diff.Equals(new Coordinate(-2, 1)) || diff.Equals(new Coordinate(-2, 2)))
                {
                    _rope[i] = curr + new Coordinate(-1, 1);
                }

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
    }
}