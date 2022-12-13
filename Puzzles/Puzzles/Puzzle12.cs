using System.Data;
using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle12 : PuzzleBase<(int[][] grid, List<Coordinate> startPositions, Coordinate top), int, int>
{
    protected override string Filename => "Input/puzzle-input-12";
    protected override string PuzzleTitle => "--- Day 12: Hill Climbing Algorithm ---";

    public override int PartOne((int[][], List<Coordinate>, Coordinate) input)
    {
        var (steps, _) = Climb(input);
        return steps;
    }

    public override int PartTwo((int[][] grid, List<Coordinate> startPositions, Coordinate top) input)
    {
        var (steps, _) = Climb(input);
        return steps;
    }
    
    public override (int[][] grid, List<Coordinate> startPositions, Coordinate top) Preprocess(IPuzzleInput input, int part = 1)
    {
        return ParseGrid(input.GetAllLines().ToArray(), part == 1 ? new[] { 'S' } : new[] { 'S', 'a' });
    }

    private (int[][] grid, List<Coordinate> startPositions, Coordinate top) ParseGrid(string[] input, char[] startSymbols)
    {
        var numRows = input.Length;
        var numCols = input[0].Length;

        var start = new List<Coordinate>();
        Coordinate top = null; 
        
        var grid = new int[numRows][];
        for (var i = 0; i < numRows; i++)
        {
            grid[i] = new int[numCols];
            for (var j = 0; j < numCols; j++)
            {
                const char offset = 'a';
                var c = input[i][j];
                if (c == 'E')
                {
                    top = new Coordinate(i, j);
                    c = 'z';
                }
                if (startSymbols.Contains(c))
                {
                    start.Add(new Coordinate(i, j));
                    c = 'a';
                }
                grid[i][j] = c - offset;
            }
        }

        return (grid, start, top);
    }

    private static int Height(Coordinate pos, int[][] grid)
    {
        return grid[pos.X][pos.Y];
    }

    private static IEnumerable<Coordinate> Neighbours(Coordinate node)
    {
        return new[]
        {
            new Coordinate(node.X - 1, node.Y), new Coordinate(node.X + 1, node.Y), new Coordinate(node.X, node.Y - 1),
            new Coordinate(node.X, node.Y + 1)
        };
    }

    private static bool InRange(Coordinate pos,  int[][] grid)
    {
        return pos.X >= 0 && pos.Y >= 0 && pos.X < grid.Length && pos.Y < grid[0].Length;
    }

    private static (int, bool) Climb((int[][], List<Coordinate>, Coordinate) input)
    {
        var (grid, startPositions, top) = input;
        
        var queue = new Queue<Coordinate>();
        foreach (var pos in startPositions)
        {
            queue.Enqueue(pos);
        }

        var steps = -1;
        var reachedDestination = false;

        var visited = new HashSet<string>();
        
        
        while (queue.Count > 0 && !reachedDestination)
        {
            steps++;
            var nodes = queue.ToList();
            queue.Clear();
            foreach (var pos in nodes)
            {
                if (pos.Equals(top))
                {
                    reachedDestination = true;
                    break;
                }

                if (visited.Contains(pos.ToString()))
                {
                    continue;
                }
                
                visited.Add(pos.ToString());
                var neighbours = Neighbours(pos).Where(x => InRange(x, grid));
                foreach (var neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour.ToString()) && Height(neighbour, grid) <= Height(pos, grid) + 1 )
                    {
                        queue.Enqueue(neighbour);    
                    }
                }
            }
            
        }

        return (steps, reachedDestination);
    }
}