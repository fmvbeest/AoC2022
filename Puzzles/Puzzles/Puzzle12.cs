using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle12 : PuzzleBase<string[], int, int>
{
    protected override string Filename => "Input/puzzle-input-12";
    protected override string PuzzleTitle => "--- Day 12: Hill Climbing Algorithm ---";

    public override int PartOne(string[] input)
    {
        var numRows = input.Length;
        var numCols = input[0].Length;

        Node start = null;
        
        var grid = new Node[numRows][];
        for (var i = 0; i < numRows; i++)
        {
            var row = new List<Node>();
            for (var j = 0; j < numCols; j++)
            {
                var c = input[i][j];
                var isTop = c == 'E';
                var isStart = c == 'S';
                char offset = 'a';
                var node = new Node(i, j, isTop ? 'z'-offset : isStart ? 'a'-offset : c-offset, isTop); 
                row.Add(node);
                if (isStart)
                {
                    start = node;
                }
            }

            grid[i] = row.ToArray();
        }

        var queue = new Queue<Coordinate>();
        queue.Enqueue(start.Pos);

        var steps = -1;
        var reachedDestination = false;

        var visited = new HashSet<string>();
        
        
        while (queue.Count > 0 && !reachedDestination)
        {
            steps++;
            var nodes = queue.ToList();
            // Console.Write("");
            // foreach (var node in nodes)
            // {
            //     Console.Write(node);
            // }
            // Console.WriteLine();
            queue.Clear();
            foreach (var pos in nodes)
            {
                var node = NodeAt(pos, grid); 
                if (node.IsTop)
                {
                    reachedDestination = true;
                    break;
                }

                if (visited.Contains(node.ToString()))
                {
                    continue;
                }
                
                visited.Add(node.ToString());
                var neighbours = Neighbours(node).Where(x => InRange(x, grid));
                foreach (var neighbour in neighbours)
                {
                    var nnode = NodeAt(neighbour, grid);

                    if (!visited.Contains(nnode.ToString()) && nnode.Height <= node.Height + 1 )
                    {
                        queue.Enqueue(neighbour);    
                    }
                }
            }
            
        }
        
        Console.WriteLine($"Reached top: {reachedDestination}");
        return steps;
    }

    public override int PartTwo(string[] input)
    {
        var numRows = input.Length;
        var numCols = input[0].Length;

        var start = new List<Node>();

        var grid = new Node[numRows][];
        for (var i = 0; i < numRows; i++)
        {
            var row = new List<Node>();
            for (var j = 0; j < numCols; j++)
            {
                var c = input[i][j];
                var isTop = c == 'E';
                var isStart = c is 'S' or 'a';
                char offset = 'a';
                var node = new Node(i, j, isTop ? 'z'-offset : isStart ? 'a'-offset : c-offset, isTop); 
                row.Add(node);
                if (isStart)
                {
                    start.Add(node);
                }
            }

            grid[i] = row.ToArray();
        }

        var queue = new Queue<Coordinate>();
        foreach (var node in start)
        {
            queue.Enqueue(node.Pos);            
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
                var node = NodeAt(pos, grid); 
                if (node.IsTop)
                {
                    reachedDestination = true;
                    break;
                }

                if (visited.Contains(node.ToString()))
                {
                    continue;
                }
                
                visited.Add(node.ToString());
                var neighbours = Neighbours(node).Where(x => InRange(x, grid));
                foreach (var neighbour in neighbours)
                {
                    var nnode = NodeAt(neighbour, grid);

                    if (!visited.Contains(nnode.ToString()) && nnode.Height <= node.Height + 1 )
                    {
                        queue.Enqueue(neighbour);    
                    }
                }
            }
            
        }
        
        Console.WriteLine($"Reached top: {reachedDestination}");
        return steps;
    }
    
    public override string[] Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().ToArray();
    }
    
    public class Node
    {
        public Coordinate Pos;

        public int Height;

        public bool IsTop;

        public Node(int x, int y, int height, bool isTop = false)
        {
            Pos = new Coordinate(x, y);
            Height = height;
            IsTop = isTop;
        }

        public override string ToString()
        {
            return Pos.ToString();
        }
    }

    private IEnumerable<Coordinate> Neighbours(Coordinate node, int part = 1)
    {
        return NonDiagonalNeighbours(node);
    }
    
    private IEnumerable<Coordinate> Neighbours(Node node, int part = 1)
    {
        return NonDiagonalNeighbours(node.Pos);
    }

    private IEnumerable<Coordinate> NonDiagonalNeighbours(Coordinate node)
    {
        return new[]
        {
            new Coordinate(node.X - 1, node.Y), new Coordinate(node.X + 1, node.Y), new Coordinate(node.X, node.Y - 1),
            new Coordinate(node.X, node.Y + 1)
        };
    }

    private Node NodeAt(Coordinate pos, Node[][] grid)
    {
        return grid[pos.X][pos.Y];
    }

    private static bool InRange(Coordinate pos,  Node[][] grid)
    {
        return pos.X >= 0 && pos.Y >= 0 && pos.X < grid.Length && pos.Y < grid[0].Length;
    }
}