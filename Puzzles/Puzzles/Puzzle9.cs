using AoC2022.Util;
using Directory = AoC2022.Util.Directory;
using File = AoC2022.Util.File;

namespace AoC2022.Puzzles;

public class Puzzle9 : PuzzleBase<int, IEnumerable<(char, int)>>
{
    protected override string Filename => "Input/puzzle-input-09";
    protected override string PuzzleTitle => "--- Day 9: Rope Bridge ---";

    public override int PartOne(IEnumerable<(char, int)> input)
    {
        var head = new Coordinate(0, 0);
        var tail = new Coordinate(0, 0);
        var visited = new List<Coordinate> { tail };

        Console.WriteLine($"{head} {tail}");
        
        foreach (var (direction, count) in input)
        {
            for (var i = 0; i < count; i++)
            {
                switch (direction)
                {
                    case 'R' : head = MoveRight(head);
                        if (head.X - tail.X > 1)
                        {
                            tail = MoveLeft(head);
                            visited.Add(tail);
                        }
                        break;
                    case 'U' : head = MoveUp(head);
                        if (head.Y - tail.Y > 1)
                        {
                            tail = MoveDown(head);
                            visited.Add(tail);
                        }
                        break;
                    case 'L' : head = MoveLeft(head);
                        if (head.X - tail.X < -1)
                        {
                            tail = MoveRight(head);
                            visited.Add(tail);
                        }
                        break;
                    case 'D' : head = MoveDown(head);
                        if (head.Y - tail.Y < -1)
                        {
                            tail = MoveUp(head);
                            visited.Add(tail);
                        }
                        break;
                }
                Console.WriteLine($"{head} {tail}");
            }
            
            
        }

        Console.WriteLine("-----");
        foreach (var pos in visited)
        {
            Console.WriteLine(pos);
        }
        
        return visited.Distinct().Count();
    }

    public override int PartTwo(IEnumerable<(char, int)> input)
    {
        return 0;
    }
    
    public override IEnumerable<(char, int)> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetInput().Select(line => line.Split(' ')).Select(s => (s[0][0], int.Parse(s[1]))).ToList();
    }

    private static Coordinate MoveRight(Coordinate pos)
    {
        return new Coordinate(pos.X+1, pos.Y);
    }
    
    private static Coordinate MoveUp(Coordinate pos)
    {
        return new Coordinate(pos.X, pos.Y+1);
    }
    
    private static Coordinate MoveLeft(Coordinate pos)
    {
        return new Coordinate(pos.X-1, pos.Y);
    }
    
    private static Coordinate MoveDown(Coordinate pos)
    {
        return new Coordinate(pos.X, pos.Y-1);
    }
    
    private class Coordinate : IEquatable<Coordinate>
    {
        private readonly (int, int) _pos;

        public Coordinate(int x, int y)
        {
            _pos = (x, y);
        }
        
        public int X => _pos.Item1;

        public int Y => _pos.Item2;

        public bool Equals(Coordinate? other)
        {
            if (other == null)
            {
                return false;
            }

            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Coordinate);
        }

        public override int GetHashCode()
        {
            return _pos.GetHashCode();
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}